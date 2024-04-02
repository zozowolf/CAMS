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

            // Définir la largeur des colonnes pour qu'elles occupent tout l'espace disponible
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Empêcher le tri des colonnes
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                // Aligner le contenu à gauche pour toutes les cellules
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            // Remplir les cellules avec des valeurs de test et définir la police d'écriture à 16
            dataGridView1.Font = new System.Drawing.Font("Arial", 16);
            dataGridView1.ReadOnly = true; // Empêcher la modification des cellules

            // Remplir les cellules avec des valeurs de test
            for (int col = 0; col < dataGridView1.ColumnCount; col++)
            {
                for (int row = 0; row < dataGridView1.RowCount; row++)
                {
                    // Formater l'ID pour qu'il ait toujours la même longueur
                    string id = (row * dataGridView1.ColumnCount + col + 1).ToString("D3");

                    dataGridView1[col, row].Value = $"{id}   {0}   {0}   {0}";
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

        private void timerDate_Tick(object sender, EventArgs e)
        {
            // Mettre à jour le label avec l'heure et la date actuelles à chaque tick de timer
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblDateTime.ForeColor = Color.White;
        }
    }
}