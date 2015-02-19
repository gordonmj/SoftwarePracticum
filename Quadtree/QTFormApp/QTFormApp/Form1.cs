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

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drawWhiteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawWhiteNode";
            MessageBox.Show("Double click anywhere on the panel to draw a white node.");
        }

        private void drawBlackNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawBlackNode";
            MessageBox.Show("Double click anywhere on the panel to draw a black node.");

        }

        private void drawGreyNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawGreyNode";
            MessageBox.Show("Double click anywhere on the panel to draw a grey node.");

        }

        private void drawArrowtoComeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawArrow";
            MessageBox.Show("Double click on two points on the panel to draw an arrow.");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mea = (MouseEventArgs)e;
                coords = mea.Location;
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e){}

        private void canvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs mea = e;
            Point whereClicked = mea.Location;
         
            Graphics graphic_obj = canvas.CreateGraphics();
            Brush black = new SolidBrush(Color.Black);
            Pen border = new Pen(black, 1);
            Brush white = new SolidBrush(Color.White);
            switch (clicked)
            {
                case "drawWhiteNode":
                    graphic_obj.FillEllipse(white, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    break;
                case "drawBlackNode":
                    graphic_obj.FillEllipse(black, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
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
                    graphic_obj.FillEllipse(lgb, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    break;
                case "drawArrow":
                    clicked = "finishArrow";
                    firstClick = whereClicked;
                    break;
                case "finishArrow":
                    Pen arrow = new Pen(black, 3);
                    arrow.EndCap = LineCap.ArrowAnchor;
                    graphic_obj.DrawLine(arrow,firstClick,whereClicked);
                    break;
                default:
                    break;
            }
        }

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

            string[] lines = System.IO.File.ReadAllLines(@fileName);
            char[] delims = { ' ', '\n' };
            string[] firstLine = lines[0].Split(delims);
            int numRows = Convert.ToInt32(firstLine[0]);
            int numCols = Convert.ToInt32(firstLine[1]);
            int maxVal = Convert.ToInt32(firstLine[2]);
            int minVal = Convert.ToInt32(firstLine[3]);
//            MessageBox.Show("Number of rows is " + numRows + ", number of colums is " + numCols + ", max value is " + maxVal + ", and min value is " + minVal);

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
