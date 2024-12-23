using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4.Models
{
    public interface IShooter
    {
        double X { get; }
        double Y { get; }
        Direction Direction { get; }
        List<Bullet> Bullets { get; }
    }
}
