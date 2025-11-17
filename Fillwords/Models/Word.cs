using Fillwords.Models;
using System.Drawing;

namespace Fillwords.Models
{
    public class Word
    {
        public string Text { get; set; }
        public bool IsFound { get; set; }
        public Color FoundColor { get; set; }

        // Статический список использованных цветов для уровня
        private static List<Color> _usedColors = new List<Color>();
        private static readonly Color[] _allColors = new Color[]
        {
        Color.LightGreen,      Color.LightBlue,         Color.LightYellow,
        Color.LightPink,       Color.LightCoral,        Color.LightSkyBlue,
        Color.Plum,            Color.Moccasin,          Color.PeachPuff,
        Color.LemonChiffon,    Color.Khaki,             Color.LightSalmon,
        Color.LightSteelBlue,  Color.Aquamarine,        Color.LightCyan,
        Color.Red,             Color.Lime,              Color.Blue,
        Color.Yellow,          Color.Magenta,           Color.Cyan,
        Color.Orange,          Color.Chartreuse,        Color.SpringGreen,
        Color.Aqua,            Color.Fuchsia,           Color.Gold,
        Color.Coral,           Color.Tomato,            Color.OrangeRed,
        Color.DodgerBlue,      Color.MediumSpringGreen, Color.DeepSkyBlue,
        Color.HotPink,         Color.MediumOrchid,      Color.LawnGreen
        };

        public Word(string text)
        {
            Text = text.ToUpper();
            FoundColor = GetUniqueColor();
        }

        private Color GetUniqueColor()
        {
            var availableColors = _allColors.Except(_usedColors).ToList();

            if (availableColors.Count == 0)
            {
                // Если все цвета использованы, очищаем список и начинаем заново
                _usedColors.Clear();
                availableColors = _allColors.ToList();
            }

            var random = new Random();
            var color = availableColors[random.Next(availableColors.Count)];
            _usedColors.Add(color);

            return color;
        }

        // Метод для сброса использованных цветов (вызывай при загрузке нового уровня)
        public static void ResetUsedColors()
        {
            _usedColors.Clear();
        }

        public bool MatchesSelection(string selectedWord)
        {
            return selectedWord == Text;
        }
    }
}