using System.Collections.Generic;
using Fillwords.Models;

namespace Fillwords.Models
{
    public class Level
    {
        public int LevelNumber { get; set; }
        public char[,] Grid { get; set; }
        public List<Word> WordsToFind { get; set; }
        public List<Word> FoundWords { get; set; }
        public int GridSize { get; set; }
        public Level()
        {
            WordsToFind = new List<Word>();
            FoundWords = new List<Word>();
        }
        public bool IsCompleted()
        {
            return FoundWords.Count >= WordsToFind.Count;
        }
        public void AddFoundWord(Word word)
        {
            if (!FoundWords.Contains(word))
            {
                FoundWords.Add(word);
                word.IsFound = true;
            }
        }
        public List<Word> GetRemainingWords()
        {
            return WordsToFind.FindAll(word => !word.IsFound);
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
    }
}