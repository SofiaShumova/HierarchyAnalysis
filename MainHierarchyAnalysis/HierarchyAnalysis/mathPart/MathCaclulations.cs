using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HierarchyAnalysis;
using MathNet.Numerics;

namespace HierarchyAnalysis.mathPart
{
   public static class MathCaclulations
    {
        public static double Eigenvalue(double[,] array)
        {
            Matrix<double> A = DenseMatrix.OfArray(array);

            Evd<double> eigen = A.Evd();
            Matrix<double> eigenvect = eigen.EigenVectors;
            Vector<Complex> eigenvalues = eigen.EigenValues;

            return eigenvalues.AbsoluteMaximum().Real;
        }

        public static List<double> LocalPriority(double[,] array)
        {
            List<double> priority = new List<double>();
            int countNumber = 0; //array.GetLength(1);
            double multiply;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                countNumber = 0;
                multiply = 1;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != 0)
                    {
                        countNumber++;
                        multiply *= array[i, j];
                    }
                    
                }
                if (countNumber<1)
                {
                    priority.Add(0);
                }
                else
                {
                    priority.Add(Math.Pow(multiply, 1.0 / countNumber));
                }
                
            }
            return priority;
        }
        public static List<double> Priority(List<double> array)
        {
            List<double> vs = new List<double>();
            double sum = array.Sum();
            foreach (double i in array)
            {
                if (i == 0)
                {
                    vs.Add(0);
                }
                else
                {
                    vs.Add(i / sum);
                }
                
            }
            return vs;
        }

        public static double GetNormalCIS(int n)
        {
            switch (n)
            {
                case 2:
                    return 0;
                case 3:
                    return 0.58;
                case 4:
                    return 0.9;
                case 5:
                    return 1.12;
                case 6:
                    return 1.24;
                case 7:
                    return 1.32;
                case 8:
                    return 1.41;
                case 9:
                    return 1.45;
                case 10:
                    return 1.49;
                case 11:
                    return 1.51;
                case 12:
                    return 1.48;
                default:
                    return 0;
            }
             
        }
        public static double GetNormalCR(int n)
        {
            switch (n)
            {
                case 2:
                    return 0.01;
                case 3:
                    return 0.05;
                case 4:
                    return 0.08;
                case 5:
                    return 0.1;
                case 6:
                    return 0.1;
                case 7:
                    return 0.1;
                case 8:
                    return 0.1;
                case 9:
                    return 0.1;
                case 10:
                    return 0.1;
                case 11:
                    return 0.1;
                case 12:
                    return 0.1;
                default:
                    return 0;
            }

        }
        public static double GetCI(double eig, int n)
        {
            return (eig - n) / (n - 1);
        }
        public static double GetCR(double ci, double cisNormal)
        {
            return ci / cisNormal;
        }

        public static double[,] MultiplyMatrix(double[,] array1, double[,] array2, double[,] array3)
        {
            Matrix<double> matrix1 = DenseMatrix.OfArray(array1);
            Matrix<double> matrix2 = DenseMatrix.OfArray(array2);
            Matrix<double> matrix3 = DenseMatrix.OfArray(array3);
            MessageBox.Show(convertToString(array1));
            MessageBox.Show(convertToString(array2));
            MessageBox.Show(convertToString(array3));
            Matrix<double> matrix = matrix1*matrix2 ;

            MessageBox.Show(convertToString(matrix.ToArray()));
            matrix *= matrix3;
            MessageBox.Show(convertToString(matrix.ToArray()));
            return matrix.ToArray();
        }
        private static string convertToString(double[,] array)
        {
            string str = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    str += $"{Math.Round(array[i, j], 4),-10}";
                }
                str += "\n";
            }
            return str;
        }
    }
}
