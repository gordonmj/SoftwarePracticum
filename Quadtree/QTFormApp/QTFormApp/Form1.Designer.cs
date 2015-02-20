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
            this.opentoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savetoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAstoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWhiteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawBlackNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawGreyNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawArrowtoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawRandomNodetoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWholeTreetoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawMaptoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvas = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // opentoComeToolStripMenuItem
            // 
            this.opentoComeToolStripMenuItem.Name = "opentoComeToolStripMenuItem";
            this.opentoComeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.opentoComeToolStripMenuItem.Text = "Open <to come>";
            this.opentoComeToolStripMenuItem.Click += new System.EventHandler(this.opentoComeToolStripMenuItem_Click);
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
            this.drawArrowtoComeToolStripMenuItem,
            this.drawRandomNodetoComeToolStripMenuItem,
            this.drawWholeTreetoComeToolStripMenuItem,
            this.drawMaptoComeToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // drawWhiteNodeToolStripMenuItem
            // 
            this.drawWhiteNodeToolStripMenuItem.Name = "drawWhiteNodeToolStripMenuItem";
            this.drawWhiteNodeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.drawWhiteNodeToolStripMenuItem.Text = "Draw white node";
            this.drawWhiteNodeToolStripMenuItem.Click += new System.EventHandler(this.drawWhiteNodeToolStripMenuItem_Click);
            // 
            // drawBlackNodeToolStripMenuItem
            // 
            this.drawBlackNodeToolStripMenuItem.Name = "drawBlackNodeToolStripMenuItem";
            this.drawBlackNodeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.drawBlackNodeToolStripMenuItem.Text = "Draw black node";
            this.drawBlackNodeToolStripMenuItem.Click += new System.EventHandler(this.drawBlackNodeToolStripMenuItem_Click);
            // 
            // drawGreyNodeToolStripMenuItem
            // 
            this.drawGreyNodeToolStripMenuItem.Name = "drawGreyNodeToolStripMenuItem";
            this.drawGreyNodeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.drawGreyNodeToolStripMenuItem.Text = "Draw grey node";
            this.drawGreyNodeToolStripMenuItem.Click += new System.EventHandler(this.drawGreyNodeToolStripMenuItem_Click);
            // 
            // drawArrowtoComeToolStripMenuItem
            // 
            this.drawArrowtoComeToolStripMenuItem.Name = "drawArrowtoComeToolStripMenuItem";
            this.drawArrowtoComeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.drawArrowtoComeToolStripMenuItem.Text = "Draw arrow";
            this.drawArrowtoComeToolStripMenuItem.Click += new System.EventHandler(this.drawArrowtoComeToolStripMenuItem_Click);
            // 
            // drawRandomNodetoComeToolStripMenuItem
            // 
            this.drawRandomNodetoComeToolStripMenuItem.Name = "drawRandomNodetoComeToolStripMenuItem";
            this.drawRandomNodetoComeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.drawRandomNodetoComeToolStripMenuItem.Text = "Draw random node <to come>";
            // 
            // drawWholeTreetoComeToolStripMenuItem
            // 
            this.drawWholeTreetoComeToolStripMenuItem.Name = "drawWholeTreetoComeToolStripMenuItem";
            this.drawWholeTreetoComeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.drawWholeTreetoComeToolStripMenuItem.Text = "Draw whole tree <to come>";
            // 
            // drawMaptoComeToolStripMenuItem
            // 
            this.drawMaptoComeToolStripMenuItem.Name = "drawMaptoComeToolStripMenuItem";
            this.drawMaptoComeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.drawMaptoComeToolStripMenuItem.Text = "Draw map <to come>";
            this.drawMaptoComeToolStripMenuItem.Click += new System.EventHandler(this.drawMaptoComeToolStripMenuItem_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.Gainsboro;
            this.canvas.Location = new System.Drawing.Point(3, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(341, 234);
            this.canvas.TabIndex = 2;
            this.canvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.canvas);
            this.splitContainer1.Size = new System.Drawing.Size(676, 234);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 231);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 262);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "QuadTree Painter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opentoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savetoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAstoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWhiteNodeToolStripMenuItem;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.ToolStripMenuItem drawBlackNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawGreyNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawRandomNodetoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawArrowtoComeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWholeTreetoComeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem drawMaptoComeToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
    }
}

