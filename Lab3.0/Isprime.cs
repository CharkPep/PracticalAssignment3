using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.OOP
{
    public class Prime
    {
        static List<bool> sleeve = new List<bool>();
        public Prime(int MaxValue)
        {
            for (int i = 0;i <= MaxValue + 1; i++)
            {
                sleeve.Add(true);
            }
            sleeve[0] = sleeve[1] = false;
            for (int i = 2; i < sleeve.Count; ++i)
                if (sleeve[i])
                    if ((long)i * (long)i <= sleeve.Count)
			            for (int j = i * i; j < sleeve.Count; j += i)
                            sleeve[j] = false;
        }
        public static bool IsPrime(int index)
        {
            return (sleeve[index] == true);
        }
    }
}
