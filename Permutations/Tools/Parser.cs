using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations.Tools
{
    static class Parser
    {
        public static List<string> ParseSetString(string setString)
        {
            var splitString = setString.Split(',', ';', ' ').ToList();

            return splitString;
        }

        public static List<int> ParseShuffleString(string setString)
        {
            var splitString = setString.Split(',', ';', ' ').ToList();
            var valueSet = splitString.Select(x => Convert.ToInt32(x)).ToList();

            return valueSet;
        }
    }
}
