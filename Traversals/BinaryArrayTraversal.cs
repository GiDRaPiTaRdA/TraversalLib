using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalLib
{
    public static class BinaryArrayTraversal
    {

        public static void Traversal<T>(T[,] binaryArray, Action<T, int, int> action)
        {
            for (int x = 0; x < binaryArray.GetLength(0); x++)
            {
                for (int y = 0; y < binaryArray.GetLength(1); y++)
                {
                    action.Invoke(binaryArray[x, y], x, y);
                }
            }
        }

        public static void Traversal<T>(T[,] binaryArray1, T[,] binaryArray2, Action<T, T, int, int> action)
        {
            for (int x = 0; x < binaryArray1.GetLength(0); x++)
            {
                for (int y = 0; y < binaryArray1.GetLength(1); y++)
                {
                    action.Invoke(binaryArray1[x, y], binaryArray2[x, y], x, y);
                }
            }
        }

        public static void Traversal<T>(this T[,] binaryArray, T[,] mask , Action<T[,], Tuple<int,int>> action)
        {
            int maskLengthAxisX = mask.GetLength(0);
            int maskLengthAxisY = mask.GetLength(1);

            int byteStepsAxisX = binaryArray.GetLength(0) - maskLengthAxisX;
            int byteStepsAxisY = binaryArray.GetLength(1) - maskLengthAxisY;

            for (int x = 0; x < byteStepsAxisX; x++)
            {
                for (int y = 0; y < byteStepsAxisY; y++)
                {
                    // Initialization of receptive field
                    var receptiveField = new T[maskLengthAxisX,maskLengthAxisY];

                    for (int mx = 0; mx < byteStepsAxisX; mx++)
                    {
                        for (int my = 0; my < byteStepsAxisY; my++)
                        {
                            receptiveField[mx, my] = binaryArray[x + mx, y + my];
                        }
                    }

                    action.Invoke(receptiveField, new Tuple<int,int>(x, y));
                }
            }
        }

    }
}
