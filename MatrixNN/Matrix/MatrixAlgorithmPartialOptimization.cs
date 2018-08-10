using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// 1 loop per 2 triangles thanks to transpose. Lots of additinal information required, tho. Too complicated
    /// </summary>
    public class MatrixAlgorithmPartialOptimization
    {
        public static int[,] SumTrianglesValues(int[,] tab)
        {
            int CurrentCell = 0;
            int EdgeCell = 0;
            int[,] OutputTab = new int[2, 2];
            int currentDimension = 0;
            int outputIndexRow = 1;
            int outputIndexCol = 1;

            #region Conditions_for_Left_and_Top_Triangles
            int LeftTopTrianglesConditions_CurrentCellIncrementType = 1;
            int LeftTopTrianglesConditions_DimensionStart = 0;
            int LeftTopTrianglesConditions_StartingCellFunc() => LeftTopTrianglesConditions_DimensionStart + 1;
            int LeftTopTrianglesConditions_EdgeCellFunc() => tab.GetLength(0) - currentDimension - 2;
            #endregion
            #region Conditions_for_Right_and_Bottom_Triangles
            int RightBottomTrianglesConditions_CurrentCellIncrementType = (-1);
            int RightBottomTrianglesConditions_DimensionStart = tab.GetLength(1) - 1;
            int RightBottomTrianglesConditions_StartingCellFunc() => RightBottomTrianglesConditions_DimensionStart - 1;
            int RightBottomTrianglesConditions_EdgeCellFunc() => 1 + currentDimension;
            #endregion

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

            for (int i = 0; i < 2; i++)
            {
                for (currentDimension = 0; currentDimension <= (tab.GetLength(1) % 2 == 0 ? tab.GetLength(1) / 2 - 2 : (tab.GetLength(1) / 2) - 1);)
                {
                    CurrentCell = LeftTopTrianglesConditions_StartingCellFunc() + currentDimension;
                    EdgeCell = LeftTopTrianglesConditions_EdgeCellFunc();

                    while (CurrentCell <= EdgeCell)
                    {
                        OutputTab[outputIndexRow, outputIndexCol] += tab[CurrentCell, LeftTopTrianglesConditions_DimensionStart + currentDimension];
                        CurrentCell += LeftTopTrianglesConditions_CurrentCellIncrementType;
                    }
                    currentDimension++;
                }

                outputIndexRow--;
                outputIndexCol--;
                TransposeMatrix(ref tab);
            }

            outputIndexRow = 0;
            outputIndexCol = 1;

            for (int i = 0; i < 2; i++)
            {
                for (currentDimension = 0; currentDimension <= (tab.GetLength(1) % 2 == 0 ? tab.GetLength(1) / 2 - 2 : (tab.GetLength(1) / 2) - 1);)
                {
                    CurrentCell = RightBottomTrianglesConditions_StartingCellFunc() - currentDimension;
                    EdgeCell = RightBottomTrianglesConditions_EdgeCellFunc();

                    while (CurrentCell >= EdgeCell)
                    {
                        OutputTab[outputIndexRow, outputIndexCol] += tab[CurrentCell, RightBottomTrianglesConditions_DimensionStart - currentDimension];

                        CurrentCell += RightBottomTrianglesConditions_CurrentCellIncrementType;
                    }
                    currentDimension++;
                }

                outputIndexRow++;
                outputIndexCol--;
                TransposeMatrix(ref tab);
            }

            return OutputTab;
        }
    }
}