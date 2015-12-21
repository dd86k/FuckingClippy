namespace FuckingClippy
{
    partial class MainForm
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
            this.cmsCharacter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.csmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiChooseAssistant = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiAnimate = new System.Windows.Forms.ToolStripMenuItem();
            this.picCharacter = new System.Windows.Forms.PictureBox();
            this.cmsCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsCharacter
            // 
            this.cmsCharacter.AccessibleName = "Main context menu";
            this.cmsCharacter.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.cmsCharacter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiHide,
            this.toolStripSeparator1,
            this.csmiOptions,
            this.cmsiChooseAssistant,
            this.cmsiAnimate});
            this.cmsCharacter.Name = "cmsCharacter";
            this.cmsCharacter.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsCharacter.ShowImageMargin = false;
            this.cmsCharacter.ShowItemToolTips = false;
            this.cmsCharacter.Size = new System.Drawing.Size(147, 98);
            // 
            // cmsiHide
            // 
            this.cmsiHide.Name = "cmsiHide";
            this.cmsiHide.Size = new System.Drawing.Size(146, 22);
            this.cmsiHide.Text = "&Hide";
            this.cmsiHide.Click += new System.EventHandler(this.cmsiHide_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // csmiOptions
            // 
            this.csmiOptions.Name = "csmiOptions";
            this.csmiOptions.Size = new System.Drawing.Size(146, 22);
            this.csmiOptions.Text = "&Options...";
            this.csmiOptions.Click += new System.EventHandler(this.csmiOptions_Click);
            // 
            // cmsiChooseAssistant
            // 
            this.cmsiChooseAssistant.Name = "cmsiChooseAssistant";
            this.cmsiChooseAssistant.Size = new System.Drawing.Size(146, 22);
            this.cmsiChooseAssistant.Text = "&Choose assistant...";
            this.cmsiChooseAssistant.Click += new System.EventHandler(this.cmsiChooseAssistant_Click);
            // 
            // cmsiAnimate
            // 
            this.cmsiAnimate.Name = "cmsiAnimate";
            this.cmsiAnimate.Size = new System.Drawing.Size(146, 22);
            this.cmsiAnimate.Text = "&Animate!";
            this.cmsiAnimate.Click += new System.EventHandler(this.cmsiAnimate_Click);
            // 
            // picCharacter
            // 
            this.picCharacter.ContextMenuStrip = this.cmsCharacter;
            this.picCharacter.Location = new System.Drawing.Point(0, 0);
            this.picCharacter.Name = "picCharacter";
            this.picCharacter.Size = new System.Drawing.Size(124, 93);
            this.picCharacter.TabIndex = 1;
            this.picCharacter.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 167);
            this.Controls.Add(this.picCharacter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.cmsCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsCharacter;
        private System.Windows.Forms.ToolStripMenuItem cmsiHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem csmiOptions;
        private System.Windows.Forms.ToolStripMenuItem cmsiChooseAssistant;
        private System.Windows.Forms.ToolStripMenuItem cmsiAnimate;
        private System.Windows.Forms.PictureBox picCharacter;
    }
}

