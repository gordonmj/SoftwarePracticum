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
        private String menuChoice;
        //public Point coords;
        public Point firstClick;
        public int lastClicked;
        public string fileName; 
        public static int nodeWidth = 40;
        public static int nodeHeight = 30;
        public System.Drawing.Graphics panel1Graphics;
        public System.Drawing.Graphics panel2Graphics;
        public System.Drawing.Graphics formGraphic;
        public System.Drawing.Graphics canvasGraphics;
        public Brush blackBrush = new SolidBrush(Color.Black);
        public Brush whiteBrush = new SolidBrush(Color.White);
        public Brush grayBrush = new SolidBrush(Color.Gray);
        public Brush slateGrayBrush = new SolidBrush(Color.SlateGray);        
        public int formWidth;
        public int formHeight;
        public Bitmap bmpToSave;
        public Bitmap bmpToSaveForQT;
        public String messageToDisplay;
        public Node[] nodes= new Node[100];
        public int currentPosition = 0;
        public int nextLevelSpace = 50;
        public int[,] map;


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
            menuChoice = "drawWhiteNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a white node.");
        }

        private void drawBlackNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "drawBlackNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a black node.");
        }

        private void drawGreyNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "drawGreyNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a grey node.");
        }

        private void drawArrowtoComeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "drawArrow";
            MessageBox.Show("Double click on two points on the right panel to draw an arrow.");
        }

        private void drawRandomNodetoComeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "drawRandom";
            Random rando = new Random();
            
            int y = rando.Next(10, splitContainer1.Height-nodeHeight);
            int x = rando.Next(5, splitContainer1.Width-nodeWidth);
            int color = rando.Next(0, 2);
            Brush[] brushes = {blackBrush, whiteBrush};
            panel2Graphics.FillEllipse(brushes[color], new Rectangle(new Point(x, y), new Size(nodeWidth, nodeHeight)));
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
            bmpToSaveForQT = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Height);
        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point whereClicked = adjustPointToCenterofNode(e.Location);

            switch (menuChoice)
            {
                case "drawWhiteNode":
                    drawNewNode(currentPosition, whereClicked, Color.White);              
                    break;
                case "drawBlackNode":
                    drawNewNode(currentPosition, whereClicked, Color.Black);              
                    break;
                case "drawGreyNode":
                     Node newGray = drawNewNode(currentPosition, whereClicked, Color.Gray);
                     if (newGray != null) addChildren(currentPosition-1);
                   break;
                case "drawArrow":
                    menuChoice = "finishArrow";
                    firstClick = whereClicked;
                    break;
                case "finishArrow":
                    Pen arrow = new Pen(slateGrayBrush, 3);
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                    arrow.CustomEndCap = bigArrow;
                    //arrow.EndCap = LineCap.ArrowAnchor;
                    panel2Graphics.DrawLine(arrow, firstClick, whereClicked);
                    menuChoice = "drawArrow";
                    break;
                default:
                    if (findTouchingNode(whereClicked) != -1)
                    {
                        String color = nodes[findTouchingNode(whereClicked)].getColorString();
                        MessageBox.Show("Hey! You clicked a "+color+" node!");
                    }
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
            Pen border = new Pen(grayBrush, 1);
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
            map = new int[numRows, numCols];
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
            bmpToSave = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);
            using (Graphics bmpGraphic = Graphics.FromImage(bmpToSave))
            {
                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        if (map[r, c] == 1)
                        {
                            panel1Graphics.FillRectangle(blackBrush, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            panel1Graphics.DrawRectangle(border, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            bmpGraphic.FillRectangle(blackBrush, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            bmpGraphic.DrawRectangle(border, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                        }
                        else
                        {
                            panel1Graphics.FillRectangle(whiteBrush, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            panel1Graphics.DrawRectangle(border, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            bmpGraphic.FillRectangle(whiteBrush, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            bmpGraphic.DrawRectangle(border, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                        }
                    }
                }
            }
            Node root = new Node();
            root = whatColor(root, map, 0, numRows - 1, 0, numCols - 1, "root");
            //MessageBox.Show(message);
            messageToDisplay = "";
            nodeList(root, "root", " ");
            messageToDisplay = "Tree as string: "+numRows+" "+numCols+" "+treeToString(root);
            MessageBox.Show(messageToDisplay);
            messageToDisplay = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1Graphics.Clear(Color.Gray);
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "drawBlackNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a black node.");
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "drawWhiteNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a white node.");
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "drawGreyNode";
            MessageBox.Show("Double click anywhere on the right panel to draw a grey node.");
        }

        private void drawArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "drawArrow";
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
                root.addChild("NE", whatColor(new Node(), m, rowStart, midPointRow, midPointCol + 1, colStop, desc + "->NE"));
                root.addChild("SE", whatColor(new Node(), m, midPointRow + 1, rowStop, midPointCol + 1, colStop, desc + "->SE"));
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

            messageToDisplay = desc + " " + root.getColorString()+"\n"+messageToDisplay;
            //MessageBox.Show(desc+" "+root.getColor());
            return returnRoot;
        }

        private void nodeList(Node n, String desc, String indent)
        {
            if (!n.hasChildren)
            {
                messageToDisplay = indent + " " + desc + " (leaf) " + n.getColorString()+"\n"+ messageToDisplay;
            }
            else
            {
                //TODO: refactor indent to int and build string at level
                nodeList(n.NW, desc + "->NW", indent + " ");
                nodeList(n.SW, desc + "->SW", indent + " ");
                nodeList(n.NE, desc + "->NE", indent + " ");
                nodeList(n.SE, desc + "->SE", indent + " ");
                messageToDisplay = indent + desc + " " + n.getColorString() + "\n" + messageToDisplay;
            }
        }

        private int findTouchingNode(Point down)
        {
            for (int i = 0; i < currentPosition; i++)
            {
                if (nodes[i] == null) break;
                if (pointInNode(down, nodes[i].getPoint()))
                {
                    return i;
                }   
            }
                return -1;
        }

        private void clearNode(int origin)
        {
            panel2Graphics.FillEllipse(grayBrush, new Rectangle(adjustPointOtherWay(nodes[origin].getPoint()), new Size(nodeWidth, nodeHeight)));
        }

        private void deleteNode(int origin)
        {
            clearNode(origin);
            nodes[origin] = null;
        }
        private Node drawNewNode(int origin, Point destination, Color color)
        {
            nodes[origin] = new Node(destination, color);
            currentPosition++;
            drawNode(origin, destination);
            return nodes[origin];
        }
        private Node drawNode(int origin, Point clicked)
        {
            Point centerPoint = new Point(clicked.X - nodeWidth / 2, clicked.Y - nodeHeight / 2);
            nodes[origin].setPoint(clicked);
            if (nodes[origin].getColor() != Color.Gray)
            {
                Brush brush = new SolidBrush(nodes[origin].getColor());
                panel2Graphics.FillEllipse(brush, new Rectangle(centerPoint, new Size(nodeWidth, nodeHeight)));
                using (Graphics bmpGraphicForQT = Graphics.FromImage(bmpToSaveForQT))
                {
                    bmpGraphicForQT.FillEllipse(brush, new Rectangle(centerPoint, new Size(nodeWidth, nodeHeight)));
                }

            }
            else
            {
                LinearGradientBrush lgb = new LinearGradientBrush(
                    clicked,
                    new Point(clicked.X + 40, clicked.Y),
                    Color.FromArgb(255, 255, 255),
                    Color.FromArgb(0, 0, 0));
                float[] intensities = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
                float[] posit = { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                Blend blend = new Blend();
                blend.Factors = intensities;
                blend.Positions = posit;
                lgb.Blend = blend;
                panel2Graphics.FillEllipse(lgb, new Rectangle(nodes[origin].getPoint(), new Size(nodeWidth, nodeHeight)));
                using (Graphics bmpGraphicForQT = Graphics.FromImage(bmpToSaveForQT))
                {
                    bmpGraphicForQT.FillEllipse(lgb, new Rectangle(centerPoint, new Size(nodeWidth, nodeHeight)));
                }
            }
            return nodes[origin];
        }
        private void addChildren(int origin)
        {
            Node n = nodes[origin];
            /*
            DialogResult doAlign = MessageBox.Show("Align?", "Align?", MessageBoxButtons.YesNo);
            if (doAlign == DialogResult.Yes)
            {
                align(origin);
            }
             */
            if (n.getColorString() == "black" || n.getColorString() == "white")
            {
                MessageBox.Show("Black or White nodes are leaf nodes!");
                return;
            }
            else {
                n.addChildren();
                int spacing = panel2.Width / 5;
                Point p;
                Color c;
                Node[] children = new Node[] {n.NW, n.SW, n.NE, n.SE};
                int i = 1;
                foreach (Node child in children)
                {
                    bool isGray = false;
                    p = new Point(i * spacing, n.getPoint().Y + nextLevelSpace);
                    DialogResult dialogResult = MessageBox.Show("Yes for black, No for white, Cancel for gray", "Black or white?", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        c = Color.Black;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        c = Color.White;
                    }
                    else
                    {
                        c = Color.Gray;
                        isGray = true;
                    }
                    drawNewNode(currentPosition, p, c);
                    child.setColor(c);
                    child.setPoint(p);
                    connectTwoNodes(n, child);
                    if (isGray && nodes[currentPosition-1] != null)
                    {
                        addChildren(currentPosition-1);
                    }
                    i++;
                }//for
                /* doAlign = MessageBox.Show("Align children?", "Align children?", MessageBoxButtons.YesNo);
                if (doAlign == DialogResult.Yes)
                {
                    //align(origin);
                }
                 * */
            }//else
        }//addChildren

        private Point adjustPointToCenterofNode(Point p)
        {
            return new Point(p.X + nodeWidth / 2, p.Y + nodeHeight / 2);
        }

        private Point adjustPointOtherWay(Point p)
        {
            return new Point(p.X - nodeWidth / 2, p.Y - nodeHeight / 2);
        }

        private void connectTwoNodes(Node a, Node b)
        {
            Point start = adjustPointToCenterofNode(a.getPoint());
            Point end = b.getPoint();
            Pen arrow = new Pen(blackBrush, 3);
            if (b.getColor() == Color.Black)
            {
                arrow = new Pen(whiteBrush, 3);
            }
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            arrow.CustomEndCap = bigArrow;
            //arrow.EndCap = LineCap.ArrowAnchor;
            panel2Graphics.DrawLine(arrow, start, end);
            using (Graphics bmpGraphicForQT = Graphics.FromImage(bmpToSaveForQT))
            {
                bmpGraphicForQT.DrawLine(arrow, start, end);
            }
        }

        private Node redrawNode(int origin, Point destination)
        {
            if (findTouchingNode(destination) != -1 && findTouchingNode(destination) != origin)
            {
                MessageBox.Show("Sorry, there is already a node here!");
                return nodes[origin];
            }
            if (destination.X < 0 || destination.Y < 0)
            {
                deleteNode(origin);
                return null;
            }
            else
            {
                clearNode(origin);
                drawNode(origin, destination);
                return nodes[origin];
            }
         }

        private void align(int origin)
        {
            Node n = nodes[origin];
            if (n == null) return;
            int center = panel2.Width/2;
            Point alignedPoint = new Point(center,n.getPoint().Y);
            if (n.isRoot || n.level == 0)
            {
                redrawNode(origin, alignedPoint);
            }
            else
            {
                Node parent = n.parent;
                int level = parent.getPoint().Y;
                int centerLine = parent.getPoint().X;
                int spacing = centerLine + (panel2.Width/parent.level + 2);
                switch (n.getDirectionString())
                {
                    case "NW":
                        spacing = 0;
                        break;
                    case "SW":
                        break;
                    case "SE":
                        spacing = spacing * 2;
                        break;
                    case "NE":
                        spacing = spacing * 3;
                        break;
                    default:
                        //add exception
                        break;

                }
                redrawNode(origin,new Point(level+nextLevelSpace,spacing));
            }
        }
        private void align(int start, int stop)
        {
            int line = nodes[start].getPoint().Y;
            int numNodes = (stop - start)+1;
            int spacing = panel2.Width / numNodes;
            for (int i = 0; i < numNodes; i++)
            {
                redrawNode(start+i, new Point(i*spacing, line));
                //favors click order over positional arrangement!
            }
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
            int whichNode = findTouchingNode(whereClicked);
            if (whereClicked.X < 0 || whereClicked.Y < 0)
            {
                deleteNode(lastClicked);
                return;
            }
            if (lastClicked == -1)
            {
                return;
            }
            if (lastClicked == whichNode){
                Node thisNode = nodes[whichNode];
                String color = thisNode.getColorString();
                String coordinates = thisNode.getPoint().ToString();
                MessageBox.Show("You clicked a "+color+" node at "+coordinates+"!\nWhat do you want to do?\nJust click and drag the node to move it.\n");
                if (color == "gray")
                {
//                    MessageBox.Show("");

                }
                //MessageBox.Show("You clicked a node!\nWhat do you want to do?\nJust click and drag the node to move it.\nWant to create children? Click __");

            }
            else
            {
                redrawNode(lastClicked, whereClicked);
            }
        }

        private bool pointInNode(Point click, Point node)
        {
            return click.X < node.X + nodeWidth && click.X > node.X - nodeWidth && click.Y < node.Y + nodeHeight && click.Y > node.Y - nodeHeight;
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < currentPosition; i++)
            {
                nodes[i] = null;
            }
            currentPosition = 0;
            bmpToSaveForQT = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Height);
            panel2Graphics.Clear(Color.Gray);

        }

        private String treeToString(Node n)
        {
            if (n == null)
            {
                return "";
            }
            if (n.getColor() == Color.Black)
            {
                return "1";
            }
            else if (n.getColor() == Color.White)
            {
                return "0";
            }
            else
            {
                String children = "";
                children += " "+treeToString(n.NW);
                children += " " + treeToString(n.SW);
                children += " " + treeToString(n.NE);
                children += " " + treeToString(n.SE); 
                return "2" + children;
            }
        }//treeToString
        
        private int stringToTree(ref String str, int start, Node n)
        {
            String[] directions = { "NW", "SW", "NE", "SE" };
            int nodeNum = 0;
            int end = start;
            while (nodeNum < 4)
            {
                if (str[start] == '1')
                {
                    Node child = n.addChild(directions[nodeNum]);
                    child.setColor(Color.Black);
                    nodeNum++;
                    end++;
                }
                else if (str[start] == '0')
                {
                    Node child = n.addChild(directions[nodeNum]);
                    child.setColor(Color.White);
                    nodeNum++;     
                    end++;
                }
                else if (str[start] == '2')
                {
                    Node child = n.addChild(directions[nodeNum]);
                    child.setColor(Color.Gray);      
                    end = stringToTree(ref str, end, child);
                    nodeNum++; 
                }
            }//while
            return end; //what number to return?
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void asImageFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Images|*.png;*.bmp;*.jpg";
            save.Title = "Save the image";
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
            if (save.ShowDialog() == DialogResult.OK)
            {
                bmpToSave.Save(save.FileName, format);
            }
        }

        private void asImageFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Images|*.png;*.bmp;*.jpg";
            save.Title = "Save the image";
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
            if (save.ShowDialog() == DialogResult.OK)
            {
                bmpToSaveForQT.Save(save.FileName, format);
            }
        }

        private String mapToString(int[,] matrix)
        {
            String s = "";
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            s += rows.ToString()+" "+cols.ToString()+" ";
            s += Environment.NewLine;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    s += matrix[r, c].ToString() + " ";
                }//columns
                s += Environment.NewLine;
            }//rows
            return s;
        }

        private void asTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text|*.txt";
            save.Title = "Save the image";
            String textToSave = mapToString(map);
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(save.FileName, textToSave);
            }
        }

        private void asTextFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text|*.txt";
            save.Title = "Save the image";
            String textToSave = treeToString(nodes[0]);
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(save.FileName, textToSave);
            }
        }
        
    }//class
}//namespace