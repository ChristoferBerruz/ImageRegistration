using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRegistration
{
    public class Transformation
    {
        private double a = 0;
        private double b = 0;
        private double t1 = 0;
        private double t2 = 0;
        public double A { set { } get { return a; } }
        public double B { set { } get { return b; } }
        public double T1 { set { } get { return t1; } }
        public double T2 { set { } get { return t2; } }
        public Transformation(double A, double B, double T1, double T2)
        {
            a = A; b = B; t1 = T1; t2 = T2;
        }

        public Transformation()
        {

        }

        public Point MapPoint(Point p)
        {
            int x = (int)(a * p.X + b * p.Y + t1);
            int y = (int)(-b * p.X + a * p.Y + t2);
            return new Point(x, y);
        }
    }
}
