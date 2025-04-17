using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace L2
{
    public partial class Battleship : Window
    {
        public Battleship()
        {
            InitializeComponent();
            CreatButtons();
            int[] border1 = new int[100];
            int[] border2 = new int[100];
            BattleshipGame gra = new BattleshipGame(border1, border2);
            GameValueConverter gameValueConverter = new GameValueConverter();
            GameValueConverter2 gameValueConverter2 = new GameValueConverter2();
            p1_board.DataContext = gra;
            Battleship2 window = new Battleship2();
            window.DataContext = gra;
            window.Show();
        }

        private void G1_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (((BattleshipGame)p1_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] == 0)
                ((BattleshipGame)p1_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())]++;
            else if (((BattleshipGame)p1_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] == 1)
                ((BattleshipGame)p1_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())]--;
        }

        private void G2_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (((BattleshipGame)p1_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] == 0 || ((BattleshipGame)p1_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] == 1)
                ((BattleshipGame)p1_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] += 2;
        }

        private void CreatButtons()
        {
            GameValueConverter converter = new GameValueConverter();
            GameValueConverter2 converter2 = new GameValueConverter2();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button button = new Button();
                    {
                        Grid.SetRow(button, i + 1);
                        Grid.SetColumn(button, j);
                    };
                    button.Tag = ((i * 10) + j);
                    Binding binding = new Binding();
                    binding.Converter = converter;
                    binding.Mode = BindingMode.TwoWay;
                    binding.Path = new PropertyPath("Player1[" + ((i * 10) + j) + "]");
                    button.SetBinding(Button.BackgroundProperty, binding);
                    button.Click += new RoutedEventHandler(G1_Shoot);
                    this.p1_board.Children.Add(button);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button button = new Button();
                    {
                        Grid.SetRow(button, i + 1);
                        Grid.SetColumn(button, j + 11);
                    };
                    button.Tag = ((i * 10) + j);
                    Binding binding = new Binding();
                    binding.Converter = converter2;
                    binding.Mode = BindingMode.TwoWay;
                    binding.Path = new PropertyPath("Player2[" + ((i * 10) + j) + "]");
                    button.SetBinding(Button.BackgroundProperty, binding);
                    button.Click += new RoutedEventHandler(G2_Shoot);
                    this.p1_board.Children.Add(button);
                }
            }
        }
    }
}

