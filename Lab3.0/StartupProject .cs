using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethodsLab2;
using Lab2.OOP;
namespace Lab3._0
{

    public static class StartupProject
    {
        private static List<int> Task1()
        {
            var list= new List<int>();
            int n = 0;
            int mod = 0;
            try
            {
                Console.WriteLine("Input the number of elements in the array: ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input maximum value in the array: ");
                mod = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            list.RandArray(n, mod);
            Console.WriteLine("Array before sorting:");
            list.Print();
            list.BubbleSort();
            Console.WriteLine("Array after sorting:");
            list.Print();
            return list;
        }
        private static void Task2()
        {
            var list = Task1();
            var Prime = new Prime(list.Max());
            Console.WriteLine("Prime numbers are: ");
            for (int i = 1; i < list.Count; i += 2)
            {
                if (i < list.Count)
                    if (Prime.IsPrime(list[i]))
                        Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
        private static void Task3()
        {
            var list = Task1();
            list.RearrangeAlternating();
            Console.WriteLine("Rearranged array: ");
            list.Print();
            list.PutZeroBeforePrime();
            Console.WriteLine("After puting 0 before prime numbers:");
            list.Print();
        }
        public static void Run()
        {
            int option = 1;
            Console.WriteLine("Choose task(1-9):");
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e) { Console.WriteLine(e.Message); }
            switch (option)
            {
                case 1: Console.WriteLine("TASK1\n"); Task1(); break;
                case 2: Console.WriteLine("TASK2\n"); Task2(); break;
                case 3: Console.WriteLine("TASK3\n"); Task3(); break;
            }
            }
    }
}
