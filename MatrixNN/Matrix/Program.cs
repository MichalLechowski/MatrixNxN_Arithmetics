using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] testTab = new int[,]
            {
                {100 , 2   , 3   , 4   , 100},
                {3   , 100 , 5   , 100 , 7  },
                {4   , 6   , 100 , 8   , 6  },
                {5   , 100 , 7   , 100 , 5  },
                {100 , 6   , 5   , 4   , 100}
            };

            int[,] output = MatrixAlgorithmFinalOptimization.SumTrianglesValues(testTab);

            for (int i = 0; i < output.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    Console.WriteLine(output[j, i]);
                }
            }
        }

    }
}