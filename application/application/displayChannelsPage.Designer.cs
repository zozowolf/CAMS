
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
            this.dBCAMSDataSet = new application.DBCAMSDataSet();
            this.dBCAMSDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.affichage = new System.Windows.Forms.Timer(this.components);
            this.Exit = new FontAwesome.Sharp.IconButton();
            this.previous = new FontAwesome.Sharp.IconButton();
            this.suivant = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dBCAMSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCAMSDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(29, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1841, 619);
            this.dataGridView1.TabIndex = 7;
            // 
            // affichage
            // 
            this.affichage.Enabled = true;
            this.affichage.Interval = 60000;
            this.affichage.Tick += new System.EventHandler(this.affichage_Tick);
            // 
            // Exit
            // 
            this.Exit.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromBracket;
            this.Exit.IconColor = System.Drawing.Color.Black;
            this.Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Exit.IconSize = 80;
            this.Exit.Location = new System.Drawing.Point(932, 905);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(76, 79);
            this.Exit.TabIndex = 13;
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // previous
            // 
            this.previous.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.previous.IconColor = System.Drawing.Color.Black;
            this.previous.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.previous.IconSize = 100;
            this.previous.Location = new System.Drawing.Point(744, 694);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(212, 114);
            this.previous.TabIndex = 14;
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // suivant
            // 
            this.suivant.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.suivant.IconColor = System.Drawing.Color.Black;
            this.suivant.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.suivant.IconSize = 100;
            this.suivant.Location = new System.Drawing.Point(988, 694);
            this.suivant.Name = "suivant";
            this.suivant.Size = new System.Drawing.Size(213, 114);
            this.suivant.TabIndex = 15;
            this.suivant.UseVisualStyleBackColor = true;
            this.suivant.Click += new System.EventHandler(this.suivant_Click);
            // 
            // displayChannelsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.suivant);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.dataGridView1);
            this.Name = "displayChannelsPage";
            this.Text = "displayChannelsPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.displayChannelsPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dBCAMSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCAMSDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dBCAMSDataSetBindingSource;
        private DBCAMSDataSet dBCAMSDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer affichage;
        private FontAwesome.Sharp.IconButton Exit;
        private FontAwesome.Sharp.IconButton previous;
        private FontAwesome.Sharp.IconButton suivant;
    }
}