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
    public partial class InputDialog : Form
    {

        private TextBox textBox;
        private Button okButton;
        public InputDialog()
        {
            InitializeComponent();
            this.textBox = new TextBox();
            this.okButton = new Button();

            // Configure TextBox
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Size = new System.Drawing.Size(200, 20);

            // Configure OK Button
            this.okButton.Location = new System.Drawing.Point(12, 40);
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.Text = "OK";
            this.okButton.DialogResult = DialogResult.OK;
            this.okButton.Click += OkButton_Click;
            // Configure Form
            this.ClientSize = new System.Drawing.Size(224, 75);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Input Dialog";
            this.ResumeLayout(false);

            // Gestion de l'événement KeyDown
            this.KeyPreview = true; // Active la réception des événements de touche par le formulaire
            this.KeyDown += InputDialog_KeyDown;
        }

        private void InputDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Vérifie si la touche enfoncée est "Entrée"
            {
                e.Handled = true; // Empêche la touche d'être traitée par les contrôles enfants
                okButton.PerformClick();

            }
        }


        private void InputDialog_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {

            this.Close(); // Close the dialog when OK button is clicked
        }

        public string GetInputValue()
        {
            return textBox.Text; // Return the value entered by the user
        }

    }
}