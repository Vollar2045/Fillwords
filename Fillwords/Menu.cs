using Fillwords.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Fillwords
{
    public partial class Menu : Form
    {
        private WindowsMediaPlayer mediaPlayer;
        private bool isMusicPlaying = false;
        private TrackBar volumeTrackBar;
        public Menu()
        {
            InitializeComponent();
            InitializeComponents();
            InitializeMusic();
            this.KeyPreview = true;            
        }
        private void InitializeComponents()
        {
            volumeTrackBar = new TrackBar()
            {
                Location = new Point(10, 50),
                Size = new Size(110, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Minimum = 0,
                Maximum = 100,
                Value = 5,
                BackColor = Color.YellowGreen,
                Cursor = Cursors.Hand,
                TabStop = false,
                TickStyle = TickStyle.None
            };
            volumeTrackBar.Scroll += VolumeTrackBar_Scroll;
            this.Controls.Add(volumeTrackBar);
            var volumeLabel = new Label()
            {
                Text = "Громкость",
                Location = new Point(0, 20),
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Font = new Font("Unispace", 16F, FontStyle.Bold | FontStyle.Italic),
                BackColor = Color.Transparent,
                ForeColor = Color.Purple,
                AutoSize = true
            };
            this.Controls.Add(volumeLabel);
        }
        private void InitializeMusic()
        {
            try
            {
                mediaPlayer = new WindowsMediaPlayer();
                string musicPath = System.IO.Path.Combine(
                    Application.StartupPath,
                    "music.mp3"
                );
                if (System.IO.File.Exists(musicPath))
                {
                    mediaPlayer.URL = musicPath;
                    mediaPlayer.settings.volume = 5;
                    mediaPlayer.settings.setMode("loop", true);
                    mediaPlayer.controls.play();
                }
                else
                {
                    MessageBox.Show($"Файл музыки не найден: {musicPath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации музыки: {ex.Message}");
            }
        }
        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            if (mediaPlayer != null)
            {
                mediaPlayer.settings.volume = volumeTrackBar.Value;
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            panelMain.Visible = false;
            panelLevels.Visible = true;
            CreateLevelButtons();
        }
        private void CreateLevelButtons()
        {
            flowLevels.Controls.Clear();
            var progressService = new ProgressService();
            int maxUnlockedLevel = progressService.GetCurrentLevel();
            for (int i = 1; i <= 10; i++)
            {
                var btn = new Button
                {
                    Text = $"Уровень {i}",
                    Size = new Size(300, 100),
                    Font = new Font("Unispace", 18F, FontStyle.Bold | FontStyle.Italic),
                    BackColor = Color.YellowGreen,
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    Tag = i,
                    Enabled = i <= maxUnlockedLevel
                };
                btn.FlatAppearance.BorderColor = Color.Purple;
                btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.MouseDownBackColor = Color.Purple;
                if (i > maxUnlockedLevel)
                {
                    btn.BackColor = Color.MistyRose;
                    btn.Text = $"Уровень {i}\n(заблокирован)";
                }
                btn.Click += (s, e) => StartLevel((int)btn.Tag);
                flowLevels.Controls.Add(btn);
            }
        }
        private void StartLevel(int levelNumber)
        {
            int currentLevel = levelNumber;
            int maxAttempts = 10;
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                try
                {
                    var gameForm = new Game(currentLevel)
                    {
                        Size = this.Size,
                        Location = this.Location,
                        WindowState = this.WindowState
                    };
                    gameForm.FormClosed += (s, args) =>
                    {
                        CreateLevelButtons();
                        this.Show();
                    };
                    gameForm.Show();
                    this.Hide();
                    return;
                }
                catch (Exception ex)
                {
                    currentLevel++;
                    if (attempt == maxAttempts - 1)
                    {
                        MessageBox.Show($"Не удалось запустить уровни с {levelNumber} по {currentLevel - 1}\n\n" +
                                       $"Последняя ошибка: {ex.Message}",
                                      "Ошибка запуска",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                  "Вы действительно хотите выйти из игры?",
                  "Подтверждение выхода",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            panelLevels.Visible = false;
            panelMain.Visible = true;
        }        
        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (panelLevels.Visible)
                {
                    btnBack_Click(null, null);
                }
                else
                {
                    btnExit_Click(null, null);
                }
                e.Handled = true;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mediaPlayer != null)
            {
                mediaPlayer.controls.stop();
                mediaPlayer.close();
            }
        }
    }
}
