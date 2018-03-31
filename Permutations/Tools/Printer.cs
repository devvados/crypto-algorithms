using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations.Tools
{
    static class Printer
    {
        public static string PrintSet<T>(List<T> set)
        {
            return string.Join(",", set);
        }
    }
}
