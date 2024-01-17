using System;
using System.Drawing;
using System.Windows.Forms;

public class MonBoutonPersonnalise1 : Button
{
    public MonBoutonPersonnalise1()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        // Efface le texte d'origine en le remplissant avec la couleur de fond du bouton
        pevent.Graphics.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);

        if (!string.IsNullOrEmpty(this.Text) && this.Text.Length >= 1)
        {
            Font regularFont = this.Font;
            Font boldFont = new Font(regularFont, FontStyle.Bold);

            // Dessine le premier caractère en gras
            string premierCaractere = this.Text.Substring(0, 1);
            string resteDuTexte = this.Text.Substring(1);

            // Mesure la taille du premier caractère pour placer le reste du texte à sa suite
            SizeF sizePremierCaractere = pevent.Graphics.MeasureString(premierCaractere, boldFont);
            PointF positionResteDuTexte = new PointF(sizePremierCaractere.Width, 0);

            // Sauvegarde la couleur d'origine pour restaurer après le rendu du texte
            Color ancienneCouleur = this.ForeColor;

            // Dessine le premier caractère en gras
            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                pevent.Graphics.DrawString(premierCaractere, boldFont, brush, new PointF(0, 0));
            }

            // Dessine le reste du texte avec la police régulière
            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                pevent.Graphics.DrawString(resteDuTexte, regularFont, brush, positionResteDuTexte);
            }

            // Restaure la couleur d'origine après le rendu du texte
            this.ForeColor = ancienneCouleur;
        }
    }
}
