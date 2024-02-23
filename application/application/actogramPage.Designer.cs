
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
            this.Startdate = new System.Windows.Forms.Label();
            this.Enddate = new System.Windows.Forms.Label();
            this.ChooseChanel = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Chn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.zoomin = new System.Windows.Forms.Button();
            this.zoomout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Startdate
            // 
            this.Startdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Startdate.AutoSize = true;
            this.Startdate.Location = new System.Drawing.Point(13, 107);
            this.Startdate.Name = "Startdate";
            this.Startdate.Size = new System.Drawing.Size(50, 13);
            this.Startdate.TabIndex = 1;
            this.Startdate.Text = "Startdate";
            // 
            // Enddate
            // 
            this.Enddate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Enddate.AutoSize = true;
            this.Enddate.Location = new System.Drawing.Point(13, 735);
            this.Enddate.Name = "Enddate";
            this.Enddate.Size = new System.Drawing.Size(47, 13);
            this.Enddate.TabIndex = 2;
            this.Enddate.Text = "Enddate";
            // 
            // ChooseChanel
            // 
            this.ChooseChanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            this.Exit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Exit.Location = new System.Drawing.Point(1757, 725);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Chn
            // 
            this.Chn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Chn.AutoSize = true;
            this.Chn.Location = new System.Drawing.Point(970, 981);
            this.Chn.Name = "Chn";
            this.Chn.Size = new System.Drawing.Size(32, 13);
            this.Chn.TabIndex = 5;
            this.Chn.Text = "Chn. ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(115, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 696);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.AutoScroll = true;
            this.panel2.Location = new System.Drawing.Point(115, 783);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1600, 183);
            this.panel2.TabIndex = 8;
            // 
            // zoomin
            // 
            this.zoomin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomin.Location = new System.Drawing.Point(1777, 358);
            this.zoomin.Name = "zoomin";
            this.zoomin.Size = new System.Drawing.Size(55, 52);
            this.zoomin.TabIndex = 9;
            this.zoomin.Text = "+";
            this.zoomin.UseVisualStyleBackColor = true;
            this.zoomin.Click += new System.EventHandler(this.zoomin_Click);
            // 
            // zoomout
            // 
            this.zoomout.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomout.Location = new System.Drawing.Point(1777, 416);
            this.zoomout.Name = "zoomout";
            this.zoomout.Size = new System.Drawing.Size(55, 51);
            this.zoomout.TabIndex = 10;
            this.zoomout.Text = "-";
            this.zoomout.UseVisualStyleBackColor = true;
            this.zoomout.Click += new System.EventHandler(this.zoomout_Click);
            // 
            // actogramPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.zoomout);
            this.Controls.Add(this.zoomin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Chn);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ChooseChanel);
            this.Controls.Add(this.Enddate);
            this.Controls.Add(this.Startdate);
            this.Name = "actogramPage";
            this.Text = "actogramPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.actogramPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Startdate;
        private System.Windows.Forms.Label Enddate;
        private System.Windows.Forms.Button ChooseChanel;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label Chn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button zoomin;
        private System.Windows.Forms.Button zoomout;
    }
}