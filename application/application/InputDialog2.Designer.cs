
using System;
using System.Windows.Forms;

namespace application
{
    partial class InputDialog2
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
            this.channelLabel = new MaterialSkin.Controls.MaterialLabel();
            this.ChannelTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.globalCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            this.messageLabel = new MaterialSkin.Controls.MaterialLabel();
            this.chercheurLabel = new MaterialSkin.Controls.MaterialLabel();
            this.chercheurComboBox = new MaterialSkin.Controls.MaterialComboBox();
            this.OkButton = new MaterialSkin.Controls.MaterialButton();
            this.textBox = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.SuspendLayout();
            // 
            // channelLabel
            // 
            this.channelLabel.Depth = 0;
            this.channelLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.channelLabel.Location = new System.Drawing.Point(21, 92);
            this.channelLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.channelLabel.Name = "channelLabel";
            this.channelLabel.Size = new System.Drawing.Size(200, 20);
            this.channelLabel.TabIndex = 0;
            this.channelLabel.Text = "Channel :";
            // 
            // ChannelTextBox
            // 
            this.ChannelTextBox.AnimateReadOnly = false;
            this.ChannelTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChannelTextBox.Depth = 0;
            this.ChannelTextBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ChannelTextBox.LeadingIcon = null;
            this.ChannelTextBox.Location = new System.Drawing.Point(24, 126);
            this.ChannelTextBox.MaxLength = 50;
            this.ChannelTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.ChannelTextBox.Multiline = false;
            this.ChannelTextBox.Name = "ChannelTextBox";
            this.ChannelTextBox.Size = new System.Drawing.Size(85, 50);
            this.ChannelTextBox.TabIndex = 1;
            this.ChannelTextBox.Text = "";
            this.ChannelTextBox.TrailingIcon = null;
            // 
            // globalCheckBox
            // 
            this.globalCheckBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.globalCheckBox.Depth = 0;
            this.globalCheckBox.Location = new System.Drawing.Point(24, 189);
            this.globalCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.globalCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.globalCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.globalCheckBox.Name = "globalCheckBox";
            this.globalCheckBox.ReadOnly = false;
            this.globalCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.globalCheckBox.Ripple = true;
            this.globalCheckBox.Size = new System.Drawing.Size(163, 40);
            this.globalCheckBox.TabIndex = 2;
            this.globalCheckBox.Text = "Message global";
            this.globalCheckBox.CheckedChanged += new System.EventHandler(this.globalCheckBox_CheckedChanged_1);
            // 
            // messageLabel
            // 
            this.messageLabel.Depth = 0;
            this.messageLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.messageLabel.Location = new System.Drawing.Point(21, 270);
            this.messageLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(230, 20);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.Text = "Message :";
            // 
            // chercheurLabel
            // 
            this.chercheurLabel.AutoSize = true;
            this.chercheurLabel.Depth = 0;
            this.chercheurLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chercheurLabel.Location = new System.Drawing.Point(24, 423);
            this.chercheurLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.chercheurLabel.Name = "chercheurLabel";
            this.chercheurLabel.Size = new System.Drawing.Size(131, 19);
            this.chercheurLabel.TabIndex = 7;
            this.chercheurLabel.Text = "Researcher name :";
            // 
            // chercheurComboBox
            // 
            this.chercheurComboBox.AutoResize = false;
            this.chercheurComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chercheurComboBox.Depth = 0;
            this.chercheurComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.chercheurComboBox.DropDownHeight = 174;
            this.chercheurComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chercheurComboBox.DropDownWidth = 121;
            this.chercheurComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.chercheurComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chercheurComboBox.FormattingEnabled = true;
            this.chercheurComboBox.IntegralHeight = false;
            this.chercheurComboBox.ItemHeight = 43;
            this.chercheurComboBox.Location = new System.Drawing.Point(21, 472);
            this.chercheurComboBox.MaxDropDownItems = 4;
            this.chercheurComboBox.MouseState = MaterialSkin.MouseState.OUT;
            this.chercheurComboBox.Name = "chercheurComboBox";
            this.chercheurComboBox.Size = new System.Drawing.Size(191, 49);
            this.chercheurComboBox.StartIndex = 0;
            this.chercheurComboBox.TabIndex = 8;
            // 
            // OkButton
            // 
            this.OkButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OkButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.OkButton.Depth = 0;
            this.OkButton.HighEmphasis = true;
            this.OkButton.Icon = null;
            this.OkButton.Location = new System.Drawing.Point(21, 588);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OkButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.OkButton.Name = "OkButton";
            this.OkButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.OkButton.Size = new System.Drawing.Size(64, 36);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.OkButton.UseAccentColor = false;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Depth = 0;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox.Location = new System.Drawing.Point(24, 306);
            this.textBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(419, 96);
            this.textBox.TabIndex = 10;
            this.textBox.Text = "";
            // 
            // InputDialog2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 647);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.chercheurComboBox);
            this.Controls.Add(this.chercheurLabel);
            this.Controls.Add(this.channelLabel);
            this.Controls.Add(this.ChannelTextBox);
            this.Controls.Add(this.globalCheckBox);
            this.Controls.Add(this.messageLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputDialog2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report message";
            this.Load += new System.EventHandler(this.InputDialog2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InputDialog2_Load(object sender, EventArgs e)
        {
            //
        }



        #endregion
        private MaterialSkin.Controls.MaterialLabel chercheurLabel;
        private MaterialSkin.Controls.MaterialComboBox chercheurComboBox;
        private MaterialSkin.Controls.MaterialButton OkButton;
        private MaterialSkin.Controls.MaterialMultiLineTextBox textBox;
    }
}