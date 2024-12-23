using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Laba4.Models
{
    public class Field
    {
        public const int FieldWidth = 40;
        public const int FieldHeight = 40;
        private Random random = new Random();

        public (int, int)? FindFreeCell(HashSet<(int, int)> occupiedPlaces)
        {
            // Находим свободные клетки
            List<(int, int)> freePlaces = new List<(int, int)>();
            for (int x = 1; x < FieldWidth - 1; x++)
            {
                for (int y = 1; y < FieldHeight - 1; y++)
                {
                    if (!occupiedPlaces.Contains((x, y)))
                    {
                        freePlaces.Add((x, y));
                    }
                }
            }

            // Если есть свободные клетки, вернуть случайную
            if (freePlaces.Count > 0)
            {
                return freePlaces[random.Next(freePlaces.Count)];
            }

            // Если свободных клеток нет, вернуть null
            return null;
        }

        public void AddWallsPlayerAndEnemy()
        {
            // Добавляем стены по контуру
            for (int x = 0; x < FieldWidth; x++)
            {
                for (int y = 0; y < FieldHeight; y++)
                {
                    if (x == 0 || x == FieldWidth - 1 || y == 0 || y == FieldHeight - 1)
                    {
                        GameWindow.MainGameWindow.Walls.Add(new Wall(x, y));
                        GameWindow.MainGameWindow.OccupiedPlaces.Add((x, y));
                    }
                }
            }

            // Добавляем случайные стены
            for (int i = 0; i < 555; i++)
            {
                int x = random.Next(1, FieldWidth - 1);
                int y = random.Next(1, FieldHeight - 1);
                if (!GameWindow.MainGameWindow.OccupiedPlaces.Contains((x, y)))
                {
                    GameWindow.MainGameWindow.Walls.Add(new Wall(x, y));
                    GameWindow.MainGameWindow.OccupiedPlaces.Add((x, y));
                }
            }

            if (GameWindow.MainGameWindow.OccupiedPlaces.Count >= FieldWidth * FieldHeight - 2)
            {
                throw new InvalidOperationException("Не осталось места для игрока или врага!");
            }

            var freeCellForPlayer = FindFreeCell(GameWindow.MainGameWindow.OccupiedPlaces);
            AddPlayer(freeCellForPlayer);

            var freeCellForEnemy = FindFreeCell(GameWindow.MainGameWindow.OccupiedPlaces);
            AddEnemy(freeCellForEnemy);
        }

        // Добавление игрока и врагов на свободные клетки
        private void AddPlayer((int, int)? freeCell)
        {
            if (freeCell != null)
            {
                var (x, y) = freeCell.Value;
                GameWindow.MainGameWindow.Player.X = x;
                GameWindow.MainGameWindow.Player.Y = y;
                GameWindow.MainGameWindow.OccupiedPlaces.Add((x, y));
            }
        }

        public void AddEnemy((int, int)? freeCell)
        {
            if (freeCell != null)
            {
                var (x, y) = freeCell.Value;
                GameWindow.MainGameWindow.Enemy.X = x;
                GameWindow.MainGameWindow.Enemy.Y = y;
            }
        }
    }
}
