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
/*! \mainpage CAMS
\author Antonin Froment, Enzo Da Cunha, Hugo Martin-Coché, Joris Vejux
\date 2024
\bug Aucun bug détecté à ce jour
\section intro_sec Introduction
Concevoir un système d'acquisition similaire à celui existant avec un matériel et un logiciel d'actualité permettant aussi quelques améliorations
\section install_sec Informations pour la mise en oeuvre
\subsection software_sec Informations logicielles
Le logiciel développé fonctionne dans l'environnement Windows
\subsection Informations Repartition des tâches
séparé en 4 partie le parametrage, les graphs, la base de données et les .DAT, module modbus et vpn 
 */

namespace application
{
    /*! \class Form1
    \brief Classe mainpage de l'application qui permet de lancer les autres fenetres et posséde un affichage de graph
    */
    public partial class Form1 : Form
    {
        private Timer timer;
        private List<Chart> charts = new List<Chart>();
        private int previousHour = -1;
        private int elapsedTime = 0;
        private int minutechrono = 60;
        private const int ChangeInterval = 30; // Intervalle en secondes pour changer les graphiques
        private const int ValueInterval = 60;
        private int currentChartIndex = 9; // Ajouter une variable pour suivre l'index du graphique actuel
        private int maxcharts = 2;
        SQL_command sqlCommand = new SQL_command();
        ModbusNum modbusnum = new ModbusNum();
        public Form1()
        {
            InitializeComponent();
            InitializeCharts();
            InitializeTimer();      
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
            for (int i = 0; i < maxcharts; i++) 
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
            chart.ChartAreas[0].AxisY.Maximum = 1500;
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
            chart.Series["Valeur"].IsValueShownAsLabel = true;
            chart.ChartAreas[0].AxisX.LineColor = Color.Red;
            chart.ChartAreas[0].AxisY.LineColor = Color.Red;


            // Ajouter un titre au graphique avec le numéro
            Title title = new Title($"Ch : {chartNumber}");
            title.Font = new Font("Arial", 18, FontStyle.Regular);
            title.Alignment = ContentAlignment.TopLeft;
            title.ForeColor = Color.Red;
            chart.Titles.Add(title);



        }

        private void UpdateChart(Chart chart)
        {
            // Réinitialiser les valeurs (temporaire en attendant la BD)
            chart.Series["Valeur"].Points.Clear();

            // Récupérer le numéro du graphique à partir du titre
            int currentChartNumber = int.Parse(chart.Titles[0].Text.Split(':')[1].Trim());

            Dictionary<int, double> valeursAgrégéesParHeure = sqlCommand.GetValeurheure(currentChartNumber);

            if (valeursAgrégéesParHeure.Count == 0)
            {
                // Masquer le graphique si aucune donnée n'est disponible
                chart.Visible = false;
            }
            else
            {
                chart.Visible = true;
                // Ajouter les valeurs agrégées au graphique
                foreach (var kvp in valeursAgrégéesParHeure)
                {
                    DataPoint dataPoint = new DataPoint();
                    dataPoint.SetValueXY(kvp.Key, kvp.Value);
                    chart.Series["Valeur"].Points.Add(dataPoint);
                }

                // Ajouter une ligne de séparation verticale à l'heure actuelle
                StripLine stripLine = new StripLine();
                stripLine.Interval = 0;
                stripLine.IntervalOffset = DateTime.Now.Hour;
                stripLine.StripWidth = 0.1; // Ajuster la largeur de la ligne de séparation selon vos besoins
                stripLine.BackColor = Color.White;

                chart.ChartAreas[0].AxisX.StripLines.Clear(); // Effacer les lignes de séparation existantes
                chart.ChartAreas[0].AxisX.StripLines.Add(stripLine);
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

            // Vérifier si le temps écoulé atteint l'intervalle de changement
            minutechrono++;
            if (minutechrono >= ValueInterval)
            {
                // Ajouter les valeurs dans la BD
                modbusnum.getNumValue();
                minutechrono = 0; // Réinitialiser le temps écoulé
            }
        }

        private void ChangeDisplayedCharts()
        {
            // Count the number of currently visible charts
            int visibleChartsCount = charts.Count(chart => chart.Visible);

            // Check if there are fewer than 9 visible charts
            if (visibleChartsCount < 9)
            {
                //Aucun changement des graphiques s'y en a pas assez
                return;
            }

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