using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.EF.LOGIC;

namespace TP5.EF.UI
{
    class DisplayMethods
    {
        public List<int> GetPaddings(List<CustomersBasicInfo> list)
        {
            string longestContact, longestCompany, longestCountry;
            longestContact = list.Aggregate("", (max, cur) => max.Length > cur.contactName.ToString().Length ? max : cur.contactName.ToString());
            longestCompany = list.Aggregate("", (max, cur) => max.Length > cur.companyName.ToString().Length ? max : cur.companyName.ToString());
            longestCountry = list.Aggregate("", (max, cur) => max.Length > cur.country.ToString().Length ? max : cur.country.ToString());
            var paddings = new List<int> { longestContact.Length, longestCompany.Length, longestCountry.Length };
            return paddings;
        }
        
    }
}
