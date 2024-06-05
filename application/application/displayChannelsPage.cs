using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace application
{
    public partial class displayChannelsPage : Form
    {
        int page = 0;
        SQL_command sqlCommand = new SQL_command();
        int idEnregistrement = 1;
        public displayChannelsPage()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Définition du nombre de colonnes et de lignes
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 28;

            // Définir la couleur du fond du DataGridView en noir
            dataGridView1.DefaultCellStyle.BackColor = Color.Black;

            // Empêcher le redimensionnement des lignes et des colonnes
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

            // Masquer les en-têtes 
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            Color lightBlue = Color.FromArgb(49, 140, 231); // Valeur RGB pour bleu clair
            Color lightRed = Color.FromArgb(238, 16, 16); // Valeur RGB pour rouge clair

            // Définir la largeur des colonnes pour qu'elles occupent tout l'espace disponible
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Empêcher le tri des colonnes
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Aligner le contenu à gauche pour toutes les cellules
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Définir les colonnes en lecture seule
                dataGridView1.Columns[i].ReadOnly = true;
            }

            // Remplir les cellules avec des valeurs de test et définir la police d'écriture à 16
            dataGridView1.Font = new System.Drawing.Font("Arial", 16);
            dataGridView1.ReadOnly = true; // Empêcher la modification des cellules


            int currentChartNumber = 1 + page;
            // Remplir les cellules avec des valeurs de test
            for (int col = 0; col < dataGridView1.ColumnCount; col++)
            {
                for (int row = 0; row < dataGridView1.RowCount; row++)
                {
                    // Formater l'ID pour qu'il ait toujours la même longueur
                    string id = (currentChartNumber).ToString("D3");

                    if (sqlCommand.GetActivity(currentChartNumber, idEnregistrement))
                    {
                        //mettre en couleur rouge
                        int sommeheure = sqlCommand.Getheuredown(currentChartNumber, idEnregistrement);
                        dataGridView1[col, row].Value = $"{id} inactive {sommeheure} Hrs";
                        dataGridView1[col, row].Style.ForeColor = lightRed;
                    }
                    if (sqlCommand.GetType(currentChartNumber, idEnregistrement) == "Num")
                    {
                        int min = sqlCommand.GetLastValeurmin(currentChartNumber, idEnregistrement);
                        int heure = sqlCommand.GetLastValeurheure(currentChartNumber, idEnregistrement);
                        int jour = sqlCommand.GetLastValeurjour(currentChartNumber, idEnregistrement);

                        dataGridView1[col, row].Value = $"{id}   {min}   {heure}   {jour}";
                        dataGridView1[col, row].Style.ForeColor = lightBlue;
                    }
                    if (sqlCommand.GetType(currentChartNumber, idEnregistrement) == "Temp")
                    {
                        double temperature = sqlCommand.GetLastTemp(currentChartNumber, idEnregistrement);

                        dataGridView1[col, row].Value = $"{id}   {temperature}°C";
                        dataGridView1[col, row].Style.ForeColor = lightBlue;
                    }
                    if (sqlCommand.GetType(currentChartNumber, idEnregistrement) == "Lux")
                    {
                        double lumiere = sqlCommand.GetLastLux(currentChartNumber, idEnregistrement);

                        dataGridView1[col, row].Value = $"{id}   {lumiere} LUX";
                        dataGridView1[col, row].Style.ForeColor = lightBlue;
                    }


                    currentChartNumber++;
                }
            }
        }

        private void displayChannelsPage_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // S'assurer que le formulaire capture les événements de touches

            // Associer l'événement KeyDown au formulaire
            this.KeyDown += new KeyEventHandler(displayChannelsPage_KeyDown);
        }

        private void displayChannelsPage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.E:
                    Exit.PerformClick();
                    break;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void affichage_Tick(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void suivant_Click(object sender, EventArgs e)
        {
            if (page != 336)
            {
                page += 112;
                InitializeDataGridView();
            }
        }

        private void precedent_Click(object sender, EventArgs e)
        {
            if (page != 0)
            {
                page -= 112;
                InitializeDataGridView();
            }
        }
    }
}