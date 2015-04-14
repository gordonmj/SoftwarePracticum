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
        private Point firstClick;
        private int lastClicked;
        private int prevClicked;
        private int beforeLastClicked;
        private string fileName; 
        private static int nodeWidth = 20;
        private static int nodeHeight = 20;
        private System.Drawing.Graphics panel1Graphics;
        private System.Drawing.Graphics panel2Graphics;
        private System.Drawing.Graphics formGraphic;
        private Brush blackBrush = new SolidBrush(Color.Black);
        private Brush whiteBrush = new SolidBrush(Color.White);
        private Brush grayBrush = new SolidBrush(Color.Gray);
        private Brush slateGrayBrush = new SolidBrush(Color.SlateGray);
        private Brush bgBrush = new SolidBrush(Color.PowderBlue);
        private int formWidth;
        private int formHeight;
        private Bitmap bmpToSave;
        private Bitmap bmpToSaveForQT;
        private String messageToDisplay;
        private Node[] nodes= new Node[100];
        private int currentPosition = 0;
        private int nextLevelSpace = 75;
        private int[,] map1;
        private int[,] map2;
        private Node root;
        private int numRows;
        private int numCols;
        private int numRows2;
        private int numCols2;
          
        private int treeLeftStart = -100;
        private int treeRightStart;
        private Point nullPoint = new Point(0, 0);

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

        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map1 != null || root != null)
            {
                drawImage(ref map1);

            }
            else
            {
                MessageBox.Show("Load an image first!");
                loadToolStripMenuItem_Click(sender, e);
            }
        }

        private void clearMap()
        {
            
        }

        private int parseMatrixInputFile(ref int[,] map)
        {
            if (fileName == null)
            {
                MessageBox.Show("You must select an input file first. Use 'Image>Load'");
                return -1;
            }
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            char[] delims = { ' ', '\n' };
            string[] firstLine = lines[0].Split(delims);
            int rows, cols;
            rows = Convert.ToInt32(firstLine[0]);
            cols = Convert.ToInt32(firstLine[1]);
            nodes = new Node[rows*cols*2];
            int maxVal = Convert.ToInt32(firstLine[2]);
            int minVal = Convert.ToInt32(firstLine[3]);
            map = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                string[] nextLine = lines[r + 1].Split(delims);
                for (int c = 0; c < cols; c++)
                {
                    map[r, c] = Convert.ToInt32(nextLine[c]);
                }
            }
            if (ReferenceEquals(map,map2))
            {
                numRows2 = rows;
                numCols2 = cols;
            }
            else
            {
                numRows = rows;
                numCols = cols;
            }
            return 0;
        }

        private void parsePreorderInputFile(ref int [,] map)
        {
            if (fileName == null)
            {
                MessageBox.Show("You must select an input file first. Use 'Image>Load'");
                return;
            }
            string[] input = System.IO.File.ReadAllLines(@fileName);
            char[] delims = { ' ', '\n' };
            string[] parsedInput = input[0].Split(delims);
            numRows = Convert.ToInt32(parsedInput[0]);
            numCols = Convert.ToInt32(parsedInput[1]);
            map = new int[numRows, numCols];
            nodes = new Node[numRows * numCols * 2];
            Node newRoot = new Node();
            newRoot.numCols = numCols;
            newRoot.numRows = numRows;
            stringToTree(ref parsedInput,2,newRoot);
            treeToImage(newRoot, 0, 0,map);
            root = newRoot;
        }

        private void isolateQuadrant(int[,] map, int[] boundaries, Graphics gp){

            drawImageHelper(ref map, boundaries, gp);
        }

        private void drawImage(ref int[,] map)
        {
            int[] regions = { 0, 0, map.GetLength(0), map.GetLength(1) };
            drawImageHelper(ref map, regions, panel1Graphics);
        }

        private void drawImageHighlight(ref int[,] map, int[] regions)
        {
            drawImageHelper(ref map, regions, panel1Graphics);
        }

        private void drawImageHelper(ref int[,] map, int[] regions, Graphics gp)
        {
            Pen border = new Pen(grayBrush, 1);
            Brush red = new SolidBrush(Color.Red);
            Pen highlight = new Pen(red, 3);
            int offset = 10;
            int size, rows, cols;
            if (ReferenceEquals(map, map1))
            {
                rows = numRows;
                cols = numCols;
            }
            else
            {
                rows = numRows2;
                cols = numCols2;
            }
            if (((formHeight - offset) / rows) < offset)
            {
                offset = 0;
            }
            if ((formWidth / cols) / 2 > (formHeight - offset) / rows)
                size = ((formHeight - offset) / rows) - offset;
            else
                size = (((formWidth - offset) / cols) / 2) - offset;
            gp.Clear(Color.DarkCyan);
            bmpToSave = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);
            using (Graphics bmpGraphic = Graphics.FromImage(bmpToSave))
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (r >= regions[1] && c >= regions[0] && r < regions[3] + regions[1] && c < regions[2] + regions[0])
                        {
                            if (map[r, c] == 1)
                            {
                                gp.FillRectangle(blackBrush, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            }//if
                            else if (map[r, c] == 0)
                            {
                                gp.FillRectangle(whiteBrush, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            }//else if
                            else
                            {
                                gp.FillRectangle(grayBrush, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                            }//else
                        }
                        //if (r >= regions[1] && c >= regions[0] && r < regions[3]+regions[1] && c < regions[2]+regions[0])
                        //{
                        //    gp.DrawRectangle(highlight, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                        //}
                        //else
                        //{
                            gp.DrawRectangle(border, new Rectangle(offset + (c * size), offset + 10 + (r * size), size, size));
                        //}
                    }//for c
                }//for r
            }//bmp
        }//drawImageHelper

        private Node imageToTree(int[,] map)
        {
            root = new Node();
            int rows, cols;
            if (ReferenceEquals(map,map2))
            {
                rows = numRows2;
                cols = numCols2;
            }
            else {
                rows = numRows;
                cols = numCols;
            }
            root.numCols = cols;
            root.numRows = rows;
            root.level = 0;
            root = whatColor(root, map, 0, rows - 1, 0, cols - 1, "root");
            messageToDisplay = "";
            nodeList(root, "root", " ");
            //MessageBox.Show(messageToDisplay);
            String treeAsString = numRows + " " + numCols + " " + treeToString(root);
            messageToDisplay = "Tree as string: " + treeAsString;
           // MessageBox.Show(messageToDisplay);
            messageToDisplay = "";
            return root;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1Graphics.Clear(Color.DarkCyan);
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

        private Node whatColor(Node n, int[,] m, int rowStart, int rowStop, int colStart, int colStop, String desc)
        {
            Node returnRoot;
            if ((rowStop - rowStart != colStop - colStart))
            {
                MessageBox.Show("Error! rowStart: "+rowStart+" rowStop "+rowStop+" colStart: "+colStart+" and colStop: "+colStop);
                this.Close();
                returnRoot = null;
            }
            if (rowStop - rowStart < 0)
            {
                MessageBox.Show("rowStart: " + rowStart + " is greater than rowStop: " + rowStop);
                this.Close();
                returnRoot = null;
            }
            else if (rowStop - rowStart == 0)
            {
                n.hasChildren = false;
                if (m[rowStart, colStart] == 1)
                {
                    n.setColor(Color.Black);
                    returnRoot = n;
                }
                else
                {
                    n.setColor(Color.White);
                    returnRoot = n;
                }
            }

            else
            {
                int midPointRow = (rowStop + rowStart) / 2;
                int midPointCol = (colStop + colStart) / 2;
                n.addChild("NW",whatColor(new Node(n), m, rowStart, midPointRow, colStart, midPointCol,desc+"->NW"));
                n.addChild("SW",whatColor(new Node(n), m, midPointRow + 1, rowStop, colStart, midPointCol, desc + "->SW"));
                n.addChild("SE", whatColor(new Node(n), m, midPointRow + 1, rowStop, midPointCol + 1, colStop, desc + "->SE"));
                n.addChild("NE", whatColor(new Node(n), m, rowStart, midPointRow, midPointCol + 1, colStop, desc + "->NE"));
                //MessageBox.Show("NW: "+root.NW.getColor()+" SW: "+root.SW.getColor()+" SE: "+root.SE.getColor()+" NE: "+root.NE.getColor());
                if (n.NW.getColor() == n.SW.getColor() && n.SW.getColor() == n.SE.getColor() && n.SE.getColor() == n.NE.getColor())
                {
            //        MessageBox.Show("In range x " + colStart + "-" + colStop + " and y " + rowStart + "-" + rowStop + " the color is " + root.NW.getColor());
                    n.setColor(n.NW.getColor());
                    if (n.NW.getColor()!=Color.Gray)
                        n.prune();
                    returnRoot = n;
                }
                else
                {
                    n.setColor(Color.Gray);
                    returnRoot = n;
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
                nodeList(n.SE, desc + "->SE", indent + " ");
                nodeList(n.NE, desc + "->NE", indent + " ");
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
                    if (nodes[i].getIndex() != i)
                    {
                        MessageBox.Show("i=" + i + " and nodes[i]=" + nodes[i]);
                        break;
                    }
                    return i;
                }   
            }
                return -1;
        }

        private void clearNode(int origin)
        {
            panel2Graphics.FillEllipse(new SolidBrush(Color.PowderBlue), new Rectangle(adjustPointOtherWay(nodes[origin].getPoint()), new Size(nodeWidth, nodeHeight)));
        }

        private void deleteNode(int origin)
        {
            clearNode(origin);
            nodes[origin] = null;
        }


        private Node drawNewNode(int origin, Point destination, Color color)
        {
            //MessageBox.Show("Node created, index is " + currentPosition+" "+origin);
            nodes[origin] = new Node(destination, color);
            nodes[origin].setIndex(origin);
            currentPosition++;
            drawNode(origin, destination);
            return nodes[origin];
        }

        private void drawNode(Node n, Point draw)
        {
            if (n.getIndex() == -1)
            {
                nodes[currentPosition] = n;
                n.setIndex(currentPosition);
                currentPosition++;
            }
            else if (n.getIndex() != currentPosition)
            {
                //MessageBox.Show("Index error! currentPosition is "+currentPosition+" and n.index is "+n.getIndex()); //PROBLEM HERE
            }
            else
            {

            }
            n.setPoint(draw);
            drawNodeHelper(n, draw);
        }

        private Node drawNode(int origin, Point clicked)
        {
            nodes[origin].setPoint(clicked);
            drawNodeHelper(nodes[origin], clicked);
            return nodes[origin];
        }

        private void drawNodeHelper(Node n, Point clicked)
        {
            Point centerPoint = new Point(clicked.X - (nodeWidth / 2), clicked.Y - (nodeHeight / 2));
            if (n.getColor() != Color.Gray)
            {
                Brush brush = new SolidBrush(n.getColor());
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
                    new Point(clicked.X + nodeWidth, clicked.Y),
                    Color.FromArgb(255, 255, 255),
                    Color.FromArgb(0, 0, 0));
                float[] intensities = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
                float[] posit = { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                Blend blend = new Blend();
                blend.Factors = intensities;
                blend.Positions = posit;
                lgb.Blend = blend;
                panel2Graphics.FillEllipse(lgb, new Rectangle(n.getPoint(), new Size(nodeWidth, nodeHeight)));
                using (Graphics bmpGraphicForQT = Graphics.FromImage(bmpToSaveForQT))
                {
                    bmpGraphicForQT.FillEllipse(lgb, new Rectangle(centerPoint, new Size(nodeWidth, nodeHeight)));
                }
            }

        }

        private void addChildren(int origin)
        {
            Node n = nodes[origin];
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
                for (int childNum = 0; childNum < 4; childNum++ )
                {
                    bool isGray = false;
                    p = new Point((childNum+1) * spacing, n.getPoint().Y + nextLevelSpace);
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
                    children[childNum] = drawNewNode(currentPosition, p, c);
                    children[childNum].setColor(c);
                    children[childNum].setPoint(p);
                    connectTwoNodes(n, children[childNum]);
                    //MessageBox.Show("isGray?" + isGray + " currentPosition=" + currentPosition);
                    MessageBox.Show("Correct node? " + (children[childNum] == nodes[currentPosition - 1]) + " and color?" + children[childNum].getColorString()+" and number "+childNum);
                    if (isGray && nodes[currentPosition - 1] != null)
                    {
                        addChildren(currentPosition - 1);
                    }
                }//for
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

        private void redrawTree(Node n, bool inPlace)
        {
            panel2Graphics.Clear(Color.PowderBlue);
            int xShift = n.getPoint().X - (panel2.Width / 2);
            int yShift = n.getPoint().Y - nextLevelSpace;
            drawTree(n, treeLeftStart+xShift, treeRightStart+xShift, nextLevelSpace+yShift, inPlace);
        }

        private Node drawTree(Node n, int leftEnd, int rightEnd, int levelSpace, bool inPlace)
        {
            int center = (leftEnd+rightEnd)/2;
            int spacing = (rightEnd - leftEnd) / 5;
            int midSpacing = spacing/2;
            Point placeNode;
            if (n.getPoint() == null || n.getPoint() == nullPoint || !inPlace)
            {
                placeNode = new Point(center, levelSpace);
            }
            else
            {
                placeNode = n.getPoint();
            }
            drawNode(n, placeNode);  
            if (n.hasChildren) {
                drawTree(n.NW,leftEnd+midSpacing,leftEnd+(3 * midSpacing),levelSpace+nextLevelSpace,inPlace);
                connectTwoNodes(n, n.NW);
                drawTree(n.SW, leftEnd + (3 * midSpacing),leftEnd+(5 * midSpacing), levelSpace + nextLevelSpace,inPlace);
                connectTwoNodes(n, n.SW);
                drawTree(n.SE, leftEnd + (5 * midSpacing), leftEnd + (7 * midSpacing), levelSpace + nextLevelSpace,inPlace);
                connectTwoNodes(n, n.SE);
                drawTree(n.NE, leftEnd + (7 * midSpacing), leftEnd + (9 * midSpacing), levelSpace + nextLevelSpace,inPlace);
                connectTwoNodes(n, n.NE);
            }
            return n;
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

        private void eraseArrow(Node a, Node b)
        {
            Point start = adjustPointToCenterofNode(a.getPoint());
            Point end = b.getPoint();
            Pen arrow = new Pen(bgBrush, 3);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            arrow.CustomEndCap = bigArrow;
            panel2Graphics.DrawLine(arrow, start, end);
            redrawNode(a.getIndex(), a.getPoint());
            redrawNode(b.getIndex(), b.getPoint());
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
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            int size;
            int offset = 10;
            if ((formWidth / numCols) / 2 > (formHeight - offset) / numRows)
                size = ((formHeight - offset) / numRows) - offset;
            else
                size = (((formWidth - offset) / numCols) / 2) - offset;
            int leftBound = offset;
            int rightBound = offset + (size * numCols);
            int upBound = offset;
            int bottomBound = offset + (size * numRows);
            int mid = (upBound+bottomBound)/2;
            int ctr = (leftBound + rightBound) / 2;
            Point whereClicked = e.Location;
            int[] bounds = new int[4];
            Node newRoot = new Node();
            bool east;
            if (whereClicked.X > ctr)
            {
                bounds[0] = numCols / 2;
                bounds[2] = numCols;
                east = false;
            }
            else
            {
                bounds[0] = 0;
                bounds[2] = numCols / 2;
                east = true;
            }
            if (whereClicked.Y > mid)
            {
                bounds[1] = numRows / 2;
                bounds[3] = numRows;
                if (east)
                {
                    newRoot = root.NE;
                }
                else
                {
                    newRoot = root.NW;
                }
            }
            else
            {
                bounds[1] = 0;
                bounds[3] = numRows / 2;
                if (east)
                {
                    newRoot = root.SE;
                }
                else
                {
                    newRoot = root.SW;
                }
            }
            redrawTree(newRoot, true);
            //isolateQuadrant(map1, bounds, panel1Graphics);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Point whereUnclicked = e.Location;
            int whichNode = findTouchingNode(whereUnclicked);
            if (whereUnclicked.X < 0 || whereUnclicked.Y < 0)
            {
                deleteNode(lastClicked);
                return;
            }
            if (menuChoice == "connectNodes")
            {
                if (nodes[prevClicked] != null && nodes[whichNode] != null)
                {
                    connectTwoNodes(nodes[prevClicked], nodes[whichNode]);
                }
                return;
            }
            if (menuChoice == "moveArrowHead")
            {
                if (nodes[lastClicked] != null && nodes[whichNode] != null)
                {
                    eraseArrow(nodes[lastClicked].parent, nodes[lastClicked]);
                    connectTwoNodes(nodes[lastClicked].parent, nodes[whichNode]);
                    beforeLastClicked = whichNode;
                    menuChoice = "moveArrowBase";
                }
                return;
            }
            if (menuChoice == "moveArrowBase")
            {
                if (nodes[lastClicked] != null && nodes[whichNode] != null)
                {
                    eraseArrow(nodes[lastClicked], nodes[beforeLastClicked]);
                    connectTwoNodes(nodes[whichNode],nodes[beforeLastClicked]);
                    menuChoice = "moveArrowHead";
                }
                return;
            } if (menuChoice == "moveTree")
            {
                root.setPoint(whereUnclicked);
                redrawTree(root,false);
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
                //DialogResult answer = MessageBox.Show("You clicked a " + color + " node at " + coordinates + "!\nDo you want to create an arrow?", "Options", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int[] highReg = highlightRegion(thisNode);
                drawImageHighlight(ref map1, highReg);
                prevClicked = lastClicked;
            }
            else
            {
                if (whichNode == -1)
                {
                    Node thisNode = nodes[lastClicked];
                    thisNode.setPoint(whereUnclicked);
                    redrawTree(root,true);
                }
                else
                {
                    Node thisNode = nodes[whichNode];
                    thisNode.setPoint(whereUnclicked);
                    redrawTree(root,true);
                }
            }
        }

        private int[] highlightRegion(Node n)
        {
            int[] region = { 0, 0, 0, 0 }; //x,y...
            Node walker = n;
            while (walker!=null && !walker.isRoot)
            {
                switch (walker.getDirectionString())
                {
                    case "NW":
                        break;
                    case "SW":
                        region[1] += walker.numRows;
                        break;
                    case "SE":
                        region[0] += walker.numCols;
                        region[1] += walker.numRows;
                        break;
                    case "NE":
                        region[0] += walker.numCols;
                        break;
                    default: //walker is root?
                        break;
                }//switch
                walker = walker.parent;
            }//while
            region[2] += n.numCols;
            region[3] += n.numRows;
            return region;
        }

        private bool pointInNode(Point click, Point node)
        {
            return click.X < node.X + nodeWidth && click.X > node.X - nodeWidth && click.Y < node.Y + nodeHeight && click.Y > node.Y - nodeHeight;
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clearAllNodes();
        }

        private void clearAllNodes()
        {
            for (int i = 0; i < currentPosition; i++)
            {
                nodes[i] = null;
            }
            currentPosition = 0;
            bmpToSaveForQT = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Height);
            panel2Graphics.Clear(Color.PowderBlue);

        }
        private void redrawAllNodes()
        {
            bmpToSaveForQT = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Height);
            panel2Graphics.Clear(Color.PowderBlue);
            for (int i = 0; i < currentPosition; i++)
            {
                redrawNode(i, nodes[i].getPoint());
            }
        }

        private String treeToString(Node n)
        {
            if (n == null)
            {
                MessageBox.Show("NULL!");
                return "";
            }
            //MessageBox.Show(n.getColorString()+" "+n.level+" "+n.numRows);
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
        
        private void stringToTree(ref String[] str, int start, Node n)
        {
            if (str[start] == "1")
            {
                n.setColor(Color.Black);
            }
            else if (str[start] == "0")
            {
                n.setColor(Color.White);

            }
            else if (str[start] == "2")
            {
                n.setColor(Color.Gray);
                Node NW = n.addChild("NW");
                nodes[currentPosition] = NW;
                NW.setIndex(currentPosition);
                currentPosition++;
                int end = stringToTreeHelper(ref str, start + 1, NW, "NW");
                Node SW = n.addChild("SW");
                nodes[currentPosition] = SW;
                SW.setIndex(currentPosition);
                currentPosition++;
                end = stringToTreeHelper(ref str, end, SW, "SW");
                Node SE = n.addChild("SE");
                nodes[currentPosition] = SE;
                SE.setIndex(currentPosition);
                currentPosition++;
                end = stringToTreeHelper(ref str, end, SE, "SE");
                Node NE = n.addChild("NE");
                nodes[currentPosition] = NE;
                NE.setIndex(currentPosition);
                currentPosition++;
                end = stringToTreeHelper(ref str, end, NE, "NE");
            }
            else {
                return;
            }
       
         }

        private int stringToTreeHelper(ref String[] str, int start, Node n, String direction)
        {
            //String[] directions = { "NW", "SW", "SE", "NE" };
            //int nodeNum = 0;
            int end = start;

                if (end >= str.Length)
                {
                    return 0;
                }
                //MessageBox.Show("Size of str: " + str.Length + ", end: " + end + ", nodeNum: " + nodeNum);
                //MessageBox.Show("Number " + str[end] + " point in string: " + end + " current node direction: " + direction);
                if (str[end] == "1")
                {
                    //MessageBox.Show(direction + " should be black");
                    n.setColor(Color.Black);
                    end++;
                }
                else if (str[end] == "0")
                {
                    //MessageBox.Show(direction + " should be white");
                    n.setColor(Color.White);
                    end++;
                }
                else if (str[end] == "2")
                {
                    //MessageBox.Show(direction + " should be gray");
                    n.setColor(Color.Gray);
                    Node NW = n.addChild("NW");
                    nodes[currentPosition] = NW;
                    NW.setIndex(currentPosition);
                    currentPosition++;
                    end = stringToTreeHelper(ref str, end + 1, NW, "NW");
                    Node SW = n.addChild("SW");
                    nodes[currentPosition] = SW;
                    SW.setIndex(currentPosition);
                    currentPosition++;
                    end = stringToTreeHelper(ref str, end, SW, "SW");
                    Node SE = n.addChild("SE");
                    nodes[currentPosition] = SE;
                    SE.setIndex(currentPosition);
                    currentPosition++;
                    end = stringToTreeHelper(ref str, end, SE, "SE");
                    Node NE = n.addChild("NE");
                    nodes[currentPosition] = NE;
                    NE.setIndex(currentPosition);
                    currentPosition++;
                    end = stringToTreeHelper(ref str, end, NE, "NE");
                }
                else
                {
                    MessageBox.Show("Something went wrong. Not a 0,1,2! "+str[end]);
                    return str.Length;
                }
            return end; //what number to return?
        }
        private void treeToImage(Node n, int rStart, int cStart, int[,] map)
        {

            if (n == null)
            {
                MessageBox.Show("Null node");
                return;
            }
            if (!n.hasChildren)
            {
                int rows = n.numRows - 1;
                int cols = n.numCols - 1;
                int fill;
                if (n.getColorString() == "black")
                {
                    fill = 1;
                }
                else
                {
                    fill = 0;
                }
                for (int r = rStart; r < rStart + n.numRows; r++)
                {
                    for (int c = cStart; c < cStart + n.numCols; c++)
                    {
                        //MessageBox.Show("rStart="+rStart+", cStart="+cStart+", r=" + r + ", c=" + c+" fill: "+fill);
                        map[r, c] = fill;
                    }
                }
            }
            else
            {
                //MessageBox.Show(n.toString()); //("Null? NW: " + (n.NW == null) + "  SW: " + (n.SW == null) + "  SE: " + (n.SE == null) + "  NE: " + (n.NE == null));
                treeToImage(n.NW, rStart, cStart,map);
                treeToImage(n.SW, rStart + (n.numRows/2), cStart,map); 
                treeToImage(n.SE, rStart + (n.numRows/2), cStart + (n.numCols/2),map);
                treeToImage(n.NE, rStart, cStart + (n.numCols/2),map);
            }
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


        private void asTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text|*.txt";
            save.Title = "Save the image";
            String textToSave = mapToString(map1);
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(save.FileName, textToSave);
            }
        }


        private void asQuadtreeTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text|*.txt";
            save.Title = "Save the image";
            String textToSave = numRows.ToString()+" "+numCols.ToString()+" "+treeToString(root);
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(save.FileName, textToSave);
            }
        }



        private String mapToString(int[,] matrix)
        {
            if (matrix == null)
            {
                MessageBox.Show("You must select an input file first. Use 'Image>Load'");
                return "";
            }
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

        private void resizeTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pixelsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pixelsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nodeHeight = 10;
            nodeWidth = 10;
            redrawAllNodes();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nodeHeight = 20;
            nodeWidth = 20;
            redrawAllNodes();

        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nodeHeight = 40;
            nodeWidth = 40;
            redrawAllNodes();

        }

        private void displayTree(Node n)
        {

        }

        private void stringToMap(ref String s)
        {
            char[] delims = { ' ', '\n' };
            string[] text = s.Split(delims);
            int newNumRows = Convert.ToInt32(text[0]);
            int newNumCols = Convert.ToInt32(text[1]);
            int [,] newMap = new int[newNumRows, newNumCols];

        }

        private void matrixFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Plaintext Files|*.txt";
            oFD.Title = "Select a Plaintext File";

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                fileName = oFD.FileName;
            }
            //displayToolStripMenuItem_Click(sender, e);
            int result = parseMatrixInputFile(ref map1);
            if (result == -1)
            {
                return;
            }
            drawImage(ref map1);
            Node newRoot = imageToTree(map1);
        }

        private void preorderFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Plaintext Files|*.txt";
            oFD.Title = "Select a Plaintext File";

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                fileName = oFD.FileName;
            }
            //displayToolStripMenuItem_Click(sender, e);
            parsePreorderInputFile(ref map1);
            String s = "";
            for (int r = 0; r < map1.GetLength(0); r++)
            {
                for (int c = 0; c < map1.GetLength(1); c++)
                {
                    s += map1[r, c];
                }
                s += Environment.NewLine;
            }
            //MessageBox.Show(s);
                drawImage(ref map1);
            //Node newRoot = imageToTree();
        }

        private void saveToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void asTextFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text|*.txt";
            save.Title = "Save the image";
            String textToSave = mapToString(map1);
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(save.FileName, textToSave);
            }
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void asPreorderTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text|*.txt";
            save.Title = "Save the image";
            String textToSave = numRows.ToString() + " " + numCols.ToString() + " " + treeToString(root);
            if (save.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(save.FileName, textToSave);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Plaintext Files|*.txt";
            oFD.Title = "Select a Plaintext File";

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                fileName = oFD.FileName;
            }
            //displayToolStripMenuItem_Click(sender, e);
            parsePreorderInputFile(ref map1);
            treeRightStart = panel2.Width - treeLeftStart;
            drawTree(root, treeLeftStart,treeRightStart,nextLevelSpace,false);
            //displayNodeList();
        }

        private void displayNodeList()
        {
            String toDisplay = "";
            for (int i = 0; i < currentPosition; i++)
            {
                toDisplay += " at " + i + " node: " + nodes[i].getIndex();
            }
            MessageBox.Show(toDisplay);
        }
        private void displayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel2Graphics.Clear(Color.PowderBlue);
            if (map1 != null)
            {
                root = imageToTree(map1);
                treeRightStart = panel2.Width - treeLeftStart;
                drawTree(root, treeLeftStart, treeRightStart, nextLevelSpace,false);
            }
            else if (root == null)
            {
                MessageBox.Show("Load an image!");
                matrixFormatToolStripMenuItem_Click(sender, e);
            }
        }

        private void moveTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "moveTree";
            MessageBox.Show("Click and drag the root node to move the tree.");
            //TODO
        }

        private void imageToQuadtreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayToolStripMenuItem1_Click(sender, e);
        }

        private void quadtreeToImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayToolStripMenuItem_Click(sender, e);
        }

        private void randomMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 128;
            numRows = n;
            numCols = n;
            map1 = new int[numRows, numCols];
            nodes = new Node[n * n * 2];
            Random rnd = new Random();
            for (int r = 0; r < numRows; r++){
                for (int c = 0; c < numCols; c++)
                {
                    int num = rnd.Next(0, 3);
                    if (num == 2)
                    {
                        num = 0;
                    }
                    map1[r, c] = num;
                }
            }
            drawImage(ref map1);
        }

        private void smallToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nodeHeight = 10;
            nodeWidth = 10;
            nextLevelSpace = 40;
            treeLeftStart += (panel2.Width / 4);
            treeRightStart -= (panel2.Width / 4);
            if (root != null)
            {
                redrawTree(root, false);
            }
            else
            {
                MessageBox.Show("Load a quadtree first!");
            }
        }

        private void mediumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nodeHeight = 20;
            nodeWidth = 20;
            nextLevelSpace = 75;
            treeLeftStart = -100;
            treeRightStart = panel2.Width - treeLeftStart;
            if (root != null)
            {
                redrawTree(root, false);
            }
            else
            {
                MessageBox.Show("Load a quadtree first!");
            }
        }

        private void largeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nodeHeight = 40;
            nodeWidth = 40;
            nextLevelSpace = 125;
            treeLeftStart -= (panel2.Width / 4);
            treeRightStart += (panel2.Width / 4);
            if (root != null)
            {
                redrawTree(root, false);
            }
            else
            {
                MessageBox.Show("Load a quadtree first!");
            }
        }

        private void comparisonImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map1 == null)
            {
                MessageBox.Show("Please use Image>Load>Matrix to load your first image");
                return;
            }
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Plaintext Files|*.txt";
            oFD.Title = "Select a Plaintext File";

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                fileName = oFD.FileName;
            }
            int result = parseMatrixInputFile(ref map2);
            if (result == -1) { 
                return;
            }
            int[] r = {0,0,0,0};
            drawImageHelper(ref map2, r, panel2Graphics);
            Node root1 = imageToTree(map1);
            Node root2 = imageToTree(map2);
            String string1 = treeToString(root1);
            String string2 = treeToString(root2);
            bool similar = checkForSimilar(string1, string2);
            if (similar){
                bool identical = checkForIdentical(root1, root2);
                if (identical){
                    MessageBox.Show("The two images are identical.");
                }
                else {
                    MessageBox.Show("The two images are similar, but not identical.");
                }
            }
            else {
                MessageBox.Show("The two images are not the same at all.");

            }
        }

        public bool checkForSimilar(String s1, String s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool checkForIdentical(Node r1, Node r2)
        {
            return (r1.numRows == r2.numRows && r1.numCols == r2.numCols);
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moveArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click and drag on a node to move the connected arrow head. Then click and drag to move base.");
            menuChoice = "moveArrowHead";
        }

        private void moveNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuChoice = "moveNode";
        }

        private void headToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void baseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on a node to move the connected arrow base");
            menuChoice = "moveArrowBase";
        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            panel1_MouseUp(sender, e);
        }

        
    }//class
}//namespace