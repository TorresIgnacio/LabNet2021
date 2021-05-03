using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.EF.Data;

namespace TP5.EF.LOGIC
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
