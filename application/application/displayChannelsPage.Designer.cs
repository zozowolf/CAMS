
namespace application
{
    partial class displayChannelsPage
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
            this.components = new System.ComponentModel.Container();
            this.Exit = new System.Windows.Forms.Button();
            this.timerDate = new System.Windows.Forms.Timer(this.components);
            this.lblDateTime = new System.Windows.Forms.Label();
            this.dBCAMSDataSet = new application.DBCAMSDataSet();
            this.dBCAMSDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.affichage = new System.Windows.Forms.Timer(this.components);
            this.suivant = new System.Windows.Forms.Button();
            this.precedent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dBCAMSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCAMSDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Exit.Location = new System.Drawing.Point(1783, 641);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 5;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // timerDate
            // 
            this.timerDate.Enabled = true;
            this.timerDate.Interval = 1000;
            this.timerDate.Tick += new System.EventHandler(this.timerDate_Tick);
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(869, 943);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(110, 20);
            this.lblDateTime.TabIndex = 6;
            this.lblDateTime.Text = "Date et Heure";
            // 
            // dBCAMSDataSet
            // 
            this.dBCAMSDataSet.DataSetName = "DBCAMSDataSet";
            this.dBCAMSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dBCAMSDataSetBindingSource
            // 
            this.dBCAMSDataSetBindingSource.DataSource = this.dBCAMSDataSet;
            this.dBCAMSDataSetBindingSource.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(264, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1081, 636);
            this.dataGridView1.TabIndex = 7;
            // 
            // affichage
            // 
            this.affichage.Enabled = true;
            this.affichage.Interval = 60000;
            this.affichage.Tick += new System.EventHandler(this.affichage_Tick);
            // 
            // suivant
            // 
            this.suivant.Location = new System.Drawing.Point(1756, 366);
            this.suivant.Name = "suivant";
            this.suivant.Size = new System.Drawing.Size(75, 43);
            this.suivant.TabIndex = 8;
            this.suivant.Text = "suivant";
            this.suivant.UseVisualStyleBackColor = true;
            this.suivant.Click += new System.EventHandler(this.suivant_Click);
            // 
            // precedent
            // 
            this.precedent.Location = new System.Drawing.Point(1570, 366);
            this.precedent.Name = "precedent";
            this.precedent.Size = new System.Drawing.Size(75, 43);
            this.precedent.TabIndex = 9;
            this.precedent.Text = "precedent";
            this.precedent.UseVisualStyleBackColor = true;
            this.precedent.Click += new System.EventHandler(this.precedent_Click);
            // 
            // displayChannelsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.precedent);
            this.Controls.Add(this.suivant);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.Exit);
            this.Name = "displayChannelsPage";
            this.Text = "displayChannelsPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.displayChannelsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dBCAMSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCAMSDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Timer timerDate;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.BindingSource dBCAMSDataSetBindingSource;
        private DBCAMSDataSet dBCAMSDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer affichage;
        private System.Windows.Forms.Button suivant;
        private System.Windows.Forms.Button precedent;
    }
}