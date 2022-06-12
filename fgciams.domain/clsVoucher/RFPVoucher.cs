using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsVoucher
{
   public class VoucherRFPModel
    {
        public long Id { get; set; }
        public long VoucherId { get; set; }
        public long RequestForPaymentId { get; set; }
        public bool IsActive { get; set; }
        public string RFPControlNumber { get; set; }
        public string VoucherControlNumber { get; set; }
    }
}
