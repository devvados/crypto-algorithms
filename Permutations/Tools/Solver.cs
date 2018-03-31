using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations.Tools
{
    static class Solver
    {
        public static List<int> FindShuffleBySets(List<string> SetA, List<string> SetB)
        {
            List<int> setShuffle = new List<int>();

            foreach (var item in SetA)
            {
                setShuffle.Add(SetB.FindIndex(x => x.Equals(item)) + 1);
            }

            return setShuffle;
        }

        public static List<string> FindSetByShuffle(List<string> SetA, List<int> Shuffle)
        {
            List<string> SetB = new List<string>();

            foreach (var item in Shuffle)
            {
                SetB.Add(SetA[item - 1]);
            }

            return SetB;
        }

        public static void FindTranspositions(IEnumerable<int> SetA)
        {

        }
    }
}
