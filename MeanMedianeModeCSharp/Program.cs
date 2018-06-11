using System;
using System.Linq;
using System.Collections.Generic;

namespace MeanMedianModeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArray = new[]
            {
                 73429, 38120, 51135, 67060, 64630, 11735, 14216, 99233, 14470, 4978
            };
            var result = calculate(inputArray);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static double[] calculate(int[] inputArray)
        {
            int maxCount = 0;
            int mod = 0;
            int medTop = 0;
            int medBottom = 0;
            int sum = 0;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = i; j < inputArray.Length; j++)
                {
                    if (inputArray[j] < inputArray[i])
                    {
                        var buf = inputArray[j];
                        inputArray[j] = inputArray[i];
                        inputArray[i] = buf;
                    }
                }
                sum += inputArray[i];
                var index = (i + 1) / 2;
                var indexTop = i / 2;
                medBottom = inputArray[index];
                medTop = inputArray[indexTop];

                int val = 0;
                dict[inputArray[i]] = dict.TryGetValue(inputArray[i], out val) ? val + 1 : 1;
                if (dict[inputArray[i]] > maxCount)
                {
                    mod = inputArray[i];
                    maxCount = dict[inputArray[i]];
                }
            }
            return new double[] { (double)sum / inputArray.Length, (double)(medTop + medBottom) / 2, mod };
        }
    }

    
}
