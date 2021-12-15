using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPInterface
{
    public enum TypeOperation
    {
        credit,
        debit
    }

    public class Operation
    {
        public decimal Montant { get; set; }

        public TypeOperation Type { get; set; }
    }
}
