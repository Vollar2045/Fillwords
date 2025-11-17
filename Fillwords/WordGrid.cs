using Fillwords.Models;
using Fillwords.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Fillwords.Controls
{
    public class WordGrid : Panel
    {
        private Level _currentLevel;
        private Cell[,] _cells;
        private List<Cell> _selectedCells;
        private bool _isSelecting;
        private readonly Color _normalColor = Color.White;
        private readonly Color _selectedColor = Color.LightBlue;
        private readonly Color _foundColor = Color.LightGreen;
        private readonly Color _hintColor = Color.Yellow;
        private readonly Color _errorColor = Color.LightPink;
        private const int CELL_SIZE = 100;
        private const int CELL_MARGIN = 2;
        private const int GRID_PADDING = 0;
        private readonly Font _cellFont = new Font("Arial", 14, FontStyle.Bold);
        public event Action<List<Cell>> OnWordSelected;
        public event Action<Cell> OnCellClicked;

        public WordGrid()
        {
            _selectedCells = new List<Cell>();
            this.DoubleBuffered = true; 
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void InitializeLevel(Level level)
        {
            _currentLevel = level;
            _selectedCells.Clear();
            _isSelecting = false;

            CreateCells();
            SetupGridLayout();
            Invalidate();
        }
        private void CreateCells()
        {
            if (_currentLevel?.Grid == null) return;

            int gridSize = _currentLevel.GridSize;
            _cells = new Cell[gridSize, gridSize];

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    _cells[row, col] = new Cell(_currentLevel.Grid[row, col], row, col);
                }
            }
        }
        private void SetupGridLayout()
        {
            if (_currentLevel?.Grid == null) return;

            int gridSize = _currentLevel.GridSize;
            int totalSize = gridSize * (CELL_SIZE + CELL_MARGIN) + GRID_PADDING * 2;

            this.Size = new Size(totalSize, totalSize);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_cells == null) return;

            var g = e.Graphics;
            g.Clear(this.BackColor);

            for (int row = 0; row < _currentLevel.GridSize; row++)
            {
                for (int col = 0; col < _currentLevel.GridSize; col++)
                {
                    DrawCell(g, _cells[row, col], row, col);
                }
            }
        }

        private void DrawCell(Graphics g, Cell cell, int row, int col)
        {
            int x = GRID_PADDING + col * (CELL_SIZE + CELL_MARGIN);
            int y = GRID_PADDING + row * (CELL_SIZE + CELL_MARGIN);
            var rect = new Rectangle(x, y, CELL_SIZE, CELL_SIZE);
            Color bgColor = GetCellColor(cell);
            using (var brush = new SolidBrush(bgColor))
            {
                g.FillRectangle(brush, rect);
            }
            g.DrawRectangle(Pens.Black, rect);
            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(cell.Letter.ToString(), _cellFont, Brushes.Black, rect, format);
        }

        private Color GetCellColor(Cell cell)
        {
            if (cell.IsFound)
                return cell.BackgroundColor;
            if (_selectedCells.Contains(cell))
                return _selectedColor;
            return _normalColor;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            var cell = GetCellAtPoint(e.Location);
            if (cell != null)
            {
                _isSelecting = true;
                StartSelection(cell);
                OnCellClicked?.Invoke(cell);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_isSelecting)
            {
                var cell = GetCellAtPoint(e.Location);
                if (cell != null && CanAddToSelection(cell))
                {
                    AddToSelection(cell);
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (_isSelecting)
            {
                _isSelecting = false;
                CompleteSelection();
            }
        }

        private Cell GetCellAtPoint(Point point)
        {
            if (_cells == null) return null;

            int col = (point.X - GRID_PADDING) / (CELL_SIZE + CELL_MARGIN);
            int row = (point.Y - GRID_PADDING) / (CELL_SIZE + CELL_MARGIN);

            if (row >= 0 && row < _currentLevel.GridSize &&
                col >= 0 && col < _currentLevel.GridSize)
            {
                return _cells[row, col];
            }

            return null;
        }

        private void StartSelection(Cell cell)
        {
            _selectedCells.Clear();
            _selectedCells.Add(cell);
            Invalidate();
        }

        private void AddToSelection(Cell cell)
        {
            if (!_selectedCells.Contains(cell))
            {
                _selectedCells.Add(cell);
                Invalidate();
            }
        }

        private bool CanAddToSelection(Cell newCell)
        {
            if (_selectedCells.Count == 0) return true;

            var lastCell = _selectedCells.Last();
            return Cell.AreCellsAdjacent(lastCell, newCell) &&
                   !_selectedCells.Contains(newCell);
        }

        private void CompleteSelection()
        {
            if (_selectedCells.Count > 0)
            {
                OnWordSelected?.Invoke(_selectedCells);
            }
        }
        public void HighlightHint(Point position)
        {
            if (position.X >= 0 && position.X < _currentLevel.GridSize &&
                position.Y >= 0 && position.Y < _currentLevel.GridSize)
            {
                var cell = _cells[position.Y, position.X];
                cell.BackgroundColor = _hintColor;
                Invalidate();
                var timer = new System.Windows.Forms.Timer { Interval = 2000 };
                timer.Tick += (s, e) =>
                {
                    cell.BackgroundColor = _normalColor;
                    Invalidate();
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }
        public void HighlightWord(List<Cell> foundCells, Color color)
        {
            if (foundCells != null)
            {
                foreach (var cell in foundCells)
                {
                    cell.IsFound = true;
                    cell.BackgroundColor = color;
                }
                Invalidate();
            }
        }

        public void ClearSelection()
        {
            _selectedCells.Clear();
            Invalidate();
        }

        public void ResetGrid()
        {
            if (_cells != null)
            {
                foreach (var cell in _cells)
                {
                    cell.Reset();
                }
                _selectedCells.Clear();
                Invalidate();
            }
        }
    }
}