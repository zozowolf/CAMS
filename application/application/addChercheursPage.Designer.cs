
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
            this.listBoxChercheurs = new System.Windows.Forms.ListBox();
            this.addChercheurButton = new MaterialSkin.Controls.MaterialButton();
            this.deleteChercheurButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // listBoxChercheurs
            // 
            this.listBoxChercheurs.FormattingEnabled = true;
            this.listBoxChercheurs.Location = new System.Drawing.Point(18, 193);
            this.listBoxChercheurs.Name = "listBoxChercheurs";
            this.listBoxChercheurs.Size = new System.Drawing.Size(776, 251);
            this.listBoxChercheurs.TabIndex = 1;
            // 
            // addChercheurButton
            // 
            this.addChercheurButton.AllowDrop = true;
            this.addChercheurButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addChercheurButton.AutoSize = false;
            this.addChercheurButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addChercheurButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.addChercheurButton.Depth = 0;
            this.addChercheurButton.HighEmphasis = true;
            this.addChercheurButton.Icon = null;
            this.addChercheurButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addChercheurButton.Location = new System.Drawing.Point(18, 83);
            this.addChercheurButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addChercheurButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addChercheurButton.Name = "addChercheurButton";
            this.addChercheurButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.addChercheurButton.Size = new System.Drawing.Size(336, 72);
            this.addChercheurButton.TabIndex = 0;
            this.addChercheurButton.Text = "Add a researcher";
            this.addChercheurButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.addChercheurButton.UseAccentColor = false;
            this.addChercheurButton.UseVisualStyleBackColor = true;
            this.addChercheurButton.Click += new System.EventHandler(this.AddChercheurButton_Click_1);
            // 
            // deleteChercheurButton
            // 
            this.deleteChercheurButton.AutoSize = false;
            this.deleteChercheurButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteChercheurButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.deleteChercheurButton.Depth = 0;
            this.deleteChercheurButton.HighEmphasis = true;
            this.deleteChercheurButton.Icon = null;
            this.deleteChercheurButton.Location = new System.Drawing.Point(409, 83);
            this.deleteChercheurButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.deleteChercheurButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.deleteChercheurButton.Name = "deleteChercheurButton";
            this.deleteChercheurButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.deleteChercheurButton.Size = new System.Drawing.Size(374, 72);
            this.deleteChercheurButton.TabIndex = 2;
            this.deleteChercheurButton.Text = "Delete a researcher";
            this.deleteChercheurButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.deleteChercheurButton.UseAccentColor = false;
            this.deleteChercheurButton.UseVisualStyleBackColor = true;
            this.deleteChercheurButton.Click += new System.EventHandler(this.deleteChercheurButton_Click);
            // 
            // addChercheursPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteChercheurButton);
            this.Controls.Add(this.addChercheurButton);
            this.Controls.Add(this.listBoxChercheurs);
            this.Name = "addChercheursPage";
            this.Text = "Researchers";
            this.Load += new System.EventHandler(this.addChercheursPage_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxChercheurs;
        private MaterialSkin.Controls.MaterialButton addChercheurButton;
        private MaterialSkin.Controls.MaterialButton deleteChercheurButton;
    }
}