using System;
using System.Windows.Forms;

namespace application
{
    public partial class DialogEvent : Form
    {
        private TextBox textBox;
        private Button okButton;
        private CheckBox checkBox; // Ajout de la CheckBox

        public DialogEvent()
        {
            InitializeComponent();
            this.textBox = new TextBox();
            this.okButton = new Button();
            this.checkBox = new CheckBox(); // Initialisation de la CheckBox

            // Configure TextBox
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Size = new System.Drawing.Size(200, 20);

            // Configure OK Button
            this.okButton.Location = new System.Drawing.Point(12, 68);
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.Text = "OK";
            this.okButton.DialogResult = DialogResult.OK;
            this.okButton.Click += OkButton_Click;

            // Configure CheckBox
            this.checkBox.Location = new System.Drawing.Point(12, 38);
            this.checkBox.Size = new System.Drawing.Size(200, 24);
            this.checkBox.Text = "Message global";

            // Configure Form
            this.ClientSize = new System.Drawing.Size(224, 103);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.checkBox); // Ajout de la CheckBox au formulaire
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Input Dialog";
        }

        private void DialogEvent_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme la fenêtre de dialogue lorsque le bouton OK est cliqué
        }

        public string GetInputValue()
        {
            return textBox.Text; // Renvoie la valeur saisie par l'utilisateur
        }

        // Ajout d'une propriété publique pour obtenir l'état de la case à cocher
        public bool IsGlobalMessageSelected()
        {
            return checkBox.Checked;
        }
    }
}
