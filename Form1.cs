using Mapack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRegistration
{
    public partial class Form1 : Form
    {
        //Shape 1 and Shape 2 are the shapes displayed on the windows form
        List<Point> Shape1 = new List<Point>();
        List<Point> Shape2 = new List<Point>();
        RegistrationTools utils = new RegistrationTools();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// We create two set of points to test our Image Registration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateShapes_Click(object sender, EventArgs e)
        {
            CreatePointLists();
            //We are going to map the point in the Shape1 to some other points using an arbitrary transformation
            Transformation T = new Transformation(1.05, 0.05, 15, 22);
            Shape2 = utils.ApplyTransformation(T, Shape1);
            Shape2[2] = new Point(Shape2[2].X + 10, Shape2[2].Y + 3); //Creating some noise that does not obey a transformation
            DrawOnPanel(panOriginal);
            
        }

        void DrawOnPanel(Panel pan)
        {
            //Drawing the shapes on the panel
            Pen blue = new Pen(Brushes.Blue, 1);
            Pen red = new Pen(Brushes.Red, 1);
            Graphics g = pan.CreateGraphics();
            DisplayShape(Shape1, blue, g);
            DisplayShape(Shape2, red, g);
        }

        void CreatePointLists()
        {
            Shape1.Clear();
            Shape2.Clear();
            Point p1a = new Point(20, 30);
            Point p2a = new Point(120, 50);
            Point p3a = new Point(160, 80);
            Point p4a = new Point(180, 300);
            Point p5a = new Point(100, 220);
            Point p6a = new Point(50, 280);
            Point p7a = new Point(20, 140);
            Shape1.Add(p1a); Shape1.Add(p2a);
            Shape1.Add(p3a); Shape1.Add(p4a);
            Shape1.Add(p5a); Shape1.Add(p6a);
            Shape1.Add(p7a);
        }

        void DisplayShape(List<Point> Shape, Pen pen, Graphics g)
        {
            Point? prevPoint = null;
            foreach(Point p in Shape)
            {
                g.DrawEllipse(pen, new Rectangle(p.X - 2, p.Y - 2, 4, 4));
                if (prevPoint != null) g.DrawLine(pen, (Point)prevPoint, p);
                prevPoint = p;
            }
            g.DrawLine(pen, Shape[0], Shape[Shape.Count - 1]);
        }

        private void btnApplyTransform_Click(object sender, EventArgs e)
        {
            Transformation T = utils.GenerateT(P1:Shape1, P2:Shape2);
            Shape2 = utils.ApplyTransformation(T, Shape2);
            DrawOnPanel(panAfterT);
        }
    }
}
