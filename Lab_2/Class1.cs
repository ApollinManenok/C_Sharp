using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassworkString
{
    class MyString
    {
        //variables
        private String str;

        //methods
        public void EnterString()
        {
            Console.WriteLine("Enter line\n");
            str = Console.ReadLine();
        }

        public void PrintString()
        {
            Console.WriteLine(str);
        }

        static public String ReverseStr(String str)
        {
            StringBuilder revStr = new StringBuilder("", 256);
            int j = 0;
            for (int i = str.Length - 1; i >= 0; --i, ++j)
            {
                revStr.Insert(j, str[i]);
            }
            return revStr.ToString();
        }

        static public int NumSum(int num)
        {
            int result = 0;
            while(num>0)
            {
                result += num % 10;
                num /= 10;
            }
            return result;
        }

        static public int CountSymbolSequence(string strToCount)
        {
            int counter = 1;
            int tempCounter = 1;
            for (int i = 0; i < strToCount.Length - 1; ++i)
            {
                if (strToCount[i] < strToCount[i + 1] || strToCount[i] == strToCount[i + 1])
                {
                    ++tempCounter;
                }
                else
                {
                    counter = counter > tempCounter ? counter : tempCounter;
                    tempCounter = 1;
                }
            }
            counter = counter > tempCounter ? counter : tempCounter;
            return counter;
        }

        public int CountPalindromes()
        {
            int count = 0;
            string[] strArray = str.Split();
            String strReverse = ReverseStr(str);
            string[] strArrayReverse = strReverse.ToString().Split();
            int j = strArrayReverse.Length-1;
            for (int i =0; i<strArray.Length; ++i, --j)
            {
                if(strArray[i] == strArrayReverse[j])
                {
                    ++count;
                }
            }
            Console.WriteLine($"There is(are) {count} palindrome(s) in this line.");
            return count;
        }

        public void OddWordFirstToUpper()
        {
            string[] strArray = str.Split();
            StringBuilder tempStr = new StringBuilder("", 256);
            for (int i = 0; i < strArray.Length; ++i)
            {                
                if (strArray[i].Length%2 != 0)
                {
                    char[] charArray = strArray[i].ToCharArray();
                    charArray[0] =(char)(charArray[0] - 32);
                    strArray[i] = new String(charArray);
                }
                if(i!=0)
                {
                    tempStr.Insert(tempStr.Length, " ");
                }
                tempStr.Insert(tempStr.Length, strArray[i]);
            }
            str = tempStr.ToString();
        }

        public void SortIncreaseSymbolSequence()
        {
            string[] strArray = str.Split();
            StringBuilder tempStr = new StringBuilder("", 256);
            bool counter = true;
            while (counter)
            {
                counter = false;
                int countFirst = CountSymbolSequence(strArray[0]);
                for (int i = 0; i < strArray.Length - 1; ++i)
                {
                    int countSecond = CountSymbolSequence(strArray[i + 1]);
                    if (countFirst > countSecond)
                    {
                        string tempString = strArray[i];
                        strArray[i] = strArray[i + 1];
                        strArray[i + 1] = tempString;
                        counter = true;
                    }
                    else
                    {
                        countFirst = countSecond;
                    }                    
                }
            }
            for (int i = 0; i < strArray.Length; ++i)
            {
                if (i != 0)
                {
                    tempStr.Insert(tempStr.Length, " ");
                }
                tempStr.Insert(tempStr.Length, strArray[i]);
            }
            str = tempStr.ToString();
        }
        
        public void ReverseWords()
        {
            string[] strArray = str.Split();
            StringBuilder tempStr = new StringBuilder("", 256);
            int i = strArray.Length;
            do
            {
                --i;
                if (i != strArray.Length-1)
                {
                    tempStr.Insert(tempStr.Length, " ");
                }
                tempStr.Insert(tempStr.Length, strArray[i]);
            } while (i != 0);
            str = tempStr.ToString();
        }

        public void SortIncreaseInt() // From lower to bigger
        {
            string[] strArray = str.Split();
            StringBuilder tempStr = new StringBuilder("", 256);
            int[] intStr = new int[strArray.Length];
            int exceptions = 0;
            for (int i = 0; i < strArray.Length; ++i)
            {
                try
                {
                    intStr.SetValue(Convert.ToInt32(strArray[i]), i - exceptions);
                }
                catch (Exception)
                {
                    Console.WriteLine("\nString contains not numeral value!\nThis value would be ignored and replaced by zero in final string.\n");
                    ++exceptions;
                }
            }

            bool counter = true;
            while(counter)
            {
                counter = false;
                for (int i = 0; i < intStr.Length - 1; ++i)
                {
                    if (NumSum(intStr[i]) > NumSum(intStr[i + 1]))
                    {
                        int tempInt = intStr[i];
                        intStr[i] = intStr[i + 1];
                        intStr[i + 1] = tempInt;
                        counter = true;
                    }
                    else if (NumSum(intStr[i]) == NumSum(intStr[i + 1]))
                    {
                        if (intStr[i] > intStr[i + 1])
                        {
                            int tempInt = intStr[i];
                            intStr[i] = intStr[i + 1];
                            intStr[i + 1] = tempInt;
                            counter = true;
                        }
                    }
                }
            }

            for (int i = 0; i < intStr.Length; ++i)
            {
                if (i != 0)
                {
                    tempStr.Insert(tempStr.Length, " ");
                }
                tempStr.Insert(tempStr.Length, intStr[i].ToString());
            }
            str = tempStr.ToString();
        }

        public void SortDecreaseInt() // From bigger to lower
        {
            string[] strArray = str.Split();
            StringBuilder tempStr = new StringBuilder("", 256);
            int[] intStr = new int[strArray.Length];
            int exceptions = 0;
            for (int i = 0; i < strArray.Length; ++i)
            {
                try
                {
                    intStr.SetValue(Convert.ToInt32(strArray[i]), i - exceptions);
                }
                catch (Exception)
                {
                    Console.WriteLine("\nString contains not numeral value!\nThis value would be ignored and replaced by zero in final string.\n");
                    ++exceptions;
                }
            }

            bool counter = true;
            while (counter)
            {
                counter = false;
                for (int i = 0; i < intStr.Length - 1; ++i)
                {
                    if (NumSum(intStr[i]) < NumSum(intStr[i + 1]))
                    {
                        int tempInt = intStr[i];
                        intStr[i] = intStr[i + 1];
                        intStr[i + 1] = tempInt;
                        counter = true;
                    }
                    else if (NumSum(intStr[i]) == NumSum(intStr[i + 1]))
                    {
                        if(intStr[i] < intStr[i+1])
                        {
                            int tempInt = intStr[i];
                            intStr[i] = intStr[i + 1];
                            intStr[i + 1] = tempInt;
                            counter = true;
                        }
                    }
                }
            }

            for (int i = 0; i < intStr.Length; ++i)
            {
                if (i != 0)
                {
                    tempStr.Insert(tempStr.Length, " ");
                }
                tempStr.Insert(tempStr.Length, intStr[i].ToString());
            }
            str = tempStr.ToString();
        }
    }
}
