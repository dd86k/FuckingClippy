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
            this.tabAssistant = new System.Windows.Forms.TabPage();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.linklblLicense = new System.Windows.Forms.LinkLabel();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblMicrosoftCopyrights = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.tabAssistant);
            this.MainTabControl.Controls.Add(this.tabOptions);
            this.MainTabControl.Controls.Add(this.tabSettings);
            this.MainTabControl.Controls.Add(this.tabAbout);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(447, 301);
            this.MainTabControl.TabIndex = 0;
            // 
            // tabAssistant
            // 
            this.tabAssistant.Location = new System.Drawing.Point(4, 24);
            this.tabAssistant.Name = "tabAssistant";
            this.tabAssistant.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssistant.Size = new System.Drawing.Size(439, 273);
            this.tabAssistant.TabIndex = 0;
            this.tabAssistant.Text = "Appearance";
            this.tabAssistant.UseVisualStyleBackColor = true;
            // 
            // tabOptions
            // 
            this.tabOptions.Location = new System.Drawing.Point(4, 24);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(439, 273);
            this.tabOptions.TabIndex = 1;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Location = new System.Drawing.Point(4, 24);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(439, 273);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.lblMicrosoftCopyrights);
            this.tabAbout.Controls.Add(this.linkLabel1);
            this.tabAbout.Controls.Add(this.lblWebsite);
            this.tabAbout.Controls.Add(this.linklblLicense);
            this.tabAbout.Controls.Add(this.lblLicense);
            this.tabAbout.Controls.Add(this.lblAbout);
            this.tabAbout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAbout.Location = new System.Drawing.Point(4, 24);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(439, 273);
            this.tabAbout.TabIndex = 3;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(6, 7);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(69, 21);
            this.lblAbout.TabIndex = 1;
            this.lblAbout.Text = "lblAbout";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(6, 47);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(61, 21);
            this.lblLicense.TabIndex = 2;
            this.lblLicense.Text = "License";
            // 
            // linklblLicense
            // 
            this.linklblLicense.AutoSize = true;
            this.linklblLicense.Location = new System.Drawing.Point(87, 47);
            this.linklblLicense.Name = "linklblLicense";
            this.linklblLicense.Size = new System.Drawing.Size(260, 21);
            this.linklblLicense.TabIndex = 3;
            this.linklblLicense.TabStop = true;
            this.linklblLicense.Text = "https://opensource.org/licenses/MIT";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(6, 87);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(65, 21);
            this.lblWebsite.TabIndex = 4;
            this.lblWebsite.Text = "Website";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(87, 87);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(328, 21);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/guitarxhero/FuckingClippy";
            // 
            // lblMicrosoftCopyrights
            // 
            this.lblMicrosoftCopyrights.AutoSize = true;
            this.lblMicrosoftCopyrights.Location = new System.Drawing.Point(8, 130);
            this.lblMicrosoftCopyrights.Name = "lblMicrosoftCopyrights";
            this.lblMicrosoftCopyrights.Size = new System.Drawing.Size(287, 42);
            this.lblMicrosoftCopyrights.TabIndex = 6;
            this.lblMicrosoftCopyrights.Text = "Copyright © Microsoft 1997-2003\r\nfor their Clippit (Clippy) Office Assistant.";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 301);
            this.Controls.Add(this.MainTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Office assistant";
            this.MainTabControl.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage tabAssistant;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.LinkLabel linklblLicense;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.Label lblMicrosoftCopyrights;
    }
}