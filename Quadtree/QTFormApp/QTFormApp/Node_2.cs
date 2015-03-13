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
    public class Node
    {
        private Point coord;
        private Color color;
        private static Brush brush;
        public Node NW = null;
        public Node NE = null;
        public Node SE = null;
        public Node SW = null;
        public bool hasChildren = false;
        public int numRows;
        public int numCols;

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
        /*
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
        */
        public void setColor(Color c)
        {
            color = c;
        }

        public Color getColor()
        {
            return color;
        }

        public String getColorString()
        {
            if (color == Color.White)
            {
                return "white";
            }
            else if (color == Color.Black)
            {
                return "black";
            }
            else
            {
                return "gray";
            }
        }
        public void setPoint(Point p)
        {
            coord = p;
        }

        public Point getPoint()
        {
            return coord;
        }

        private void validate(Node n){
            if (color == Color.Gray && (NW.color == NE.color && NE.color == SW.color && SW.color == SE.color))
            {
                throw new Exception("Bad node");
            }
        }

        public void addChild(String s)
        {
            hasChildren = true;
            switch (s)
            {
                case "NW":
                    NW = new Node();
                    break;
                case "SW":
                    SW = new Node();
                    break;
                case "SE":
                    SE = new Node();
                    break;
                case "NE":
                    NE = new Node();
                    break;
                default:
                    //add exception
                    break;
            }
        }

        public void addChild(String s, Node n)
        {
            hasChildren = true;
            switch (s)
            {
                case "NW":
                    NW = n;
                    break;
                case "SW":
                    SW = n;
                    break;
                case "SE":
                    SE = n;
                    break;
                case "NE":
                    NE = n;
                    break;
                default:
                    //add exception
                    break;
            }
        }

        public void addChildren()
        {
            hasChildren = true;

            addChild("NW");
            addChild("SW");
            addChild("SE");
            addChild("NE");
        }

        public void removeChildren()
        {
            NW = null;
            NE = null;
            SE = null;
            SW = null;
            hasChildren = false;
        }

        public void prune()
        {
            if (hasChildren)
            {
                if (NW.getColor() == SW.getColor() && NW.getColor() == NE.getColor() && NW.getColor() == SE.getColor())
                {
                    removeChildren();
                }
                else
                {
                    NW.prune();
                    SW.prune();
                    SE.prune();
                    NE.prune();
                }
            }
        }
    }
}