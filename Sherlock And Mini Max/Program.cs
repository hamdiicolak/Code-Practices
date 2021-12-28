using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SherlockAndMiniMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int p = Convert.ToInt32(firstMultipleInput[0]);
            int q = Convert.ToInt32(firstMultipleInput[1]);
            int result = sherlockAndMinimax(arr, p, q);
            Console.WriteLine(result);
        }
        public static int sherlockAndMinimax(List<int> arr, int p, int q)
        {
            int maxValue = 0, maxValueIndex = 0;
            Parallel.For(p, q, i =>
            {
                int minValue = Math.Abs(arr[0] - i);
                for (int j = 1; j < arr.Count; j++)
                {
                    minValue = Math.Min(minValue, Math.Abs(arr[j] - i));
                }
                if (minValue > 0 && minValue > maxValue)
                {
                    maxValue = minValue;
                    maxValueIndex = i;
                }
            });
            return maxValueIndex;
        }
    }
}
