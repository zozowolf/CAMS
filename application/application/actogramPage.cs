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
        int idEnregistrement = 1;
        int numbchannel = 1;
        int luxnumbchannel;
        private int MaxXValue = 1440;
        private const int chartHeight = 100;
        private const int margin = 10;
        SQL_command sqlCommand = new SQL_command();
        bool luxbool = false;

        private ToolTip toolTip1; // Ajouter un champ ToolTip

        public actogramPage()
        {
            InitializeComponent();
            InitializeCharts();
            InitializeScroll();

            // Initialiser le ToolTip
            toolTip1 = new ToolTip();
        }

        private void InitializeScroll()
        {
            panel2.AutoScroll = true;

            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.AutoScroll = true;

            panel2.Scroll += Panel2_Scroll;
        }

        private void Panel2_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.HorizontalScroll.Value = panel2.HorizontalScroll.Value;
        }

        private void InitializeCharts()
        {
            // Supprime tous les contrôles des panels
            foreach (Control control in panel1.Controls)
            {
                control.Dispose();
            }

            foreach (Control control in panel2.Controls)
            {
                control.Dispose();
            }

            // Efface la liste des contrôles dans les panels
            panel1.Controls.Clear();
            panel2.Controls.Clear();

            // Récupérer les jours uniques triés
            List<DateTime> sortedDays = sqlCommand.GetSortedDays(numbchannel, idEnregistrement);

            //affichage du channel actuel 
            Chn.Text = "Chn. " + numbchannel.ToString("000") + ": c" + numbchannel;

            captortype.Text = "(Type : " + sqlCommand.GetTypeCapteur(numbchannel) + ")";

            maxcount.Text = "max " + sqlCommand.GetMaxValeur(numbchannel, idEnregistrement);

            // Créer les graphiques en fonction des jours triés
            for (int i = 0; i < sortedDays.Count; i++)
            {
                Chart chart = CreateChart(i + 1, chartHeight, sortedDays[i]);
                panel1.Controls.Add(chart);
            }

            // Créer le graphique à lignes avec des points en bleu
            Chart blueChart = CreateBlueLineChart(panel2.Height);
            panel2.Controls.Add(blueChart);
        }

        private Chart CreateChart(int chartNumber, int chartHeight, DateTime day)
        {
            // Récupérer les jours uniques triés
            List<DateTime> sortedDays = sqlCommand.GetSortedDays(numbchannel, idEnregistrement);

            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            Series series = chart.Series.Add($"Chart{chartNumber}");

            Title title = new Title(sortedDays[chartNumber - 1].Date.ToString("dd/MM/yyyy"));
            title.Font = new Font("Arial", 16, FontStyle.Regular);
            title.Alignment = ContentAlignment.TopLeft;
            title.ForeColor = Color.White;
            chart.Titles.Add(title);

            // Ajouter une deuxième série de points non visible
            Series hiddenSeries = chart.Series.Add($"HiddenChart{chartNumber}");
            hiddenSeries.ChartType = SeriesChartType.Line;
            hiddenSeries.Color = Color.Orange;
            hiddenSeries.IsVisibleInLegend = false;
            if (!luxbool)
            {
                hiddenSeries.Enabled = false;
            }



            UpdateChart(chart, chartNumber, day);

            // Configurer le style de la ligne
            series.Color = Color.Green; // Couleur verte
            series.BorderWidth = 2;

            ConfigureChart(chart, chartNumber, chartHeight);

            return chart;
        }

        private void UpdateChart(Chart chart, int chartNumber, DateTime day)
        {
            // Réinitialiser les valeurs (temporaire en attendant la BD)
            chart.Series[$"Chart{chartNumber}"].Points.Clear();
            chart.Series[$"HiddenChart{chartNumber}"].Points.Clear();

            // Initialiser un tableau pour stocker les valeurs par minute
            double[] valeursParMinute = sqlCommand.GetValeurminutes(numbchannel, idEnregistrement, day);


            // Ajouter les valeurs au graphique
            for (int x = 0; x <= MaxXValue; x++)
            {
                double valeur = valeursParMinute[x];
                DataPoint dataPoint = new DataPoint();
                dataPoint.SetValueXY(x, valeur);
                chart.Series[$"Chart{chartNumber}"].Points.Add(dataPoint);
            }

            double[] hiddenValues;
            if (luxbool)
            {
                // Initialiser un tableau pour stocker les valeurs par minute
                hiddenValues = sqlCommand.GetLUXValeurminutes(luxnumbchannel, idEnregistrement, day);
                // Ajouter les valeurs au graphique
                for (int x = 0; x <= MaxXValue; x++)
                {
                    // Ajouter des points à la série cachée
                    DataPoint hiddenDataPoint = new DataPoint();
                    hiddenDataPoint.SetValueXY(x, hiddenValues[x]);
                    chart.Series[$"HiddenChart{chartNumber}"].Points.Add(hiddenDataPoint);
                }
            }
        }

        private Chart CreateBlueLineChart(int chartHeight)
        {
            // Récupérer les jours uniques triés
            List<DateTime> sortedDays = sqlCommand.GetSortedDays(numbchannel, idEnregistrement);

            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            Series series = chart.Series.Add("Total");
            series.ChartType = SeriesChartType.Line;

            // Ajouter la série cachée pour les moyennes des hiddenSeries
            Series hiddenSeries = chart.Series.Add("HiddenTotal");
            hiddenSeries.ChartType = SeriesChartType.Line;
            hiddenSeries.Color = Color.Orange;
            hiddenSeries.IsVisibleInLegend = false;
            if (!luxbool)
            {
                hiddenSeries.Enabled = false;
            }


            // Initialiser un tableau pour stocker la somme des valeurs par minute pour chaque graphique
            double[] sumValuesPerMinute = new double[MaxXValue + 1];
            double[] sumHiddenValuesPerMinute = new double[MaxXValue + 1];

            // Calculer la somme des valeurs de chaque point pour chaque graphique
            foreach (Chart lineChart in panel1.Controls.OfType<Chart>())
            {
                int chartNumber = int.Parse(lineChart.Series[0].Name.Substring("Chart".Length));
                for (int x = 0; x <= MaxXValue; x++)
                {
                    sumValuesPerMinute[x] += lineChart.Series[0].Points[x].YValues[0];
                    if (luxbool)
                    {
                        sumHiddenValuesPerMinute[x] += lineChart.Series[$"HiddenChart{chartNumber}"].Points[x].YValues[0];
                    }
                }
            }

            // Calculer la moyenne des valeurs pour chaque point
            for (int x = 0; x <= MaxXValue; x++)
            {
                double averageValue = sumValuesPerMinute[x] / panel1.Controls.Count;
                series.Points.AddXY(x, averageValue);
                if (luxbool)
                {
                    double averageHiddenValue = sumHiddenValuesPerMinute[x] / panel1.Controls.Count;
                    hiddenSeries.Points.AddXY(x, averageHiddenValue);
                }
            }

            // Configurer le style de la ligne en bleu
            series.Color = Color.Blue; // Couleur bleue
            series.BorderWidth = 2;

            ConfigureChart(chart, sortedDays.Count + 1, chartHeight);

            return chart;
        }


        private void ConfigureChart(Chart chart, int chartNumber, int chartHeight)
        {
            // Ajuster les limites des l'axes 
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = MaxXValue;
            chart.ChartAreas[0].AxisY.Minimum = 0;

            // Rendre les valeurs des axes invisibles
            //chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;

            // Configurer la transparence du fond
            chart.BackColor = Color.Transparent;
            chart.ChartAreas[0].BackColor = Color.Transparent;

            //couleur des axes
            chart.ChartAreas[0].AxisX.LineColor = Color.White;
            chart.ChartAreas[0].AxisY.LineColor = Color.White;

            // Ne pas afficher les valeurs des X
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;

            // Configurer la transparence des valeurs des axes
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;

            // Désactiver le quadrillage du fond
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // Supprimer les marqueurs de points
            chart.Series[0].MarkerStyle = MarkerStyle.None;

            // Définir la position et la taille du graphique
            if (chartHeight != panel2.Height)
            {
                int top = (chartHeight + margin + trackBarX.Value / 30) * (chartNumber - 1) + margin;
                chart.Location = new System.Drawing.Point(10, top);
                chart.Size = new System.Drawing.Size(panel1.Width + trackBarX.Value, chartHeight + trackBarX.Value / 50);
            }
            else
            {
                chart.Size = new System.Drawing.Size(panel2.Width + trackBarX.Value, chartHeight - 25);
            }

            for (int i = 360; i <= 1440; i += 360)
            {
                StripLine stripLine = new StripLine();
                stripLine.Interval = 0;
                stripLine.IntervalOffset = i;
                stripLine.StripWidth = 2;
                stripLine.BackColor = Color.Red; // Couleur rouge 

                chart.ChartAreas[0].AxisX.StripLines.Add(stripLine);
            }
            // Attacher l'événement MouseMove
            chart.MouseMove += Chart_MouseMove;
        }

        private void actogramPage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.C:
                    ChooseChanel.PerformClick();
                    break;
                case Keys.E:
                    Exit.PerformClick();
                    break;
                case Keys.L:
                    LUX.PerformClick();
                    break;
            }
        }

        private void actogramPage_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // S'assurer que le formulaire capture les événements de touches

            // Associer l'événement KeyDown au formulaire
            this.KeyDown += new KeyEventHandler(actogramPage_KeyDown);
        }

        private void ChooseChanel_Click(object sender, EventArgs e)
        {
            // Récupérer les identifiants de canal uniques
            List<int> uniqueChannelIds = sqlCommand.GetUniqueChannelIds(idEnregistrement);

            // Afficher la boîte de dialogue de saisie de valeur
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                // Récupérer la valeur saisie par l'utilisateur
                string userInput = inputDialog.GetInputValue();

                // Vérifier si la valeur saisie est un identifiant de canal valide
                if (int.TryParse(userInput, out int selectedChannel) && uniqueChannelIds.Contains(selectedChannel))
                {
                    // Mettre à jour le numéro de canal
                    numbchannel = selectedChannel;

                    // Initialiser les graphiques avec le numéro de canal mis à jour
                    InitializeCharts();
                }
                else
                {
                    // Afficher un message d'erreur ou prendre une action appropriée si l'entrée est invalide
                    MessageBox.Show("Identifiant de canal invalide. Veuillez saisir un identifiant de canal valide.");
                }
            }
        }

        private void trackBarX_Scroll(object sender, EventArgs e)
        {
            // Met à jour avec la valeur actuelle du TrackBar
            InitializeCharts();
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            Chart chart = sender as Chart;
            HitTestResult hit = chart.HitTest(e.X, e.Y);

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint dataPoint = hit.Series.Points[hit.PointIndex];
                string time = ConvertMinutesToTime(dataPoint.XValue);
                toolTip1.Show($"Time: {time}, Value: {dataPoint.YValues[0]}", chart, e.X, e.Y - 15);
            }
            else
            {
                toolTip1.Hide(chart);
            }
        }
        private string ConvertMinutesToTime(double minutes)
        {
            int hours = (int)minutes / 60;
            int mins = (int)minutes % 60;
            return $"{hours:D2}:{mins:D2}";
        }

        private void warningButton_Click(object sender, EventArgs e)
        {
            InputDialog2 inputDialog2 = new InputDialog2();
            inputDialog2.ShowDialog();
        }

        private void LUX_Click(object sender, EventArgs e)
        {
            // Récupérer les identifiants de canal uniques
            List<int> uniqueLuxChannelIds = sqlCommand.GetUniqueLuxChannelIds(idEnregistrement);

            // Afficher la boîte de dialogue de saisie de valeur
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                // Récupérer la valeur saisie par l'utilisateur
                string userInput = inputDialog.GetInputValue();

                // Vérifier si la valeur saisie est un identifiant de canal valide
                if (int.TryParse(userInput, out int selectedChannel) && uniqueLuxChannelIds.Contains(selectedChannel))
                {
                    // Mettre à jour le numéro de canal
                    luxnumbchannel = selectedChannel;

                    // Initialiser les graphiques avec le numéro de canal mis à jour
                    luxbool = !luxbool;
                    InitializeCharts();
                    checkBox1.Visible = true;

                }
                else
                {
                    // Afficher un message d'erreur ou prendre une action appropriée si l'entrée est invalide
                    MessageBox.Show("Identifiant de canal invalide. Veuillez saisir un identifiant de canal valide.");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Chart chart in panel1.Controls.OfType<Chart>())
            {
                foreach (Series series in chart.Series)
                {
                    if (series.Name.StartsWith("HiddenChart"))
                    {
                        series.Enabled = !series.Enabled;
                    }
                }
            }

            // Gérer la série cachée du blueChart
            foreach (Chart chart in panel2.Controls.OfType<Chart>())
            {
                foreach (Series series in chart.Series)
                {
                    if (series.Name == "HiddenTotal")
                    {
                        series.Enabled = !series.Enabled;
                    }
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
