using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class MatrixAlgorithmFinalOptimization
    {
        public static int[,] SumTrianglesValues(int[,] tab)
        {
            int CurrentCell = 0;
            int EdgeCell = 0;
            int[,] OutputTab = new int[2, 2];
            int currentDimension = 0;
            int outputIndexRow = 1;
            int outputIndexCol = 1;

            void TransposeMatrix(ref int[,] inputTab)
            {
                int[,] temp = new int[inputTab.GetLength(0), inputTab.GetLength(1)];

                for (int k = 0; k < inputTab.GetLength(0); k++)
                {
                    for (int l = 0; l < inputTab.GetLength(0); l++)
                    {
                        temp[l, k] = inputTab[k, l];
                    }
                }
                inputTab = temp;
            }

            void MirrorMatrixByDiagonal(ref int[,] inputTab)
            {
                int[,] temp = new int[inputTab.GetLength(0), inputTab.GetLength(1)];

                for (int i = 0; i < inputTab.GetLength(0); i++)
                {
                    for (int j = 0; j < inputTab.GetLength(1); j++)
                    {

                        temp[i, j] = inputTab[inputTab.GetLength(0) - 1 - i, inputTab.GetLength(1) - 1 - j];
                    }
                }
                inputTab = temp;
            }

            for (int m = 0; m < 2; m++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (currentDimension = 0; currentDimension <= (tab.GetLength(1) % 2 == 0 ? tab.GetLength(1) / 2 - 2 : (tab.GetLength(1) / 2) - 1);)
                    {
                        CurrentCell = currentDimension + 1;
                        EdgeCell = tab.GetLength(0) - currentDimension - 2;

                        while (CurrentCell <= EdgeCell)
                        {
                            OutputTab[outputIndexRow, outputIndexCol] += tab[CurrentCell, currentDimension];
                            CurrentCell++;
                        }
                        currentDimension++;
                    }

                    if (outputIndexCol == 1 && outputIndexRow == 0)
                    {
                        outputIndexCol = 0;
                        outputIndexRow = 1;
                    }
                    else
                    {
                        outputIndexRow--;
                        outputIndexCol--;
                    }
                    TransposeMatrix(ref tab);
                }

                if (outputIndexCol == -1 && outputIndexRow == -1) //można dać IndexCol < 0 dla uproszczenia
                {
                    outputIndexRow = 0;
                    outputIndexCol = 1;
                }
                MirrorMatrixByDiagonal(ref tab);
            }
            return OutputTab;
        }
    }
}