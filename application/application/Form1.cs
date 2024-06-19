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
        int idEnregistrement = 1;
        private List<Chart> charts = new List<Chart>();
        private int maxcharts = 500;
        private bool FirstExecute = false;
        SQL_command sqlCommand = new SQL_command();
        ModbusNum modbusnum = new ModbusNum();

        public Form1()
        {

            InitializeComponent();
            InitializeCharts();
            RéorganiserBoutons();
            if (!FirstExecute)
            {
                FirstExecute = true;
                // Module mise a zero
                //modbusnum.RAZ();
                // Mettre à jour le graphique avec les nouvelles valeurs
                foreach (var chart in charts)
                {
                    UpdateChart(chart);
                }
            }
        }

        private void RéorganiserBoutons()
        {

            // Calculer la largeur et la hauteur d'un bouton pour remplir le FlowLayoutPanel
            int largeurBouton = optionMenu.ClientSize.Width / 7;
            int hauteurBouton = optionMenu.ClientSize.Height / 3;

            // Redimensionner chaque bouton
            foreach (Button bouton in optionMenu.Controls)
            {
                bouton.Width = largeurBouton;
                bouton.Height = hauteurBouton;
            }
        }

        private void InitializeCharts()
        {
            // Créer plusieurs graphiques et les ajouter au TableLayoutPanel
            for (int i = 0; i < maxcharts; i++)
            {
                Chart chart = new Chart();
                chart.Size = new System.Drawing.Size((displayWindow.Width / 3) - 30, (displayWindow.Height / 3) - 15);
                charts.Add(chart);
                displayWindow.Controls.Add(chart);
                InitializeChart(chart, i + 1); // Ajouter le numéro du graphique
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

            chart.ChartAreas[0].AxisX.LineColor = Color.Red;
            chart.ChartAreas[0].AxisY.LineColor = Color.Red;

            // Ajouter un titre au graphique avec le numéro
            Title title = new Title($"Ch : {chartNumber}");
            title.Font = new Font("Arial", 16, FontStyle.Regular);
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

            Dictionary<int, double> valeursAgrégéesParHeure = sqlCommand.GetValeurheure(currentChartNumber, idEnregistrement);

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



        private void timerHeure_Tick(object sender, EventArgs e)
        {
            // Mettre à jour le graphique avec les nouvelles valeurs
            foreach (var chart in charts)
            {
                UpdateChart(chart);
            }
        }

        private void timerMinute_Tick(object sender, EventArgs e)
        {
            // Ajouter les valeurs dans la BD
            modbusnum.getNumValue();
            modbusnum.getNumValueTOR();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    displayChannelButton.PerformClick();
                    break;
                case Keys.A:
                    actogramButton.PerformClick();
                    break;
                case Keys.S:
                    systemInformationButton.PerformClick();
                    break;
                case Keys.C:
                    channelDefinitionButton.PerformClick();
                    break;
                case Keys.R:
                    recordingIntervalButton.PerformClick();
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

        private void displayChannelButton_Click(object sender, EventArgs e)
        {
            displayChannelsPage nouvelleForme = new displayChannelsPage();
            nouvelleForme.Show();
        }

        private void actogramButton_Click(object sender, EventArgs e)
        {
            actogramPage nouvelleForme = new actogramPage();
            nouvelleForme.Show();
        }

        private void systemInformationButton_Click(object sender, EventArgs e)
        {
            systemInformationPage nouvelleForme = new systemInformationPage();
            nouvelleForme.Show();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
        }

        private void lightControlsButton_Click(object sender, EventArgs e)
        {
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void channelDefinitionButton_Click(object sender, EventArgs e)
        {
            channelDefinitionPage nouvelleForme = new channelDefinitionPage();
            if (nouvelleForme != null)
            {
                nouvelleForme.Show();
            }
            else
            {
                MessageBox.Show("La nouvelle forme est null.");
            }
        }

        private void recordingIntervalButton_Click(object sender, EventArgs e)
        {
            recordingIntervalPage nouvelleForme = new recordingIntervalPage();
            nouvelleForme.Show();
        }

        private void inactivityCheckButton_Click(object sender, EventArgs e)
        {
        }

        private void fileManagementButton_Click(object sender, EventArgs e)
        {
        }

        private void researcherButton_Click(object sender, EventArgs e)
        {
            addChercheursPage nouvelleForme = new addChercheursPage();
            if (nouvelleForme != null)
            {
                nouvelleForme.Show();
            }
            else
            {
                MessageBox.Show("La nouvelle forme est null.");
            }
        }

        private void configurationModulesButton_Click(object sender, EventArgs e)
        {
            configurationModulePage nouvelleForme = new configurationModulePage();
            if (nouvelleForme != null)
            {
                nouvelleForme.Show();
            }
            else
            {
                MessageBox.Show("La nouvelle forme est null.");
            }
        }
    }
}