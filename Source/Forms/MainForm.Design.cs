namespace FuckingClippy
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        System.ComponentModel.IContainer components = null;

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
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cmsCharacter = new System.Windows.Forms.ContextMenuStrip(components);
            cmsiHide = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            csmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            cmsiChooseAssistant = new System.Windows.Forms.ToolStripMenuItem();
            cmsiAnimate = new System.Windows.Forms.ToolStripMenuItem();
            picAssistant = new System.Windows.Forms.PictureBox();
            cmsCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picAssistant)).BeginInit();
            SuspendLayout();
            // 
            // cmsCharacter
            // 
            cmsCharacter.AccessibleName = "Main context menu";
            cmsCharacter.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            cmsCharacter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            cmsiHide,
            toolStripSeparator1,
            csmiOptions,
            cmsiChooseAssistant,
            cmsiAnimate});
            cmsCharacter.Name = "cmsCharacter";
            cmsCharacter.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            cmsCharacter.ShowImageMargin = false;
            cmsCharacter.ShowItemToolTips = false;
            // 
            // cmsiHide
            // 
            cmsiHide.Name = "cmsiHide";
            cmsiHide.Text = "&Hide";
            cmsiHide.Click += new System.EventHandler(cmsiHide_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // csmiOptions
            // 
            csmiOptions.Name = "csmiOptions";
            csmiOptions.Text = "&Options...";
            csmiOptions.Click += new System.EventHandler(csmiOptions_Click);
            // 
            // cmsiChooseAssistant
            // 
            cmsiChooseAssistant.Name = "cmsiChooseAssistant";
            cmsiChooseAssistant.Text = "&Choose assistant...";
            cmsiChooseAssistant.Click += new System.EventHandler(cmsiChooseAssistant_Click);
            // 
            // cmsiAnimate
            // 
            cmsiAnimate.Name = "cmsiAnimate";
            cmsiAnimate.Text = "&Animate!";
            cmsiAnimate.Click += new System.EventHandler(cmsiAnimate_Click);
            // 
            // picAssistant
            // 
            picAssistant.ContextMenuStrip = cmsCharacter;
            picAssistant.Location = new System.Drawing.Point(0, 0);
            picAssistant.Name = "picAssistant";
            picAssistant.Size = new System.Drawing.Size(124, 93);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(124, 93);
            Controls.Add(picAssistant);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "MainForm";
            Text = "Clippy";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(picAssistant)).EndInit();
        }
        
        System.Windows.Forms.ContextMenuStrip cmsCharacter;
        System.Windows.Forms.ToolStripMenuItem cmsiHide;
        System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        System.Windows.Forms.ToolStripMenuItem csmiOptions;
        System.Windows.Forms.ToolStripMenuItem cmsiChooseAssistant;
        System.Windows.Forms.ToolStripMenuItem cmsiAnimate;
        System.Windows.Forms.PictureBox picAssistant;
    }
}

