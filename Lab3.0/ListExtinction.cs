using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lab2.OOP;
namespace ExtensionMethodsLab2
{
    public static class ListExtinction
    {
        public static bool BinarySearch<T>(this List<T> arr, int l, int r, T key) where T : IComparable
        {

            if (r >= l && arr.Count != 0)
            {
                int mid = l + (r - l) / 2;
                if (mid >= arr.Count)
                    return false;
                if (key.CompareTo(arr[mid]) == 0)
                    return true;

                if (key.CompareTo(arr[mid]) < 0)
                    return BinarySearch(arr, l, mid - 1, key);

                return BinarySearch(arr, mid + 1, r, key);
            }
            return false;
        }
        public static void Swap<T>(this List<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        public static void BubbleSort<T>(this List<T> arr) where T : IComparable<T>
        {
            int n = arr.Count;
            for(int i = 0; i < n - 1; i++)
            {
                for(int j = i + 1;j < n; j++)
                {
                    if (arr[j].CompareTo(arr[i]) < 0)
                    {
                        arr.Swap(j, i);
                    }
                }
            }        
        }
        public static void RandArray(this List<int> arr, int n)
        {
            var rand = new Random();
            for(int i = 0;i < n; i++)
            {
                arr.Add(rand.Next(1000));
            }
        }
        public static void RandArray(this List<int> arr, int n, int mod)
        {
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                arr.Add(rand.Next(mod));
            }
        }
        public static void Print<T>(this List<T> arr)
        {
            foreach (T item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public static void RearrangeAlternating(this List<int> list)
        {
            int even = 0;
            int odd = 1;
            int n = list.Count;

            while (even < n && odd < n)
            {
                while (even < n && list[even] % 2 == 0)
                {
                    even += 2;
                }

                while (odd < n && list[odd] % 2 != 0)
                {
                    odd += 2;
                }

                if (even < n && odd < n)
                {
                    int temp = list[even];
                    list[even] = list[odd];
                    list[odd] = temp;
                }
            }
        }
        public static void PutZeroBeforePrime(this List<int> list)
        {
            var n = list.Count;
            var Prime = new Prime(list.Max());
            for(int i = 0;i < n;i++)
            {
                if (Prime.IsPrime(list[i]) && i != 0)
                {
                    list[i - 1] = 0;
                }
            }
        }
        public static List<int> FindTriangleNumbers(this List<int> list)
        {
            list.Sort();
            var res = new List<int>();
            int t = 1;
            int i = 1;
            while (t <= list[list.Count - 1])
            {
                int index = list.BinarySearch(t);
                if (index >= 0 && index < list.Count && list[index] == t)
                {
                    res.Add(t);
                }
                i++;
                t = (i * (i + 1)) / 2;
            }
            return res;
        }
        public static void GetRand(this List<int> list)
        {
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
        }
        public static void Input(this List<int> list, int n)
        {
            for(int i = 0;i < n; i++)
            {
                try
                {
                    list.Add(Int32.Parse(Console.ReadLine()));
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void GetRand(this List<List<int>> arr, int rows, int columns, int mod)
        {
            var rand = new Random();
            var tmp = new List<int>();
            for (int i = 0; i < rows; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < columns; j++)
                {
                    row.Add(rand.Next(mod));
                }
                arr.Add(row);
            }
        }
        public static void Print<T>(this List<List<T>> arr)
        {
            foreach (var i in arr)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

        }
        public static int Sum<T>(this List<List<int>> arr)
        {
            int sum = 0;
            for (var i = 0; i < arr.Count; i++)
            {
                for (var j = 0; j < arr[i].Count; j++)
                {
                    sum += arr[i][j];
                }
            }
            return sum;
        }
        public static int MinSumRow(this List<List<int>> arr)
        {
            int indx = -1;
            int minSum = int.MaxValue;
            for (var i = 0; i < arr.Count; i++)
            {
                var sum = 0;
                for (var j = 0; j < arr[i].Count; j++)
                {
                    sum += arr[i][j];
                }
                if(sum < minSum)
                {
                    minSum = sum;
                    indx = i;
                }
            }
            return indx;
        }
        public static int MaxSumRow(this List<List<int>> arr)
        {
            int indx = -1;
            int maxSum = -1;
            for (var i = 0; i < arr.Count; i++)
            {
                var sum = 0;
                for (var j = 0; j < arr[i].Count; j++)
                {
                    sum += arr[i][j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    indx = i;
                }
            }
            return indx;
        }
        public static void DeleteEmptyRow(this List<List<int>> arr)
        {
            for (var i = 0; i < arr.Count; i++)
            {
                var sum = 0;
                for (var j = 0; j < arr[i].Count; j++)
                {
                    sum += arr[i][j];
                }
                if (sum == 0)
                {
                    arr.RemoveAt(i);
                    i--;
                }
            }
        }
        private static void Swap<T>(this List<List<T>> arr, int i,int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
        public static void SortRowsBySum(this List<List<int>> arr)
        {
            var RowSum = new List<int>(arr.Count);
            foreach(var i in arr)
            {
                int sum = 0;
                foreach(var j in i)
                {
                    sum += j;
                }
                RowSum.Add(sum);
            }
            //RowSum.Print();
            for(int i = 0;i < arr.Count; i++)
            {
                for(int j = i + 1;j < arr.Count; j++)
                {
                    if (RowSum[i] > RowSum[j])
                    {
                        arr.Swap(i, j);
                        RowSum.Swap(i, j);
                    }
                }
            }
        }
    }
}
