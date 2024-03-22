
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
            this.ChooseChanel = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Chn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            this.SuspendLayout();
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
            this.Chn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chn.ForeColor = System.Drawing.Color.White;
            this.Chn.Location = new System.Drawing.Point(970, 981);
            this.Chn.Name = "Chn";
            this.Chn.Size = new System.Drawing.Size(63, 25);
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
            // trackBarX
            // 
            this.trackBarX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.trackBarX.LargeChange = 1000;
            this.trackBarX.Location = new System.Drawing.Point(779, 12);
            this.trackBarX.Maximum = 5000;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(448, 45);
            this.trackBarX.SmallChange = 10;
            this.trackBarX.TabIndex = 300;
            this.trackBarX.TickFrequency = 1000;
            this.trackBarX.Scroll += new System.EventHandler(this.trackBarX_Scroll);
            // 
            // actogramPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Chn);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ChooseChanel);
            this.Name = "actogramPage";
            this.Text = "actogramPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.actogramPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ChooseChanel;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label Chn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar trackBarX;
    }
}