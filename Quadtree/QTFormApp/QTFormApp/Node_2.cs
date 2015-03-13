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
        public Node SW = null;
        public Node NE = null;
        public Node SE = null;
        public Node parent = null;
        public bool hasChildren = false;
        public bool isRoot = true;
        public int numRows;
        public int numCols;
        public int level = 0;

        public Node()
        {
            coord = new Point(20, 20);
            color = Color.White;
            NW = null;
            SW = null;
            NE = null;
            SE = null;
            parent = null;
        }

        public Node(bool isItRoot)
        {
            isRoot = isItRoot;
            coord = new Point(20, 20);
            color = Color.White;
            NW = null;
            SW = null;
            NE = null;
            SE = null;
            parent = null;
        }

        public Node(Point p)
        {
            coord = p;
            color = Color.White;
            NW = null;
            SW = null;
            NE = null;
            SE = null;
            parent = null;
        }

        public Node(Color c)
        {
            coord = new Point(20, 20);
            color = c;
            NW = null;
            SW = null;
            NE = null;
            SE = null;
            parent = null;
        }

        public Node(Point p, Color c)
        {
            coord = p;
            color = c;
            NW = null;
            SW = null;
            NE = null;
            SE = null;
            parent = null;
        }

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
                    NW = new Node(false);
                    NW.parent = this;
                    NW.level = level++;
                    break;
                case "SW":
                    SW = new Node(false);
                    SW.parent = this;
                    SW.level = level++;
                    break;
                case "SE":
                    SE = new Node(false);
                    SE.parent = this;
                    SE.level = level++;
                    break;
                case "NE":
                    NE = new Node(false);
                    NE.parent = this;
                    NE.level = level++;
                    break;
                default:
                    //add exception
                    break;
            }
        }

        public String getDirectionString()
        {
            if (this == this.parent.NW)
            {
                return "NW";
            }
            else if (this == this.parent.SW)
            {
                return "SW";
            }
            else if (this == this.parent.NE)
            {
                return "NE";
            }
            else if (this == this.parent.SE)
            {
                return "SE";
            }
            else if (this.isRoot)
            {
                return "root";
            }
            return "";
        }
        public void addChild(String s, Node n)
        {
            hasChildren = true;
            n.isRoot = false;
            n.parent = this;
            n.level = level++;
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
            addChild("NE");
            addChild("SE");
        }

        public void removeChildren()
        {
            NW = null;
            SW = null;
            NE = null;
            SE = null;
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
                    NE.prune();
                    SE.prune();
                }
            }
        }
    }
}