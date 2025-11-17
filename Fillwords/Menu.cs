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

namespace Fillwords
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
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
            int maxLevel = progressService.GetCurrentLevel();
            for (int i = 1; i <= maxLevel; i++)
            {
                var btn = new Button
                {
                    Text = $"Уровень {i}",
                    Size = new Size(100, 50),
                    Tag = i
                };
                btn.Click += (s, e) => StartLevel((int)btn.Tag);
                flowLevels.Controls.Add(btn);
            }
        }
        private void StartLevel(int levelNumber)
        {
            var gameForm = new Game(levelNumber); 
            gameForm.FormClosed += (s, args) => this.Show();
            gameForm.Show();
            this.Hide();
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
    }
}
