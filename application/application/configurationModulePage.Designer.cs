
using System.Drawing;

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
            this.materialIpAddressMaskedTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialMasqueMaskedTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialPasserelleMaskedTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialTypeModuleComboBox = new MaterialSkin.Controls.MaterialComboBox();
            this.materialNbEntreeSortieTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialQueryButton = new MaterialSkin.Controls.MaterialButton();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.materialLabelModuleType = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelEntryExit = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelGateway = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelMask = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelIpAdress = new MaterialSkin.Controls.MaterialLabel();
            this.exit = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // materialIpAddressMaskedTextBox
            // 
            this.materialIpAddressMaskedTextBox.AllowPromptAsInput = true;
            this.materialIpAddressMaskedTextBox.AnimateReadOnly = false;
            this.materialIpAddressMaskedTextBox.AsciiOnly = false;
            this.materialIpAddressMaskedTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialIpAddressMaskedTextBox.BeepOnError = false;
            this.materialIpAddressMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialIpAddressMaskedTextBox.Depth = 0;
            this.materialIpAddressMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialIpAddressMaskedTextBox.HidePromptOnLeave = false;
            this.materialIpAddressMaskedTextBox.HideSelection = true;
            this.materialIpAddressMaskedTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.materialIpAddressMaskedTextBox.LeadingIcon = null;
            this.materialIpAddressMaskedTextBox.Location = new System.Drawing.Point(179, 100);
            this.materialIpAddressMaskedTextBox.Mask = "";
            this.materialIpAddressMaskedTextBox.MaxLength = 32767;
            this.materialIpAddressMaskedTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.materialIpAddressMaskedTextBox.Name = "materialIpAddressMaskedTextBox";
            this.materialIpAddressMaskedTextBox.PasswordChar = '\0';
            this.materialIpAddressMaskedTextBox.PrefixSuffixText = null;
            this.materialIpAddressMaskedTextBox.PromptChar = '_';
            this.materialIpAddressMaskedTextBox.ReadOnly = false;
            this.materialIpAddressMaskedTextBox.RejectInputOnFirstFailure = false;
            this.materialIpAddressMaskedTextBox.ResetOnPrompt = true;
            this.materialIpAddressMaskedTextBox.ResetOnSpace = true;
            this.materialIpAddressMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialIpAddressMaskedTextBox.SelectedText = "";
            this.materialIpAddressMaskedTextBox.SelectionLength = 0;
            this.materialIpAddressMaskedTextBox.SelectionStart = 0;
            this.materialIpAddressMaskedTextBox.ShortcutsEnabled = true;
            this.materialIpAddressMaskedTextBox.Size = new System.Drawing.Size(157, 36);
            this.materialIpAddressMaskedTextBox.SkipLiterals = true;
            this.materialIpAddressMaskedTextBox.TabIndex = 15;
            this.materialIpAddressMaskedTextBox.TabStop = false;
            this.materialIpAddressMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.materialIpAddressMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialIpAddressMaskedTextBox.TrailingIcon = null;
            this.materialIpAddressMaskedTextBox.UseAccent = false;
            this.materialIpAddressMaskedTextBox.UseSystemPasswordChar = false;
            this.materialIpAddressMaskedTextBox.UseTallSize = false;
            this.materialIpAddressMaskedTextBox.ValidatingType = null;
            // 
            // materialMasqueMaskedTextBox
            // 
            this.materialMasqueMaskedTextBox.AllowPromptAsInput = true;
            this.materialMasqueMaskedTextBox.AnimateReadOnly = false;
            this.materialMasqueMaskedTextBox.AsciiOnly = false;
            this.materialMasqueMaskedTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialMasqueMaskedTextBox.BeepOnError = false;
            this.materialMasqueMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialMasqueMaskedTextBox.Depth = 0;
            this.materialMasqueMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialMasqueMaskedTextBox.HidePromptOnLeave = false;
            this.materialMasqueMaskedTextBox.HideSelection = true;
            this.materialMasqueMaskedTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.materialMasqueMaskedTextBox.LeadingIcon = null;
            this.materialMasqueMaskedTextBox.Location = new System.Drawing.Point(179, 159);
            this.materialMasqueMaskedTextBox.Mask = "";
            this.materialMasqueMaskedTextBox.MaxLength = 32767;
            this.materialMasqueMaskedTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.materialMasqueMaskedTextBox.Name = "materialMasqueMaskedTextBox";
            this.materialMasqueMaskedTextBox.PasswordChar = '\0';
            this.materialMasqueMaskedTextBox.PrefixSuffixText = null;
            this.materialMasqueMaskedTextBox.PromptChar = '_';
            this.materialMasqueMaskedTextBox.ReadOnly = false;
            this.materialMasqueMaskedTextBox.RejectInputOnFirstFailure = false;
            this.materialMasqueMaskedTextBox.ResetOnPrompt = true;
            this.materialMasqueMaskedTextBox.ResetOnSpace = true;
            this.materialMasqueMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialMasqueMaskedTextBox.SelectedText = "";
            this.materialMasqueMaskedTextBox.SelectionLength = 0;
            this.materialMasqueMaskedTextBox.SelectionStart = 0;
            this.materialMasqueMaskedTextBox.ShortcutsEnabled = true;
            this.materialMasqueMaskedTextBox.Size = new System.Drawing.Size(157, 36);
            this.materialMasqueMaskedTextBox.SkipLiterals = true;
            this.materialMasqueMaskedTextBox.TabIndex = 16;
            this.materialMasqueMaskedTextBox.TabStop = false;
            this.materialMasqueMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.materialMasqueMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialMasqueMaskedTextBox.TrailingIcon = null;
            this.materialMasqueMaskedTextBox.UseAccent = false;
            this.materialMasqueMaskedTextBox.UseSystemPasswordChar = false;
            this.materialMasqueMaskedTextBox.UseTallSize = false;
            this.materialMasqueMaskedTextBox.ValidatingType = null;
            // 
            // materialPasserelleMaskedTextBox
            // 
            this.materialPasserelleMaskedTextBox.AllowPromptAsInput = true;
            this.materialPasserelleMaskedTextBox.AnimateReadOnly = false;
            this.materialPasserelleMaskedTextBox.AsciiOnly = false;
            this.materialPasserelleMaskedTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialPasserelleMaskedTextBox.BeepOnError = false;
            this.materialPasserelleMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialPasserelleMaskedTextBox.Depth = 0;
            this.materialPasserelleMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialPasserelleMaskedTextBox.HidePromptOnLeave = false;
            this.materialPasserelleMaskedTextBox.HideSelection = true;
            this.materialPasserelleMaskedTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.materialPasserelleMaskedTextBox.LeadingIcon = null;
            this.materialPasserelleMaskedTextBox.Location = new System.Drawing.Point(179, 217);
            this.materialPasserelleMaskedTextBox.Mask = "";
            this.materialPasserelleMaskedTextBox.MaxLength = 32767;
            this.materialPasserelleMaskedTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.materialPasserelleMaskedTextBox.Name = "materialPasserelleMaskedTextBox";
            this.materialPasserelleMaskedTextBox.PasswordChar = '\0';
            this.materialPasserelleMaskedTextBox.PrefixSuffixText = null;
            this.materialPasserelleMaskedTextBox.PromptChar = '_';
            this.materialPasserelleMaskedTextBox.ReadOnly = false;
            this.materialPasserelleMaskedTextBox.RejectInputOnFirstFailure = false;
            this.materialPasserelleMaskedTextBox.ResetOnPrompt = true;
            this.materialPasserelleMaskedTextBox.ResetOnSpace = true;
            this.materialPasserelleMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialPasserelleMaskedTextBox.SelectedText = "";
            this.materialPasserelleMaskedTextBox.SelectionLength = 0;
            this.materialPasserelleMaskedTextBox.SelectionStart = 0;
            this.materialPasserelleMaskedTextBox.ShortcutsEnabled = true;
            this.materialPasserelleMaskedTextBox.Size = new System.Drawing.Size(157, 36);
            this.materialPasserelleMaskedTextBox.SkipLiterals = true;
            this.materialPasserelleMaskedTextBox.TabIndex = 17;
            this.materialPasserelleMaskedTextBox.TabStop = false;
            this.materialPasserelleMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.materialPasserelleMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialPasserelleMaskedTextBox.TrailingIcon = null;
            this.materialPasserelleMaskedTextBox.UseAccent = false;
            this.materialPasserelleMaskedTextBox.UseSystemPasswordChar = false;
            this.materialPasserelleMaskedTextBox.UseTallSize = false;
            this.materialPasserelleMaskedTextBox.ValidatingType = null;
            // 
            // materialTypeModuleComboBox
            // 
            this.materialTypeModuleComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialTypeModuleComboBox.AutoResize = false;
            this.materialTypeModuleComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialTypeModuleComboBox.Depth = 0;
            this.materialTypeModuleComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.materialTypeModuleComboBox.DropDownHeight = 174;
            this.materialTypeModuleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialTypeModuleComboBox.DropDownWidth = 121;
            this.materialTypeModuleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialTypeModuleComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialTypeModuleComboBox.FormattingEnabled = true;
            this.materialTypeModuleComboBox.IntegralHeight = false;
            this.materialTypeModuleComboBox.ItemHeight = 43;
            this.materialTypeModuleComboBox.Location = new System.Drawing.Point(179, 269);
            this.materialTypeModuleComboBox.MaxDropDownItems = 4;
            this.materialTypeModuleComboBox.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTypeModuleComboBox.Name = "materialTypeModuleComboBox";
            this.materialTypeModuleComboBox.Size = new System.Drawing.Size(157, 49);
            this.materialTypeModuleComboBox.StartIndex = 0;
            this.materialTypeModuleComboBox.TabIndex = 18;
            this.materialTypeModuleComboBox.SelectedIndexChanged += new System.EventHandler(this.materialTypeModuleComboBox_SelectedIndexChanged);
            // 
            // materialNbEntreeSortieTextBox
            // 
            this.materialNbEntreeSortieTextBox.AllowPromptAsInput = true;
            this.materialNbEntreeSortieTextBox.AnimateReadOnly = false;
            this.materialNbEntreeSortieTextBox.AsciiOnly = false;
            this.materialNbEntreeSortieTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialNbEntreeSortieTextBox.BeepOnError = false;
            this.materialNbEntreeSortieTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialNbEntreeSortieTextBox.Depth = 0;
            this.materialNbEntreeSortieTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialNbEntreeSortieTextBox.HidePromptOnLeave = false;
            this.materialNbEntreeSortieTextBox.HideSelection = true;
            this.materialNbEntreeSortieTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.materialNbEntreeSortieTextBox.LeadingIcon = null;
            this.materialNbEntreeSortieTextBox.Location = new System.Drawing.Point(179, 347);
            this.materialNbEntreeSortieTextBox.Mask = "";
            this.materialNbEntreeSortieTextBox.MaxLength = 32767;
            this.materialNbEntreeSortieTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.materialNbEntreeSortieTextBox.Name = "materialNbEntreeSortieTextBox";
            this.materialNbEntreeSortieTextBox.PasswordChar = '\0';
            this.materialNbEntreeSortieTextBox.PrefixSuffixText = null;
            this.materialNbEntreeSortieTextBox.PromptChar = '_';
            this.materialNbEntreeSortieTextBox.ReadOnly = false;
            this.materialNbEntreeSortieTextBox.RejectInputOnFirstFailure = false;
            this.materialNbEntreeSortieTextBox.ResetOnPrompt = true;
            this.materialNbEntreeSortieTextBox.ResetOnSpace = true;
            this.materialNbEntreeSortieTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialNbEntreeSortieTextBox.SelectedText = "";
            this.materialNbEntreeSortieTextBox.SelectionLength = 0;
            this.materialNbEntreeSortieTextBox.SelectionStart = 0;
            this.materialNbEntreeSortieTextBox.ShortcutsEnabled = true;
            this.materialNbEntreeSortieTextBox.Size = new System.Drawing.Size(157, 36);
            this.materialNbEntreeSortieTextBox.SkipLiterals = true;
            this.materialNbEntreeSortieTextBox.TabIndex = 19;
            this.materialNbEntreeSortieTextBox.TabStop = false;
            this.materialNbEntreeSortieTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.materialNbEntreeSortieTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialNbEntreeSortieTextBox.TrailingIcon = null;
            this.materialNbEntreeSortieTextBox.UseAccent = false;
            this.materialNbEntreeSortieTextBox.UseSystemPasswordChar = false;
            this.materialNbEntreeSortieTextBox.UseTallSize = false;
            this.materialNbEntreeSortieTextBox.ValidatingType = null;
            // 
            // materialQueryButton
            // 
            this.materialQueryButton.AutoSize = false;
            this.materialQueryButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialQueryButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialQueryButton.Depth = 0;
            this.materialQueryButton.Font = new System.Drawing.Font("Arial", 20F);
            this.materialQueryButton.HighEmphasis = true;
            this.materialQueryButton.Icon = null;
            this.materialQueryButton.Location = new System.Drawing.Point(428, 180);
            this.materialQueryButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialQueryButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialQueryButton.Name = "materialQueryButton";
            this.materialQueryButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialQueryButton.Size = new System.Drawing.Size(329, 114);
            this.materialQueryButton.TabIndex = 25;
            this.materialQueryButton.Text = "Add to Database";
            this.materialQueryButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialQueryButton.UseAccentColor = false;
            this.materialQueryButton.UseVisualStyleBackColor = true;
            this.materialQueryButton.Click += new System.EventHandler(this.materialQueryButton_Click);
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.ForeColor = System.Drawing.Color.Navy;
            this.materialProgressBar1.Location = new System.Drawing.Point(0, 442);
            this.materialProgressBar1.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(794, 5);
            this.materialProgressBar1.TabIndex = 26;
            // 
            // materialLabelModuleType
            // 
            this.materialLabelModuleType.AutoSize = true;
            this.materialLabelModuleType.BackColor = System.Drawing.SystemColors.InfoText;
            this.materialLabelModuleType.Depth = 0;
            this.materialLabelModuleType.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabelModuleType.Location = new System.Drawing.Point(36, 299);
            this.materialLabelModuleType.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelModuleType.Name = "materialLabelModuleType";
            this.materialLabelModuleType.Size = new System.Drawing.Size(96, 19);
            this.materialLabelModuleType.TabIndex = 23;
            this.materialLabelModuleType.Text = "Module type :";
            // 
            // materialLabelEntryExit
            // 
            this.materialLabelEntryExit.AutoSize = true;
            this.materialLabelEntryExit.Depth = 0;
            this.materialLabelEntryExit.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabelEntryExit.Location = new System.Drawing.Point(16, 363);
            this.materialLabelEntryExit.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelEntryExit.Name = "materialLabelEntryExit";
            this.materialLabelEntryExit.Size = new System.Drawing.Size(157, 19);
            this.materialLabelEntryExit.TabIndex = 24;
            this.materialLabelEntryExit.Text = "Amount of Entry/Exit :";
            // 
            // materialLabelGateway
            // 
            this.materialLabelGateway.AutoSize = true;
            this.materialLabelGateway.Depth = 0;
            this.materialLabelGateway.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabelGateway.Location = new System.Drawing.Point(48, 234);
            this.materialLabelGateway.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelGateway.Name = "materialLabelGateway";
            this.materialLabelGateway.Size = new System.Drawing.Size(71, 19);
            this.materialLabelGateway.TabIndex = 22;
            this.materialLabelGateway.Text = "Gateway :";
            // 
            // materialLabelMask
            // 
            this.materialLabelMask.AutoSize = true;
            this.materialLabelMask.Depth = 0;
            this.materialLabelMask.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabelMask.Location = new System.Drawing.Point(58, 176);
            this.materialLabelMask.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelMask.Name = "materialLabelMask";
            this.materialLabelMask.Size = new System.Drawing.Size(48, 19);
            this.materialLabelMask.TabIndex = 21;
            this.materialLabelMask.Text = "Mask :";
            // 
            // materialLabelIpAdress
            // 
            this.materialLabelIpAdress.AutoSize = true;
            this.materialLabelIpAdress.Depth = 0;
            this.materialLabelIpAdress.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabelIpAdress.Location = new System.Drawing.Point(44, 117);
            this.materialLabelIpAdress.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelIpAdress.Name = "materialLabelIpAdress";
            this.materialLabelIpAdress.Size = new System.Drawing.Size(75, 19);
            this.materialLabelIpAdress.TabIndex = 20;
            this.materialLabelIpAdress.Text = "IP Adress :";
            // 
            // exit
            // 
            this.exit.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromBracket;
            this.exit.IconColor = System.Drawing.Color.Black;
            this.exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exit.IconSize = 60;
            this.exit.Location = new System.Drawing.Point(727, 379);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(58, 57);
            this.exit.TabIndex = 27;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // configurationModulePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.materialLabelEntryExit);
            this.Controls.Add(this.materialLabelGateway);
            this.Controls.Add(this.materialLabelModuleType);
            this.Controls.Add(this.materialLabelMask);
            this.Controls.Add(this.materialLabelIpAdress);
            this.Controls.Add(this.materialProgressBar1);
            this.Controls.Add(this.materialQueryButton);
            this.Controls.Add(this.materialNbEntreeSortieTextBox);
            this.Controls.Add(this.materialTypeModuleComboBox);
            this.Controls.Add(this.materialPasserelleMaskedTextBox);
            this.Controls.Add(this.materialMasqueMaskedTextBox);
            this.Controls.Add(this.materialIpAddressMaskedTextBox);
            this.Name = "configurationModulePage";
            this.Text = "Configuration Module Page";
            this.Load += new System.EventHandler(this.configurationModulePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialMaskedTextBox materialIpAddressMaskedTextBox;
        private MaterialSkin.Controls.MaterialMaskedTextBox materialMasqueMaskedTextBox;
        private MaterialSkin.Controls.MaterialMaskedTextBox materialPasserelleMaskedTextBox;
        private MaterialSkin.Controls.MaterialComboBox materialTypeModuleComboBox;
        private MaterialSkin.Controls.MaterialMaskedTextBox materialNbEntreeSortieTextBox;
        private MaterialSkin.Controls.MaterialButton materialQueryButton;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private MaterialSkin.Controls.MaterialLabel materialLabelModuleType;
        private MaterialSkin.Controls.MaterialLabel materialLabelEntryExit;
        private MaterialSkin.Controls.MaterialLabel materialLabelGateway;
        private MaterialSkin.Controls.MaterialLabel materialLabelMask;
        private MaterialSkin.Controls.MaterialLabel materialLabelIpAdress;
        private FontAwesome.Sharp.IconButton exit;
    }
}