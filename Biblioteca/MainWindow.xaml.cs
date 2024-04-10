using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CamadaNegocios;
using LiveCharts;
using static CamadaNegocios.Aeroporto;


namespace Biblioteca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChartValues<int> Aeroportototal { get; set; }
        public ListaAeroporto ListaTotal { get; set; }
        public int contagemAeroporto { get; set; }
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
            this.Aeroportototal = new ChartValues<int> { };
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
            ListaAeroporto listaAeroporto = Aeroporto.ObterListaAeroporto();
            if (listaAeroporto != null)
            {
                this.ListaTotal = listaAeroporto;
            }
        }


        private void refreshData()
        {
            DateTime? dataInicio = this.DataInicio.SelectedDate;
            DateTime? dataFim = this.DataFim.SelectedDate;


            List<Aeroporto> filtroaeroporto = new List<Aeroporto>();


            if (dataInicio.HasValue && dataFim.HasValue && dataInicio <= dataFim)
            {
                filtroaeroporto = (
                    from d in this.ListaTotal
                    where (d.DataPartida >= dataInicio.Value) && (d.DataChegada <= dataFim.Value)
                    select d).ToList();
            }
            monthlyChartData.FillData(filtroaeroporto);
            GetTotals(filtroaeroporto);
            DataContext = this;
        }

        

        private void GetTotals(List<Aeroporto> filtroaeroporto)
        {
            this.contagemAeroporto = filtroaeroporto?.Count() ?? 0;
            this.contagementidades = filtroaeroporto?.Select(x => x.Descricao).Distinct().Count() ?? 0;

            TotalAeroporto aeroportoTotais = new TotalAeroporto("Aeroporto", this.contagemAeroporto);
            this.lotacaoTotal.DataContext = aeroportoTotais;

            TotalAeroporto contadorTotalApps = new TotalAeroporto("Descricao", this.contagementidades);
            this.descricaoTotal.DataContext = contadorTotalApps;
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
