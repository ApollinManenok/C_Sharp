using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    
    class MyMatrix
    {
        //variables
        private double[,] matrix;
        private int line = 0;
        private int column = 0;

        //methods
        public MyMatrix(int lines, int columns, int randomValMin = 0, int randomValMax = 1001)
        {
            matrix = new double[lines, columns];
            line = lines;
            column = columns;
            Random tempRandom = new Random();
            for (int i = 0; i<line; ++i)
            {
                for (int j = 0; j<column; ++j)
                {
                    matrix[i, j] = tempRandom.Next(randomValMin, randomValMax) / 100.0;
                }
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < line; ++i)
            {
                for (int j = 0; j < column; ++j)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.Write("\n");
            }
            Console.Write("\n\n");
        }

        public double GetAt(int lineInd, int columnInd)
        {
            return matrix[lineInd, columnInd];
        }

        public void SetAt(int elem, int lineInd, int columnInd)
        {
            matrix[lineInd, columnInd] = elem;
        }

        public double FindMax()
        {
            double max = 0.0;
            foreach (double elem in matrix)
            {
                if(elem > max)
                {
                    max = elem;
                }
            }
            return max;
        }

        public double FindMin()
        {
            double min = matrix[0,0];
            foreach (double elem in matrix)
            {
                if (elem < min)
                {
                    min = elem;
                }
            }
            return min;
        }

        public double TotalSum()
        {
            double sum = 0.0;
            foreach (double elem in matrix)
            {
                sum += elem;
            }
            return sum;
        }

        public double TotalProduct()
        {
            double result = matrix[0,0];
            foreach (double elem in matrix)
            {
                result *= elem;
            }
            return result/matrix[0,0];
        }

        public double SumOddColumnElem() // first column which is zero pretend to be odd... because it's first.
        {
            double sum = 0.0;
            for (int i = 0; i<line; ++i)
            {
                for (int j = 0; j < column; j+=2)
                {
                    sum += matrix[i,j];
                }
            }
            return sum;
        }
    }
}
