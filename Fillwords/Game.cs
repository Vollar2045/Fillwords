using Fillwords.Controls;
using Fillwords.Models;
using Fillwords.Services;
using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using WMPLib;

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
        private System.Windows.Forms.Timer _hintCooldownTimer;
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
            _hintCooldownTimer = new System.Windows.Forms.Timer();
            _hintCooldownTimer.Interval = 2000;
            _hintCooldownTimer.Tick += (s, e) =>
            {
                _hintCooldownTimer.Stop();
                SetHintButtonEnabled(_hintService.GetHintsAvailable(_currentLevel) > 0);
                UpdateHintsInfo();
            };
            this.KeyPreview = true;
            LoadLevel(_levelNumber);
        }        
        private void LoadLevel(int levelNumber)
        {
            try
            {
                Fillwords.Models.Word.ResetUsedColors();
                _currentLevel = _levelLoader.LoadLevel(levelNumber);
                _hintService.ResetHintsForLevel(_currentLevel);
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
            bool canUseHint = hintsAvailable > 0 && _currentLevel.GetRemainingWords().Any();
            if (!_hintCooldownTimer.Enabled) 
            {
                SetHintButtonEnabled(canUseHint);
            }
        }
        private void btnHint_Click(object sender, EventArgs e)
        {
            if (_hintService.CanUseHint(_currentLevel) && !_hintCooldownTimer.Enabled)
            {
                var word = _hintService.GetRandomUnfoundWord(_currentLevel);
                if (word != null)
                {
                    var hintCell = FindFirstLetterCell(word.Text);
                    if (hintCell != null)
                    {
                        _hintService.UseHint(_currentLevel, word);
                        SetHintButtonEnabled(false);
                        _hintCooldownTimer.Start();
                        _wordGrid.HighlightHint(hintCell);
                        UpdateHintsInfo();
                    }
                }
            }
            else if (_hintService.GetHintsAvailable(_currentLevel) > 0)
            {
                MessageBox.Show(
                    "Все оставшиеся слова уже были подсказаны!\nНайдите их без дополнительных подсказок.",
                    "Подсказки закончились",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void SetHintButtonEnabled(bool enabled)
        {
            btnHint.Enabled = enabled;
            if (enabled)
            {
                btnHint.BackColor = Color.YellowGreen;
                btnHint.ForeColor = Color.Black;
            }
            else
            {
                btnHint.BackColor = Color.Yellow;
                btnHint.ForeColor = Color.DarkGray;
            }
        }
        private Cell FindFirstLetterCell(string wordText)
        {
            if (string.IsNullOrEmpty(wordText)) return null;
            char firstLetter = wordText[0];
            var possibleStartCells = new List<Cell>();
            for (int row = 0; row < _currentLevel.GridSize; row++)
            {
                for (int col = 0; col < _currentLevel.GridSize; col++)
                {
                    var cell = _wordGrid.GetCellAtPosition(row, col);
                    if (cell != null && cell.Letter == firstLetter && !cell.IsFound)
                    {
                        possibleStartCells.Add(cell);
                    }
                }
            }
            foreach (var cell in possibleStartCells)
            {
                if (CanWordStartFromCell(wordText, cell.Row, cell.Column))
                {
                    return cell;
                }
            }
            return possibleStartCells.FirstOrDefault();
        }
        private bool CanWordStartFromCell(string wordText, int startRow, int startCol)
        {
            return DFS(wordText, 0, startRow, startCol, new bool[_currentLevel.GridSize, _currentLevel.GridSize]);
        }
        private bool DFS(string word, int index, int row, int col, bool[,] visited)
        {
            if (index >= word.Length) return true;
            if (row < 0 || row >= _currentLevel.GridSize || col < 0 || col >= _currentLevel.GridSize)
                return false;
            if (visited[row, col]) return false;
            var cell = _wordGrid.GetCellAtPosition(row, col);
            if (cell == null || cell.Letter != word[index] || cell.IsFound)
                return false;
            visited[row, col] = true;
            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int newRow = row + dr[i];
                int newCol = col + dc[i];
                if (DFS(word, index + 1, newRow, newCol, visited))
                {
                    return true;
                }
            }
            visited[row, col] = false;
            return false;
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
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnMenu_Click(null, null);
                e.Handled = true;
            }
        }       
    }
}