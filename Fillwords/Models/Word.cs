using System.Collections.Generic;
using System.Linq;

namespace FIllwords.Models
{
    public class Word
    {
        public string Text { get; set; }
        public List<Cell> Cells { get; set; }
        public bool IsFound { get; set; }

        public Word(string text)
        {
            Text = text.ToUpper();
            Cells = new List<Cell>();
        }

        // Проверяет, соответствует ли последовательность ячеек этому слову
        public bool MatchesCells(List<Cell> selectedCells)
        {
            if (selectedCells.Count != Text.Length)
                return false;

            string selectedWord = new string(selectedCells.Select(c => c.Letter).ToArray());
            return selectedWord == Text;
        }

        // Добавляет ячейки, составляющие слово (для проверки пересечений)
        public void AddCell(Cell cell)
        {
            Cells.Add(cell);
        }
    }
}