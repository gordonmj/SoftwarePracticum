﻿namespace QTFormApp
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
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWhiteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawBlackNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawGreyNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawRandomNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWholeTreetoComeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.imageToolStripMenuItem,
            this.displayImageToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.displayToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.displayToolStripMenuItem.Text = "Display";
            this.displayToolStripMenuItem.Click += new System.EventHandler(this.displayToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // displayImageToolStripMenuItem
            // 
            this.displayImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.displayToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.closeToolStripMenuItem1});
            this.displayImageToolStripMenuItem.Name = "displayImageToolStripMenuItem";
            this.displayImageToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.displayImageToolStripMenuItem.Text = "Quadtree";
            this.displayImageToolStripMenuItem.Click += new System.EventHandler(this.displayImageToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // displayToolStripMenuItem1
            // 
            this.displayToolStripMenuItem1.Name = "displayToolStripMenuItem1";
            this.displayToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.displayToolStripMenuItem1.Text = "Display";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.closeToolStripMenuItem1.Text = "Close";
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
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.drawToolStripMenuItem.Text = "Manual draw";
            // 
            // drawWhiteNodeToolStripMenuItem
            // 
            this.drawWhiteNodeToolStripMenuItem.Name = "drawWhiteNodeToolStripMenuItem";
            this.drawWhiteNodeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.drawWhiteNodeToolStripMenuItem.Text = "Draw white node";
            this.drawWhiteNodeToolStripMenuItem.Click += new System.EventHandler(this.drawWhiteNodeToolStripMenuItem_Click);
            // 
            // drawBlackNodeToolStripMenuItem
            // 
            this.drawBlackNodeToolStripMenuItem.Name = "drawBlackNodeToolStripMenuItem";
            this.drawBlackNodeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.drawBlackNodeToolStripMenuItem.Text = "Draw black node";
            this.drawBlackNodeToolStripMenuItem.Click += new System.EventHandler(this.drawBlackNodeToolStripMenuItem_Click);
            // 
            // drawGreyNodeToolStripMenuItem
            // 
            this.drawGreyNodeToolStripMenuItem.Name = "drawGreyNodeToolStripMenuItem";
            this.drawGreyNodeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.drawGreyNodeToolStripMenuItem.Text = "Draw grey node";
            this.drawGreyNodeToolStripMenuItem.Click += new System.EventHandler(this.drawGreyNodeToolStripMenuItem_Click);
            // 
            // drawArrowToolStripMenuItem
            // 
            this.drawArrowToolStripMenuItem.Name = "drawArrowToolStripMenuItem";
            this.drawArrowToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.drawArrowToolStripMenuItem.Text = "Draw arrow";
            this.drawArrowToolStripMenuItem.Click += new System.EventHandler(this.drawArrowtoComeToolStripMenuItem_Click);
            // 
            // drawRandomNodeToolStripMenuItem
            // 
            this.drawRandomNodeToolStripMenuItem.Name = "drawRandomNodeToolStripMenuItem";
            this.drawRandomNodeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.drawRandomNodeToolStripMenuItem.Text = "Draw random node";
            this.drawRandomNodeToolStripMenuItem.Click += new System.EventHandler(this.drawRandomNodetoComeToolStripMenuItem_Click);
            // 
            // drawMapToolStripMenuItem
            // 
            this.drawMapToolStripMenuItem.Name = "drawMapToolStripMenuItem";
            this.drawMapToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.drawMapToolStripMenuItem.Text = "Draw map";
            this.drawMapToolStripMenuItem.Click += new System.EventHandler(this.drawMaptoComeToolStripMenuItem_Click);
            // 
            // drawWholeTreetoComeToolStripMenuItem
            // 
            this.drawWholeTreetoComeToolStripMenuItem.Name = "drawWholeTreetoComeToolStripMenuItem";
            this.drawWholeTreetoComeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.drawWholeTreetoComeToolStripMenuItem.Text = "Draw whole tree";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(676, 238);
            this.splitContainer1.SplitterDistance = 310;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Paint);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 238);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 238);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(676, 262);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "QuadTree Painter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem displayImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
    }
}

