using Fillwords.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fillwords.Services
{
    public class LevelLoader : ILevelLoader
    {
        private const string LEVELS_FOLDER = "Levels";
        private const string LEVEL_FILE_PREFIX = "level";
        public LevelLoader()
        {
            if (!Directory.Exists(LEVELS_FOLDER))
            {
                Directory.CreateDirectory(LEVELS_FOLDER);
                ExtractLevelsFromResources();
            }
            else
            {
                EnsureLevelsExist();
            }
        }

        private void ExtractLevelsFromResources()
        {
            try
            {
                var levels = new Dictionary<string, string>
        {
            { "level1.txt", Properties.Resources.level1 },
            { "level2.txt", Properties.Resources.level2 },
            { "level3.txt", Properties.Resources.level3 },
            { "level4.txt", Properties.Resources.level4 },
            { "level5.txt", Properties.Resources.level5 },
            { "level6.txt", Properties.Resources.level6 },
            { "level7.txt", Properties.Resources.level7 },
            { "level8.txt", Properties.Resources.level8 },
            { "level9.txt", Properties.Resources.level9 },
            { "level10.txt", Properties.Resources.level10 },
        };
                foreach (var level in levels)
                {
                    string filePath = Path.Combine(LEVELS_FOLDER, level.Key);
                    File.WriteAllText(filePath, level.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка извлечения уровней: {ex.Message}");
            }
        }
        private void EnsureLevelsExist()
        {
            for (int i = 1; i <= 10; i++)
            {
                string levelPath = Path.Combine(LEVELS_FOLDER, $"level{i}.txt");
                if (!File.Exists(levelPath))
                {
                    ExtractMissingLevel(i);
                }
            }
        }
        private void ExtractMissingLevel(int levelNumber)
        {
            try
            {
                string resourceName = $"level{levelNumber}";
                var resourceValue = Properties.Resources.ResourceManager.GetString(resourceName);
                if (!string.IsNullOrEmpty(resourceValue))
                {
                    string filePath = Path.Combine(LEVELS_FOLDER, $"level{levelNumber}.txt");
                    File.WriteAllText(filePath, resourceValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка восстановления уровня {levelNumber}: {ex.Message}");
            }
        }
        public Level LoadLevel(int levelNumber)
        {
            if (levelNumber < 1 || levelNumber > 10)
                throw new ArgumentException("Уровень должен быть от 1 до 10");
            string filePath = GetLevelFilePath(levelNumber);
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл уровня {levelNumber} не найден: {filePath}");
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return ParseLevelFile(lines, levelNumber);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки уровня {levelNumber}: {ex.Message}");
            }
        }
        public List<Level> LoadAllLevels()
        {
            var levels = new List<Level>();
            int levelNumber = 1;
            var failedLevels = new List<string>(); 
            while (LevelExists(levelNumber))
            {
                try
                {
                    levels.Add(LoadLevel(levelNumber));
                }
                catch (Exception ex)
                {
                    string error = $"Уровень {levelNumber}: {ex.Message}";
                    failedLevels.Add(error);
                }
                levelNumber++;
            }
            if (failedLevels.Count > 0)
            {
                string errorMessage = "Не удалось загрузить следующие уровни:\n\n" +
                                     string.Join("\n", failedLevels) +
                                     $"\n\nУспешно загружено: {levels.Count} уровней";

                MessageBox.Show(errorMessage,
                              "Ошибки загрузки уровней",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
            if (levels.Count == 0)
            {
                MessageBox.Show("Не удалось загрузить ни одного уровня",
                              "Критическая ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return new List<Level>();
            }
            return levels;
        }
        public bool LevelExists(int levelNumber)
        {
            return File.Exists(GetLevelFilePath(levelNumber));
        }
        public int GetTotalLevelsCount()
        {
            int count = 0;
            while (LevelExists(count + 1))
                count++;
            return count;
        }
        private string GetLevelFilePath(int levelNumber)
        {
            return Path.Combine(LEVELS_FOLDER, $"{LEVEL_FILE_PREFIX}{levelNumber}.txt");
        }
        private Level ParseLevelFile(string[] lines, int levelNumber)
        {
            if (lines.Length < 2)
                throw new Exception("Файл уровня должен содержать как минимум 2 строки");
            string[] words = lines[0].Split(',');
            var level = new Level
            {
                LevelNumber = levelNumber,
                WordsToFind = words.Select(w => new Fillwords.Models.Word(w.Trim().ToUpper())).ToList()
            };
            int gridSize = lines.Length - 1;
            level.GridSize = gridSize;
            level.Grid = new char[gridSize, gridSize];
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim().ToUpper();
                if (line.Length != gridSize)
                    throw new Exception($"Строка {i} имеет неверную длину. Ожидается: {gridSize}, получено: {line.Length}");
                for (int j = 0; j < gridSize; j++)
                {
                    level.Grid[i - 1, j] = line[j];
                }
            }
            return level;
        }
    }
}