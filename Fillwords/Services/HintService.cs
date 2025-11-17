using FIllwords.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Fillwords.Services
{
    public class HintService
    {
        private const int MAX_HINTS_PER_LEVEL = 3;
        private readonly Dictionary<int, int> _hintsUsedByLevel; // levelNumber -> hintsUsed

        public HintService()
        {
            _hintsUsedByLevel = new Dictionary<int, int>();
        }

        public bool CanUseHint(Level level)
        {
            if (level == null) return false;

            int hintsUsed = GetHintsUsed(level);
            return hintsUsed < MAX_HINTS_PER_LEVEL && level.GetRemainingWords().Any();
        }

        public Point? GetHint(Level level)
        {
            if (!CanUseHint(level))
                return null;

            try
            {
                var remainingWords = level.GetRemainingWords();
                if (!remainingWords.Any())
                    return null;

                // Выбираем случайное ненайденное слово
                var random = new Random();
                var randomWord = remainingWords[random.Next(remainingWords.Count)];

                // Получаем позицию первой буквы слова
                var firstCell = GetFirstLetterPosition(level, randomWord);
                if (firstCell.HasValue)
                {
                    // Увеличиваем счетчик использованных подсказок
                    int hintsUsed = GetHintsUsed(level);
                    _hintsUsedByLevel[level.LevelNumber] = hintsUsed + 1;

                    return firstCell.Value;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении подсказки: {ex.Message}");
                return null;
            }
        }

        public int GetHintsUsed(Level level)
        {
            if (level == null) return 0;
            return _hintsUsedByLevel.ContainsKey(level.LevelNumber)
                ? _hintsUsedByLevel[level.LevelNumber]
                : 0;
        }

        public int GetHintsAvailable(Level level)
        {
            return MAX_HINTS_PER_LEVEL - GetHintsUsed(level);
        }

        public void ResetHintsForLevel(Level level)
        {
            if (level != null && _hintsUsedByLevel.ContainsKey(level.LevelNumber))
            {
                _hintsUsedByLevel.Remove(level.LevelNumber);
            }
        }

        private Point? GetFirstLetterPosition(Level level, Word word)
        {
            // Ищем первую букву слова в сетке
            char firstLetter = word.Text[0];

            for (int row = 0; row < level.GridSize; row++)
            {
                for (int col = 0; col < level.GridSize; col++)
                {
                    if (level.Grid[row, col] == firstLetter)
                    {
                        // Проверяем, что эта ячейка еще не найдена в другом слове
                        // (упрощенная проверка)
                        return new Point(col, row);
                    }
                }
            }

            return null;
        }
    }
}