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
    public partial class channelDefinitionPage : Form
    {



        private DataTable dataTable;
        private BindingSource bindingSource;


        public channelDefinitionPage()
        {


            InitializeComponent();
            Bounds = Screen.PrimaryScreen.Bounds; // plein écran

                
            // Créer une DataTable
            dataTable = new DataTable();

            // Ajouter des colonnes à la DataTable
            dataTable.Columns.Add("No", typeof(int));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("Group", typeof(string));
            dataTable.Columns.Add("Comments", typeof(string));

            // Ajouter une colonne de ComboBox
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.Name = "Type";
            comboBoxColumn.HeaderText = "Type";
            comboBoxColumn.DataSource = GetListeChoix(); // Méthode pour obtenir la liste des choix
            comboBoxColumn.DataPropertyName = "NomDeLaColonneDansDataTable"; // Assurez-vous que cela correspond à votre DataTable
            dataGridView1.Columns.Add(comboBoxColumn);

            AjouterDonneesFactices();

            // Initialiser le BindingSource
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            // Lier le DataGridView au BindingSource
            dataGridView1.DataSource = bindingSource;

            dataGridView1.Columns["Comments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Comments"].FillWeight = 1;




        }

        // Méthode pour ajouter des données factices pour les tests
        private void AjouterDonneesFactices()
        {
            // Ajouter des lignes avec des valeurs factices
            for (int i = 1; i <= 10; i++)
            {
                // creer ligne
                DataRow newRow = dataTable.NewRow();

                // on met des valeurs pour chaque colonne
                newRow["No"] = i;
                newRow["Type"] = "Wheel";
                newRow["Group"] = "";
                newRow["Comments"] = "10/14 LD Cycle";

                // on ajoute a la grid
                dataTable.Rows.Add(newRow);
            }
        }

        private DataTable GetListeChoix()
        {
            DataTable choixTable = new DataTable();
            choixTable.Columns.Add("Choix", typeof(string));

            // Ajoutez les choix spécifiques
            choixTable.Rows.Add("Wheel");
            choixTable.Rows.Add("Option 2");
            choixTable.Rows.Add("Option 3");
            // Ajoutez d'autres choix selon vos besoins

            return choixTable;
        }

        private void channelDefinitionPage_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is ArgumentException && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                // Gérer l'erreur liée à la colonne ComboBox
                DataGridViewComboBoxCell comboCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;

                if (comboCell != null)
                {
                    object cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Valider manuellement la valeur de la cellule ComboBox
                    if (!comboCell.Items.Contains(cellValue))
                    {
                        MessageBox.Show("La valeur sélectionnée dans la colonne ComboBox n'est pas valide.", "Erreur de données", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Annuler la validation manuelle
                        dataGridView1.CancelEdit();
                    }
                }
                else
                {
                    // Traiter d'autres cas d'erreur
                    MessageBox.Show($"Une erreur s'est produite : {e.Exception.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Annuler l'erreur pour éviter que la boîte de dialogue par défaut ne soit affichée
                e.ThrowException = false;
                e.Cancel = true;
            }
        }



    }
}
