using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            ////140537896 243908675 670291834 923018467 520718469
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            miniMaxSum(arr);
        }
        public static void miniMaxSum(List<int> arr)
        {
            long total = 0, min = 0, max = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                total = 0;
                for (int j = 0; j < arr.Count; j++)
                {
                    if (j != i)
                        total += arr[j];
                }
                if (total > max)
                    max = total;
                if (min == 0)
                    min = total;
                else if(total < min)
                    min = total;
            }
            Console.WriteLine(min + " " + max);
        }
    }
}
