using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace Laba4.Models
{
    public class Bullet : GameObject
    {
        public int Damage { get; set; }
        public Direction Direction { get; set; }
        public double Speed { get; set; } = 0.75;

        BitmapImage bitmapImage;

        public Bullet(double x, double y, Direction direction)
        {
            X = x;
            Y = y;
            Damage = 1;
            Direction = direction;

            switch (direction)
            {
                case Direction.Up:
                    Width = 3;
                    Height = 4;
                    bitmapImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Bullets/Bullet_Up.png")));
                    break;
                case Direction.Down:
                    Width = 3;
                    Height = 4;
                    bitmapImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Bullets/Bullet_Down.png")));
                    break;
                case Direction.Left:
                    Width = 4;
                    Height = 3;
                    bitmapImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Bullets/Bullet_Left.png")));
                    break;
                case Direction.Right:
                    Width = 4;
                    Height = 3;
                    bitmapImage = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Bullets/Bullet_Right.png")));
                    break;
            }
            Image = new Image
            {
                Source = bitmapImage,
                Width = Width,
                Height = Height
            };
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.Up: Y -= Speed; break;
                case Direction.Down: Y += Speed; break;
                case Direction.Left: X -= Speed; break;
                case Direction.Right: X += Speed; break;
            }
        }

        public static void UpdateBullets(IShooter shooter)
        {
            for (int i = shooter.Bullets.Count - 1; i >= 0; i--)
            {
                var bullet = shooter.Bullets[i];

                bullet.Move();

                if (bullet.X <= 1 || bullet.X >= Field.FieldWidth - 1 || bullet.Y <= 1 || bullet.Y >= Field.FieldHeight - 1)
                {
                    shooter.Bullets.RemoveAt(i);
                    continue;
                }

                // Проверка на попадание в разрушаемую стенку
                foreach (var wall in GameWindow.MainGameWindow.Walls)
                {
                    bullet.ObjectRect = new Rect(bullet.X, bullet.Y, 1 / bullet.Width, 1 / bullet.Height);

                    if (bullet.ObjectRect.IntersectsWith(wall.ObjectRect))
                    {
                        wall.TakeDamage(bullet.Damage);
                        shooter.Bullets.RemoveAt(i);
                        //GameWindow.MainGameWindow.Walls.Remove(wall);
                        break;
                    }
                }

                // Проверка на попадание в игрока
                if (bullet.ObjectRect.IntersectsWith(GameWindow.MainGameWindow.Player.ObjectRect))
                {
                    shooter.Bullets.RemoveAt(i);
                    GameWindow.MainGameWindow.Player.TakeDamage(bullet.Damage);
                    continue;
                }

                // Проверка на попадание в врагов
                if (bullet.ObjectRect.IntersectsWith(GameWindow.MainGameWindow.Enemy.ObjectRect))
                {
                    shooter.Bullets.RemoveAt(i);
                    GameWindow.MainGameWindow.Enemy.TakeDamage(bullet.Damage);
                    break;
                }
            }
        }

        // Стрельба
        public static void ShootBullet(IShooter shooter)
        {
            if (shooter.Bullets.Count != 5)
            {
                double bulletStartX = shooter.X;
                double bulletStartY = shooter.Y;

                switch (shooter.Direction)
                {
                    case Direction.Up:
                        bulletStartX = shooter.X + 0.4;
                        bulletStartY = shooter.Y + 0.1;
                        break;
                    case Direction.Down:
                        bulletStartX = shooter.X + 0.4;
                        bulletStartY = shooter.Y + 0.5;
                        break;
                    case Direction.Left:
                        bulletStartX = shooter.X + 0.2;
                        bulletStartY = shooter.Y + 0.4;
                        break;
                    case Direction.Right:
                        bulletStartX = shooter.X + 0.5;
                        bulletStartY = shooter.Y + 0.4;
                        break;
                }

                var bullet = new Bullet(bulletStartX, bulletStartY, shooter.Direction);

                shooter.Bullets.Add(bullet);
            }
        }
    }
}
