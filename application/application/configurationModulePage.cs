using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace application
{
    public partial class configurationModulePage : MaterialForm
    {
        SQL_command sqlCommand = new SQL_command();
        private int filledFieldsCount = 0;
        private MaterialSkinManager materialSkinManager;
        private readonly int totalFields = 5;

        public configurationModulePage()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Optional: Set the color scheme
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE
            );

            // Connect event handlers to the controls
            materialIpAddressMaskedTextBox.Mask = @"000\.000\.000\.000";
            materialMasqueMaskedTextBox.Mask = @"000\.000\.000\.000";
            materialPasserelleMaskedTextBox.Mask = @"000\.000\.000\.000";

            materialIpAddressMaskedTextBox.TextChanged += Fields_TextChanged;
            materialMasqueMaskedTextBox.TextChanged += Fields_TextChanged;
            materialPasserelleMaskedTextBox.TextChanged += Fields_TextChanged;
            materialNbEntreeSortieTextBox.TextChanged += Fields_TextChanged;
            materialTypeModuleComboBox.SelectedIndexChanged += Fields_TextChanged;

            materialQueryButton.Enabled = false;
        }

        private void configurationModulePage_Load(object sender, EventArgs e)
        {
            // Populate ComboBox with choices
            materialTypeModuleComboBox.Items.Add("ET_7253");
            materialTypeModuleComboBox.Items.Add("ET_7217");

            // Configure the ProgressBar
            materialProgressBar1.Minimum = 0;
            materialProgressBar1.Maximum = totalFields;
            materialProgressBar1.Step = 1;
        }

        private void materialTypeModuleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTypeModuleComboBox.SelectedItem.ToString() == "ET_7253")
            {
                materialNbEntreeSortieTextBox.Text = "16";
                materialNbEntreeSortieTextBox.Enabled = false;
            }

            if (materialTypeModuleComboBox.SelectedItem.ToString() == "ET_7217")
            {
                materialNbEntreeSortieTextBox.Text = "12";
                materialNbEntreeSortieTextBox.Enabled = false;
            }

            UpdateProgress();
        }

        private void Fields_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            filledFieldsCount = 0;

            // Check if the fields are not the default masked values
            if (!IsDefaultMaskedText(materialIpAddressMaskedTextBox)) filledFieldsCount++;
            if (!IsDefaultMaskedText(materialMasqueMaskedTextBox)) filledFieldsCount++;
            if (!IsDefaultMaskedText(materialPasserelleMaskedTextBox)) filledFieldsCount++;
            if (!string.IsNullOrWhiteSpace(materialNbEntreeSortieTextBox.Text)) filledFieldsCount++;
            if (materialTypeModuleComboBox.SelectedItem != null) filledFieldsCount++;

            materialProgressBar1.Value = filledFieldsCount;
            materialQueryButton.Enabled = filledFieldsCount == totalFields;
        }

        private bool IsDefaultMaskedText(MaterialMaskedTextBox textBox)
        {
            return textBox.Text == textBox.Mask.Replace('0', ' ') || string.IsNullOrWhiteSpace(textBox.Text.Trim(new char[] { ' ', '.' }));
        }

        private void materialQueryButton_Click(object sender, EventArgs e)
        {
            string adresseIp = materialIpAddressMaskedTextBox.Text;
            string masque = materialMasqueMaskedTextBox.Text;
            string passerlle = materialPasserelleMaskedTextBox.Text;
            string typeModule = materialTypeModuleComboBox.Text;
            string nbES = materialNbEntreeSortieTextBox.Text;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
