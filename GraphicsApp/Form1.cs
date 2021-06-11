using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            
            InitializeComponent();
            rand = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_PaintRect(object sender, PaintEventArgs e)
        {
            if (DrawingState == 1)
            {
                DrawingState = 1;
                var randColour = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                e.Graphics.FillRectangle(new SolidBrush(randColour), Rect);
            }
            if (DrawingState == 2)
            {
                
                SolidBrush sb = new SolidBrush(Color.Red);
                e.Graphics.DrawLine(new Pen(sb), Rect.X, Rect.Y, Rect.X + Rect.Width, Rect.X + Rect.Height);
                e.Graphics.DrawRectangle(new Pen(sb), Rect.X, Rect.Y, Rect.Width, Rect.Height);
            }
        }

       
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            DrawingState = 2;
            Point StartPoint = new Point(rand.Next(this.Width), rand.Next(this.Height));
            var startingPoint = StartPoint;
            var finishPoint = new Point(StartPoint.X, Math.Abs(StartPoint.Y+100));
            PenWidth = 1;
            DrawFractal(startingPoint, finishPoint, 5);
        }
        
        public void DrawFractal(Point startingPoint, Point finishPoint, int iteration)
        {
            if (iteration == 0) { return; }
            var s = startingPoint;
            var f = finishPoint;
            Rect = new Rectangle(s.X, s.Y, Math.Abs(s.X - f.X), Math.Abs(s.Y - f.Y));
            this.Invalidate(Rect);
            Application.DoEvents();
            DrawFractal(new Point(s.X,s.Y),new Point(f.X -50, f.Y +50), iteration-1);
            DrawFractal(new Point(s.X, s.Y), new Point(f.X + 50, f.Y + 50), iteration - 1);
            /*Rect = new Rectangle(s.X / 2, s.Y / 2, Math.Abs(s.X - f.X), Math.Abs(s.Y - f.Y));
            this.Invalidate(Rect);
            Application.DoEvents();
            DrawFractal(new Point(Rect.X, Rect.Y), new Point(Rect.X + 50, Rect.Y + 50), iteration-1);*/
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
            GraphicsPath g = new GraphicsPath();
            g.
            
        }

        private void updateTopLeftPosition(ref Point p1, ref Point p2) 
        { 

        }

        


       
    }
}
