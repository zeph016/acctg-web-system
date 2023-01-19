using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsVoucher
{
   public class VoucherRFPModel
    {
        public long Id { get; set; }
        public long VoucherId { get; set; }
        public long RequestForPaymentId { get; set; }
        public bool IsActive { get; set; }
        public string RFPControlNumber { get; set; } = string.Empty;
        public string VoucherControlNumber { get; set; } = string.Empty;
        public decimal Amount {get; set;}
        public decimal TotalAmount { get; set; }
        public long payeeId { get; set; }
        public Enums.ProjectCategory payeeCategory { get; set; }
        public Enums.RFPDetailTypeId rfpType;
        public string PayeeName = String.Empty;
        public string Remarks = String.Empty;
    }
}
