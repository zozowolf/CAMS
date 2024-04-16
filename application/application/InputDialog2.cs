using System;
using System.Windows.Forms;
using System.Data.SqlClient; // SQL Server local DB

namespace application
{
    public partial class InputDialog2 : Form
    {
        private Label channelLabel;
        private NumericUpDown numericUpDown;
        private CheckBox globalCheckBox;
        private Label messageLabel;
        private TextBox textBox;
        private Button okButton;
        private DateTime currentDate;
        private Label chercheurLabel;
        private ComboBox chercheurComboBox;
        private string connectionString = Properties.Settings.Default.DBCAMSConnectionString;


        public InputDialog2()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            this.channelLabel = new Label();
            this.numericUpDown = new NumericUpDown();
            this.globalCheckBox = new CheckBox();
            this.messageLabel = new Label();
            this.textBox = new TextBox();
            this.okButton = new Button();

            // Configure Channel Label
            this.channelLabel.Location = new System.Drawing.Point(12, 20);
            this.channelLabel.Size = new System.Drawing.Size(200, 20);
            this.channelLabel.Text = "Channel concerné:";

            // Configure NumericUpDown
            this.numericUpDown.Location = new System.Drawing.Point(12, 50);
            this.numericUpDown.Size = new System.Drawing.Size(200, 20);
            this.numericUpDown.Minimum = 0;
            this.numericUpDown.Maximum = 100;

            // Configure Global CheckBox
            this.globalCheckBox.Location = new System.Drawing.Point(12, 80);
            this.globalCheckBox.Size = new System.Drawing.Size(100, 20);
            this.globalCheckBox.Text = "Message global";
            this.globalCheckBox.CheckedChanged += GlobalCheckBox_CheckedChanged;

            // Configure Message Label
            this.messageLabel.Location = new System.Drawing.Point(12, 110);
            this.messageLabel.Size = new System.Drawing.Size(200, 20);
            this.messageLabel.Text = "Message à rentrer:";

            // Configure TextBox
            this.textBox.Location = new System.Drawing.Point(12, 140);
            this.textBox.Size = new System.Drawing.Size(200, 20);

            // Configure OK Button
            this.okButton.Location = new System.Drawing.Point(12, 170);
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.Text = "OK";
            this.okButton.DialogResult = DialogResult.OK;
            this.okButton.Click += OkButton_Click;

            // Configure Chercheur Label
            this.chercheurLabel = new Label();
            this.chercheurLabel.Location = new System.Drawing.Point(12, 200);
            this.chercheurLabel.Size = new System.Drawing.Size(200, 20);
            this.chercheurLabel.Text = "Nom du chercheur:";

            // Configure Chercheur ComboBox
            this.chercheurComboBox = new ComboBox();
            this.chercheurComboBox.Location = new System.Drawing.Point(12, 230);
            this.chercheurComboBox.Size = new System.Drawing.Size(200, 20);
            this.chercheurComboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Pour rendre la liste déroulante non modifiable

            // Configure Form
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.channelLabel);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.globalCheckBox);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Signalement";
            this.ResumeLayout(false);

            // Appeler la méthode Load pour charger les noms de chercheurs
            LoadChercheurs();

            // Ajouter les contrôles au formulaire
            this.Controls.Add(this.chercheurLabel);
            this.Controls.Add(this.chercheurComboBox);
            this.Controls.Add(this.okButton);


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

        private void OkButton_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Now;
            this.Close(); // Close the dialog when OK button is clicked
        }

        public string GetTextValue()
        {
            return textBox.Text; // Return the value entered by the user
        }

        public int GetNbChannelValue()
        {
            return (int)numericUpDown.Value; // Return the value entered by the user
        }


        public bool IsGlobalMessage()
        {
            return globalCheckBox.Checked; // Return whether the global checkbox is checked
        }

        public DateTime GetCurrentDate()
        {
            return currentDate;
        }

        private void GlobalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable the numericUpDown based on the checked state of globalCheckBox
            numericUpDown.Enabled = !globalCheckBox.Checked;
        }
        public string GetNomChercheur()
        {
            return chercheurComboBox.SelectedItem?.ToString();
        }



    }
}
