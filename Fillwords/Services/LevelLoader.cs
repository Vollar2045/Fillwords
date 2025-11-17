using FIllwords.Models;
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
            // Создаем папку для уровней, если ее нет
            if (!Directory.Exists(LEVELS_FOLDER))
            {
                Directory.CreateDirectory(LEVELS_FOLDER);
                CreateSampleLevels(); // Создаем примеры уровней для тестирования
            }
        }

        public Level LoadLevel(int levelNumber)
        {
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

            while (LevelExists(levelNumber))
            {
                try
                {
                    levels.Add(LoadLevel(levelNumber));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не удалось загрузить уровень {levelNumber}: {ex.Message}");
                }
                levelNumber++;
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

            // Первая строка - слова для поиска
            string[] words = lines[0].Split(',');
            var level = new Level
            {
                LevelNumber = levelNumber,
                WordsToFind = words.Select(w => new Word(w.Trim().ToUpper())).ToList()
            };

            // Определяем размер сетки
            int gridSize = lines.Length - 1;
            level.GridSize = gridSize;
            level.Grid = new char[gridSize, gridSize];

            // Заполняем сетку из оставшихся строк
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

        // Метод для создания примеров уровней (для тестирования)
        private void CreateSampleLevels()
        {
            // Уровень 1
            File.WriteAllText(GetLevelFilePath(1),
                "КОТ,ТОК,КОМ\n" +
                "КТМ\n" +
                "ООА\n" +
                "ТКК");

            // Уровень 2
            File.WriteAllText(GetLevelFilePath(2),
                "МАМА,ПАПА,СЫН,ДОЧЬ\n" +
                "МПСД\n" +
                "ААЫО\n" +
                "МПНЧ\n" +
                "ААЬЬ");

            // Уровень 3
            File.WriteAllText(GetLevelFilePath(3),
                "ПРОГРАММА,КОД,ТЕСТ,БАГ\n" +
                "ПКБТ\n" +
                "РОАА\n" +
                "ОГГГ\n" +
                "ГДЕЕ\n" +
                "РМАС\n" +
                "ААТТ\n" +
                "ММББ");
        }
    }
}