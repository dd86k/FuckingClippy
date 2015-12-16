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
            this.picCharacter = new System.Windows.Forms.PictureBox();
            this.cmsCharacter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.csmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiChooseAssistant = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiAnimate = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).BeginInit();
            this.cmsCharacter.SuspendLayout();
            this.SuspendLayout();
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
            // cmsCharacter
            // 
            this.cmsCharacter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiHide,
            this.toolStripSeparator1,
            this.csmiOptions,
            this.cmsiChooseAssistant,
            this.cmsiAnimate});
            this.cmsCharacter.Name = "cmsCharacter";
            this.cmsCharacter.Size = new System.Drawing.Size(172, 98);
            // 
            // cmsiHide
            // 
            this.cmsiHide.Name = "cmsiHide";
            this.cmsiHide.Size = new System.Drawing.Size(171, 22);
            this.cmsiHide.Text = "Hide";
            this.cmsiHide.Click += new System.EventHandler(this.cmsiHide_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // csmiOptions
            // 
            this.csmiOptions.Name = "csmiOptions";
            this.csmiOptions.Size = new System.Drawing.Size(171, 22);
            this.csmiOptions.Text = "Options...";
            // 
            // cmsiChooseAssistant
            // 
            this.cmsiChooseAssistant.Name = "cmsiChooseAssistant";
            this.cmsiChooseAssistant.Size = new System.Drawing.Size(171, 22);
            this.cmsiChooseAssistant.Text = "Choose assistant...";
            // 
            // cmsiAnimate
            // 
            this.cmsiAnimate.Name = "cmsiAnimate";
            this.cmsiAnimate.Size = new System.Drawing.Size(171, 22);
            this.cmsiAnimate.Text = "Animate !";
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
            ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).EndInit();
            this.cmsCharacter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCharacter;
        private System.Windows.Forms.ContextMenuStrip cmsCharacter;
        private System.Windows.Forms.ToolStripMenuItem cmsiHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem csmiOptions;
        private System.Windows.Forms.ToolStripMenuItem cmsiChooseAssistant;
        private System.Windows.Forms.ToolStripMenuItem cmsiAnimate;
    }
}

