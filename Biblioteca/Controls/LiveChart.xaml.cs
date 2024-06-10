using System;
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

        public void FillData(List<Aeroporto> aeroporto, string localPartida)
        {
            this.Aeroporto = aeroporto;
            this.GetMonthlyChart(localPartida);
        }

        private void GetMonthlyChart(string localPartida)
        {
            MonthlyChartSeries = new SeriesCollection();

            if (this.Aeroporto == null)
            {
                DataContext = this;
                return;
            }

            List<string> labels = new List<string>();
            ChartValues<int> charvalsChegadas = new ChartValues<int>();
            ChartValues<int> charvalsPartidas = new ChartValues<int>();

            DateTime minDate = this.Aeroporto.Min(k => k.DataPartida);
            DateTime maxDate = this.Aeroporto.Max(k => k.DataPartida);

            for (DateTime date = minDate; date <= maxDate; date = date.AddMonths(1))
            {
                labels.Add(date.ToString("MMM yyyy"));
                charvalsChegadas.Add(this.Aeroporto.Count(dnl => dnl.DataPartida.Month == date.Month && dnl.DataPartida.Year == date.Year && dnl.LocalChegada == localPartida));
                charvalsPartidas.Add(this.Aeroporto.Count(dnl => dnl.DataPartida.Month == date.Month && dnl.DataPartida.Year == date.Year && dnl.LocalPartida == localPartida));
            }

            LineSeries lineSeriesChegadas = new LineSeries
            {
                Title = "Total Chegadas",
                DataLabels = true,
                Stroke = Brushes.RoyalBlue,
                Fill = Brushes.Transparent,
                Values = charvalsChegadas
            };

            LineSeries lineSeriesPartidas = new LineSeries
            {
                Title = "Total Partidas",
                DataLabels = true,
                Stroke = Brushes.DarkRed,
                Fill = Brushes.Transparent,
                Values = charvalsPartidas
            };

            this.Labels = labels.ToArray();
            MonthlyChartSeries.Add(lineSeriesChegadas);
            MonthlyChartSeries.Add(lineSeriesPartidas);

            monthlyChart.Series = this.MonthlyChartSeries;

            Axis xAxis = new Axis
            {
                Labels = this.Labels,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = labels.Count > 18 ? Math.Ceiling(labels.Count / 18.0) : 1,
                    IsEnabled = false
                },
                LabelsRotation = 45
            };

            monthlyChart.AxisX.Clear();
            monthlyChart.AxisX.Add(xAxis);

            monthlyChart.Update();
            DataContext = this;
        }
    }
}
