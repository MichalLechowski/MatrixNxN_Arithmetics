using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class MatrixArithmetics
    {
        public static int[,] Add(int[,] tab)
        {
            int CurrentCell = 0;
            int EdgeCell = 0;
            int Dimension = 0;
            int[,] OutputTab = new int[2, 2];

            Dimension = 0;
            CurrentCell = 0;
            for (int i = 0; i <= (tab.GetLength(1) % 2 == 0 ? tab.GetLength(1) / 2 - 2 : (tab.GetLength(1) / 2) - 1); i++)
            {
                CurrentCell = Dimension + 1;
                EdgeCell = tab.GetLength(0) - Dimension - 2;

                while (CurrentCell <= EdgeCell)
                {
                    OutputTab[1, 1] += tab[CurrentCell, Dimension];

                    CurrentCell++;
                }
                Dimension++;
            }



            CurrentCell = 0;
            for (int i = 0; i <= (tab.GetLength(1) % 2 == 0 ? tab.GetLength(1) / 2 - 2 : (tab.GetLength(1) / 2) - 1); i++)
            {
                CurrentCell = Dimension + 1;
                EdgeCell = tab.GetLength(0) - Dimension - 2;

                while (CurrentCell <= EdgeCell)
                {
                    OutputTab[0, 0] += tab[Dimension, CurrentCell];

                    CurrentCell++;
                }
                Dimension++;
            }



            CurrentCell = 0;
            for (int i = 0; i <= (tab.GetLength(1) % 2 == 0 ? tab.GetLength(1) / 2 - 2 : (tab.GetLength(1) / 2) - 1); i++)
            {
                CurrentCell = Dimension - 1;
                EdgeCell = tab.GetLength(1) - Dimension;

                while (CurrentCell >= EdgeCell)
                {
                    OutputTab[1, 0] += tab[CurrentCell, Dimension];

                    CurrentCell--;
                }
                Dimension--;
            }



            CurrentCell = 0;
            for (int i = 0; i <= (tab.GetLength(1) % 2 == 0 ? tab.GetLength(1) / 2 - 2 : (tab.GetLength(1) / 2) - 1); i++)
            {
                CurrentCell = Dimension - 1;
                EdgeCell = tab.GetLength(1) - Dimension;

                while (CurrentCell >= EdgeCell)
                {
                    OutputTab[0, 1] += tab[Dimension, CurrentCell];

                    CurrentCell--;
                }
                Dimension--;
            }


            return OutputTab;
        }
    }
}