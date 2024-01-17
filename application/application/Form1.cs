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

namespace application
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private List<Chart> charts = new List<Chart>();
        private int previousHour = -1;
        private int elapsedTime = 0;
        private const int ChangeInterval = 30; // Intervalle en secondes pour changer les graphiques
        private int currentChartIndex = 9; // Ajouter une variable pour suivre l'index du graphique actuel
        private int maxcharts = 18;

        public Form1()
        {
            InitializeComponent();
            InitializeCharts();
            InitializeTimer();
          
            Bounds = Screen.PrimaryScreen.Bounds; // Ajuster la taille de la fenêtre à la taille de l'écran

        }

        private void InitializeCharts()
        {
            // Utiliser un TableLayoutPanel pour organiser les graphiques
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.ColumnCount = 3;
            displayWindow.Controls.Add(tableLayoutPanel);

            // Créer plusieurs graphiques et les ajouter au TableLayoutPanel
            for (int i = 0; i < maxcharts; i++) // Changez 9 au nombre de graphiques que vous voulez afficher
            {
                Chart chart = new Chart();
                chart.Size = new Size(300, 150);
                charts.Add(chart);
                tableLayoutPanel.Controls.Add(chart);
                InitializeChart(chart, i + 1); // Ajouter le numéro du graphique
            }

            // Masquer les graphiques restants
            for (int i = 9; i < maxcharts; i++)
            {
                charts[i].Visible = false;
            }
        }

        private void InitializeChart(Chart chart, int chartNumber)
        {
            // Configuration du graphique
            Series series = new Series("Valeur");
            chart.Series.Add(series);

            // Ajuster les limites des l'axes 
            chart.ChartAreas.Add(new ChartArea());
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 26;

            // Rendre les valeurs des axes invisibles
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;

            // Rendre le fond du graphique transparent
            chart.BackColor = Color.Transparent;
            chart.ChartAreas[0].BackColor = Color.Transparent;

            // Rendre le quadrillage invisible
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // Changer la couleur de la série à rouge
            chart.Series["Valeur"].Color = Color.Red;
            chart.ChartAreas[0].AxisX.LineColor = Color.Red;
            chart.ChartAreas[0].AxisY.LineColor = Color.Red;

            // Ajouter un titre au graphique avec le numéro
            Title title = new Title($"Ch : {chartNumber}");
            title.Font = new Font("Arial", 18, FontStyle.Regular);
            title.Alignment = ContentAlignment.TopLeft;
            title.ForeColor = Color.Red;
            chart.Titles.Add(title);

            // Mettre à jour le graphique avec les valeurs
            UpdateChart(chart);
        }

        private void UpdateChart(Chart chart)
        {
            // Ajouter des données au graphique
            int[] Valeur = { 20, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 22, 250 };

            // Effacer les points existants
            chart.Series["Valeur"].Points.Clear();

            for (int i = 0; i < 24; i++)
            {
                // Vérifier l'heure actuelle pour charger les valeurs d'avant
                if (i < DateTime.Now.Hour || DateTime.Now.Hour == 0)
                {
                    DataPoint dataPoint = new DataPoint();
                    // Ajouter le point de données au graphique
                    dataPoint.SetValueXY("", Valeur[i]);
                    chart.Series["Valeur"].Points.Add(dataPoint);
                }

                if (i == 23)
                {
                    DataPoint dataPoint = new DataPoint();
                    // Changer la couleur de valeur en blanc pour l'heure actuelle
                    dataPoint.Color = Color.White;
                    dataPoint.SetValueXY("", 1);
                    chart.Series["Valeur"].Points.Add(dataPoint);
                }
            }
        }



        private void InitializeTimer()
        {
            // Initialiser le timer
            timer = new Timer();
            timer.Interval = 1000; // Intervalle en millisecondes (1 seconde)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Vérifier si l'heure actuelle a changé
            if (DateTime.Now.Hour != previousHour)
            {
                // Mettre à jour le graphique avec les nouvelles valeurs
                foreach (var chart in charts)
                {
                    UpdateChart(chart);
                }

                // Mettre à jour l'heure précédente
                previousHour = DateTime.Now.Hour;
            }

            // Mettre à jour le label avec l'heure et la date actuelles à chaque tick de timer
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblDateTime.ForeColor = Color.White;

            // Vérifier si le temps écoulé atteint l'intervalle de changement
            elapsedTime++;
            if (elapsedTime >= ChangeInterval)
            {
                // Changer les graphiques affichés
                ChangeDisplayedCharts();
                elapsedTime = 0; // Réinitialiser le temps écoulé
            }
        }

        private void ChangeDisplayedCharts()
        {
            // Masquer tous les graphiques
            foreach (var chart in charts)
            {
                chart.Visible = false;
            }

            // Afficher les 9 graphiques suivants à partir de l'index actuel
            for (int i = 0; i < 9; i++)
            {
                int indexToShow = (currentChartIndex + i) % charts.Count; // Assurer la circularité
                charts[indexToShow].Visible = true;
                UpdateChart(charts[indexToShow]); // Mettre à jour les valeurs du graphique affiché
            }

            // Mettre à jour l'index actuel
            currentChartIndex = (currentChartIndex + 9) % charts.Count;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    button1.PerformClick();
                    break;

                case Keys.A:
                    button2.PerformClick();
                    break;
                case Keys.S:
                    button3.PerformClick();
                    break;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // S'assurer que le formulaire capture les événements de touches

            // Associer l'événement KeyDown au formulaire
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void monBouton_Click(object sender, EventArgs e)
        {

        }

        private void monBouton_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            displayChannelsPage nouvelleForme = new displayChannelsPage();
            nouvelleForme.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actogramPage nouvelleForme = new actogramPage();
            nouvelleForme.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            systemInformationPage nouvelleForme = new systemInformationPage();
            nouvelleForme.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}