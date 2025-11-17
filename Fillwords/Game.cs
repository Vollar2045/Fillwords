namespace Fillwords
{
    public partial class Game : Form
    {
        private int _levelNumber;
        public Game()
        {
            InitializeComponent();
        }
        public Game(int levelNumber) : this() 
        {
            _levelNumber = levelNumber;
            this.Text = $"Филворды - Уровень {_levelNumber}";
        }
    }
}