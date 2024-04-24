using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Wpf.Gauges
{
    public partial class AngularGaugeExmple : UserControl, INotifyPropertyChanged
    {
        private int _totalCompanhias;

        public AngularGaugeExmple()
        {
            InitializeComponent();

            TotalCompanhias = 0; // Inicializa com zero
            DataContext = this;
        }

        public int TotalCompanhias
        {
            get { return _totalCompanhias; }
            set
            {
                _totalCompanhias = value;
                OnPropertyChanged("TotalCompanhias");
            }
        }

        private void ChangeValueOnClick(object sender, RoutedEventArgs e)
        {
            // Aqui você pode definir o valor total de companhias com base nos dados
            // que você deseja exibir. Por exemplo:
            TotalCompanhias = new Random().Next(50, 250);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
