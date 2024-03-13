using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CamadaNegocios;
using LiveCharts;
using static CamadaNegocios.Reservas;


namespace Biblioteca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChartValues<int> Reservastotal { get; set; }
        public ListaReservas ListaTotal { get; set; }
        public int contagemReservas { get; set; }
        public int contagementidades { get; set; }
  


        public MainWindow()
        {


            InitializeComponent();
            MouseDown += Window_MouseDown;

            this.DataInicio.SelectedDate = DateTime.Today.AddYears(-5);

            this.DataFim.SelectedDate = DateTime.Today.AddYears(-2);

            this.DataInicio.SelectedDateChanged += SelectedDateChanged;

            this.DataFim.SelectedDateChanged += SelectedDateChanged;

            Init();
        }

        private void Init()
        {
            this.Reservastotal = new ChartValues<int> { };
            this.ObterDownloads();
            this.refreshData();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }


        private void ObterDownloads()
        {
            ListaReservas listaReservas = Reservas.ObterListaReservas();
            if (listaReservas != null)
            {
                this.ListaTotal = listaReservas;
            }
        }


        private void refreshData()
        {
            DateTime? dataInicio = this.DataInicio.SelectedDate;
            DateTime? dataFim = this.DataFim.SelectedDate;


            List<Reservas> filtroreservas = new List<Reservas>();


            if (dataInicio.HasValue && dataFim.HasValue && dataInicio <= dataFim)
            {
                filtroreservas = (
                    from d in this.ListaTotal
                    where (d.Timestamp >= dataInicio.Value) && (d.Timestamp <= dataFim.Value)
                    select d).ToList();
            }
            monthlyChartData.FillData(filtroreservas);
            GetTotals(filtroreservas);
            DataContext = this;
        }

        

        private void GetTotals(List<Reservas> filtroreservas)
        {
            this.contagemReservas = filtroreservas?.Count() ?? 0;
            this.contagementidades = filtroreservas?.Select(x => x.Entidade).Distinct().Count() ?? 0;

            TotalReservas reservasTotais = new TotalReservas("Reservas", this.contagemReservas.ToString());
            this.reservasTotal.DataContext = reservasTotais;

            TotalReservas contadorTotalApps = new TotalReservas("Entidades", this.contagementidades.ToString());
            this.entidadesTotal.DataContext = contadorTotalApps;
        }

        private void SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            refreshData();
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
