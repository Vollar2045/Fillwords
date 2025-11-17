using System;
using System.IO;

namespace Fillwords.Services
{
    public class ProgressService : IProgressService
    {
        private const string PROGRESS_FILE = "progress.txt";

        public int GetCurrentLevel()
        {
            try
            {
                if (!ProgressExists())
                {
                    return 1; // Начинаем с первого уровня
                }

                string content = File.ReadAllText(PROGRESS_FILE).Trim();

                if (int.TryParse(content, out int level) && level >= 1)
                {
                    return level;
                }

                // Если файл поврежден, возвращаем первый уровень
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки прогресса: {ex.Message}");
                return 1;
            }
        }

        public void SaveCurrentLevel(int level)
        {
            try
            {
                if (level < 1)
                    throw new ArgumentException("Уровень не может быть меньше 1");

                File.WriteAllText(PROGRESS_FILE, level.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения прогресса: {ex.Message}");
                throw;
            }
        }

        public void ResetProgress()
        {
            try
            {
                if (File.Exists(PROGRESS_FILE))
                {
                    File.Delete(PROGRESS_FILE);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сброса прогресса: {ex.Message}");
                throw;
            }
        }

        public bool ProgressExists()
        {
            return File.Exists(PROGRESS_FILE);
        }

        // Дополнительные методы для удобства
        public void CompleteLevel(int completedLevel)
        {
            int nextLevel = completedLevel + 1;
            SaveCurrentLevel(nextLevel);
        }

        public bool IsLevelUnlocked(int levelNumber)
        {
            int currentMaxLevel = GetCurrentLevel();
            return levelNumber <= currentMaxLevel;
        }

        public void UnlockLevel(int levelNumber)
        {
            if (levelNumber > GetCurrentLevel())
            {
                SaveCurrentLevel(levelNumber);
            }
        }
    }
}