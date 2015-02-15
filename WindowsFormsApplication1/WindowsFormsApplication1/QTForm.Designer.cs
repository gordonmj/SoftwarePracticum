namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opentoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savetoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAstoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.inputToolStripMenuItem,
            this.drawToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opentoComeToolStripMenuItem,
            this.savetoComeToolStripMenuItem,
            this.saveAstoComeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toComeToolStripMenuItem});
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.inputToolStripMenuItem.Text = "Input";
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawNodeToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // drawNodeToolStripMenuItem
            // 
            this.drawNodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atCoordinatesToolStripMenuItem});
            this.drawNodeToolStripMenuItem.Name = "drawNodeToolStripMenuItem";
            this.drawNodeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.drawNodeToolStripMenuItem.Text = "Draw node";
            this.drawNodeToolStripMenuItem.Click += new System.EventHandler(this.drawNodeToolStripMenuItem_Click);
            // 
            // toComeToolStripMenuItem
            // 
            this.toComeToolStripMenuItem.Name = "toComeToolStripMenuItem";
            this.toComeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.toComeToolStripMenuItem.Text = "<To come>";
            // 
            // opentoComeToolStripMenuItem
            // 
            this.opentoComeToolStripMenuItem.Name = "opentoComeToolStripMenuItem";
            this.opentoComeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.opentoComeToolStripMenuItem.Text = "Open <to come>";
            // 
            // savetoComeToolStripMenuItem
            // 
            this.savetoComeToolStripMenuItem.Name = "savetoComeToolStripMenuItem";
            this.savetoComeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.savetoComeToolStripMenuItem.Text = "Save <to come>";
            // 
            // saveAstoComeToolStripMenuItem
            // 
            this.saveAstoComeToolStripMenuItem.Name = "saveAstoComeToolStripMenuItem";
            this.saveAstoComeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.saveAstoComeToolStripMenuItem.Text = "Save as <to come>";
            // 
            // atCoordinatesToolStripMenuItem
            // 
            this.atCoordinatesToolStripMenuItem.Name = "atCoordinatesToolStripMenuItem";
            this.atCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.atCoordinatesToolStripMenuItem.Text = "At coordinates";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawNodeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem opentoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savetoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAstoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atCoordinatesToolStripMenuItem;
    }
}

