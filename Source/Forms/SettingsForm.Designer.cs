namespace FuckingClippy
{
    partial class SettingsForm
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.AssistantTab = new System.Windows.Forms.TabPage();
            this.OptionsTab = new System.Windows.Forms.TabPage();
            this.chkShowInTaskbar = new System.Windows.Forms.CheckBox();
            this.TipsGroup = new System.Windows.Forms.GroupBox();
            this.ResetTipsButton = new System.Windows.Forms.Button();
            this.KeyboardShortcutsCheck = new System.Windows.Forms.CheckBox();
            this.DailyTipCheck = new System.Windows.Forms.CheckBox();
            this.ImportantTipsCheck = new System.Windows.Forms.CheckBox();
            this.MouseUsageCheck = new System.Windows.Forms.CheckBox();
            this.SoftwareUsageCheck = new System.Windows.Forms.CheckBox();
            this.AboutTab = new System.Windows.Forms.TabPage();
            this.CopyrightsLabel = new System.Windows.Forms.Label();
            this.WebsiteLink = new System.Windows.Forms.LinkLabel();
            this.WebsiteLabel = new System.Windows.Forms.Label();
            this.LicenseLink = new System.Windows.Forms.LinkLabel();
            this.LicenseLabel = new System.Windows.Forms.Label();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.MainTabControl.SuspendLayout();
            this.OptionsTab.SuspendLayout();
            this.TipsGroup.SuspendLayout();
            this.AboutTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.AssistantTab);
            this.MainTabControl.Controls.Add(this.OptionsTab);
            this.MainTabControl.Controls.Add(this.AboutTab);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(447, 301);
            this.MainTabControl.TabIndex = 0;
            // 
            // AssistantTab
            // 
            this.AssistantTab.Location = new System.Drawing.Point(4, 24);
            this.AssistantTab.Name = "AssistantTab";
            this.AssistantTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssistantTab.Size = new System.Drawing.Size(439, 273);
            this.AssistantTab.TabIndex = 0;
            this.AssistantTab.Text = "Appearance";
            this.AssistantTab.UseVisualStyleBackColor = true;
            // 
            // OptionsTab
            // 
            this.OptionsTab.Controls.Add(this.chkShowInTaskbar);
            this.OptionsTab.Controls.Add(this.TipsGroup);
            this.OptionsTab.Location = new System.Drawing.Point(4, 24);
            this.OptionsTab.Name = "OptionsTab";
            this.OptionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.OptionsTab.Size = new System.Drawing.Size(439, 273);
            this.OptionsTab.TabIndex = 1;
            this.OptionsTab.Text = "Options";
            this.OptionsTab.UseVisualStyleBackColor = true;
            // 
            // chkShowInTaskbar
            // 
            this.chkShowInTaskbar.AutoSize = true;
            this.chkShowInTaskbar.Location = new System.Drawing.Point(31, 17);
            this.chkShowInTaskbar.Name = "chkShowInTaskbar";
            this.chkShowInTaskbar.Size = new System.Drawing.Size(111, 19);
            this.chkShowInTaskbar.TabIndex = 2;
            this.chkShowInTaskbar.Text = "Show in Taskbar";
            this.chkShowInTaskbar.UseVisualStyleBackColor = true;
            // 
            // TipsGroup
            // 
            this.TipsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TipsGroup.Controls.Add(this.ResetTipsButton);
            this.TipsGroup.Controls.Add(this.KeyboardShortcutsCheck);
            this.TipsGroup.Controls.Add(this.DailyTipCheck);
            this.TipsGroup.Controls.Add(this.ImportantTipsCheck);
            this.TipsGroup.Controls.Add(this.MouseUsageCheck);
            this.TipsGroup.Controls.Add(this.SoftwareUsageCheck);
            this.TipsGroup.Location = new System.Drawing.Point(6, 110);
            this.TipsGroup.Name = "TipsGroup";
            this.TipsGroup.Size = new System.Drawing.Size(427, 155);
            this.TipsGroup.TabIndex = 1;
            this.TipsGroup.TabStop = false;
            this.TipsGroup.Text = "Show tips on";
            // 
            // ResetTipsButton
            // 
            this.ResetTipsButton.Location = new System.Drawing.Point(230, 72);
            this.ResetTipsButton.Name = "ResetTipsButton";
            this.ResetTipsButton.Size = new System.Drawing.Size(118, 23);
            this.ResetTipsButton.TabIndex = 1;
            this.ResetTipsButton.Text = "&Reset tips";
            this.ResetTipsButton.UseVisualStyleBackColor = true;
            // 
            // KeyboardShortcutsCheck
            // 
            this.KeyboardShortcutsCheck.AutoSize = true;
            this.KeyboardShortcutsCheck.Location = new System.Drawing.Point(25, 72);
            this.KeyboardShortcutsCheck.Name = "KeyboardShortcutsCheck";
            this.KeyboardShortcutsCheck.Size = new System.Drawing.Size(128, 19);
            this.KeyboardShortcutsCheck.TabIndex = 0;
            this.KeyboardShortcutsCheck.Text = "Keyboard shortcuts";
            this.KeyboardShortcutsCheck.UseVisualStyleBackColor = true;
            // 
            // DailyTipCheck
            // 
            this.DailyTipCheck.AutoSize = true;
            this.DailyTipCheck.Location = new System.Drawing.Point(230, 47);
            this.DailyTipCheck.Name = "DailyTipCheck";
            this.DailyTipCheck.Size = new System.Drawing.Size(153, 19);
            this.DailyTipCheck.TabIndex = 0;
            this.DailyTipCheck.Text = "Show daily tip at startup";
            this.DailyTipCheck.UseVisualStyleBackColor = true;
            // 
            // ImportantTipsCheck
            // 
            this.ImportantTipsCheck.AutoSize = true;
            this.ImportantTipsCheck.Location = new System.Drawing.Point(230, 22);
            this.ImportantTipsCheck.Name = "ImportantTipsCheck";
            this.ImportantTipsCheck.Size = new System.Drawing.Size(159, 19);
            this.ImportantTipsCheck.TabIndex = 0;
            this.ImportantTipsCheck.Text = "Show only important tips";
            this.ImportantTipsCheck.UseVisualStyleBackColor = true;
            // 
            // MouseUsageCheck
            // 
            this.MouseUsageCheck.AutoSize = true;
            this.MouseUsageCheck.Location = new System.Drawing.Point(25, 47);
            this.MouseUsageCheck.Name = "MouseUsageCheck";
            this.MouseUsageCheck.Size = new System.Drawing.Size(163, 19);
            this.MouseUsageCheck.TabIndex = 0;
            this.MouseUsageCheck.Text = "Optimal use of the mouse";
            this.MouseUsageCheck.UseVisualStyleBackColor = true;
            // 
            // SoftwareUsageCheck
            // 
            this.SoftwareUsageCheck.AutoSize = true;
            this.SoftwareUsageCheck.Location = new System.Drawing.Point(25, 22);
            this.SoftwareUsageCheck.Name = "SoftwareUsageCheck";
            this.SoftwareUsageCheck.Size = new System.Drawing.Size(185, 19);
            this.SoftwareUsageCheck.TabIndex = 0;
            this.SoftwareUsageCheck.Text = "Optimal usage of the software";
            this.SoftwareUsageCheck.UseVisualStyleBackColor = true;
            // 
            // AboutTab
            // 
            this.AboutTab.Controls.Add(this.CopyrightsLabel);
            this.AboutTab.Controls.Add(this.WebsiteLink);
            this.AboutTab.Controls.Add(this.WebsiteLabel);
            this.AboutTab.Controls.Add(this.LicenseLink);
            this.AboutTab.Controls.Add(this.LicenseLabel);
            this.AboutTab.Controls.Add(this.AboutLabel);
            this.AboutTab.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutTab.Location = new System.Drawing.Point(4, 24);
            this.AboutTab.Name = "AboutTab";
            this.AboutTab.Padding = new System.Windows.Forms.Padding(3);
            this.AboutTab.Size = new System.Drawing.Size(439, 273);
            this.AboutTab.TabIndex = 3;
            this.AboutTab.Text = "About";
            this.AboutTab.UseVisualStyleBackColor = true;
            // 
            // CopyrightsLabel
            // 
            this.CopyrightsLabel.AutoSize = true;
            this.CopyrightsLabel.Location = new System.Drawing.Point(8, 130);
            this.CopyrightsLabel.Name = "CopyrightsLabel";
            this.CopyrightsLabel.Size = new System.Drawing.Size(287, 42);
            this.CopyrightsLabel.TabIndex = 6;
            this.CopyrightsLabel.Text = "Copyright © Microsoft 1997-2003\r\nfor their Clippit (Clippy) Office Assistant.";
            // 
            // WebsiteLink
            // 
            this.WebsiteLink.AutoSize = true;
            this.WebsiteLink.Location = new System.Drawing.Point(87, 87);
            this.WebsiteLink.Name = "WebsiteLink";
            this.WebsiteLink.Size = new System.Drawing.Size(292, 21);
            this.WebsiteLink.TabIndex = 5;
            this.WebsiteLink.TabStop = true;
            this.WebsiteLink.Text = "https://github.com/dd86k/FuckingClippy";
            // 
            // WebsiteLabel
            // 
            this.WebsiteLabel.AutoSize = true;
            this.WebsiteLabel.Location = new System.Drawing.Point(6, 87);
            this.WebsiteLabel.Name = "WebsiteLabel";
            this.WebsiteLabel.Size = new System.Drawing.Size(65, 21);
            this.WebsiteLabel.TabIndex = 4;
            this.WebsiteLabel.Text = "Website";
            // 
            // LicenseLink
            // 
            this.LicenseLink.AutoSize = true;
            this.LicenseLink.Location = new System.Drawing.Point(87, 47);
            this.LicenseLink.Name = "LicenseLink";
            this.LicenseLink.Size = new System.Drawing.Size(260, 21);
            this.LicenseLink.TabIndex = 3;
            this.LicenseLink.TabStop = true;
            this.LicenseLink.Text = "https://opensource.org/licenses/MIT";
            // 
            // LicenseLabel
            // 
            this.LicenseLabel.AutoSize = true;
            this.LicenseLabel.Location = new System.Drawing.Point(6, 47);
            this.LicenseLabel.Name = "LicenseLabel";
            this.LicenseLabel.Size = new System.Drawing.Size(61, 21);
            this.LicenseLabel.TabIndex = 2;
            this.LicenseLabel.Text = "License";
            // 
            // AboutLabel
            // 
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Location = new System.Drawing.Point(6, 7);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(69, 21);
            this.AboutLabel.TabIndex = 1;
            this.AboutLabel.Text = "lblAbout";
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(368, 307);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 1;
            this.QuitButton.Text = "Cancel";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(287, 307);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 337);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.MainTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Office assistant";
            this.MainTabControl.ResumeLayout(false);
            this.OptionsTab.ResumeLayout(false);
            this.OptionsTab.PerformLayout();
            this.TipsGroup.ResumeLayout(false);
            this.TipsGroup.PerformLayout();
            this.AboutTab.ResumeLayout(false);
            this.AboutTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage AssistantTab;
        private System.Windows.Forms.TabPage OptionsTab;
        private System.Windows.Forms.TabPage AboutTab;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.Label LicenseLabel;
        private System.Windows.Forms.LinkLabel LicenseLink;
        private System.Windows.Forms.LinkLabel WebsiteLink;
        private System.Windows.Forms.Label WebsiteLabel;
        private System.Windows.Forms.Label CopyrightsLabel;
        private System.Windows.Forms.GroupBox TipsGroup;
        private System.Windows.Forms.CheckBox KeyboardShortcutsCheck;
        private System.Windows.Forms.CheckBox DailyTipCheck;
        private System.Windows.Forms.CheckBox ImportantTipsCheck;
        private System.Windows.Forms.CheckBox MouseUsageCheck;
        private System.Windows.Forms.CheckBox SoftwareUsageCheck;
        private System.Windows.Forms.Button ResetTipsButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.CheckBox chkShowInTaskbar;
    }
}