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
    public partial class recordingIntervalPage : Form
    {

        int maVariable;
        public recordingIntervalPage()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            label1.Location = new Point( (this.ClientSize.Width - label1.Width) / 2, 9);
            label2.Location = new Point(((this.ClientSize.Width - label2.Width) / 2), 150);
            label4.Location = new Point(((this.ClientSize.Width - label4.Width) / 2 ) + 170, 150);
            maVariable = 0;
            label4.Text = maVariable.ToString();
            CentrerBoutonAuMilieu(button1);
        }

        private void recordingIntervalPage_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Afficher la boîte de dialogue de saisie de valeur
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                // Récupérer la valeur saisie par l'utilisateur
                string valeurSaisie = inputDialog.GetInputValue();

                // Stocker la valeur saisie dans votre code

                maVariable = int.Parse(valeurSaisie);
            }
            label4.Text = maVariable.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CentrerBoutonAuMilieu(Button b)
        {
            // Récupérer les dimensions de la page (formulaire)
            int largeurPage = this.ClientSize.Width;
            int hauteurPage = this.ClientSize.Height;

            // Récupérer les dimensions du label
            int largeurLabel = b.Width;
            int hauteurLabel = b.Height;

            // Calculer la position X du label au centre de la page
            int positionXLabel = (largeurPage - largeurLabel) / 2;

            // Calculer la position Y du label au centre de la page
            int positionYLabel = (hauteurPage - hauteurLabel) / 2;

            // Définir la position du label
            b.Location = new Point(positionXLabel, positionYLabel);
        }

    }
}
