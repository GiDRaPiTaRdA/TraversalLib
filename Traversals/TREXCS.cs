using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalLib
{
    /// <summary>
    /// Traversal Recursive Extention Class[Single]
    /// </summary>
    public static class TREXCS
    {
        /// <summary>
        /// Traversal of single array extention
        /// </summary>
        public static void Traversal(this Array array, Action<object, int[]> act)
        {
            int rank = array.Rank;
            int penatration = 0;
            int[] coords = new int[rank];

            Recursive(penatration, array, act, coords, rank);
        }

        /// <summary>
        /// Traversal of single array
        /// </summary>
        public static void RecursiveTraversal(Array ienumerable, Action<object, int[]> act)
        {
            ienumerable.Traversal(act);
        }

        #region BlackMagic
        /// <summary>
        /// Recursive method
        /// </summary>
        private static void Recursive(int penatration, Array binaryArray, Action<object, int[]> act, int[] coords, int rank)
        {
            penatration++;

            for (int i = 0; i < binaryArray.GetLength(penatration - 1); i++)
            {
                coords[penatration - 1] = i;

                if (penatration < rank)
                {
                    Recursive(penatration, binaryArray, act, coords, rank);
                }
                else
                {
                    act(binaryArray.GetValue(coords), coords);
                }
            }

            penatration--;

        }
        #endregion

    }
}
