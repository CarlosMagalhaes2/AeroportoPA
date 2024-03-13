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

namespace Biblioteca.Controls
{
    /// <summary>
    /// Interaction logic for Totais.xaml
    /// </summary>
    public partial class Totais : UserControl
    {
        public Totais()
        {
            InitializeComponent();
        }

        public static implicit operator Totais(int v)
        {
            throw new NotImplementedException();
        }
    }
}
