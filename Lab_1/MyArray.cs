using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class MyArray
    {
        //variables
        private int[] arr;
        public static Random rand = new Random();
        //methods
        public MyArray(int len)
        {
            arr = new int[len];
        }

        public void ManualFill()
        {
            Console.WriteLine($"Enter {arr.Length} number(s) for your array");
            for (int i = 0; i < arr.Length; i++)
            {
                String num = Console.ReadLine();
                arr.SetValue(Convert.ToInt32(num), i);
            }
        }

        public void RandomFill()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 10);
            }
        }

        public void PrintArray()
        {
            foreach (var elem in arr)
            {
                Console.Write($"{elem} ");
            }
            Console.Write("\n\n");
        }

        public int GetAt(int index)
        {
            return arr[index];
        }

        public int GetLength()
        {
            return arr.Length;
        }

        public void SetAt(int elem, int index)
        {
            arr[index] = elem;
        }

        public int FindMax()
        {
            int max = 0;
            foreach (int elem in arr)
            {
                if (elem > max)
                {
                    max = elem;
                }
            }
            return max;
        }

        public int FindMin()
        {
            int min = arr[0];
            foreach (int elem in arr)
            {
                if (elem < min)
                {
                    min = elem;
                }
            }
            return min;
        }

        public int TotalSum()
        {
            int sum = 0;
            foreach (int elem in arr)
            {
                sum += elem;
            }
            return sum;
        }

        public int TotalProduct()
        {
            int result = arr[0];
            foreach (int elem in arr)
            {
                result *= elem;
            }
            return result / arr[0];
        }

        public int SumEvenNum()
        {
            int result = 0;
            foreach(int elem in arr)
            {
                if(elem%2 == 0)
                {
                    result += elem;
                }
            }
            return result;
        }

    }
}

