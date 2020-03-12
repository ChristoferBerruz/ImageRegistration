using Mapack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRegistration
{
    public class RegistrationTools
    {
        /// <summary>
        /// Creates the best mapping for the set of points
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <returns></returns>
        public Transformation GenerateT(List<Point> P1, List<Point> P2)
        {
            if (P1.Count != P2.Count) throw new ArgumentException("Lists are not the same size!");
            int m = P1.Count;
            Matrix I1 = new Matrix(m, 2);
            Matrix I2 = new Matrix(m, 2);
            //Unpacking the points into matrices
            for (int i = 0; i < m; i++)
            {
                I1[i, 0] = P1[i].X;
                I1[i, 1] = P1[i].Y;
                I2[i, 0] = P2[i].X;
                I2[i, 1] = P2[i].Y;
            }
            return GenerateT(I1, I2);

        }

        public Transformation GenerateT(Matrix I1, Matrix I2)
        {
            Matrix parameters = LLOptimization(I1, I2);
            double a = parameters[0, 0]; double b = parameters[1, 0]; double t1 = parameters[2, 0]; double t2 = parameters[3, 0];
            return new Transformation(a, b, t1, t2);
        }

        public Matrix LLOptimization(Matrix I1, Matrix I2)
        {
            int m = I1.Rows;
            Matrix X1 = I1.Submatrix(startRow: 0, endRow: m-1, startColumn: 0, endColumn: 0);
            Matrix Y1 = I1.Submatrix(startRow: 0, endRow: m-1, startColumn: 1, endColumn: 1);
            Matrix X2 = I2.Submatrix(startRow: 0, endRow: m-1, startColumn: 0, endColumn: 0);
            Matrix Y2 = I2.Submatrix(startRow: 0, endRow: m-1, startColumn: 1, endColumn: 1);
            //Solving Ax = b
            //Creating A
            Matrix A = new Matrix(4, 4);
            Matrix B = new Matrix(4, 1);
            //Creating and setting values into the matrix to be solved
            double sumOfSquares = 2 * X2.HadamardProduct(X2).Sum() + 2*Y2.HadamardProduct(Y2).Sum(); // 2*Sum(X2 ** 2) + 2*Sum(Y2**2)
            double sumOfX2 = 2 * X2.Sum();
            double sumOfY2 = 2 * Y2.Sum();
            double twoM = 2 * m;
            A[0, 0] = sumOfSquares; A[0, 1] = 0; A[0, 2] = sumOfX2; A[0, 3] = sumOfY2;
            A[1, 0] = 0; A[1, 1] = sumOfSquares; A[1, 2] = sumOfY2; A[1, 3] = -sumOfX2;
            A[2, 0] = sumOfX2; A[2, 1] = sumOfY2; A[2, 2] = twoM; A[2, 3] = 0;
            A[3, 0] = sumOfY2; A[3, 1] = -sumOfX2; A[3, 2] = 0; A[3, 3] = twoM;
            //Calculating and setting values for b vector
            double x1x2 = 2 * X1.HadamardProduct(X2).Sum();
            double y1y2 = 2 * Y1.HadamardProduct(Y2).Sum();
            double x1y2 = 2 * X1.HadamardProduct(Y2).Sum();
            double y1x2 = 2 * Y1.HadamardProduct(X2).Sum();
            B[0, 0] = x1x2 + y1y2;
            B[1, 0] = x1y2 - y1x2;
            B[2, 0] = 2 * X1.Sum();
            B[3, 0] = 2 * Y1.Sum();
            //Calculating the solution for this Linear Least Squares Optimization
            return A.Inverse * B; //return [a, b, t1, t2] as a column vector (or 4x1 matrix)

        }

        /// <summary>
        /// Applys a transformation to a List of Points
        /// </summary>
        /// <param name="T"> Needs to be a matrix</param>
        /// <returns></returns>
        public List<Point> ApplyTransformation(Transformation T, List<Point> Points)
        {
            List<Point> Result = new List<Point>();
            foreach(Point p in Points)
            {
                Result.Add(T.MapPoint(p));
            }
            return Result;
        }

        /// <summary>
        /// Computing cost of a transformation T in a set of points
        /// </summary>
        /// <param name="T"></param>
        /// <param name="ExpectedPoints"></param>
        /// <param name="Points"></param>
        /// <returns></returns>
        public double ComputeOverallCost(Transformation T, List<Point> ExpectedPoints, List<Point> Points)
        {
            double cost = 0.0;
            //We assume mapping is one to one, in order
            for(int i = 0; i < Points.Count; i++)
            {
                cost += ComputeSingleCost(T, ExpectedPoints[i], Points[i]); //squared distance between points
            }
            return cost;
        }

        public double ComputeSingleCost(Transformation T, Point p, Point P2)
        {
            Point prime = T.MapPoint(P2);
            return (p.X - prime.X) * (p.X - prime.X) + (p.Y - prime.Y) * (p.Y - prime.Y);
        }

        /// <summary>
        /// Ransac algorithm for removing outliers of the dataset. We are trying to find the best Transformation
        /// </summary>
        /// <param name="Shape1"> Original points</param>
        /// <param name="Shape2"> Mapped Points</param>
        /// <param name="nStartingPoints"> N intially random picked points</param>
        /// <param name="tresh"> Treshold to accept a datum, keep in mind that here cost is distance squared</param>
        /// <param name="nTotalPoints"> Lower bound on how many points is need for the consesus set to be representative</param>
        /// <param name="cleanedShape1"> Best consensus set of Shape1</param>
        /// <param name="cleanedShape2">Best consensus set of Shape2</param>
        /// <param name="bestCost"> Best cost of the current Transformation</param>
        /// <param name="bestT"> Best Transformation</param>
        public void Ransac(List<Point> Shape1, List<Point>Shape2, int nStartingPoints, double tresh, int nTotalPoints, int iterations,  ref List<Point> cleanedShape1, ref List<Point> cleanedShape2, 
            ref double bestCost, ref Transformation bestT)
        {
            //Max number of iterations of the algorithm
            for(int i = 0; i < iterations; i++)
            {
                bool[] indexUsed = new bool[Shape2.Count];
                List<Point> curShape1 = new List<Point>(); List<Point> curShape2 = new List<Point>();
                PickRandomPoints(nStartingPoints, Shape1, Shape2, ref indexUsed, ref curShape1, ref curShape2);
                Transformation T = GenerateT(curShape1, curShape2); //Model that best fits the current set
                //Now try to add a point into the current consensus set  based on treshold,
                for(int j  = 0; j < Shape2.Count; j++)
                {
                    if(!indexUsed[j])//Only points that have not been added
                    {
                        double cost = ComputeSingleCost(T, Shape1[j], Shape2[j]); // How good does this datum fit the consensus set model
                        if(cost<tresh)
                        {
                            //We add to the current consensus set
                            curShape1.Add(Shape1[j]); curShape2.Add(Shape2[j]);
                        }
                    }
                }

                //We need to check if we added at least nTotalPoints
                if(curShape1.Count > nTotalPoints)
                {
                    T = GenerateT(curShape1, curShape2); //Finding the transformation that fits this consesus set
                    //We now compute the error of this transformation on ALL the dataset
                    double curCost = ComputeOverallCost(T, Shape1, Shape2);
                    if(i == 0)
                    {
                        //It is the first iteration, so we just the current cost is the best cost
                        bestCost = curCost;
                    }

                    if (curCost <= bestCost)
                    { 
                            bestT = T;
                            bestCost = curCost;
                            cleanedShape1 = curShape1;
                            cleanedShape2 = curShape2;
                    }
                    
                }

            }
            
        }

        public void PickRandomPoints(int n, List<Point> Shape1, List<Point> Shape2, ref bool[] indexes, ref List<Point> R1, ref List<Point> R2)
        {
            Random rand = new Random();
            int curpicked = 0;
            do
            {
                int idx = rand.Next(0, Shape1.Count);
                if (!indexes[idx])
                {
                    indexes[idx] = true;
                    curpicked += 1;
                    R1.Add(Shape1[idx]); R2.Add(Shape2[idx]);
                }
            } while (curpicked < n);
        }
    }
}
