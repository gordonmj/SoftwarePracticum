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
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preorderFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asQuadtreeTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.asMatrixTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asPreorderTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeNodeSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToQuadtreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadtreeToImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.asTextFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.randomMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTreeSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.manualToolStripMenuItem,
            this.automatedToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1043, 24);
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
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matrixFormatToolStripMenuItem,
            this.preorderFormatToolStripMenuItem,
            this.randomMatrixToolStripMenuItem});
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // matrixFormatToolStripMenuItem
            // 
            this.matrixFormatToolStripMenuItem.Name = "matrixFormatToolStripMenuItem";
            this.matrixFormatToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.matrixFormatToolStripMenuItem.Text = "Matrix format";
            this.matrixFormatToolStripMenuItem.Click += new System.EventHandler(this.matrixFormatToolStripMenuItem_Click);
            // 
            // preorderFormatToolStripMenuItem
            // 
            this.preorderFormatToolStripMenuItem.Name = "preorderFormatToolStripMenuItem";
            this.preorderFormatToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.preorderFormatToolStripMenuItem.Text = "Preorder format";
            this.preorderFormatToolStripMenuItem.Click += new System.EventHandler(this.preorderFormatToolStripMenuItem_Click);
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
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asTextFileToolStripMenuItem,
            this.asQuadtreeTextToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // asTextFileToolStripMenuItem
            // 
            this.asTextFileToolStripMenuItem.Name = "asTextFileToolStripMenuItem";
            this.asTextFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.asTextFileToolStripMenuItem.Text = "As matrix text";
            this.asTextFileToolStripMenuItem.Click += new System.EventHandler(this.asTextFileToolStripMenuItem_Click_1);
            // 
            // asQuadtreeTextToolStripMenuItem
            // 
            this.asQuadtreeTextToolStripMenuItem.Name = "asQuadtreeTextToolStripMenuItem";
            this.asQuadtreeTextToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.asQuadtreeTextToolStripMenuItem.Text = "As quadtree text";
            this.asQuadtreeTextToolStripMenuItem.Click += new System.EventHandler(this.asQuadtreeTextToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // displayImageToolStripMenuItem
            // 
            this.displayImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.displayToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.resizeTreeToolStripMenuItem,
            this.closeToolStripMenuItem1});
            this.displayImageToolStripMenuItem.Name = "displayImageToolStripMenuItem";
            this.displayImageToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.displayImageToolStripMenuItem.Text = "Quadtree";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // displayToolStripMenuItem1
            // 
            this.displayToolStripMenuItem1.Name = "displayToolStripMenuItem1";
            this.displayToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.displayToolStripMenuItem1.Text = "Display";
            this.displayToolStripMenuItem1.Click += new System.EventHandler(this.displayToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asMatrixTextFileToolStripMenuItem,
            this.asPreorderTextFileToolStripMenuItem});
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // asMatrixTextFileToolStripMenuItem
            // 
            this.asMatrixTextFileToolStripMenuItem.Name = "asMatrixTextFileToolStripMenuItem";
            this.asMatrixTextFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.asMatrixTextFileToolStripMenuItem.Text = "As matrix text file";
            // 
            // asPreorderTextFileToolStripMenuItem
            // 
            this.asPreorderTextFileToolStripMenuItem.Name = "asPreorderTextFileToolStripMenuItem";
            this.asPreorderTextFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.asPreorderTextFileToolStripMenuItem.Text = "As preorder text file";
            this.asPreorderTextFileToolStripMenuItem.Click += new System.EventHandler(this.asPreorderTextFileToolStripMenuItem_Click);
            // 
            // resizeTreeToolStripMenuItem
            // 
            this.resizeTreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeNodeSizeToolStripMenuItem,
            this.changeTreeSizeToolStripMenuItem});
            this.resizeTreeToolStripMenuItem.Name = "resizeTreeToolStripMenuItem";
            this.resizeTreeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resizeTreeToolStripMenuItem.Text = "Resize tree";
            this.resizeTreeToolStripMenuItem.Click += new System.EventHandler(this.resizeTreeToolStripMenuItem_Click);
            // 
            // changeNodeSizeToolStripMenuItem
            // 
            this.changeNodeSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.largeToolStripMenuItem});
            this.changeNodeSizeToolStripMenuItem.Name = "changeNodeSizeToolStripMenuItem";
            this.changeNodeSizeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.changeNodeSizeToolStripMenuItem.Text = "Change node size";
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.smallToolStripMenuItem.Text = "Small";
            this.smallToolStripMenuItem.Click += new System.EventHandler(this.smallToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // largeToolStripMenuItem
            // 
            this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            this.largeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.largeToolStripMenuItem.Text = "Large";
            this.largeToolStripMenuItem.Click += new System.EventHandler(this.largeToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawNodeToolStripMenuItem,
            this.drawArrowToolStripMenuItem,
            this.moveTreeToolStripMenuItem});
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // drawNodeToolStripMenuItem
            // 
            this.drawNodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.whiteToolStripMenuItem,
            this.grayToolStripMenuItem});
            this.drawNodeToolStripMenuItem.Name = "drawNodeToolStripMenuItem";
            this.drawNodeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.drawNodeToolStripMenuItem.Text = "Draw node";
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.blackToolStripMenuItem.Text = "Black";
            this.blackToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.whiteToolStripMenuItem.Text = "White";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // grayToolStripMenuItem
            // 
            this.grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            this.grayToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.grayToolStripMenuItem.Text = "Gray";
            this.grayToolStripMenuItem.Click += new System.EventHandler(this.grayToolStripMenuItem_Click);
            // 
            // drawArrowToolStripMenuItem
            // 
            this.drawArrowToolStripMenuItem.Name = "drawArrowToolStripMenuItem";
            this.drawArrowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.drawArrowToolStripMenuItem.Text = "Draw arrow";
            this.drawArrowToolStripMenuItem.Click += new System.EventHandler(this.drawArrowToolStripMenuItem_Click);
            // 
            // moveTreeToolStripMenuItem
            // 
            this.moveTreeToolStripMenuItem.Name = "moveTreeToolStripMenuItem";
            this.moveTreeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moveTreeToolStripMenuItem.Text = "Move tree";
            this.moveTreeToolStripMenuItem.Click += new System.EventHandler(this.moveTreeToolStripMenuItem_Click);
            // 
            // automatedToolStripMenuItem
            // 
            this.automatedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToQuadtreeToolStripMenuItem,
            this.quadtreeToImageToolStripMenuItem,
            this.compareToolStripMenuItem});
            this.automatedToolStripMenuItem.Name = "automatedToolStripMenuItem";
            this.automatedToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.automatedToolStripMenuItem.Text = "Automated";
            // 
            // imageToQuadtreeToolStripMenuItem
            // 
            this.imageToQuadtreeToolStripMenuItem.Name = "imageToQuadtreeToolStripMenuItem";
            this.imageToQuadtreeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.imageToQuadtreeToolStripMenuItem.Text = "Image to Quadtree";
            this.imageToQuadtreeToolStripMenuItem.Click += new System.EventHandler(this.imageToQuadtreeToolStripMenuItem_Click);
            // 
            // quadtreeToImageToolStripMenuItem
            // 
            this.quadtreeToImageToolStripMenuItem.Name = "quadtreeToImageToolStripMenuItem";
            this.quadtreeToImageToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.quadtreeToImageToolStripMenuItem.Text = "Quadtree to Image";
            this.quadtreeToImageToolStripMenuItem.Click += new System.EventHandler(this.quadtreeToImageToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.compareToolStripMenuItem.Text = "Compare";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // asTextFileToolStripMenuItem1
            // 
            this.asTextFileToolStripMenuItem1.Name = "asTextFileToolStripMenuItem1";
            this.asTextFileToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.asTextFileToolStripMenuItem1.Text = "As Text File";
            this.asTextFileToolStripMenuItem1.Click += new System.EventHandler(this.asTextFileToolStripMenuItem1_Click);
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1043, 600);
            this.splitContainer1.SplitterDistance = 507;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 600);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 600);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDoubleClick);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // randomMatrixToolStripMenuItem
            // 
            this.randomMatrixToolStripMenuItem.Name = "randomMatrixToolStripMenuItem";
            this.randomMatrixToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.randomMatrixToolStripMenuItem.Text = "Random matrix";
            this.randomMatrixToolStripMenuItem.Click += new System.EventHandler(this.randomMatrixToolStripMenuItem_Click);
            // 
            // changeTreeSizeToolStripMenuItem
            // 
            this.changeTreeSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallToolStripMenuItem1,
            this.mediumToolStripMenuItem1,
            this.largeToolStripMenuItem1});
            this.changeTreeSizeToolStripMenuItem.Name = "changeTreeSizeToolStripMenuItem";
            this.changeTreeSizeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.changeTreeSizeToolStripMenuItem.Text = "Change tree size";
            // 
            // smallToolStripMenuItem1
            // 
            this.smallToolStripMenuItem1.Name = "smallToolStripMenuItem1";
            this.smallToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.smallToolStripMenuItem1.Text = "Small";
            this.smallToolStripMenuItem1.Click += new System.EventHandler(this.smallToolStripMenuItem1_Click);
            // 
            // mediumToolStripMenuItem1
            // 
            this.mediumToolStripMenuItem1.Name = "mediumToolStripMenuItem1";
            this.mediumToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.mediumToolStripMenuItem1.Text = "Medium";
            this.mediumToolStripMenuItem1.Click += new System.EventHandler(this.mediumToolStripMenuItem1_Click);
            // 
            // largeToolStripMenuItem1
            // 
            this.largeToolStripMenuItem1.Name = "largeToolStripMenuItem1";
            this.largeToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.largeToolStripMenuItem1.Text = "Large";
            this.largeToolStripMenuItem1.Click += new System.EventHandler(this.largeToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1043, 624);
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
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
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToQuadtreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quadtreeToImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asTextFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asQuadtreeTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeNodeSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrixFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preorderFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asMatrixTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asPreorderTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeTreeSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem1;
    }
}
