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
            this.atCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atCoordinatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tofromGivenNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawEntireTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.inputToolStripMenuItem.Text = "Input";
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawNodeToolStripMenuItem,
            this.drawArrowToolStripMenuItem,
            this.drawEntireTreeToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // drawNodeToolStripMenuItem
            // 
            this.drawNodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atCoordinatesToolStripMenuItem,
            this.randomToolStripMenuItem});
            this.drawNodeToolStripMenuItem.Name = "drawNodeToolStripMenuItem";
            this.drawNodeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.drawNodeToolStripMenuItem.Text = "Draw node";
            // 
            // atCoordinatesToolStripMenuItem
            // 
            this.atCoordinatesToolStripMenuItem.Name = "atCoordinatesToolStripMenuItem";
            this.atCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.atCoordinatesToolStripMenuItem.Text = "At coordinates";
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.randomToolStripMenuItem.Text = "Random";
            // 
            // drawArrowToolStripMenuItem
            // 
            this.drawArrowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atCoordinatesToolStripMenuItem1,
            this.tofromGivenNodeToolStripMenuItem});
            this.drawArrowToolStripMenuItem.Name = "drawArrowToolStripMenuItem";
            this.drawArrowToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.drawArrowToolStripMenuItem.Text = "Draw arrow";
            // 
            // atCoordinatesToolStripMenuItem1
            // 
            this.atCoordinatesToolStripMenuItem1.Name = "atCoordinatesToolStripMenuItem1";
            this.atCoordinatesToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.atCoordinatesToolStripMenuItem1.Text = "At coordinates";
            // 
            // tofromGivenNodeToolStripMenuItem
            // 
            this.tofromGivenNodeToolStripMenuItem.Name = "tofromGivenNodeToolStripMenuItem";
            this.tofromGivenNodeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.tofromGivenNodeToolStripMenuItem.Text = "To/from given node";
            // 
            // drawEntireTreeToolStripMenuItem
            // 
            this.drawEntireTreeToolStripMenuItem.Name = "drawEntireTreeToolStripMenuItem";
            this.drawEntireTreeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.drawEntireTreeToolStripMenuItem.Text = "Draw entire tree";
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
        private System.Windows.Forms.ToolStripMenuItem atCoordinatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atCoordinatesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tofromGivenNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawEntireTreeToolStripMenuItem;
    }
}

