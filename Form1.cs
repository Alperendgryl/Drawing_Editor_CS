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

namespace DrawingEditor
{
    public partial class Form1 : Form
    {

        int x, y, height, width;
        Pen pen = new Pen(Color.Red, 5f);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            height = e.X - x;
            width = e.Y - y;
            Graphics g = this.CreateGraphics();
            Rectangle rect = new Rectangle(x, y, height, width);

            if (radioButton1.Checked) // Circle
            {
                g.DrawEllipse(pen, rect); 
            }
            else if (radioButton2.Checked) // Square
            {
                g.DrawRectangle(pen, rect);
            }
            else if (radioButton3.Checked) // Rectangle
            {
                g.DrawRectangle(pen, rect);
            }
            else if (radioButton4.Checked) // Line
            {
                g.DrawLine(pen,new Point (x,y), e.Location);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Change the color
        {
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;
            pen.Color = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e) // Clear the page
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
        }
    }
}
