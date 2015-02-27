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
    }
}
