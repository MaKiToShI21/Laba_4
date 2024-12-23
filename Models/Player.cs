using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace Laba4.Models
{
    public class Player : GameObject, IShooter
    {
        public double Speed { get; set; }
        public Direction Direction { get; set; }
        public List<Bullet> Bullets { get; set; } = new List<Bullet>();
        private BitmapImage _playerImage;

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        public Player()
        {
            Health = 5;
            Score = 0;
            Speed = 0.25;
            Width = 16;
            Height = 16;
            Direction = Direction.Up;
            ObjectRect = new Rect(X, Y, 0.99, 0.99);
            Image = new Image
            {
                Width = Width,
                Height = Height,
                Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Player/Player_Up.png")))
            };
        }

        public void Move(Direction direction)
        {
            Direction = direction;
            double newX = X;
            double newY = Y;

            switch (direction)
            {
                case Direction.Up:
                    newY -= Speed;
                    _playerImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Player/Player_Up.png")));
                    break;
                case Direction.Down:
                    newY += Speed;
                    _playerImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Player/Player_Down.png")));
                    break;
                case Direction.Left:
                    newX -= Speed;
                    _playerImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Player/Player_Left.png")));
                    break;
                case Direction.Right:
                    newX += Speed;
                    _playerImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Player/Player_Right.png")));
                    break;
            }

            Image = new Image
            {
                Width = Width,
                Height = Height,
                Source = _playerImage
            };

            ObjectRect = new Rect(newX, newY, 0.99, 0.99);

            foreach (var wall in GameWindow.MainGameWindow.Walls)
            {
                if (ObjectRect.IntersectsWith(wall.ObjectRect))
                    return;
            }

            if (ObjectRect.IntersectsWith(GameWindow.MainGameWindow.Enemy.ObjectRect))
            {
                return;
            }
            if (newX < 0 || newX >= Field.FieldWidth || newY < 0 || newY >= Field.FieldHeight)
                return;

            X = newX;
            Y = newY;
        }

        public void TakeDamage(int damage)
        {
            int newHealth = Health - damage;
            if (newHealth <= 0)
                GameWindow.MainGameWindow.EndGame();
            else
                Health = newHealth;
        }

        public void GameWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.W:
                    Move(Direction.Up);
                    break;
                case System.Windows.Input.Key.S:
                    Move(Direction.Down);
                    break;
                case System.Windows.Input.Key.A:
                    Move(Direction.Left);
                    break;
                case System.Windows.Input.Key.D:
                    Move(Direction.Right);
                    break;
                case Key.Space:
                    Bullet.ShootBullet(GameWindow.MainGameWindow.Player);
                    break;
            }
        }
    }
}
