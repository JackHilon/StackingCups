using System;
using System.Collections.Generic;

namespace StackingCups
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stacking Cups
            // https://open.kattis.com/problems/cups 
            // bubble sort over 2 arrays

            int myCounter = EnterCounter();
            string[] colors = new string[myCounter];
            int[] diameters = new int[myCounter];

            string[] temp = new string[2];
            object[] right = new object[2];
            for (int i = 0; i < myCounter; i++)
            {
                temp = Enter2Str();
                right = GetRightObject(temp);
                diameters[i] = (int)right[0];
                colors[i] = (string)right[1];
            }
            var result = BubbleSort(diameters, colors);

            PrintArray(result);
        }

        private static void PrintArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        private static string[] BubbleSort(int[] myDiameters, string[] myColors)
        {
            var colors = myColors;
            var diameters = myDiameters;

            string colorTemp;
            int diameterTemp;
            for (int p = 0; p < diameters.Length; p++)
            {
                for (int i = 1; i < diameters.Length; i++)
                {
                    if(diameters[i]<diameters[i-1])
                    {
                        diameterTemp = diameters[i-1];
                        diameters[i-1] = diameters[i];
                        diameters[i] = diameterTemp;
                        //..............................
                        colorTemp = colors[i - 1];
                        colors[i - 1] = colors[i];
                        colors[i] = colorTemp;
                    }
                } // end inner for
            } // end outer for
            return colors;
        }
        private static object[] GetRightObject(string[] arr)
        {
            string diaStr = arr[0];
            string color = arr[1];
            if(IsNumber(diaStr)==true)
            {
                return MyObjectIs(int.Parse(diaStr), color);
            }
            else
            {
                return MyObjectIs(2 * int.Parse(color), diaStr);
            }
        }
        private static object[] MyObjectIs(int diameter, string color)
        {
            var res = new object[2];
            res[0] = diameter;
            res[1] = color;
            return res;
        }
        private static bool IsNumber(string str)
        {
            int a = 0;
            try
            {
                a = int.Parse(str);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        private static string[] Enter2Str()
        {
            var arr = new string[2];
            try
            {
                arr = Console.ReadLine().Split(' ', 2);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length == 0)
                        throw new ArgumentException();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enter2Str();
            }
            return arr;
        }
        private static int EnterCounter()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1)
                    throw new IndexOutOfRangeException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterCounter();
            }
            return a;
        }
    }
}
