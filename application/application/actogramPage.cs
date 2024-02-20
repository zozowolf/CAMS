﻿using System;
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

        int numbchannel = 1;
        private const int MaxXValue = 1440;
        private const int chartHeight = 105;
        private const int Margin = 10;

        public actogramPage()
        {
            InitializeComponent();
            InitializeCharts();

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

            //affichage du channel actuel
            Chn.Text = "Chn. " + numbchannel.ToString("000") + ": c" + numbchannel;

            // Récupérer les jours uniques triés
            List<DateTime> sortedDays = GetSortedDays();

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
            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            Series series = chart.Series.Add($"Chart{chartNumber}");

            UpdateChart(chart, chartNumber, day);

            // Configurer le style de la ligne
            series.Color = Color.Green; // Couleur verte
            series.BorderWidth = 2;

            ConfigureChart(chart, chartNumber, chartHeight);

            return chart;
        }


        private List<DateTime> GetSortedDays()
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            List<DateTime> joursDifferents = new List<DateTime>();

            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();
                string sql_Text = $"SELECT dateHeure FROM Mesure WHERE IdChannel = '{numbchannel}' ORDER BY dateHeure ASC";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["dateHeure"] != DBNull.Value)
                            {
                                DateTime dateHeure = (DateTime)reader["dateHeure"];
                                DateTime jourUnique = dateHeure.Date;
                                if (!joursDifferents.Contains(jourUnique))
                                {
                                    joursDifferents.Add(jourUnique);
                                }
                            }
                        }
                    }
                }
            }

            // Trier les jours de manière ascendante
            joursDifferents.Sort();
            Startdate.Text = joursDifferents[0].Date.ToString("dd/MM/yyyy");
            Enddate.Text = joursDifferents[joursDifferents.Count - 1].Date.ToString("dd/MM/yyyy");
            return joursDifferents;
        }

        private void UpdateChart(Chart chart, int chartNumber, DateTime day)
        {
            // Réinitialiser les valeurs (temporaire en attendant la BD)
            chart.Series[$"Chart{chartNumber}"].Points.Clear();

            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();

                // Initialiser un tableau pour stocker les valeurs par minute
                double[] valeursParMinute = new double[MaxXValue + 1];

                string sql_Text = $"SELECT valeur, dateHeure FROM Mesure WHERE IdChannel = '{numbchannel}' AND CONVERT(date, dateHeure) = '{day.ToString("yyyy-MM-dd")}' ORDER BY dateHeure ASC";

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
            // Récupérer les jours uniques triés
            List<DateTime> sortedDays = GetSortedDays();

            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            Series series = chart.Series.Add("Total");
            series.ChartType = SeriesChartType.Line;

            // Ajouter les valeurs totales des autres graphiques
            for (int x = 0; x <= MaxXValue; x++)
            {
                double totalValue = 0;
                foreach (Chart lineChart in panel1.Controls.OfType<Chart>())
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

            ConfigureChart(chart, sortedDays.Count + 1, chartHeight);

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
            if (chartHeight != panel2.Height)
            {
                int top = (chartHeight + Margin) * (chartNumber - 1) + Margin;
                chart.Location = new System.Drawing.Point(10, top);
            }

            chart.Size = new System.Drawing.Size(panel1.Width - 30, chartHeight);
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
            }


        }

        private void actogramPage_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // S'assurer que le formulaire capture les événements de touches

            // Associer l'événement KeyDown au formulaire
            this.KeyDown += new KeyEventHandler(actogramPage_KeyDown);

        }

        private List<int> GetUniqueChannelIds()
        {
            string cn_string = Properties.Settings.Default.DBCAMSConnectionString;
            List<int> uniqueChannelIds = new List<int>();

            // Ouvrir la connexion à la base de données
            using (SqlConnection cn_connection = new SqlConnection(cn_string))
            {
                cn_connection.Open();
                // Sélectionner les identifiants de canal distincts
                string sql_Text = "SELECT DISTINCT IdChannel FROM Mesure";

                using (SqlCommand cmd = new SqlCommand(sql_Text, cn_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Parcourir les résultats et ajouter les identifiants de canal à la liste
                        while (reader.Read())
                        {
                            if (reader["IdChannel"] != DBNull.Value)
                            {
                                int channelId = (int)reader["IdChannel"];
                                uniqueChannelIds.Add(channelId);
                            }
                        }
                    }
                }
            }

            // Retourner la liste des identifiants de canal uniques
            return uniqueChannelIds;
        }

        private void ChooseChanel_Click(object sender, EventArgs e)
        {
            // Récupérer les identifiants de canal uniques
            List<int> uniqueChannelIds = GetUniqueChannelIds();

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


        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}