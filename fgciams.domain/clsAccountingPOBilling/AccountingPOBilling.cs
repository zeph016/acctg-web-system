using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsAccountingPOBilling
{
    public class AccountingPOBillingModel
    {
        public Int64 POBillingId { get; set; }
        public string ControlNumber { get; set; } = string.Empty;
        public DateTime BillingDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PreparedByName { get; set; } = string.Empty;
        public string Supplier { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
    }
}
