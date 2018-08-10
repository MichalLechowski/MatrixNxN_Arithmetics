using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// One method to count all 4 triangles. Always count left triangle, the others by moving triangles
    /// using transpose and mirroring the matrix by diagonal. No additional information required
    /// except proper indexes for values in output 2x2 matrix.
    /// </summary>
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
            
            //transpose matrix method
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
            
            //mirror matrix by diagonal
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

            //always counts left triangle:
            //1st - the way the matrix is by default which means count left triangle
            //2nd - transpose matrix which means count upper triangle
            //go back to default matrix form
            //3th - mirror matrix by diagonal which means count right triangle
            //4th - transpose mirrored matrix which means count bottom triangle
            //put calculated values inside proper cells in an output matrix
            //end
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

                if (outputIndexCol == -1 && outputIndexRow == -1) //viable: IndexCol < 0, one parameter check's enough
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