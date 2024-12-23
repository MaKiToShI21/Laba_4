using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace Laba4.Models
{
    public class Enemy : GameObject, IShooter
    {
        public double Speed { get; set; } = 0.25;
        public Direction Direction { get; set; }
        public List<Bullet> Bullets { get; set; } = new List<Bullet>();
        private BitmapImage enemyImage;
        private int stepsUntilDirectionChange = 0;
        private int rndDirection = 0;

        public Enemy()
        {
            Health = 5;
            Width = 16;
            Height = 16;
            Image = new Image
            {
                Width = Width,
                Height = Height,
                Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Enemy/Enemy_Up.png")))
            };
            ObjectRect = new Rect(X, Y, 0.99, 0.99);
        }

        public void Move(int rndMove, int rndSteps)
        {
            if (stepsUntilDirectionChange <= 0)
            {
                rndDirection = rndMove;
                stepsUntilDirectionChange = rndSteps;
            }

            stepsUntilDirectionChange--;

            double newX = X;
            double newY = Y;

            switch (rndDirection)
            {
                case 1:
                    newY -= Speed;
                    Direction = Direction.Up;
                    enemyImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Enemy/Enemy_Up.png")));
                    break;
                case 2:
                    newY += Speed;
                    Direction = Direction.Down;
                    enemyImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Enemy/Enemy_Down.png")));
                    break;
                case 3:
                    newX -= Speed;
                    Direction = Direction.Left;
                    enemyImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Enemy/Enemy_Left.png")));
                    break;
                case 4:
                    newX += Speed;
                    Direction = Direction.Right;
                    enemyImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Enemy/Enemy_Right.png")));
                    break;
            }

            Image = new Image
            {
                Width = Width,
                Height = Height,
                Source = enemyImage
            };

            ObjectRect = new Rect(newX, newY, 0.99, 0.99);

            foreach (var wall in GameWindow.MainGameWindow.Walls)
            {
                if (ObjectRect.IntersectsWith(wall.ObjectRect))
                {
                    stepsUntilDirectionChange = 0;
                    return;
                }
            }

            if (ObjectRect.IntersectsWith(GameWindow.MainGameWindow.Player.ObjectRect))
            {
                stepsUntilDirectionChange = 0;
                return;
            }

            if (newX < 0 || newX >= Field.FieldWidth || newY < 0 || newY >= Field.FieldHeight)
            {
                stepsUntilDirectionChange = 0;
                return;
            }

            X = newX;
            Y = newY;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                GameWindow.MainGameWindow.Player.Score += 1;
                GameWindow.MainGameWindow.Enemy.Health = 5;
                GameWindow.Field.AddEnemy(GameWindow.Field.FindFreeCell(GameWindow.MainGameWindow.OccupiedPlaces));
            }
        }

        public void EnemyShoot(int rndShoot)
        {
            if (rndShoot == 10)
            {
                Bullet.ShootBullet(GameWindow.MainGameWindow.Enemy);
            }
        }

        public void UpdateEnemy()
        {
            Random random = new Random();
            int rndMove = random.Next(1, 5);
            int rndSteps = random.Next(5, 11);
            int rndShoot = random.Next(1, 11);
            Move(rndMove, rndSteps);
            EnemyShoot(rndShoot);
            Bullet.UpdateBullets(GameWindow.MainGameWindow.Enemy);
        }
    }
}
