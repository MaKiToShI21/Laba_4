using Laba4.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization;

namespace Laba4
{
    public partial class GameWindow : Window
    {
        public static Field Field { get; set; } = new Field();
        public static GameWindow MainGameWindow { get; set; }
        public Player Player { get; set; } = new Player();
        public Enemy Enemy { get; set; } = new Enemy();
        public List<Wall> Walls { get; set; } = new List<Wall>();
        public bool IsRunning { get; set; } = true;
        public HashSet<(int, int)> OccupiedPlaces { get; set; } = new HashSet<(int, int)>();

        private Random random = new Random();
       

        public GameWindow()
        {
            InitializeComponent();
            DataContext = this;
            this.Closing += MainWindow.GameController.GameWindow_Closing;
            playerImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Player/Player_Up.png")));
            enemyImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Enemy/Enemy_Up.png")));
        }
        private void RestartClick(object sender, RoutedEventArgs e)
        {
            GameCanvas.Visibility = Visibility.Visible;
            GameOverCanvas.Visibility = Visibility.Hidden;
            MainWindow.GameController.ResetCanvas();
        }

        public void EndGame()
        {
            GameCanvas.Visibility = Visibility.Hidden;
            GameOverCanvas.Visibility = Visibility.Visible;
        }

        // Отрисовка игры
        public void DrawGame()
        {
            GameCanvas.Children.Clear();

            // Отображение игрока
            Canvas.SetLeft(Player.Image, Player.X * Player.Width);
            Canvas.SetTop(Player.Image, Player.Y * Player.Height);

            GameCanvas.Children.Add(Player.Image);

            // Отображение врага
            Canvas.SetLeft(Enemy.Image, Enemy.X * Enemy.Width);
            Canvas.SetTop(Enemy.Image, Enemy.Y * Enemy.Height);

            GameCanvas.Children.Add(Enemy.Image);

            // Отображение стен
            foreach (var wall in Walls)
            {
                Canvas.SetLeft(wall.Image, wall.X * wall.Width);
                Canvas.SetTop(wall.Image, wall.Y * wall.Height);

                GameCanvas.Children.Add(wall.Image);
            }

            // Отображаем пули игрока
            foreach (var bullet in Player.Bullets)
            {
                Canvas.SetLeft(bullet.Image, bullet.X * Player.Width);
                Canvas.SetTop(bullet.Image, bullet.Y * Player.Height);

                GameCanvas.Children.Add(bullet.Image);
            }

            // Отображаем пули игрока
            foreach (var bullet in Enemy.Bullets)
            {
                Canvas.SetLeft(bullet.Image, bullet.X * Enemy.Width);
                Canvas.SetTop(bullet.Image, bullet.Y * Enemy.Height);

                GameCanvas.Children.Add(bullet.Image);
            }
        }

        private void SaveGameClick(object sender, RoutedEventArgs e)
        {
            DataStorage.SaveGame();
        }

        private void OpenMainWindowClick(object sender, RoutedEventArgs e)
        {
            MainWindow.GameController.OpenMainWindow();
        }
    }
}
