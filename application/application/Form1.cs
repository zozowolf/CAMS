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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    button1.PerformClick();
                    break;

                case Keys.A:
                    button2.PerformClick();
                    break;
                case Keys.S:
                    button3.PerformClick();
                    break;
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // S'assurer que le formulaire capture les événements de touches

            // Associer l'événement KeyDown au formulaire
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void monBouton_Click(object sender, EventArgs e)
        {

        }

        private void monBouton_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            displayChannelsPage nouvelleForme = new displayChannelsPage();
            nouvelleForme.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actogramPage nouvelleForme = new actogramPage();
            nouvelleForme.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            systemInformationPage nouvelleForme = new systemInformationPage();
            nouvelleForme.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}