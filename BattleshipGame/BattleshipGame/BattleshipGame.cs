using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;

namespace L2
{
    public class BattleshipGame : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<int> player1 = new ObservableCollection<int> { };
        ObservableCollection<int> player2 = new ObservableCollection<int> { };

        public ObservableCollection<int> Player1
        {
            get
            {
                return player1;
            }
            set
            {
                player1 = value;
                OnPropertyChanged("PersonID");
            }
        }

        public ObservableCollection<int> Player2
        {
            get
            {
                return player2;
            }
            set
            {
                player2 = value;
                OnPropertyChanged("PersonID");
            }
        }

        public BattleshipGame(int[] borderp1, int[] borderp2)
        {
            foreach (int person in borderp1)
            {
                player1.Add(person);
            }

            foreach (int person2 in borderp2)
            {
                player2.Add(person2);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class GameValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                case 1:
                    return new SolidColorBrush(Colors.Green);
                case 0:
                    return new SolidColorBrush(Colors.Blue);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }

    public class GameValueConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                case 1:
                    return new SolidColorBrush(Colors.Blue);
                case 0:
                    return new SolidColorBrush(Colors.Blue);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 0;
        }
    }
}
