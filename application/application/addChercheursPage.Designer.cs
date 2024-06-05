
namespace application
{
    partial class addChercheursPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddChercheurButton = new System.Windows.Forms.Button();
            this.listBoxChercheurs = new System.Windows.Forms.ListBox();
            this.deleteChercheurButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddChercheurButton
            // 
            this.AddChercheurButton.Location = new System.Drawing.Point(44, 159);
            this.AddChercheurButton.Name = "AddChercheurButton";
            this.AddChercheurButton.Size = new System.Drawing.Size(229, 23);
            this.AddChercheurButton.TabIndex = 0;
            this.AddChercheurButton.Text = "Ajouter un chercheur";
            this.AddChercheurButton.UseVisualStyleBackColor = true;
            this.AddChercheurButton.Click += new System.EventHandler(this.AddChercheurButton_Click_1);
            // 
            // listBoxChercheurs
            // 
            this.listBoxChercheurs.FormattingEnabled = true;
            this.listBoxChercheurs.Location = new System.Drawing.Point(472, 33);
            this.listBoxChercheurs.Name = "listBoxChercheurs";
            this.listBoxChercheurs.Size = new System.Drawing.Size(277, 368);
            this.listBoxChercheurs.TabIndex = 1;
            // 
            // deleteChercheurButton
            // 
            this.deleteChercheurButton.Location = new System.Drawing.Point(44, 233);
            this.deleteChercheurButton.Name = "deleteChercheurButton";
            this.deleteChercheurButton.Size = new System.Drawing.Size(229, 23);
            this.deleteChercheurButton.TabIndex = 2;
            this.deleteChercheurButton.Text = "Supprimer un chercheur";
            this.deleteChercheurButton.UseVisualStyleBackColor = true;
            this.deleteChercheurButton.Click += new System.EventHandler(this.deleteChercheurButton_Click);
            // 
            // addChercheursPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteChercheurButton);
            this.Controls.Add(this.listBoxChercheurs);
            this.Controls.Add(this.AddChercheurButton);
            this.Name = "addChercheursPage";
            this.Text = "addChercheursPage";
            this.Load += new System.EventHandler(this.addChercheursPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddChercheurButton;
        private System.Windows.Forms.ListBox listBoxChercheurs;
        private System.Windows.Forms.Button deleteChercheurButton;
    }
}