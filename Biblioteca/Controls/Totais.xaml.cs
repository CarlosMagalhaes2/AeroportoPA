using System.Windows;
using System.Windows.Controls;

namespace Biblioteca.Controls
{
    public partial class Totais : UserControl
    {
        public static readonly DependencyProperty TotalCompanhiasProperty =
            DependencyProperty.Register("TotalCompanhias", typeof(int), typeof(Totais), new PropertyMetadata(0));

        public int TotalCompanhias
        {
            get { return (int)GetValue(TotalCompanhiasProperty); }
            set { SetValue(TotalCompanhiasProperty, value); }
        }

        public Totais()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
