using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace application
{
    public partial class addChercheursPage : Form
    {
        private SqlConnection connection; // Déclaration de la connexion à la base de données

        public addChercheursPage()
        {
            InitializeComponent();

            // Initialisation de la connexion à la base de données
            string connectionString = Properties.Settings.Default.DBCAMSConnectionString;
            connection = new SqlConnection(connectionString);
        }

        private void addChercheursPage_Load(object sender, EventArgs e)
        {
            LoadChercheursData();
        }


        private void AddChercheurButton_Click_1(object sender, EventArgs e)
        {
            // Afficher l'InputDialog pour que l'utilisateur entre un nom
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                string nomChercheur = inputDialog.GetInputValue(); // Récupérer le nom saisi par l'utilisateur

                // Ajouter le nom à la table Chercheurs dans la base de données
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Chercheur (Id, Nom) VALUES ((SELECT ISNULL(MAX(Id), 0) + 1 FROM Chercheur), @Nom);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nom", nomChercheur);
                        command.ExecuteNonQuery();
                    }

                    // Ajouter le nouveau nom à la ListBox
                    listBoxChercheurs.Items.Add(nomChercheur);

                    MessageBox.Show("Nom ajouté avec succès à la table Chercheurs.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout du nom à la table Chercheurs : " + ex.Message);
                }
                finally
                {

                    connection.Close();
                }
            }
        }
        private void LoadChercheursData()
        {
            try
            {
                connection.Open();
                string query = "SELECT Nom FROM Chercheur";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Vider la liste avant de charger de nouvelles données
                        listBoxChercheurs.Items.Clear();

                        // Lire chaque ligne de données
                        while (reader.Read())
                        {
                            // Ajouter le nom à la liste ListBox
                            listBoxChercheurs.Items.Add(reader["Nom"]);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors du chargement des noms de chercheurs : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void dataGridViewChercheurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 
        }

        private void deleteChercheurButton_Click(object sender, EventArgs e)
        {
            // Vérifiez d'abord si un élément est sélectionné dans le ListBox
            if (listBoxChercheurs.SelectedItem != null)
            {
                string nomChercheur = listBoxChercheurs.SelectedItem.ToString();

                try
                {
                    connection.Open();
                    string query = "DELETE FROM Chercheur WHERE Nom = @Nom";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nom", nomChercheur);
                        command.ExecuteNonQuery();
                    }

                    // Ajouter le nouveau nom à la ListBox
                    listBoxChercheurs.Items.Remove(nomChercheur);

                    MessageBox.Show("Nom supprimé avec succès de la table Chercheurs.");

                    // Rechargez les données après la suppression
                    LoadChercheursData();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors du chargement des noms de chercheurs : " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un nom à supprimer.");
            }
        }
    }
}
