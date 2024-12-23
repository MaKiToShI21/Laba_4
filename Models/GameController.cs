using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Laba4.Models
{
    public class GameController
    {
        public DispatcherTimer GameTimer { get; set; }

        public void StartGame()
        {
            GameWindow.MainGameWindow.KeyDown += GameWindow.MainGameWindow.Player.GameWindow_KeyDown;
            GameTimer = new DispatcherTimer();
            GameTimer.Interval = TimeSpan.FromMilliseconds(50);
            GameTimer.Tick += (sender, e) => UpdateGame();
            GameTimer.Start();
        }

        public void StartNewGame()
        {
            StartGame();
            ResetCanvas();
        }

        public void LoadSavedGame()
        {
            StartGame();
        }

        public void ResetCanvas()
        {
            GameWindow.MainGameWindow.IsRunning = true;
            GameWindow.MainGameWindow.Walls.Clear();
            GameWindow.MainGameWindow.OccupiedPlaces.Clear();
            GameWindow.MainGameWindow.Player.Score = 0;
            GameWindow.MainGameWindow.Player.Health = 5;
            GameWindow.MainGameWindow.Enemy.Health = 5;
            GameWindow.Field.AddWallsPlayerAndEnemy();
        }

        // Обновление всех действий
        private void UpdateGame()
        {
            if (GameWindow.MainGameWindow.IsRunning)
            {
                Bullet.UpdateBullets(GameWindow.MainGameWindow.Player);
                GameWindow.MainGameWindow.Enemy.UpdateEnemy();
                GameWindow.MainGameWindow.DrawGame();
            }
            else
            {
                GameTimer.Stop();
                GameWindow.MainGameWindow.EndGame();
            }
        }

        public void OpenMainWindow()
        {
            GameTimer.Stop();

            GameWindow.MainGameWindow.Closing -= MainWindow.GameController.GameWindow_Closing;

            var result = MessageBox.Show(
                "Вы уверены, что хотите вернуться на главное меню?",
                "Подтверждение",
                MessageBoxButton.YesNo
            );
            if (result == MessageBoxResult.No)
            {
                GameTimer.Start();
                GameWindow.MainGameWindow.Closing += MainWindow.GameController.GameWindow_Closing;
                return;
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            GameTimer = null;
            GameWindow.MainGameWindow.Close();

            GameWindow.MainGameWindow.Closing += MainWindow.GameController.GameWindow_Closing;
        }

        public void GameWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GameTimer.Stop();
            var result = CloseGameWindow();
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
                GameTimer.Start();
                return;
            }
            GameTimer = null;
        }

        public void ExitGame()
        {
            var result = CloseGameWindow();
            if (result == MessageBoxResult.No)
                return;
            Application.Current.Shutdown();
        }

        private MessageBoxResult CloseGameWindow()
        {
            return MessageBox.Show(
                "Вы уверены, что хотите выйти из игры?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );
        }
    }
}
