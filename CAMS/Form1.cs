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

namespace CAMS
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private Chart chart;
        private int previousHour = -1;
        public Form1()
        {
            InitializeComponent();
            InitializeChart();
            InitializeTimer();
        }

        private void InitializeChart()
        {
            // Créer un nouveau graphique
            chart = new Chart();
            chart.Size = new Size(400, 200); // 400 largeur et 200 hauteur
            this.Controls.Add(chart);

            // Configuration du graphique
            Series series = new Series("Valeur");
            chart.Series.Add(series);

            // Ajuster les limites des l'axes 
            chart.ChartAreas.Add(new ChartArea());
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 250;
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

            // Ajouter un titre au graphique
            Title title = new Title("Ch : 1");
            title.Font = new Font("Arial", 18, FontStyle.Regular); // Définir la police à Arial, taille 18
            title.Alignment = ContentAlignment.TopLeft; // Aligner en haut à gauche
            title.ForeColor = Color.Red; // Changer la couleur du titre en rouge
            chart.Titles.Add(title);

            // Mettre à jour le graphique avec les valeurs 
            UpdateChart();
        }

        private void UpdateChart()
        {
            // Ajouter des données au graphique
            int[] Valeur = { 20, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 22, 250 };

            // Effacer les points existant
            chart.Series["Valeur"].Points.Clear();

            for (int i = 0; i < 24; i++)
            {
                // Vérifier l'heure actuel pour charger les valeurs d'avant

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
                    // Changer la couleur de valeur en blanc pour l'heure actuel
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
                UpdateChart();

                // Mettre à jour l'heure précédente
                previousHour = DateTime.Now.Hour;
            }
            // Mettre à jour le label avec l'heure et la date actuelles à chaque tick de timer
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblDateTime.ForeColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
