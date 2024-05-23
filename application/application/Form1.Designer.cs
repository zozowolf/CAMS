
namespace application
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.timerDate = new System.Windows.Forms.Timer(this.components);
            this.timerMinute = new System.Windows.Forms.Timer(this.components);
            this.timerHeure = new System.Windows.Forms.Timer(this.components);
            this.displayWindow = new System.Windows.Forms.FlowLayoutPanel();
            this.optionMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.optionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(228, 119);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(219, 23);
            this.button10.TabIndex = 10;
            this.button10.Text = "Configuration Modules";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(228, 90);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(219, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = "File management";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(228, 32);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(219, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "Inactivity Check";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 119);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(219, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Channels Definitions";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Display channels";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(453, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(219, 23);
            this.button11.TabIndex = 9;
            this.button11.Text = "Chercheurs";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(453, 32);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(219, 23);
            this.button12.TabIndex = 8;
            this.button12.Text = "EXit / System Settings";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(228, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(219, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "Recording Interval";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(228, 61);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(219, 23);
            this.button8.TabIndex = 4;
            this.button8.Text = "Light Controls";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 90);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(219, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Help (F1)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(219, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "System Information";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Actogram";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(753, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "CIRCADIAN ACTIVITY MONITORING SYSTEM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(897, 980);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(110, 20);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "Date et Heure";
            // 
            // timerDate
            // 
            this.timerDate.Enabled = true;
            this.timerDate.Interval = 1000;
            this.timerDate.Tick += new System.EventHandler(this.timerDate_Tick);
            // 
            // timerMinute
            // 
            this.timerMinute.Enabled = true;
            this.timerMinute.Interval = 60000;
            this.timerMinute.Tick += new System.EventHandler(this.timerMinute_Tick);
            // 
            // timerHeure
            // 
            this.timerHeure.Enabled = true;
            this.timerHeure.Interval = 3600000;
            this.timerHeure.Tick += new System.EventHandler(this.timerHeure_Tick);
            // 
            // displayWindow
            // 
            this.displayWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayWindow.AutoScroll = true;
            this.displayWindow.Location = new System.Drawing.Point(12, 217);
            this.displayWindow.Name = "displayWindow";
            this.displayWindow.Size = new System.Drawing.Size(1870, 645);
            this.displayWindow.TabIndex = 5;
            // 
            // optionMenu
            // 
            this.optionMenu.AutoScroll = true;
            this.optionMenu.Controls.Add(this.button1);
            this.optionMenu.Controls.Add(this.button2);
            this.optionMenu.Controls.Add(this.button3);
            this.optionMenu.Controls.Add(this.button4);
            this.optionMenu.Controls.Add(this.button5);
            this.optionMenu.Controls.Add(this.button6);
            this.optionMenu.Controls.Add(this.button7);
            this.optionMenu.Controls.Add(this.button8);
            this.optionMenu.Controls.Add(this.button9);
            this.optionMenu.Controls.Add(this.button10);
            this.optionMenu.Controls.Add(this.button11);
            this.optionMenu.Controls.Add(this.button12);
            this.optionMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.optionMenu.Location = new System.Drawing.Point(404, 24);
            this.optionMenu.Name = "optionMenu";
            this.optionMenu.Size = new System.Drawing.Size(1320, 171);
            this.optionMenu.TabIndex = 13;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.optionMenu);
            this.Controls.Add(this.displayWindow);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.optionMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timerMinute;
        private System.Windows.Forms.Timer timerHeure;
        private System.Windows.Forms.FlowLayoutPanel displayWindow;
        private System.Windows.Forms.FlowLayoutPanel optionMenu;
        private System.Windows.Forms.Timer timerDate;
    }
}

