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
    public partial class configurationModulePage : Form
    {

        SQL_command sqlCommand = new SQL_command();
        public configurationModulePage()
        {
            InitializeComponent();

            // Connecter les gestionnaires d'événements aux contrôles
            
            ipAddressMaskedTextBox.Mask = @"000\.000\.000\.000";
            ipAddressMaskedTextBox.TextChanged += Fields_TextChanged;

            masqueMaskedTextBox.Mask = @"000\.000\.000\.000";
            masqueMaskedTextBox.TextChanged += Fields_TextChanged;

            passerelleMaskedTextBox.Mask = @"000\.000\.000\.000";
            passerelleMaskedTextBox.TextChanged += Fields_TextChanged;

            nbEntreeSortieTextBox.TextChanged += Fields_TextChanged;
            typeModuleComboBox.SelectedIndexChanged += Fields_TextChanged;

            queryButton.Enabled = false;

        }

        private void configurationModulePage_Load(object sender, EventArgs e)
        {
            // Peupler le ComboBox avec les choix
            typeModuleComboBox.Items.Add("ET_7253");
            typeModuleComboBox.Items.Add("ET_7217");
        }

        private void typeModuleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vérifier si "Analogique" est sélectionné
            if (typeModuleComboBox.SelectedItem.ToString() == "ET_7253")
            {
                // Remplir automatiquement le champ nbEntreeSortieTextBox à 16
                nbEntreeSortieTextBox.Text = "16";

                // Désactiver la modification du champ nbEntreeSortieTextBox
                nbEntreeSortieTextBox.Enabled = false;
            }

            // Vérifier si "Numérique" est sélectionné
            if (typeModuleComboBox.SelectedItem.ToString() == "ET_7217")
            {
                // Remplir automatiquement le champ nbEntreeSortieTextBox à 16
                nbEntreeSortieTextBox.Text = "12";

                // Désactiver la modification du champ nbEntreeSortieTextBox
                nbEntreeSortieTextBox.Enabled = false;
            }
        }

        private void Fields_TextChanged(object sender, EventArgs e)
        {
            // Vérifier si tous les champs sont remplis
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(ipAddressMaskedTextBox.Text) &&
                                   !string.IsNullOrWhiteSpace(masqueMaskedTextBox.Text) &&
                                   !string.IsNullOrWhiteSpace(passerelleMaskedTextBox.Text) &&
                                   !string.IsNullOrWhiteSpace(nbEntreeSortieTextBox.Text) &&
                                   typeModuleComboBox.SelectedItem != null;

            // Activer ou désactiver le bouton en fonction de la vérification
            queryButton.Enabled = allFieldsFilled;
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            string adresseIp = ipAddressMaskedTextBox.Text;
            string masque = masqueMaskedTextBox.Text;
            string passerlle = passerelleMaskedTextBox.Text;
            string typeModule = typeModuleComboBox.Text;
            string nbES = nbEntreeSortieTextBox.Text;
            int.TryParse(nbES, out int nombreES);

            try
            {
                sqlCommand.AddValueToModule(adresseIp, masque, passerlle, typeModule, nombreES);
                MessageBox.Show("Ajout effectué.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout." + ex.Message);
            }        
        }
    }
}