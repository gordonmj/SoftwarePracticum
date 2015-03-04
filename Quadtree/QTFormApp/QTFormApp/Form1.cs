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
        public static int nodeW = 40;
        public static int nodeH = 30;
        public System.Drawing.Graphics panel1Graphics;
        public System.Drawing.Graphics panel2Graphics;
        public System.Drawing.Graphics formGraphic;
        public System.Drawing.Graphics canvasGraphics;
        public Brush black = new SolidBrush(Color.Black);
        public Brush white = new SolidBrush(Color.White);
        public Brush gray = new SolidBrush(Color.Gray);
        public int formWidth;
        public int formHeight;
        public Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
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
            
            int y = rando.Next(10, splitContainer1.Height-nodeH);
            int x = rando.Next(5, splitContainer1.Width-nodeW);
            int color = rando.Next(0, 2);
            Brush[] brushes = {black, white};
            panel2Graphics.FillEllipse(brushes[color], new Rectangle(new Point(x, y), new Size(nodeW, nodeH)));
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            panel1Graphics = panel1.CreateGraphics();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2Graphics = panel2.CreateGraphics();
        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs mea = e;
            Point whereClicked = mea.Location;

            switch (clicked)
            {
                case "drawWhiteNode":
                    panel2Graphics.FillEllipse(white, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                   // Node whiteNode = Node.drawNode(panel2Graphics, whereClicked, Color.White);              
                    break;
                case "drawBlackNode":
                    //Node blackNode = Node.drawNode(panel2Graphics, whereClicked, Color.Black);              
                    panel2Graphics.FillEllipse(black, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    break;
                case "drawGreyNode":
                    LinearGradientBrush lgb = new LinearGradientBrush(
                    whereClicked,
                    new Point(whereClicked.X + 40, whereClicked.Y),
                    Color.FromArgb(255, 255, 255),
                    Color.FromArgb(0, 0, 0));
                    float[] intensities = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
                    float[] positions = { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                    Blend blend = new Blend();
                    blend.Factors = intensities;
                    blend.Positions = positions;
                    lgb.Blend = blend;
                    panel2Graphics.FillEllipse(lgb, new Rectangle(whereClicked, new Size(nodeW, nodeH)));
                    //Node grayNode = Node.drawNode(panel2Graphics, whereClicked, lgb);              
                    break;
                case "drawArrow":
                    clicked = "finishArrow";
                    firstClick = whereClicked;
                    break;
                case "finishArrow":
                    Pen arrow = new Pen(black, 3);
                    arrow.EndCap = LineCap.ArrowAnchor;
                    panel2Graphics.DrawLine(arrow, firstClick, whereClicked);
                    clicked = "drawArrow";
                    break;
                default:
                    break;
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to quit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                this.Close();
            }

            else if (answer == DialogResult.No)
            {
                return;
            }

        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Plaintext Files|*.txt";
            oFD.Title = "Select a Plaintext File";

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                fileName = oFD.FileName;
            }
            displayToolStripMenuItem_Click(sender, e);
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pen border = new Pen(gray, 1);
            if (fileName == null)
            {
                MessageBox.Show("You must select an input file first. Use 'Image>Load'");
                return;
            }
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            char[] delims = { ' ', '\n' };
            string[] firstLine = lines[0].Split(delims);
            int numRows = Convert.ToInt32(firstLine[0]);
            int numCols = Convert.ToInt32(firstLine[1]);
            int maxVal = Convert.ToInt32(firstLine[2]);
            int minVal = Convert.ToInt32(firstLine[3]);
            int[,] map = new int[numRows, numCols];
            for (int r = 0; r < numRows; r++)
            {
                string[] nextLine = lines[r + 1].Split(delims);
                for (int c = 0; c < numCols; c++)
                {
                    map[r, c] = Convert.ToInt32(nextLine[c]);
                }
            }
            Node root = new Node();
            root = whatColor(root, map, 0, numRows - 1, 0, numCols - 1);
            int offset = 10;
            int size;
            if ((formWidth / numCols) / 2 > (formHeight - offset) / numRows)
                size = ((formHeight - offset) / numRows) - offset;
            else
                size = (((formWidth - offset) / numCols) / 2) - offset;
            panel1Graphics.Clear(Color.Gray);
            bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);
            using (Graphics bmpGraphic = Graphics.FromImage(bmp))
            {
                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        if (map[r, c] == 1)
                        {
                            panel1Graphics.FillRectangle(black, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            panel1Graphics.DrawRectangle(border, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            bmpGraphic.FillRectangle(black, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            bmpGraphic.DrawRectangle(border, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                        }
                        else
                        {
                            panel1Graphics.FillRectangle(white, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            panel1Graphics.DrawRectangle(border, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            bmpGraphic.FillRectangle(white, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            bmpGraphic.DrawRectangle(border, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                        }
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Images|*.png;*.bmp;*.jpg";
            save.Title = "Save the image";
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
            if (save.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(save.FileName, format);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1Graphics.Clear(Color.Gray);
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawBlackNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a black node.");
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawWhiteNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a white node.");
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawGreyNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a grey node.");
        }

        private void drawArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clicked = "drawArrow";
            MessageBox.Show("Double click on two points on the right panel to draw an arrow.");
        }

        enum NodeColor
        {
            Black,
            White,
            Gray
        }

        private Node whatColor(Node root, int[,] m, int rowStart, int rowStop, int colStart, int colStop)
        {
            if ((rowStop - rowStart != colStop - colStart))
            {
                MessageBox.Show("Error! rowStart: "+rowStart+" rowStop "+rowStop+" colStart: "+colStart+" and colStop: "+colStop);
                //throw new Exception("Not a square!");
                this.Close();
                return null;
            }
            MessageBox.Show("rowStart: " + rowStart + " rowStop: " + rowStop + " colStart: " + colStart + " colStop: " + colStop);
            if (rowStop - rowStart < 0)
            {
                MessageBox.Show("rowStart: " + rowStart + " and rowStop: " + rowStop + " colStart: " + colStart + " and colStop: " + colStop);
                //throw new Exception("Invalid params");
                this.Close();
                return null;
            }
            else if (rowStop - rowStart == 0)
            {
                if (m[rowStart, colStart] == 1)
                {
                    //MessageBox.Show("At coords " + rowStart + ", " + colStop + " the color is black.");
                    root.setColor(Color.Black);
                    return root;
                }
                else
                    //MessageBox.Show("At coords " + rowStart + ", " + colStop + " the color is white.");
                    root.setColor(Color.White);
                    return root;
            }
            else
            {
                int midPointRow = (rowStop - rowStart) / 2;
                int midPointCol = (colStop - colStart) / 2;
                root.NW = whatColor(root, m, rowStart, midPointRow, colStart, midPointCol);
                root.SW = whatColor(root, m, midPointRow + 1, rowStop, colStart, midPointCol);
                root.SE = whatColor(root, m, midPointRow + 1, rowStop, midPointCol + 1, colStop);
                root.NE = whatColor(root, m, rowStart, midPointRow, midPointCol + 1, colStop);
                if (root.NW.getColor() == root.SW.getColor() && root.SW.getColor() == root.SE.getColor() && root.SE.getColor() == root.NE.getColor())
                {
                    MessageBox.Show("In range x " + colStart + "-" + colStop + " and y " + rowStart + "-" + rowStop + " the color is " + root.NW.getColor());
                    root.setColor(root.NW.getColor());
                    return root;
                }
                else
                {
                    root.setColor(Color.Gray);
                    return root;
                }
            }
        }

    }
}
