
namespace application
{
    partial class actogramPage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Startdate = new System.Windows.Forms.Label();
            this.Enddate = new System.Windows.Forms.Label();
            this.ChooseChanel = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(115, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1600, 828);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Startdate
            // 
            this.Startdate.AutoSize = true;
            this.Startdate.Location = new System.Drawing.Point(13, 107);
            this.Startdate.Name = "Startdate";
            this.Startdate.Size = new System.Drawing.Size(50, 13);
            this.Startdate.TabIndex = 1;
            this.Startdate.Text = "Startdate";
            // 
            // Enddate
            // 
            this.Enddate.AutoSize = true;
            this.Enddate.Location = new System.Drawing.Point(13, 899);
            this.Enddate.Name = "Enddate";
            this.Enddate.Size = new System.Drawing.Size(47, 13);
            this.Enddate.TabIndex = 2;
            this.Enddate.Text = "Enddate";
            // 
            // ChooseChanel
            // 
            this.ChooseChanel.Location = new System.Drawing.Point(1757, 632);
            this.ChooseChanel.Name = "ChooseChanel";
            this.ChooseChanel.Size = new System.Drawing.Size(105, 23);
            this.ChooseChanel.TabIndex = 3;
            this.ChooseChanel.Text = "Choose Chanel";
            this.ChooseChanel.UseVisualStyleBackColor = true;
            this.ChooseChanel.Click += new System.EventHandler(this.ChooseChanel_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(1757, 725);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // actogramPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ChooseChanel);
            this.Controls.Add(this.Enddate);
            this.Controls.Add(this.Startdate);
            this.Controls.Add(this.groupBox1);
            this.Name = "actogramPage";
            this.Text = "actogramPage";
            this.Load += new System.EventHandler(this.actogramPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Startdate;
        private System.Windows.Forms.Label Enddate;
        private System.Windows.Forms.Button ChooseChanel;
        private System.Windows.Forms.Button Exit;
    }
}