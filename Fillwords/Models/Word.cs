using FIllwords.Models;
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
            Color.LightGreen, Color.LightBlue, Color.LightYellow,
            Color.LightPink, Color.LightCoral, Color.LightSkyBlue,
            Color.PaleGreen, Color.PaleTurquoise, Color.Plum, Color.Moccasin
            };
            return colors[random.Next(colors.Length)];
        }

        public bool MatchesSelection(string selectedWord)
        {
            return selectedWord == Text;
        }
    }
}