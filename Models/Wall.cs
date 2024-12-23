using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace Laba4.Models
{
    public class Wall : GameObject
    {
        public Wall(int x, int y)
        {
            X = x;
            Y = y;
            Width = 16;
            Height = 16;
            Health = 2;
            Image = new Image
            {
                Width = Width,
                Height = Height,
                Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Walls/BreakableWall.png")))
            };
            ObjectRect = new Rect(X, Y, 0.99, 0.99);
        }

        public void TakeDamage(int damage)
        {
            int newHealth = Health - damage;
            if (newHealth <= 0)
                GameWindow.MainGameWindow.Walls.Remove(this);
            else
            {
                Health = newHealth;
                this.Image.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/Walls/HalfBreakableWall.png")));
            }
        }
    }
}
