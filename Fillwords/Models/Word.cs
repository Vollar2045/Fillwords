using Fillwords.Models;
using System.Drawing;

namespace Fillwords.Models
{
    public class Word
    {
        public string Text { get; set; }
        public bool IsFound { get; set; }
        public Color FoundColor { get; set; }

        public Word(string text)
        {
            Text = text.ToUpper();
            FoundColor = GetRandomColor();
        }

        private Color GetRandomColor()
        {
            var random = new Random();
            var colors = new Color[]
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
            return colors[random.Next(colors.Length)];
        }
        public bool MatchesSelection(string selectedWord)
        {
            return selectedWord == Text;
        }
    }
}