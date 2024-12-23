using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba4.Models
{
    public class SerializableGameObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Health { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ImagePath { get; set; }
        public Rect ObjectRect { get; set; }
        public Direction? Direction { get; set; }
    }
}
