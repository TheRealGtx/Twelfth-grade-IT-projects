using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    internal class sortCustomerBySurname : IComparer<Customer<decimal>>
    { 
        public int Compare(Customer<decimal> imp1, Customer<decimal> imp2)
        {
            return string.Compare(imp1.Cognome, imp2.Cognome);
        }
    }
}

