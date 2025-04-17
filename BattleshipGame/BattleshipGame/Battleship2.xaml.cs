using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace L2
{
    public partial class Battleship2 : Window
    {
        public Battleship2()
        {
            InitializeComponent();
            CreatButtons();
        }
        private void G2_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (((BattleshipGame)p2_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] == 0)
                ((BattleshipGame)p2_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())]++;
            else if (((BattleshipGame)p2_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] == 1)
                ((BattleshipGame)p2_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())]--;
        }
        private void G1_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (((BattleshipGame)p2_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] == 0 || ((BattleshipGame)p2_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] == 1)
                ((BattleshipGame)p2_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] += 2;
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
                    binding.Path = new PropertyPath("Player2[" + ((i * 10) + j) + "]");
                    button.SetBinding(Button.BackgroundProperty, binding);
                    button.Click += new RoutedEventHandler(G2_Shoot);
                    this.p2_board.Children.Add(button);
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
                    binding.Path = new PropertyPath("Player1[" + ((i * 10) + j) + "]");
                    button.SetBinding(Button.BackgroundProperty, binding);
                    button.Click += new RoutedEventHandler(G1_Shoot);
                    this.p2_board.Children.Add(button);
                }
            }
        }
    }
}