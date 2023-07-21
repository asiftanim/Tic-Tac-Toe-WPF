using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_tacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Game game;
        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Board_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            
            if(button.Name != "NewGame")
            {
                button.Content = game.getCurrentPlayer();

                if (game.getTurnCount() == 9)
                {
                    Notification.Content = "Match Draw!!!";
                    DisableAllBoardButtons();
                }
                else
                {
                    game.UpdateGameBoard(button.Tag.ToString());
                    if (game.CheckWinCondition())
                    {
                        Notification.Content = game.getCurrentPlayer() + " Won !!!";
                        DisableAllBoardButtons();
                    }
                    game.setNextPlayer();
                }
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            game.resetGame();
            ResetButton();
        }

        private void ResetButton()
        {
            foreach (Button button in buttonGrid.Children)
            {
                button.Content = String.Empty;
                button.IsEnabled = true;
            }
            Notification.Content = "";
        }

        private void DisableAllBoardButtons()
        {
            foreach (Button button in buttonGrid.Children)
            {
                button.IsEnabled = false;
            }
        }
    }
}
