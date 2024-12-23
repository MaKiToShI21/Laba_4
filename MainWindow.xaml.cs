using Laba4.Models;
using System.Windows;

namespace Laba4
{
    public partial class MainWindow : Window
    {
        public static string SaveFilePath { get; } = @"SavedGame.json";
        public static GameController GameController { get; set; } = new GameController();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(SaveFilePath))
            {
                var result = MessageBox.Show(
                    "Сохранение найдено. Вы уверены, что хотите начать новую игру? Сохранение будет удалено.",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result == MessageBoxResult.No)
                    return;

                System.IO.File.Delete(SaveFilePath);
            }

            var gameWindow = new GameWindow();
            GameWindow.MainGameWindow = gameWindow;
            GameController.StartNewGame();
            gameWindow.Show();
            this.Close();
        }

        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            GameWindow.MainGameWindow = gameWindow;
            if (DataStorage.LoadGame(SaveFilePath))
            {
                GameController.LoadSavedGame();
                gameWindow.Show();
                this.Close();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (GameWindow.MainGameWindow != null)
                GameWindow.MainGameWindow.Closing -= MainWindow.GameController.GameWindow_Closing;
            GameController.ExitGame();
        }
    }
}