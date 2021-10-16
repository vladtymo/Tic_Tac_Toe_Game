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
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }

        public bool IsNextX { get; set; }
        public Game(string player1, string player2)
        {
            InitializeComponent();

            Player1 = player1;
            Player2 = player2;

            Start();
        }

        void Start()
        {
            Random rnd = new Random();
            if (rnd.Next(2) == 0)
                currentPlayer.Text = Player1;
            else
                currentPlayer.Text = Player2;

            IsNextX = true;
        }
        void Restart()
        {
            foreach (var item in field.Children.OfType<Button>())
            {
                item.Content = null;
            }
            Start();
        }
        void ChangePlayer()
        {
            if (currentPlayer.Text == Player1)
                currentPlayer.Text = Player2;
            else
                currentPlayer.Text = Player1;
        }
        bool IsWin()
        {
            if ((field.Children[0] as Button).Content != null &&
                (field.Children[0] as Button).Content == (field.Children[1] as Button).Content &&
                (field.Children[0] as Button).Content == (field.Children[2] as Button).Content)
                return true;
            else
                return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content != null)
            {
                MessageBox.Show("You cannot change the existing move!");
                return;
            }


            (sender as Button).Content = IsNextX ? "X" : "O";

            if (IsWin())
            {
                MessageBox.Show($"Player {currentPlayer.Text} won!");
                Restart();
            }
            else
            {
                IsNextX = !IsNextX;
                ChangePlayer();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Restart();
        }
    }
}
