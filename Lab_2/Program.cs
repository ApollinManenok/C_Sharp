using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassworkString
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString obj1 = new MyString();
            Console.WriteLine("Task 1. Count palindromes");
            obj1.EnterString();
            obj1.CountPalindromes();

            Console.WriteLine("\nTask 2. Set to upper first literal in word with odd amount of literals");
            obj1.EnterString();
            obj1.OddWordFirstToUpper();
            obj1.PrintString();

            Console.WriteLine("\nTask 3. Sort by increase symbol sequence in word");
            obj1.EnterString();
            obj1.SortIncreaseSymbolSequence();
            obj1.PrintString();

            Console.WriteLine("\nTask 4. Reverse words in string");
            obj1.EnterString();
            obj1.ReverseWords();
            obj1.PrintString();

            Console.WriteLine("\nTask 5. Sort by increase numbers in string");
            obj1.EnterString();
            obj1.SortIncreaseInt();
            obj1.PrintString();

            Console.WriteLine("\nTask 5. Sort by decrease numbers in string");
            obj1.EnterString();
            obj1.SortDecreaseInt();
            obj1.PrintString();
        }
    }
}
