
namespace application
{
    partial class configurationModulePage
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
            this.ipAdressLabel = new System.Windows.Forms.Label();
            this.ipAdressTextBox = new System.Windows.Forms.TextBox();
            this.maqueTextBox = new System.Windows.Forms.TextBox();
            this.maskLabel = new System.Windows.Forms.Label();
            this.passerelleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.typeModuleLabel = new System.Windows.Forms.Label();
            this.nbEntreeSortieTextBox = new System.Windows.Forms.TextBox();
            this.nbEntreeSortieLabel = new System.Windows.Forms.Label();
            this.typeModuleComboBox = new System.Windows.Forms.ComboBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipAdressLabel
            // 
            this.ipAdressLabel.AutoSize = true;
            this.ipAdressLabel.Location = new System.Drawing.Point(12, 37);
            this.ipAdressLabel.Name = "ipAdressLabel";
            this.ipAdressLabel.Size = new System.Drawing.Size(64, 13);
            this.ipAdressLabel.TabIndex = 0;
            this.ipAdressLabel.Text = "Adresse IP :";
            // 
            // ipAdressTextBox
            // 
            this.ipAdressTextBox.Location = new System.Drawing.Point(92, 34);
            this.ipAdressTextBox.Name = "ipAdressTextBox";
            this.ipAdressTextBox.Size = new System.Drawing.Size(149, 20);
            this.ipAdressTextBox.TabIndex = 1;
            // 
            // maqueTextBox
            // 
            this.maqueTextBox.Location = new System.Drawing.Point(92, 92);
            this.maqueTextBox.Name = "maqueTextBox";
            this.maqueTextBox.Size = new System.Drawing.Size(149, 20);
            this.maqueTextBox.TabIndex = 3;
            // 
            // maskLabel
            // 
            this.maskLabel.AutoSize = true;
            this.maskLabel.Location = new System.Drawing.Point(12, 95);
            this.maskLabel.Name = "maskLabel";
            this.maskLabel.Size = new System.Drawing.Size(51, 13);
            this.maskLabel.TabIndex = 2;
            this.maskLabel.Text = "Masque :";
            // 
            // passerelleTextBox
            // 
            this.passerelleTextBox.Location = new System.Drawing.Point(92, 147);
            this.passerelleTextBox.Name = "passerelleTextBox";
            this.passerelleTextBox.Size = new System.Drawing.Size(149, 20);
            this.passerelleTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Passerelle :";
            // 
            // typeModuleLabel
            // 
            this.typeModuleLabel.AutoSize = true;
            this.typeModuleLabel.Location = new System.Drawing.Point(12, 207);
            this.typeModuleLabel.Name = "typeModuleLabel";
            this.typeModuleLabel.Size = new System.Drawing.Size(74, 13);
            this.typeModuleLabel.TabIndex = 6;
            this.typeModuleLabel.Text = "Type module :";
            // 
            // nbEntreeSortieTextBox
            // 
            this.nbEntreeSortieTextBox.Location = new System.Drawing.Point(92, 262);
            this.nbEntreeSortieTextBox.Name = "nbEntreeSortieTextBox";
            this.nbEntreeSortieTextBox.Size = new System.Drawing.Size(149, 20);
            this.nbEntreeSortieTextBox.TabIndex = 9;
            // 
            // nbEntreeSortieLabel
            // 
            this.nbEntreeSortieLabel.AutoSize = true;
            this.nbEntreeSortieLabel.Location = new System.Drawing.Point(12, 265);
            this.nbEntreeSortieLabel.Name = "nbEntreeSortieLabel";
            this.nbEntreeSortieLabel.Size = new System.Drawing.Size(72, 13);
            this.nbEntreeSortieLabel.TabIndex = 8;
            this.nbEntreeSortieLabel.Text = "Nombre E/S :";
            // 
            // typeModuleComboBox
            // 
            this.typeModuleComboBox.FormattingEnabled = true;
            this.typeModuleComboBox.Location = new System.Drawing.Point(93, 204);
            this.typeModuleComboBox.Name = "typeModuleComboBox";
            this.typeModuleComboBox.Size = new System.Drawing.Size(148, 21);
            this.typeModuleComboBox.TabIndex = 10;
            this.typeModuleComboBox.SelectedIndexChanged += new System.EventHandler(this.typeModuleComboBox_SelectedIndexChanged);
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(15, 354);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(245, 23);
            this.queryButton.TabIndex = 11;
            this.queryButton.Text = "Ajouter à la Base de données";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // configurationModulePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.typeModuleComboBox);
            this.Controls.Add(this.nbEntreeSortieTextBox);
            this.Controls.Add(this.nbEntreeSortieLabel);
            this.Controls.Add(this.typeModuleLabel);
            this.Controls.Add(this.passerelleTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maqueTextBox);
            this.Controls.Add(this.maskLabel);
            this.Controls.Add(this.ipAdressTextBox);
            this.Controls.Add(this.ipAdressLabel);
            this.Name = "configurationModulePage";
            this.Text = "configurationModulePage";
            this.Load += new System.EventHandler(this.configurationModulePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipAdressLabel;
        private System.Windows.Forms.TextBox ipAdressTextBox;
        private System.Windows.Forms.TextBox maqueTextBox;
        private System.Windows.Forms.Label maskLabel;
        private System.Windows.Forms.TextBox passerelleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label typeModuleLabel;
        private System.Windows.Forms.TextBox nbEntreeSortieTextBox;
        private System.Windows.Forms.Label nbEntreeSortieLabel;
        private System.Windows.Forms.ComboBox typeModuleComboBox;
        private System.Windows.Forms.Button queryButton;
    }
}