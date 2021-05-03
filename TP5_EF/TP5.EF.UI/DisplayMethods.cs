using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5.EF.UI
{
    class DisplayMethods
    {
        public static int MaxLength(List<string> list)
        {
            string longest;
            longest = list.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
            return longest.Length;
        }
        
    }
}
