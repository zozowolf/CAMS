using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace application
{
    /*! \class actogramPage
    \brief Classe permettant de modéliser des actograms
    */
    public partial class actogramPage : Form
    {
        private const int NumCharts = 7;
        private const int MaxXValue = 25;
        private const int ChartHeight = 25;
        private const int Margin = 10;

        public actogramPage()
        {
            InitializeComponent();
            InitializeCharts();

            Bounds = Screen.PrimaryScreen.Bounds; // Ajuster la taille de la fenêtre à la taille de l'écran
        }

        private void InitializeCharts()
        {
            // Créer les graphiques à lignes avec des points
            Random random = new Random(); // Générateur de nombres aléatoires

            for (int i = 1; i <= NumCharts; i++)
            {
                Chart chart = CreateLineChart(i, random);
                groupBox1.Controls.Add(chart);
            }

            // Créer le graphique à lignes avec des points en bleu
            Chart blueChart = CreateBlueLineChart();
            blueChart.Size = new System.Drawing.Size(blueChart.Width, ChartHeight+10);
            groupBox1.Controls.Add(blueChart);
        }

        private Chart CreateLineChart(int chartNumber, Random random)
        {
            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());


            Series series = chart.Series.Add($"Chart{chartNumber}");
            series.ChartType = SeriesChartType.Line;

            for (int x = 0; x <= MaxXValue; x++)
            {
                int randomValue = random.Next();
                series.Points.AddXY(x, randomValue);
            }

            // Configurer le style de la ligne
            series.Color = Color.Green; // Couleur verte
            series.BorderWidth = 2;

            ConfigureChart(chart, chartNumber);

            return chart;
        }

        private Chart CreateBlueLineChart()
        {
            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            Series series = chart.Series.Add("Total");
            series.ChartType = SeriesChartType.Line;

            // Ajouter les valeurs totales des autres graphiques
            for (int x = 0; x <= MaxXValue; x++)
            {
                double totalValue = 0;
                foreach (Chart lineChart in groupBox1.Controls.OfType<Chart>())
                {
                    if (lineChart != chart)
                    {
                        int chartNumber = int.Parse(lineChart.Series[0].Name.Substring("Chart".Length));
                        totalValue += lineChart.Series[0].Points[x].YValues[0];
                    }
                }
                series.Points.AddXY(x, totalValue);
            }

            // Configurer le style de la ligne en bleu
            series.Color = Color.Blue; // Couleur bleue
            series.BorderWidth = 2;

            ConfigureChart(chart, NumCharts + 1);

            return chart;
        }

        private void ConfigureChart(Chart chart, int chartNumber)
        {
            // Rendre les valeurs des axes invisibles
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;

            // Configurer la transparence du fond
            chart.BackColor = Color.Transparent;
            chart.ChartAreas[0].BackColor = Color.Transparent;

            // Configurer la transparence des valeurs des axes
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;

            // Désactiver le quadrillage du fond
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // Supprimer les marqueurs de points
            chart.Series[0].MarkerStyle = MarkerStyle.None;

            // Définir la position et la taille du graphique
            chart.Width = groupBox1.Width - 20; // Largeur ajustée à celle du GroupBox
            int top = (ChartHeight + Margin) * (chartNumber - 1) + Margin;
            chart.Location = new System.Drawing.Point(10, top);
            chart.Size = new System.Drawing.Size(chart.Width, ChartHeight);
        }

        private void actogramPage_Load(object sender, EventArgs e)
        {

        }
    }
}
