using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsVoucher
{
    public class VoucherAuditTrailModel
    {
        public Int64 Id { get; set; }
        public Int64 VoucherId { get; set; }
        public DateTime LogDateTime { get; set; }
        public Int64 UserId { get; set; }
        public string Activity { get; set; }
        public string UserName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
    }
}
