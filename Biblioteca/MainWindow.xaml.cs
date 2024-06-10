using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CamadaNegocios;
using LiveCharts;
using static CamadaNegocios.Aeroporto;

namespace Biblioteca
{

    public partial class MainWindow : Window
    {
        public ChartValues<int> Aeroportototal { get; set; }
        public ListaAeroporto ListaTotal { get; set; }
        public int totalVoos { get; set; }
        public double mediaLotacao { get; set; }
        public string CartaoTexto { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;
            this.DataInicio.SelectedDate = DateTime.Today.AddYears(-5);
            this.DataFim.SelectedDate = DateTime.Today.AddYears(-2);
            this.DataInicio.SelectedDateChanged += SelectedDateChanged;
            this.DataFim.SelectedDateChanged += SelectedDateChanged;
            Init();
            ExibirCartaoNaTextBox();
        }

        private void Init()
        {
            this.Aeroportototal = new ChartValues<int> { };
            this.ObterDownloads();
            this.RefreshData();
            this.LoadLocalidades();
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

        private void RefreshData()
        {
            DateTime? dataInicio = this.DataInicio.SelectedDate;
            DateTime? dataFim = this.DataFim.SelectedDate;
            string selectedLocalidade = LocalidadesComboBox.SelectedItem as string;

            if (dataInicio.HasValue && dataFim.HasValue && dataInicio <= dataFim)
            {
                List<Aeroporto> filtroaeroporto = new List<Aeroporto>();

                filtroaeroporto = (
                     from d in this.ListaTotal
                     where (d.DataPartida >= dataInicio.Value)
                           && (d.DataChegada <= dataFim.Value)
                           && (string.IsNullOrEmpty(selectedLocalidade) || d.LocalChegada == selectedLocalidade || d.LocalPartida == selectedLocalidade)
                     select d).ToList();

                monthlyChartData.FillData(filtroaeroporto, selectedLocalidade);
                CalcularTotaisEmedia(filtroaeroporto);
                ExibirCartaoNaTextBox();
                DataContext = this;
            }
        }

        private void CalcularTotaisEmedia(List<Aeroporto> filtroaeroporto)
        {
            this.totalVoos = filtroaeroporto?.Count() ?? 0;
            this.mediaLotacao = filtroaeroporto.Any() ? filtroaeroporto.Average(a => a.Lotacao) : 0;
        }

        private void SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.RefreshData();
        }

        private void ExibirCartaoNaTextBox()
        {
            this.CartaoTexto = ObterTextoDoCartao(this.totalVoos, this.mediaLotacao);

            cartaoTextBox.Text = this.CartaoTexto;
        }

        private string ObterTextoDoCartao(int totalVoos, double mediaLotacao)
        {
            return $"Cartão de Visualização de Dados:\n" +
                   $"--------------------------------\n" +
                   $"Total de Voos: {totalVoos}\n" +
                   $"Média de Lotação dos Voos: {mediaLotacao.ToString("0")}\n" +
                   $"--------------------------------";
        }

        private void LoadLocalidades()
        {
            List<Localidades> localidadesList = Localidades.GetLocalidades();
            var chegadas = localidadesList.Select(l => l.Localidade).Distinct();
            var partidas = localidadesList.Select(l => l.Localidade).Distinct();
            var allLocalidades = chegadas.Union(partidas).Distinct().OrderBy(localidade => localidade).ToList();

            foreach (var localidade in allLocalidades)
            {
                LocalidadesComboBox.Items.Add(localidade);
            }

            if (LocalidadesComboBox.Items.Count > 0)
            {
                LocalidadesComboBox.SelectedIndex = 0;
            }
        }

        private void LocalidadesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.RefreshData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
