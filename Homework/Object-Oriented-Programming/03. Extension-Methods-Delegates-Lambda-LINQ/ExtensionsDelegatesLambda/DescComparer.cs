using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsDelegatesLambda
{
    class DescComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(y, x, StringComparison.Ordinal);
        }
    }
}
