using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP6.LINQ.Data;

namespace TP6.LINQ.LOGIC
{
    public class CommonLogic
    {
        protected readonly NorthwindContext context;

        public CommonLogic()
        {
            context = new NorthwindContext();
        }
    }
}
