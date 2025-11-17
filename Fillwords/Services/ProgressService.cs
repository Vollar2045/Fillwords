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
                if (!ProgressExists()) return 1;
                string content = File.ReadAllText(PROGRESS_FILE).Trim();
                if (int.TryParse(content, out int level) && level >= 1 && level <= 10)
                {
                    return level;
                }
                return 1;
            }
            catch
            {
                return 1;
            }
        }
        public void SaveCurrentLevel(int level)
        {
            try
            {
                if (level < 1)
                    throw new ArgumentException("Уровень не может быть меньше 1");
                int currentMaxLevel = GetCurrentLevel();
                if (level > currentMaxLevel)
                {
                    File.WriteAllText(PROGRESS_FILE, level.ToString());
                }
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
        public void CompleteLevel(int completedLevel)
        {
            int nextLevel = completedLevel + 1;
            int currentMaxLevel = GetCurrentLevel();
            if (nextLevel > currentMaxLevel && nextLevel <= 10)
            {
                SaveCurrentLevel(nextLevel);
            }
        }
    }
}