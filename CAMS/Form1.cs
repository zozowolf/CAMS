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
        public Form1()
        {
            InitializeComponent();
            InitializeChart();
            InitializeTimer();
        }

        private void InitializeChart()
        {
            // Données brut

            int[] valeur = { 8, 6, 7, 5, 9, 8, 4, 7, 8, 1, 6, 3, 7, 2, 4, 0 }; // Exemple de données 


            // Ajouter les données au graphique
            for (int i = 0; i < valeur.Length; i++)
            {
                chart1.Series["Valeur"].Points.AddXY("", valeur[i]);
            }

            // Configuration du graphique
            chart1.Series["Valeur"].ChartType = SeriesChartType.Column;

            // Facultatif : ajuster les limites de l'axe Y
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 10;

            // Rendre les valeurs des axes invisibles
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;

            // Rendre le fond du graphique transparent
            chart1.BackColor = Color.Transparent;
            chart1.ChartAreas[0].BackColor = Color.Transparent;

            // Rendre le quadrillage invisible
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // Changer la couleur de la série à rouge
            chart1.Series["Valeur"].Color = Color.Red;

            // Ajouter un titre au graphique
            Title title = new Title("Ch : 1");
            title.Font = new Font("Arial", 18, FontStyle.Regular); // Définir la police à Arial, taille 18
            title.Alignment = ContentAlignment.TopLeft; // Aligner en haut à gauche
            title.ForeColor = Color.Red; // Changer la couleur du titre en rouge
            chart1.Titles.Add(title);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

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
            // Mettre à jour le label avec l'heure et la date actuelles à chaque tick de timer
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}