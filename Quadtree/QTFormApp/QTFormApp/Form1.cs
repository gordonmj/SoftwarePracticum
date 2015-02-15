using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTFormApp
{
    public partial class Form1 : Form
    {
        private String clicked;
        public Point coords;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mea = (MouseEventArgs)e;
                coords = mea.Location;
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            //Graphics graphic_obj = canvas.CreateGraphics();
            //Brush black = new SolidBrush(Color.Black);
            //Pen border = new Pen(black, 1);
            //switch (clicked)
            //{
            //    case "drawNode":
            //        graphic_obj.DrawEllipse(border, new Rectangle(new Point(50, 50), new Size(50, 25)));
            //        break;

            //    default:
            //        break;
            //}
        }

        private void canvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs mea = e;
            Point whereClicked = mea.Location;
         
            Graphics graphic_obj = canvas.CreateGraphics();
            Brush black = new SolidBrush(Color.Black);
            Pen border = new Pen(black, 1);
            switch (clicked)
            {
                case "drawWhiteNode":
                    graphic_obj.DrawEllipse(border, new Rectangle(whereClicked, new Size(50, 25)));
                    break;
                case "drawBlackNode":
                    graphic_obj.FillEllipse(black, new Rectangle(whereClicked, new Size(50, 25)));
                    break;

                default:
                    break;
            }
        }

    }
}
