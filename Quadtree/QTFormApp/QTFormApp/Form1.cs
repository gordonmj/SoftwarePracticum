using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QTFormApp
{
    public partial class Form1 : Form
    {
        private String clicked;
        public Point coords;
        public Point firstClick;
        public string fileName;
        public int nodeW = 50;
        public int nodeH = 25;
        public System.Drawing.Graphics panel1Graphics;
        public System.Drawing.Graphics graphic_obj;
        public System.Drawing.Graphics formGraphic;
        public System.Drawing.Graphics canvasGraphics;
        public Brush black = new SolidBrush(Color.Black);
        public Brush white = new SolidBrush(Color.White);
        public Brush gray = new SolidBrush(Color.Gray);
        public int formWidth;
        public int formHeight;

        public Form1()
        {
            InitializeComponent();
            formGraphic = this.CreateGraphics();
            formWidth = this.Width;
            formHeight = this.Height;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drawWhiteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawWhiteNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a white node.");
        }

        private void drawBlackNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawBlackNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a black node.");
        }

        private void drawGreyNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawGreyNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a grey node.");
        }

        private void drawArrowtoComeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawArrow";
            MessageBox.Show("Double click on two points on the right panel to draw an arrow.");
        }

        private void drawRandomNodetoComeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawRandom";
            Random rando = new Random();
            
            int y = rando.Next(10, panel1.Height-nodeH);
            int x = rando.Next(5, panel1.Width-nodeW);
            int color = rando.Next(0, 2);
            Brush[] brushes = {black, white};
            //formGraphic.FillEllipse(brushes[color], new Rectangle(new Point(x, y), new Size(nodeW, nodeH)));
            panel1Graphics.FillEllipse(brushes[color], new Rectangle(new Point(x, y), new Size(nodeW, nodeH)));
        }
        /*
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mea = (MouseEventArgs)e;
                coords = mea.Location;
            }
        }
        */
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void opentoComeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Plaintext Files|*.txt";
            oFD.Title = "Select a Plaintext File";

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                fileName = oFD.FileName;
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void drawMaptoComeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen border = new Pen(black, 1);
            if (fileName == null)
            {
                MessageBox.Show("You must select an input file first. Use 'File>Load/Open'");
                return;
            }
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            char[] delims = { ' ', '\n' };
            string[] firstLine = lines[0].Split(delims);
            int numRows = Convert.ToInt32(firstLine[0]);
            int numCols = Convert.ToInt32(firstLine[1]);
            int maxVal = Convert.ToInt32(firstLine[2]);
            int minVal = Convert.ToInt32(firstLine[3]);
            int[,] map = new int[numRows,numCols];
            string mapToPrint = "";
            for (int r = 0; r < numRows; r++)
            {
                string[] nextLine = lines[r + 1].Split(delims);
                for (int c = 0; c < numCols; c++)
                {
                    map[r, c] = Convert.ToInt32(nextLine[c]);
                    mapToPrint += nextLine[c];
                }
                mapToPrint += "\n";
            }
            int offset = 10;
            int size;
            if ((formWidth/numCols)/2 > (formHeight-offset)/numRows)
                size = (formHeight-offset)/numRows;
            else
                size = (formWidth/numCols)/2;
            formGraphic.Clear(Color.Gray);
            //MessageBox.Show("Form: width " + formWidth + " and hieght " + formHeight + " and size " + size);
            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    if (map[r, c] == 1)
                    {
                        //MessageBox.Show("Postion "+r+" & "+c+": 1!");
                        formGraphic.FillRectangle(black, new Rectangle(offset+(c*size), offset+10+(r*size), size, size));
                    }
                    else
                    {
                        //MessageBox.Show("Postion " + r + " & " + c + ": 0!");
                        formGraphic.FillRectangle(white, new Rectangle(offset+(c * size), offset+10+(r * size), size, size));
                    }
                }
            }
//            MessageBox.Show(mapToPrint);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
            MouseEventArgs mea = e;
            Point whereClicked = mea.Location;

            //            graphic_obj = canvas.CreateGraphics();
            switch (clicked)
            {
                case "drawWhiteNode":
                    formGraphic.FillEllipse(white, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    break;
                case "drawBlackNode":
                    formGraphic.FillEllipse(black, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    break;
                case "drawGreyNode":
                    LinearGradientBrush lgb = new LinearGradientBrush(
                    whereClicked,
                    new Point(whereClicked.X + 50, whereClicked.Y),
                    Color.FromArgb(255, 255, 255),
                    Color.FromArgb(0, 0, 0));
                    float[] intensities = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
                    float[] positions = { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                    Blend blend = new Blend();
                    blend.Factors = intensities;
                    blend.Positions = positions;
                    lgb.Blend = blend;
                    Pen gradientPen = new Pen(lgb);
                    formGraphic.FillEllipse(lgb, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    panel1Graphics.FillEllipse(lgb, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    break;
                case "drawArrow":
                    clicked = "finishArrow";
                    firstClick = whereClicked;
                    break;
                case "finishArrow":
                    Pen arrow = new Pen(black, 3);
                    arrow.EndCap = LineCap.ArrowAnchor;
                    formGraphic.DrawLine(arrow, firstClick, whereClicked);
                    clicked = "drawArrow";
                    break;
                default:
                    break;
            }
             */
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //InitializeComponent();
            panel1Graphics = panel1.CreateGraphics();
            //panel1Graphics = e.Graphics;
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs mea = e;
            Point whereClicked = mea.Location;

            switch (clicked)
            {
                case "drawWhiteNode":
                    panel1Graphics.FillEllipse(white, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    break;
                case "drawBlackNode":
                    panel1Graphics.FillEllipse(black, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    break;
                case "drawGreyNode":
                    LinearGradientBrush lgb = new LinearGradientBrush(
                    whereClicked,
                    new Point(whereClicked.X + 50, whereClicked.Y),
                    Color.FromArgb(255, 255, 255),
                    Color.FromArgb(0, 0, 0));
                    float[] intensities = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
                    float[] positions = { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                    Blend blend = new Blend();
                    blend.Factors = intensities;
                    blend.Positions = positions;
                    lgb.Blend = blend;
                    Pen gradientPen = new Pen(lgb);
//                    formGraphic.FillEllipse(lgb, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    panel1Graphics.FillEllipse(lgb, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    break;
                case "drawArrow":
                    clicked = "finishArrow";
                    firstClick = whereClicked;
                    break;
                case "finishArrow":
                    Pen arrow = new Pen(black, 3);
                    arrow.EndCap = LineCap.ArrowAnchor;
                    panel1Graphics.DrawLine(arrow, firstClick, whereClicked);
                    clicked = "drawArrow";
                    break;
                default:
                    break;
            }

        }


    }
}
