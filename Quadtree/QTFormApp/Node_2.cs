using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QTFormApp
{
    class Node
    {
        private Point coord;
        private Color color;
        private static Brush brush;
        private Node NW;
        private Node NE;
        private Node SE;
        private Node SW;

        public Node()
        {
            coord = new Point(20, 20);
            color = Color.White;
            NW = null;
            NE = null;
            SE = null;
            SW = null;
        }

        public Node(Point p)
        {
            coord = p;
            color = Color.White;
            NW = null;
            NE = null;
            SE = null;
            SW = null;
        }

        public Node(Color c)
        {
            coord = new Point(20, 20);
            color = c;
            NW = null;
            NE = null;
            SE = null;
            SW = null;
        }

        public Node(Point p, Color c)
        {
            coord = p;
            color = c;
            NW = null;
            NE = null;
            SE = null;
            SW = null;
        }

        public static Node drawNode(System.Drawing.Graphics pg, Point p, Color c)
        {
            brush = new SolidBrush(c);
            pg.FillEllipse(brush, new Rectangle(p, new Size(Form1.nodeW, Form1.nodeH)));
            return new Node(p, c);
        }

        public static Node drawNode(System.Drawing.Graphics pg, Point pt, LinearGradientBrush lgb)
        {
            pg.FillEllipse(lgb, new Rectangle(pt, new Size(Form1.nodeW, Form1.nodeH)));
            return new Node(pt, Color.Gray);
        }

        public void setColor(Color c)
        {
            color = c;
        }

        private void validate(Node n){
            if (color == Color.Gray && (NW.color==NE.color==SW.color==SE.color)){
                throw new Exception("Bad node");
            }
        }
        /*
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
                MessageBox.Show("Exception!");
                throw new Exception("Not a square!");
            }
            MessageBox.Show("rowStart: " + rowStart + " rowStop: " + rowStop + " colStart: " + colStart + " colStop: " + colStop);
            if (rowStop - rowStart < 0)
            {
                throw new Exception("Invalid params");
            }
            else if (rowStop - rowStart == 0)
            {
                if (m[rowStart, colStart] == 1)
                {
                    MessageBox.Show("At coords " + rowStart + ", " + colStop + " the color is black.");
                    root.setColor(Color.Black);
                    return root;
                }
                else
                    MessageBox.Show("At coords " + rowStart + ", " + colStop + " the color is white.");
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
         */
    }

}
