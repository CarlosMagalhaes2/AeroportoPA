using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace Biblioteca.Controls
{
    public partial class PieChart : UserControl
    {
        public PieChart()
        {
            InitializeComponent();
            CarregarDadosNoGrafico();
        }

        private void CarregarDadosNoGrafico()
        {
            
            var dados = CamadaNegocios.Aeroporto.ContarVoosPorEstado();

            foreach (var item in dados)
            {
                MainPieChart.Series.Add(new PieSeries
                {
                    Title = item.Key.ToString(),
                    Values = new ChartValues<int> { item.Value },
                    DataLabels = true,
                });
            }
        }
    }
}
