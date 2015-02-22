namespace QTFormApp
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
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savetoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAstoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWhiteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawBlackNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawGreyNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawRandomNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWholeTreetoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.drawToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.savetoComeToolStripMenuItem,
            this.saveAstoComeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openToolStripMenuItem.Text = "Load/Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.opentoComeToolStripMenuItem_Click);
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
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawWhiteNodeToolStripMenuItem,
            this.drawBlackNodeToolStripMenuItem,
            this.drawGreyNodeToolStripMenuItem,
            this.drawArrowToolStripMenuItem,
            this.drawRandomNodeToolStripMenuItem,
            this.drawMapToolStripMenuItem,
            this.drawWholeTreetoComeToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // drawWhiteNodeToolStripMenuItem
            // 
            this.drawWhiteNodeToolStripMenuItem.Name = "drawWhiteNodeToolStripMenuItem";
            this.drawWhiteNodeToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.drawWhiteNodeToolStripMenuItem.Text = "Draw white node";
            this.drawWhiteNodeToolStripMenuItem.Click += new System.EventHandler(this.drawWhiteNodeToolStripMenuItem_Click);
            // 
            // drawBlackNodeToolStripMenuItem
            // 
            this.drawBlackNodeToolStripMenuItem.Name = "drawBlackNodeToolStripMenuItem";
            this.drawBlackNodeToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.drawBlackNodeToolStripMenuItem.Text = "Draw black node";
            this.drawBlackNodeToolStripMenuItem.Click += new System.EventHandler(this.drawBlackNodeToolStripMenuItem_Click);
            // 
            // drawGreyNodeToolStripMenuItem
            // 
            this.drawGreyNodeToolStripMenuItem.Name = "drawGreyNodeToolStripMenuItem";
            this.drawGreyNodeToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.drawGreyNodeToolStripMenuItem.Text = "Draw grey node";
            this.drawGreyNodeToolStripMenuItem.Click += new System.EventHandler(this.drawGreyNodeToolStripMenuItem_Click);
            // 
            // drawArrowToolStripMenuItem
            // 
            this.drawArrowToolStripMenuItem.Name = "drawArrowToolStripMenuItem";
            this.drawArrowToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.drawArrowToolStripMenuItem.Text = "Draw arrow";
            this.drawArrowToolStripMenuItem.Click += new System.EventHandler(this.drawArrowtoComeToolStripMenuItem_Click);
            // 
            // drawRandomNodeToolStripMenuItem
            // 
            this.drawRandomNodeToolStripMenuItem.Name = "drawRandomNodeToolStripMenuItem";
            this.drawRandomNodeToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.drawRandomNodeToolStripMenuItem.Text = "Draw random node";
            this.drawRandomNodeToolStripMenuItem.Click += new System.EventHandler(this.drawRandomNodetoComeToolStripMenuItem_Click);
            // 
            // drawMapToolStripMenuItem
            // 
            this.drawMapToolStripMenuItem.Name = "drawMapToolStripMenuItem";
            this.drawMapToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.drawMapToolStripMenuItem.Text = "Draw map";
            this.drawMapToolStripMenuItem.Click += new System.EventHandler(this.drawMaptoComeToolStripMenuItem_Click);
            // 
            // drawWholeTreetoComeToolStripMenuItem
            // 
            this.drawWholeTreetoComeToolStripMenuItem.Name = "drawWholeTreetoComeToolStripMenuItem";
            this.drawWholeTreetoComeToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.drawWholeTreetoComeToolStripMenuItem.Text = "Draw whole tree <to come>";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(676, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "QuadTree Painter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savetoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAstoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWhiteNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawBlackNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawGreyNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawRandomNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWholeTreetoComeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem drawMapToolStripMenuItem;
    }
}

