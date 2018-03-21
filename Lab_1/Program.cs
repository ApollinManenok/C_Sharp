using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// massiv dvumernyj, odnomernyj, zapolnenie s konsoli

namespace ConsoleApp2
{
    class Program
    {
        static double MaxElemArrayMatrix(MyArray a, MyMatrix b)
        {
            int maxInt = a.FindMax();
            double maxDouble = b.FindMax();
            return maxInt > maxDouble ? maxInt : maxDouble; ;
        }

        static double MinElemArrayMatrix(MyArray a, MyMatrix b)
        {
            int minInt = a.FindMin();
            double minDouble = b.FindMin();
            return minInt < minDouble ? minInt : minDouble; ;
        }

        static double TotalSumArrayMatrix(MyArray a, MyMatrix b)
        {
            return a.TotalSum() + b.TotalSum();
        }

        static double TotalProductArrayMatrix(MyArray a, MyMatrix b)
        {
            return a.TotalProduct() * b.TotalProduct();
        }

        static MyArray CreateArrayFromSameNums(MyArray one, MyArray two)
        {
            int result = 0;
            int max1 = one.FindMax();
            int max2 = two.FindMax();
            int[] arr = new int[max1 > max2 ? max1 : max2];
            for(int i = 0; i < one.GetLength(); ++i)
            {
                for (int j = 0; j < two.GetLength(); ++j)
                {
                    if(one.GetAt(i) == two.GetAt(j))
                    {
                        bool added = false;
                        for(int i1 = 0; i1 < result; ++i1)
                        {
                            if(one.GetAt(i) == arr[i1])
                            {
                                added = true;
                                break;
                            }
                        }
                        if(!added)
                        {
                            arr[result] = one.GetAt(i);
                            ++result;
                        }
                    }
                }
            }

            MyArray third = new MyArray(result);
            for(int i = 0; i < result; ++i)
            {
                third.SetAt(arr[i], i);
            }
            return third;
        }
        
        static int SumMinMaxMatrix(ref int[,] matrix)
        {
            //Find min/max values and its indexes
            int[] minParam = { matrix[0, 0], 0, 0 };
            int[] maxParam = { matrix[0, 0], 0, 0 };
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    if (minParam[0] > matrix[i, j])
                    {
                        minParam[0] = matrix[i, j];
                        minParam[1] = i;
                        minParam[2] = j;
                    }
                    if (maxParam[0] < matrix[i, j])
                    {
                        maxParam[0] = matrix[i, j];
                        maxParam[1] = i;
                        maxParam[2] = j;
                    }
                }
            }
            //Console.Write($"{minParam[0]} ({minParam[1]},{minParam[2]})\n{maxParam[0]} ({maxParam[1]},{maxParam[2]})\n\n");
            //Wich is first or second
            int start = 0;
            int end = 0;
            if (minParam[1] * 5 + minParam[2] > maxParam[1] * 5 + maxParam[2])
            {
                start = maxParam[0];
                end = minParam[0];
            }
            else
            {
                start = minParam[0];
                end = maxParam[0];
            }
            //Counting sum from first to second
            int sum = 0;
            bool inRangeMinMax = false;
            foreach (int elem in matrix)
            {
                if (!inRangeMinMax && elem == start)
                {
                    sum += elem;
                    inRangeMinMax = true;
                }
                else if (inRangeMinMax)
                {
                    sum += elem;
                    if (elem == end)
                    {
                        break;
                    }
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            
            MyArray A = new MyArray(5);
            A.ManualFill();
            A.PrintArray();
            MyMatrix B = new MyMatrix(3, 4);
            B.PrintMatrix();
            Console.WriteLine($"Max num {MaxElemArrayMatrix(A, B)}");
            Console.WriteLine($"Min num {MinElemArrayMatrix(A, B)}");
            Console.WriteLine($"Total sum {TotalSumArrayMatrix(A, B)}");
            Console.WriteLine($"Total product of numbers {TotalProductArrayMatrix(A, B)}");
            Console.WriteLine($"Sum of even numbers {A.SumEvenNum()}");
            Console.WriteLine($"Sum of odd columns {B.SumOddColumnElem()}");
          
            MyArray first = new MyArray(10);
            first.RandomFill();
            MyArray second = new MyArray(20);
            second.RandomFill();
            MyArray third = CreateArrayFromSameNums(first, second);
            Console.WriteLine("\n\nFirst array:");
            first.PrintArray();
            Console.WriteLine("Second array:");
            second.PrintArray();
            Console.WriteLine("Result array:");
            third.PrintArray();

            Console.WriteLine("\nMatrix 5x5 from -100 to 100:\n");
            int[,] matrix = new int[5, 5];
            for(int i = 0; i < 5; ++i)
            {
                for(int j = 0; j < 5; ++j)
                {
                    matrix[i, j] = MyArray.rand.Next(-100, 100);
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.Write("\n\n");
            Console.WriteLine($"Sum between min and max values {SumMinMaxMatrix(ref matrix)}\n");
        }
    }
}
