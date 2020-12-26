using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        private Rectangle Rect;
        private float PenWidth = 50;
        private Random rand;
        Point p1;
        Point p2;
        int DrawingState { get; set; } 
        public Form1()
        {
            DrawingState = 1;
            InitializeComponent();
            rand = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_PaintRect(object sender, PaintEventArgs e)
        {
            DrawingState = 1;
            var randColour = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            e.Graphics.DrawRectangle(new Pen(randColour, PenWidth), Rect);
        }

        private void Form1_PaintFractal(object sender, PaintEventArgs e)
        {
            if (DrawingState != 2) { return; }
            SolidBrush sb = new SolidBrush(Color.Red);
            e.Graphics.DrawLine(new Pen(sb), p1.X, p1.Y, p2.X, p2.Y);
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            DrawingState = 2;
            p1 = new Point(this.Width / 2, this.Height);
            p2 = new Point(this.Width / 2, this.Height / 2);
           
            DrawFractal(p1, p2, 5);
            for (int i = 0; i <= 5; i++)
            {
                
                Point p = new Point(p2.X < p1.X ? p2.X : p1.X, p2.Y < p1.Y ? p2.Y : p1.Y);
                Rectangle Rect = new Rectangle(p.X, p.Y, Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
                this.Invalidate(Rect);
            }
        }

        private int Distance(Point p1, Point p2)
        {
            var distance = Math.Sqrt((p1.X-p2.X)^2 + (p1.Y-p2.Y)^2);
            return (int)distance;
        }

        /*private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Rect.Width = 50;
            Rect.Height = 50;
            Console.WriteLine("MouseClicked");
            this.Invalidate(Rect);
        }*/

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            DrawingState = 1;
            p1 = new Point (e.X, e.Y);
            Rect.Location = p1;
            
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            p2 = new Point(e.X, e.Y);
            Rect.X = p2.X < p1.X ? p2.X : p1.X;
            Rect.Y = p2.Y < p1.Y ? p2.Y : p1.Y;
            Rect.Width = Math.Abs(p2.X - p1.X);
            Rect.Height = Math.Abs(p2.Y - p1.Y);
            this.Invalidate(Rect);
        }

        private void updateTopLeftPosition(ref Point p1, ref Point p2) 
        { 

        }

        


       
    }
}
