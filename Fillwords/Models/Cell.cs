using System.Drawing;

namespace Fillwords.Models
{
    public class Cell
    {
        public char Letter { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsSelected { get; set; }
        public bool IsFound { get; set; }
        public Color BackgroundColor { get; set; } = Color.White;
        public Color TextColor { get; set; } = Color.Black;
        public Cell(char letter, int row, int column)
        {
            Letter = letter;
            Row = row;
            Column = column;
        }
        public void Reset()
        {
            IsSelected = false;
            IsFound = false;
            BackgroundColor = Color.White; 
            TextColor = Color.Black;
        }
        public static bool AreCellsAdjacent(Cell cell1, Cell cell2)
        {
            int rowDiff = Math.Abs(cell1.Row - cell2.Row);
            int colDiff = Math.Abs(cell1.Column - cell2.Column);

            return (rowDiff == 1 && colDiff == 0) ||
                   (rowDiff == 0 && colDiff == 1);
        }
    }
}