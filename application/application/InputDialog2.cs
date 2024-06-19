using System;
using System.Windows.Forms;
using System.Data.SqlClient; // SQL Server local DB
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace application
{
    public partial class InputDialog2 : MaterialForm
    {
        private MaterialLabel channelLabel;
        private MaterialTextBox ChannelTextBox;
        private MaterialCheckbox globalCheckBox;
        private MaterialLabel messageLabel;
        private DateTime currentDate;
        SQL_command sqlCommand = new SQL_command();
        private string connectionString = Properties.Settings.Default.DBCAMSConnectionString;


        public InputDialog2()
        {
            InitializeComponent();
            

            // Appeler la méthode Load pour charger les noms de chercheurs
            LoadChercheurs();


        }


        private void LoadChercheurs()
        {
            // Assurez-vous d'avoir une instance de votre connexion à la base de données
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Nom FROM Chercheur";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Ajoutez chaque nom de chercheur à la liste déroulante
                            while (reader.Read())
                            {
                                chercheurComboBox.Items.Add(reader["Nom"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des noms de chercheurs : " + ex.Message);
                }
            }
        }


        public string GetTextValue()
        {
            return textBox.Text; // Return the value entered by the user
        }

        public int GetNbChannelValue()
        {
            int valeur;
            if (int.TryParse(ChannelTextBox.Text, out valeur))
            {
                return valeur; // Retourne la valeur convertie en entier si la conversion réussit
            }
            else
            {
                // Gestion du cas où l'entrée utilisateur n'est pas un nombre valide
                // Ici, vous pouvez retourner une valeur par défaut ou gérer l'erreur selon vos besoins
                MessageBox.Show("Veuillez entrer un nombre entier valide.");
                return 0; // Par exemple, retourner 0 en cas d'échec de la conversion
            }
        }

        public string GetNomChercheur()
        {
            return chercheurComboBox.SelectedItem?.ToString();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            bool isGlobal = globalCheckBox.Checked;
            string nomChercheur = chercheurComboBox.SelectedItem?.ToString();
            string message = textBox.Text;
            int idChannel;
            currentDate = DateTime.Now;

            int.TryParse(ChannelTextBox.Text, out idChannel);

            // si pas de chercheurs on met un string quand meme
            if (nomChercheur==null)
            {
                nomChercheur = "";
            }


            if (isGlobal) // on vérifie si la case message global est coché
                {  // si c'est le cas, le message concerne tout l'enregistrement, donc on met dans Event  
                    try
                    {
                        sqlCommand.AddValueToEvent(message, currentDate, nomChercheur);
                        MessageBox.Show("Message bien ajouté.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de l'ajout du message : " + ex.Message);
                    }
                }
                else
                {  // sinon on met dans alerte et c'est lié qu'à un channel en particulier
                    try
                    {
                        sqlCommand.AddValueToAlerte(idChannel, message, currentDate, nomChercheur);
                        MessageBox.Show("Message bien ajouté.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de l'ajout du message : " + ex.Message);
                    }
                }
            this.Close(); // Close the dialog when OK button is clicked
        }

        private void globalCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            ChannelTextBox.Enabled = !ChannelTextBox.Enabled;
        }
    }
}
