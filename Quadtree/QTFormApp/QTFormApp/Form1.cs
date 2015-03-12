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
        public int lastClicked;
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
        public String message;
        public Node[] positions= new Node[100];
        public int pos = 0;

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
            Point whereClicked = e.Location;

            switch (clicked)
            {
                case "drawWhiteNode":
                    drawNewNode(pos++, whereClicked, Color.White);              
                    break;
                case "drawBlackNode":
                    drawNewNode(pos++, whereClicked, Color.Black);              
                    break;
                case "drawGreyNode":
                     drawNewNode(pos++, whereClicked, Color.Gray);              
                   break;
                case "drawArrow":
                    clicked = "finishArrow";
                    firstClick = whereClicked;
                    break;
                case "finishArrow":
                    Pen arrow = new Pen(black, 3);
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                    arrow.CustomEndCap = bigArrow;
                    //arrow.EndCap = LineCap.ArrowAnchor;
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
            Node root = new Node();
            root = whatColor(root, map, 0, numRows - 1, 0, numCols - 1, "root");
            //MessageBox.Show(message);
            message = "";
            nodeList(root, "root", " ");
            MessageBox.Show(message);
            message = "";
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

        private Node whatColor(Node root, int[,] m, int rowStart, int rowStop, int colStart, int colStop, String desc)
        {
            Node returnRoot;
            if ((rowStop - rowStart != colStop - colStart))
            {
                MessageBox.Show("Error! rowStart: "+rowStart+" rowStop "+rowStop+" colStart: "+colStart+" and colStop: "+colStop);
                //throw new Exception("Not a square!");
                this.Close();
                returnRoot = null;
            }
//            MessageBox.Show("rowStart: " + rowStart + " rowStop: " + rowStop + " colStart: " + colStart + " colStop: " + colStop);
            if (rowStop - rowStart < 0)
            {
                MessageBox.Show("rowStart: " + rowStart + " is greater than rowStop: " + rowStop);
                //throw new Exception("Invalid params");
                this.Close();
                returnRoot = null;
            }
            else if (rowStop - rowStart == 0)
            {
                if (m[rowStart, colStart] == 1)
                {
                    root.setColor(Color.Black);
                    //MessageBox.Show(desc + " " + root.getColor());
                    returnRoot = root;
                }
                else
                    root.setColor(Color.White);
                    //MessageBox.Show(desc + " " + root.getColor());
                    returnRoot = root;
            }
            else
            {
                int midPointRow = (rowStop + rowStart) / 2;
                int midPointCol = (colStop + colStart) / 2;
                root.addChild("NW",whatColor(new Node(), m, rowStart, midPointRow, colStart, midPointCol,desc+"->NW"));
                root.addChild("SW",whatColor(new Node(), m, midPointRow + 1, rowStop, colStart, midPointCol, desc + "->SW"));
                root.addChild("SE",whatColor(new Node(), m, midPointRow + 1, rowStop, midPointCol + 1, colStop, desc + "->SE"));
                root.addChild("NE", whatColor(new Node(), m, rowStart, midPointRow, midPointCol + 1, colStop, desc + "->NE"));
                //MessageBox.Show("NW: "+root.NW.getColor()+" SW: "+root.SW.getColor()+" SE: "+root.SE.getColor()+" NE: "+root.NE.getColor());
                if (root.NW.getColor() == root.SW.getColor() && root.SW.getColor() == root.SE.getColor() && root.SE.getColor() == root.NE.getColor())
                {
            //        MessageBox.Show("In range x " + colStart + "-" + colStop + " and y " + rowStart + "-" + rowStop + " the color is " + root.NW.getColor());
                    root.setColor(root.NW.getColor());
                    if (root.NW.getColor()!=Color.Gray)
                        root.prune();
                    returnRoot = root;
                }
                else
                {
                    root.setColor(Color.Gray);
                    returnRoot = root;
                }
            }

            message = desc + " " + root.getColor().ToString()+"\n"+message;
            //MessageBox.Show(desc+" "+root.getColor());
            return returnRoot;
        }

        private void nodeList(Node n, String desc, String indent)
        {
            if (!n.hasChildren)
            {
                message = indent + " " + desc + " (leaf) " + n.getColor().ToString()+"\n"+ message;
            }
            else
            {
                //TODO: refactor indent to int and build string at level
                nodeList(n.NW, desc + "->NW", indent + " ");
                nodeList(n.SW, desc + "->SW", indent + " ");
                nodeList(n.SE, desc + "->SE", indent + " ");
                nodeList(n.NE, desc + "->NE", indent + " ");
                message = indent + desc + " " + n.getColor().ToString() + "\n" + message;
            }
        }

        private int findTouchingNode(Point down)
        {
            for (int i = 0; i < pos; i++)
            {
                if (pointInNode(down, positions[i].getPoint()))
                {
                    return i;
                }   
            }
                return -1;
        }

        private void clearNode(int origin)
        {
            panel2Graphics.FillEllipse(gray, new Rectangle(positions[origin].getPoint(), new Size(nodeW, nodeH)));
        }

        private void drawNewNode(int origin, Point destination, Color color)
        {
            positions[origin] = new Node(destination, color);
            drawNode(origin, destination);
        }
        private void drawNode(int origin, Point destination)
        {
            positions[origin].setPoint(destination);
            if (positions[origin].getColor() != Color.Gray)
            {
                Brush brush = new SolidBrush(positions[origin].getColor());
                panel2Graphics.FillEllipse(brush, new Rectangle(positions[origin].getPoint(), new Size(nodeW, nodeH)));
            }
            else
            {
                LinearGradientBrush lgb = new LinearGradientBrush(
                    destination,
                    new Point(destination.X + 40, destination.Y),
                    Color.FromArgb(255, 255, 255),
                    Color.FromArgb(0, 0, 0));
                float[] intensities = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
                float[] posit = { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                Blend blend = new Blend();
                blend.Factors = intensities;
                blend.Positions = posit;
                lgb.Blend = blend;
                panel2Graphics.FillEllipse(lgb, new Rectangle(positions[origin].getPoint(), new Size(nodeW, nodeH)));
            }
        }
        private void redrawNode(int origin, Point destination)
        {
            if (findTouchingNode(destination) != -1 && findTouchingNode(destination) != origin)
            {
                MessageBox.Show("Sorry, there is already a node here!");
                return;
            }    
            clearNode(origin);
            drawNode(origin, destination);
         }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Point whereClicked = e.Location;
            int whichNode = findTouchingNode(whereClicked);
            lastClicked = whichNode;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Point whereClicked = e.Location;
            if (lastClicked != -1){
                redrawNode(lastClicked, whereClicked);
            }

        }

        private bool pointInNode(Point click, Point node)
        {
            return click.X < node.X + nodeW && click.X > node.X - nodeW && click.Y < node.Y + nodeH && click.Y > node.Y - nodeH;
        }


    }//class
}//namespace