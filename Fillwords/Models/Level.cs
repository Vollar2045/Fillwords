using System.Collections.Generic;

namespace FIllwords.Models
{
    public class Level
    {
        public int LevelNumber { get; set; }
        public char[,] Grid { get; set; }
        public List<Word> WordsToFind { get; set; }
        public List<Word> FoundWords { get; set; }
        public int GridSize { get; set; }
        public int HintsUsed { get; set; }
        public int HintsAvailable { get; set; } = 3;

        public Level()
        {
            WordsToFind = new List<Word>();
            FoundWords = new List<Word>();
        }

        public bool IsCompleted()
        {
            return FoundWords.Count >= WordsToFind.Count;
        }
        public bool IsValidWordSelection(List<Cell> selectedCells)
        {
            if (selectedCells == null || !selectedCells.Any())
                return false;

            string selectedWord = new string(selectedCells.Select(c => c.Letter).ToArray());
            return WordsToFind.Any(w => w.Text == selectedWord && !w.IsFound);
        }

        public Word GetWordFromSelection(List<Cell> selectedCells)
        {
            if (selectedCells == null || !selectedCells.Any())
                return null;

            string selectedWord = new string(selectedCells.Select(c => c.Letter).ToArray());
            return WordsToFind.FirstOrDefault(w => w.Text == selectedWord && !w.IsFound);
        }

        public void AddFoundWord(Word word)
        {
            if (!FoundWords.Contains(word))
            {
                FoundWords.Add(word);
                word.IsFound = true;

                // Помечаем ячейки как найденные
                foreach (var cell in word.Cells)
                {
                    cell.IsFound = true;
                    cell.BackgroundColor = Color.LightGreen; // Можно настроить цвета
                }
            }
        }

        public List<Word> GetRemainingWords()
        {
            return WordsToFind.FindAll(word => !word.IsFound);
        }
    }
}