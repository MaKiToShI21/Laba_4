using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace Laba4.Models
{
    public class DataStorage
    {
        public static SerializableGameObject ToSerializable(GameObject obj)
        {
            var serializable = new SerializableGameObject
            {
                X = obj.X,
                Y = obj.Y,
                Health = obj.Health,
                Width = obj.Width,
                Height = obj.Height,
                ObjectRect = obj.ObjectRect,
                ImagePath = (obj.Image.Source as BitmapImage)?.UriSource?.LocalPath
            };
            // Если объект имеет Direction, добавляем его
            if (obj is Player player)
            {
                serializable.Direction = player.Direction;
            }
            else if (obj is Enemy enemy)
            {
                serializable.Direction = enemy.Direction;
            }

            return serializable;

        }

        public static void ApplySerializable(GameObject obj, SerializableGameObject data)
        {
            obj.X = data.X;
            obj.Y = data.Y;
            obj.Health = data.Health;
            obj.Width = data.Width;
            obj.Height = data.Height;
            obj.ObjectRect = data.ObjectRect;
            obj.Image = new Image
            {
                Width = obj.Width,
                Height = obj.Height,
                Source = new BitmapImage(new Uri(data.ImagePath))
            };

            // Применяем Direction, если это Player или Enemy
            if (obj is Player player && data.Direction.HasValue)
            {
                player.Direction = data.Direction.Value;
            }
            else if (obj is Enemy enemy && data.Direction.HasValue)
            {
                enemy.Direction = data.Direction.Value;
            }
        }

        public static void SaveGame()
        {
            try
            {
                MainWindow.GameController.GameTimer.Stop();
                if (System.IO.File.Exists(MainWindow.SaveFilePath))
                {
                    var result = MessageBox.Show(
                    "Сохранение найдено. Если вы подтвердите новое сохранение, старое - будет удалено.",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                    );

                    if (result == MessageBoxResult.No)
                    {
                        MainWindow.GameController.GameTimer.Start();
                        return;
                    }    
                }

                var gameState = new GameState
                {
                    Score = GameWindow.MainGameWindow.Player.Score,
                    Player = ToSerializable(GameWindow.MainGameWindow.Player),
                    Enemy = ToSerializable(GameWindow.MainGameWindow.Enemy),
                    Walls = GameWindow.MainGameWindow.Walls.Select(ToSerializable).ToList(),
                    OccupiedPlaces = GameWindow.MainGameWindow.OccupiedPlaces
                };

                var serializer = new DataContractJsonSerializer(typeof(GameState));
                using (var stream = new FileStream(MainWindow.SaveFilePath, FileMode.Create))
                {
                    serializer.WriteObject(stream, gameState);
                }
                MessageBox.Show("Игра была сохранена.");
                MainWindow.GameController.GameTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении игры: {ex.Message}");
            }
        }

        public static bool LoadGame(string filePath)
        {
            try
            {
                if (File.Exists(MainWindow.SaveFilePath))
                {

                    var serializer = new DataContractJsonSerializer(typeof(GameState));
                    using (var stream = new FileStream(MainWindow.SaveFilePath, FileMode.Open))
                    {
                        var gameState = (GameState)serializer.ReadObject(stream);
                        GameWindow.MainGameWindow.Player.Score = gameState.Score;
                        GameWindow.MainGameWindow.OccupiedPlaces = gameState.OccupiedPlaces;
                        ApplySerializable(GameWindow.MainGameWindow.Player, gameState.Player);
                        ApplySerializable(GameWindow.MainGameWindow.Enemy, gameState.Enemy);
                        GameWindow.MainGameWindow.Walls.Clear();
                        foreach (var wallData in gameState.Walls)
                        {
                            var wall = new Wall(0, 0);
                            ApplySerializable(wall, wallData);
                            GameWindow.MainGameWindow.Walls.Add(wall);
                        }
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Сохранение не найдено.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке игры: {ex.Message}");
                return false;
            }
        }
    }
}
