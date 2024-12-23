using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4.Models
{
    public class GameState
    {
        public int Score { get; set; }
        public SerializableGameObject Player { get; set; }
        public SerializableGameObject Enemy { get; set; }
        public List<SerializableGameObject> Walls { get; set; }
        public HashSet<(int, int)> OccupiedPlaces { get; set; }
    }
}
