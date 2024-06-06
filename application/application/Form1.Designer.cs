
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
            this.configurationModulesButton = new FontAwesome.Sharp.IconButton();
            this.fileManagementButton = new FontAwesome.Sharp.IconButton();
            this.inactivityCheckButton = new FontAwesome.Sharp.IconButton();
            this.channelDefinitionButton = new FontAwesome.Sharp.IconButton();
            this.displayChannelButton = new FontAwesome.Sharp.IconButton();
            this.researcherButton = new FontAwesome.Sharp.IconButton();
            this.exitButton = new FontAwesome.Sharp.IconButton();
            this.recordingIntervalButton = new FontAwesome.Sharp.IconButton();
            this.lightControlsButton = new FontAwesome.Sharp.IconButton();
            this.helpButton = new FontAwesome.Sharp.IconButton();
            this.systemInformationButton = new FontAwesome.Sharp.IconButton();
            this.actogramButton = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.timerMinute = new System.Windows.Forms.Timer(this.components);
            this.timerHeure = new System.Windows.Forms.Timer(this.components);
            this.displayWindow = new System.Windows.Forms.FlowLayoutPanel();
            this.optionMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.optionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // configurationModulesButton
            // 
            this.configurationModulesButton.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.configurationModulesButton.IconColor = System.Drawing.Color.Black;
            this.configurationModulesButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.configurationModulesButton.IconSize = 32;
            this.configurationModulesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.configurationModulesButton.Location = new System.Drawing.Point(228, 119);
            this.configurationModulesButton.Name = "configurationModulesButton";
            this.configurationModulesButton.Size = new System.Drawing.Size(219, 23);
            this.configurationModulesButton.TabIndex = 10;
            this.configurationModulesButton.Text = "Configuration Modules";
            this.configurationModulesButton.UseVisualStyleBackColor = true;
            this.configurationModulesButton.Click += new System.EventHandler(this.configurationModulesButton_Click);
            // 
            // fileManagementButton
            // 
            this.fileManagementButton.IconChar = FontAwesome.Sharp.IconChar.File;
            this.fileManagementButton.IconColor = System.Drawing.Color.Black;
            this.fileManagementButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.fileManagementButton.IconSize = 32;
            this.fileManagementButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fileManagementButton.Location = new System.Drawing.Point(228, 90);
            this.fileManagementButton.Name = "fileManagementButton";
            this.fileManagementButton.Size = new System.Drawing.Size(219, 23);
            this.fileManagementButton.TabIndex = 11;
            this.fileManagementButton.Text = "File management";
            this.fileManagementButton.UseVisualStyleBackColor = true;
            this.fileManagementButton.Click += new System.EventHandler(this.fileManagementButton_Click);
            // 
            // inactivityCheckButton
            // 
            this.inactivityCheckButton.IconChar = FontAwesome.Sharp.IconChar.Bed;
            this.inactivityCheckButton.IconColor = System.Drawing.Color.Black;
            this.inactivityCheckButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.inactivityCheckButton.IconSize = 32;
            this.inactivityCheckButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.inactivityCheckButton.Location = new System.Drawing.Point(228, 32);
            this.inactivityCheckButton.Name = "inactivityCheckButton";
            this.inactivityCheckButton.Size = new System.Drawing.Size(219, 23);
            this.inactivityCheckButton.TabIndex = 5;
            this.inactivityCheckButton.Text = "Inactivity Check";
            this.inactivityCheckButton.UseVisualStyleBackColor = true;
            this.inactivityCheckButton.Click += new System.EventHandler(this.inactivityCheckButton_Click);
            // 
            // channelDefinitionButton
            // 
            this.channelDefinitionButton.IconChar = FontAwesome.Sharp.IconChar.Table;
            this.channelDefinitionButton.IconColor = System.Drawing.Color.Black;
            this.channelDefinitionButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.channelDefinitionButton.IconSize = 32;
            this.channelDefinitionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.channelDefinitionButton.Location = new System.Drawing.Point(3, 119);
            this.channelDefinitionButton.Name = "channelDefinitionButton";
            this.channelDefinitionButton.Size = new System.Drawing.Size(219, 23);
            this.channelDefinitionButton.TabIndex = 7;
            this.channelDefinitionButton.Text = "Channels Definitions";
            this.channelDefinitionButton.UseVisualStyleBackColor = true;
            this.channelDefinitionButton.Click += new System.EventHandler(this.channelDefinitionButton_Click);
            // 
            // displayChannelButton
            // 
            this.displayChannelButton.IconChar = FontAwesome.Sharp.IconChar.List;
            this.displayChannelButton.IconColor = System.Drawing.Color.Black;
            this.displayChannelButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.displayChannelButton.IconSize = 32;
            this.displayChannelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.displayChannelButton.Location = new System.Drawing.Point(3, 3);
            this.displayChannelButton.Name = "displayChannelButton";
            this.displayChannelButton.Size = new System.Drawing.Size(219, 23);
            this.displayChannelButton.TabIndex = 12;
            this.displayChannelButton.Text = "Display channels";
            this.displayChannelButton.UseVisualStyleBackColor = true;
            this.displayChannelButton.Click += new System.EventHandler(this.displayChannelButton_Click);
            // 
            // researcherButton
            // 
            this.researcherButton.IconChar = FontAwesome.Sharp.IconChar.PersonDress;
            this.researcherButton.IconColor = System.Drawing.Color.Black;
            this.researcherButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.researcherButton.IconSize = 32;
            this.researcherButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.researcherButton.Location = new System.Drawing.Point(453, 3);
            this.researcherButton.Name = "researcherButton";
            this.researcherButton.Size = new System.Drawing.Size(219, 23);
            this.researcherButton.TabIndex = 9;
            this.researcherButton.Text = "Researchers";
            this.researcherButton.UseVisualStyleBackColor = true;
            this.researcherButton.Click += new System.EventHandler(this.researcherButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.exitButton.IconColor = System.Drawing.Color.Black;
            this.exitButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exitButton.IconSize = 32;
            this.exitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitButton.Location = new System.Drawing.Point(453, 32);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(219, 23);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "EXit / System Settings";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // recordingIntervalButton
            // 
            this.recordingIntervalButton.IconChar = FontAwesome.Sharp.IconChar.Hourglass3;
            this.recordingIntervalButton.IconColor = System.Drawing.Color.Black;
            this.recordingIntervalButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.recordingIntervalButton.IconSize = 32;
            this.recordingIntervalButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.recordingIntervalButton.Location = new System.Drawing.Point(228, 3);
            this.recordingIntervalButton.Name = "recordingIntervalButton";
            this.recordingIntervalButton.Size = new System.Drawing.Size(219, 23);
            this.recordingIntervalButton.TabIndex = 6;
            this.recordingIntervalButton.Text = "Recording Interval";
            this.recordingIntervalButton.UseVisualStyleBackColor = true;
            this.recordingIntervalButton.Click += new System.EventHandler(this.recordingIntervalButton_Click);
            // 
            // lightControlsButton
            // 
            this.lightControlsButton.IconChar = FontAwesome.Sharp.IconChar.Lightbulb;
            this.lightControlsButton.IconColor = System.Drawing.Color.Black;
            this.lightControlsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.lightControlsButton.IconSize = 32;
            this.lightControlsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lightControlsButton.Location = new System.Drawing.Point(228, 61);
            this.lightControlsButton.Name = "lightControlsButton";
            this.lightControlsButton.Size = new System.Drawing.Size(219, 23);
            this.lightControlsButton.TabIndex = 4;
            this.lightControlsButton.Text = "Light Controls";
            this.lightControlsButton.UseVisualStyleBackColor = true;
            this.lightControlsButton.Click += new System.EventHandler(this.lightControlsButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.helpButton.IconColor = System.Drawing.Color.Black;
            this.helpButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.helpButton.IconSize = 32;
            this.helpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.helpButton.Location = new System.Drawing.Point(3, 90);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(219, 23);
            this.helpButton.TabIndex = 3;
            this.helpButton.Text = "Help (F1)";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // systemInformationButton
            // 
            this.systemInformationButton.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.systemInformationButton.IconColor = System.Drawing.Color.Black;
            this.systemInformationButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.systemInformationButton.IconSize = 32;
            this.systemInformationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.systemInformationButton.Location = new System.Drawing.Point(3, 61);
            this.systemInformationButton.Name = "systemInformationButton";
            this.systemInformationButton.Size = new System.Drawing.Size(219, 23);
            this.systemInformationButton.TabIndex = 2;
            this.systemInformationButton.Text = "System Information";
            this.systemInformationButton.UseVisualStyleBackColor = true;
            this.systemInformationButton.Click += new System.EventHandler(this.systemInformationButton_Click);
            // 
            // actogramButton
            // 
            this.actogramButton.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.actogramButton.IconColor = System.Drawing.Color.Black;
            this.actogramButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.actogramButton.IconSize = 32;
            this.actogramButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.actogramButton.Location = new System.Drawing.Point(3, 32);
            this.actogramButton.Name = "actogramButton";
            this.actogramButton.Size = new System.Drawing.Size(219, 23);
            this.actogramButton.TabIndex = 1;
            this.actogramButton.Text = "Actogram";
            this.actogramButton.UseVisualStyleBackColor = true;
            this.actogramButton.Click += new System.EventHandler(this.actogramButton_Click);
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
            this.optionMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.optionMenu.AutoScroll = true;
            this.optionMenu.Controls.Add(this.displayChannelButton);
            this.optionMenu.Controls.Add(this.actogramButton);
            this.optionMenu.Controls.Add(this.systemInformationButton);
            this.optionMenu.Controls.Add(this.helpButton);
            this.optionMenu.Controls.Add(this.channelDefinitionButton);
            this.optionMenu.Controls.Add(this.recordingIntervalButton);
            this.optionMenu.Controls.Add(this.inactivityCheckButton);
            this.optionMenu.Controls.Add(this.lightControlsButton);
            this.optionMenu.Controls.Add(this.fileManagementButton);
            this.optionMenu.Controls.Add(this.configurationModulesButton);
            this.optionMenu.Controls.Add(this.researcherButton);
            this.optionMenu.Controls.Add(this.exitButton);
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
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.optionMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconButton fileManagementButton;
        private FontAwesome.Sharp.IconButton configurationModulesButton;
        private FontAwesome.Sharp.IconButton researcherButton;
        private FontAwesome.Sharp.IconButton exitButton;
        private FontAwesome.Sharp.IconButton channelDefinitionButton;
        private FontAwesome.Sharp.IconButton recordingIntervalButton;
        private FontAwesome.Sharp.IconButton inactivityCheckButton;
        private FontAwesome.Sharp.IconButton lightControlsButton;
        private FontAwesome.Sharp.IconButton helpButton;
        private FontAwesome.Sharp.IconButton systemInformationButton;
        private FontAwesome.Sharp.IconButton actogramButton;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton displayChannelButton;
        private System.Windows.Forms.Timer timerMinute;
        private System.Windows.Forms.Timer timerHeure;
        private System.Windows.Forms.FlowLayoutPanel displayWindow;
        private System.Windows.Forms.FlowLayoutPanel optionMenu;
    }
}

