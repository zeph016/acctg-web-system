using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.bll
{
    public static class VoucherComputation
    {
        public static decimal ComputeVAT(decimal grossIncome = 0, decimal vATValue = 0)
        {
            decimal _vatpercent = vATValue / 100;
            decimal _vatinput = 1 + _vatpercent;
            return (grossIncome / _vatinput) * _vatpercent;
        }

        public static decimal ComputeVATAmount(decimal grossIncome = 0, decimal vatOutput = 0)
        {
            return (grossIncome - vatOutput);
        }

        public static decimal ComputeWithholdingTax(decimal vATNet = 0, decimal taxvalue = 0)
        {
            return vATNet * (taxvalue / 100);
        }

        public static decimal ComputeTotalAmount(decimal grossIncome = 0, decimal withholdingTax = 0)
        {
            return (grossIncome - withholdingTax);
        }
    }
}
