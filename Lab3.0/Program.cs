using System.Collections.Generic;
using Lab3ShowCase;
namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var set = new Dictionary<int, int>();
            set.Add(1, 2);
            set.Add(2, 3);
            set.Add(3, 4);
            foreach(var item in set )
            {
                Console.WriteLine(item);
            }
            
        }
    }
}