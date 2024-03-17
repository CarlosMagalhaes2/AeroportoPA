using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CamadaNegocios;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace Biblioteca.Controls
{
    /// <summary>
    /// Interaction logic for LiveChart.xaml
    /// </summary>
    public partial class LiveChart : UserControl
    {
        public string[] Labels { get; set; }
        public SeriesCollection MonthlyChartSeries { get; set; }
        private List<Aeroporto> Aeroporto { get; set; }


        public LiveChart()
        {
            InitializeComponent();
        }


        public void FillData(List<Aeroporto> aeroporto)
        {
            this.Aeroporto = aeroporto;
            this.GetMonthlyChart();
        }

        private void GetMonthlyChart()
        {
            MonthlyChartSeries = new SeriesCollection();
            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Nov", "Dec" };

            List<IEnumerable<Aeroporto>> months = new List<IEnumerable<Aeroporto>>();

            if (this.Aeroporto == null)
            {

                DataContext = this;
                return;
            }

            for (int i = 1; i < 12; i++)
            {
                IEnumerable<Aeroporto> month = this.Aeroporto.Where(dnl => dnl.DataPartida.Month == i).ToList();
                months.Add(month);
            }

            LineSeries lineSeries = new LineSeries();
            lineSeries.Title = "Total Entradas";
            lineSeries.Stroke = Brushes.Gray;
            lineSeries.Fill = Brushes.LightBlue;
            lineSeries.Configuration = new CartesianMapper<Point>();

            ChartValues<int> charvals = new ChartValues<int>();

            for (int i = 0; i < 11; i++)
            {
                charvals.Add(this.Aeroporto.Count(dnl => dnl.DataPartida.Month == i + 1));
            }

            lineSeries.Values = charvals;
            MonthlyChartSeries.Add(lineSeries);
            monthlyChart.Series = this.MonthlyChartSeries;
            monthlyChart.Update();
            DataContext = this;
        }



    }
}
