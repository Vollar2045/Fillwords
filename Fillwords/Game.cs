using Fillwords.Controls;
using Fillwords.Services;
using Fillwords.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fillwords
{
    public partial class Game : Form
    {
        private int _levelNumber;
        private Level _currentLevel;
        private WordGrid _wordGrid;
        private LevelLoader _levelLoader;
        private ProgressService _progressService;
        private HintService _hintService;
        public Game()
        {
            InitializeComponent();
        }
        public Game(int levelNumber) : this()
        {
            _levelNumber = levelNumber;
            _levelLoader = new LevelLoader();
            _progressService = new ProgressService();
            _hintService = new HintService();
            LoadLevel(_levelNumber);
        }        
        private void LoadLevel(int levelNumber)
        {
            try
            {
                Fillwords.Models.Word.ResetUsedColors();
                _currentLevel = _levelLoader.LoadLevel(levelNumber);
                tableGrid.Controls.Clear();
                tableGrid.RowStyles.Clear();
                tableGrid.ColumnStyles.Clear();
                tableGrid.ColumnCount = _currentLevel.GridSize;
                tableGrid.RowCount = _currentLevel.GridSize;
                SetupGridSize();
                for (int i = 0; i < _currentLevel.GridSize; i++)
                {
                    tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / _currentLevel.GridSize));
                    tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / _currentLevel.GridSize));
                }
                _wordGrid = new WordGrid();
                _wordGrid.Dock = DockStyle.Fill;
                tableGrid.Controls.Add(_wordGrid, 0, 0);
                tableGrid.SetColumnSpan(_wordGrid, _currentLevel.GridSize);
                tableGrid.SetRowSpan(_wordGrid, _currentLevel.GridSize);
                _wordGrid.InitializeLevel(_currentLevel);
                _wordGrid.OnWordSelected += OnWordSelected;
                UpdateLevelInfo();
                UpdateHintsInfo();

                this.Text = $"Филворды - Уровень {_levelNumber}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки уровня: {ex.Message}", "Ошибка");
                this.Close();
            }
        }
        private void SetupGridSize()
        {
            if (_currentLevel == null) return;
            int gridSize = _currentLevel.GridSize;
            int cellSize = 100;
            int margin = 2;
            int borderWidth = tableGrid.Margin.Horizontal + tableGrid.Padding.Horizontal;
            int borderHeight = tableGrid.Margin.Vertical + tableGrid.Padding.Vertical;
            int cellPadding = tableGrid.CellBorderStyle == TableLayoutPanelCellBorderStyle.Single ? 1 : 0;
            int totalSize = gridSize * (cellSize + margin + cellPadding) + borderWidth;
            tableGrid.Size = new Size(totalSize, totalSize);
            tableGrid.Location = new Point(
                (this.ClientSize.Width - totalSize) / 2,
                tableGrid.Location.Y
            );
        }
        private void OnWordSelected(System.Collections.Generic.List<Cell> selectedCells)
        {
            if (_currentLevel.IsValidWordSelection(selectedCells))
            {
                Fillwords.Models.Word word = _currentLevel.GetWordFromSelection(selectedCells);
                if (word != null)
                {
                    _currentLevel.AddFoundWord(word);
                    _wordGrid.HighlightWord(selectedCells, word.FoundColor);

                    if (_currentLevel.IsCompleted())
                    {
                        OnLevelCompleted();
                    }
                }
            }
            else
            {
                _wordGrid.ClearSelection();
            }
        }
        private void OnLevelCompleted()
        {
            _progressService.CompleteLevel(_levelNumber);

            // ПРОВЕРЯЕМ ДО увеличения уровня
            bool isLastLevel = _levelNumber >= 10;

            if (isLastLevel)
            {
                MessageBox.Show(
                    "УРА! Вы прошли ВСЕ уровни игры!\nСпасибо за игру!",
                    "Полная победа!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                var result = MessageBox.Show(
                    $"Уровень {_levelNumber} пройден!\nПерейти к уровню {_levelNumber + 1}?",
                    "Поздравляем!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _levelNumber++;
                    ResetGameForNewLevel();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void ResetGameForNewLevel()
        {
            tableGrid.Controls.Clear();
            _wordGrid = null;
            LoadLevel(_levelNumber);
        }

        private void UpdateLevelInfo()
        {
            lblLevel.Text = $"Уровень: {_levelNumber}";
        }

        private void UpdateHintsInfo()
        {
            int hintsAvailable = _hintService.GetHintsAvailable(_currentLevel);
            lblHints.Text = $"Подсказки: {hintsAvailable}/3";
            hintButton.Enabled = hintsAvailable > 0 && _currentLevel.GetRemainingWords().Any();
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            if (_hintService.CanUseHint(_currentLevel))
            {
                var hintPosition = _hintService.GetHint(_currentLevel);
                if (hintPosition.HasValue)
                {
                    _wordGrid.HighlightHint(hintPosition.Value);
                    UpdateHintsInfo();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Начать уровень заново?", "Подтверждение",
                                       MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                tableGrid.Controls.Clear();
                LoadLevel(_levelNumber);
            }
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Вернуться в главное меню?\nВесь прогресс текущего уровня будет потерян.",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}