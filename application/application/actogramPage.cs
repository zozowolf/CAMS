using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient; // SQL Server local DB

namespace application
{
    /*! \class actogramPage
    \brief Classe permettant de modéliser des actograms
    */
    public partial class actogramPage : Form
    {
        

        private const int MaxXValue = 1440;
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

            int chartHeight = (groupBox1.Height - (NumCharts() + 1) * Margin) / (NumCharts() + 1); // Calculer la hauteur des graphiques

            for (int i = 1; i <= NumCharts(); i++)
            {
                Chart chart = CreateChart(i, random, chartHeight);
                groupBox1.Controls.Add(chart);
            }

            // Créer le graphique à lignes avec des points en bleu
            Chart blueChart = CreateBlueLineChart(chartHeight);
            groupBox1.Controls.Add(blueChart);
        }

        private Chart CreateChart(int chartNumber, Random random, int chartHeight)
        {
            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            Series series = chart.Series.Add($"Chart{chartNumber}");

            UpdateChart(chart, chartNumber);

            // Configurer le style de la ligne
            series.Color = Color.Green; // Couleur verte
            series.BorderWidth = 2;

            ConfigureChart(chart, chartNumber, chartHeight);

            return chart;
        }


        private int NumCharts()
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            HashSet<DateTime> joursDifferents = new HashSet<DateTime>();

            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();
                string sql_Text = $"SELECT dateHeure FROM Mesure WHERE IdChannel = 1 ORDER BY dateHeure ASC";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["dateHeure"] != DBNull.Value)
                            {
                                DateTime dateHeure = (DateTime)reader["dateHeure"];
                                // Ignorer les composants d'heure pour ne considérer que la date
                                DateTime jourUnique = dateHeure.Date;
                                joursDifferents.Add(jourUnique);
                            }
                        }
                    }
                }
            }

            return joursDifferents.Count;
        }

        private void UpdateChart(Chart chart, int chartNumber)
        {
            // Réinitialiser les valeurs (temporaire en attendant la BD)
            chart.Series[$"Chart{chartNumber}"].Points.Clear();

            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Initialiser un tableau pour stocker les valeurs par minute
                double[] valeursParMinute = new double[MaxXValue + 1];

                string sql_Text = $"SELECT valeur, dateHeure FROM Mesure WHERE IdChannel = 1 ORDER BY dateHeure ASC";
                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Utiliser la colonne correspondante pour récupérer les données
                            double valeur = Convert.ToDouble(reader["valeur"]);
                            DateTime dateHeure = Convert.ToDateTime(reader["dateHeure"]);

                            // Calculer l'index de la minute dans la journée
                            int minuteIndex = dateHeure.Hour * 60 + dateHeure.Minute;

                            // Stocker la valeur dans le tableau
                            valeursParMinute[minuteIndex] = valeur;
                        }
                    }
                }

                // Ajouter les valeurs au graphique
                for (int x = 0; x <= MaxXValue; x++)
                {
                    double valeur = valeursParMinute[x];
                    DataPoint dataPoint = new DataPoint();
                    dataPoint.SetValueXY(x, valeur);
                    chart.Series[$"Chart{chartNumber}"].Points.Add(dataPoint);
                }
            }
        }




        private Chart CreateBlueLineChart(int chartHeight)
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

            ConfigureChart(chart, NumCharts() + 1, chartHeight);

            return chart;
        }


        private void ConfigureChart(Chart chart, int chartNumber, int chartHeight)
        {
            // Ajuster les limites des l'axes 
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = MaxXValue;

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
            int top = (chartHeight + Margin) * (chartNumber - 1) + Margin;
            chart.Location = new System.Drawing.Point(10, top);
            chart.Size = new System.Drawing.Size(groupBox1.Width - 20, chartHeight);
        }

        private void actogramPage_Load(object sender, EventArgs e)
        {

        }
    }
}