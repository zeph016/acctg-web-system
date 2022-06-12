using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsRequestForPaymentAuditTrail
{
    public class RequestForPaymentAuditTrailModel
    {
      public RequestForPaymentAuditTrailModel()
      {
        Id= 0;
        RequestForPaymentId = 0;
        UserName = "";
      }
        public Int64 Id { get; set; }
        public Int64 RequestForPaymentId { get; set; }
        public DateTime LogDateTime { get; set; }
        public string Activity { get; set; } = string.Empty;
        public Int64 UserId { get; set; }
        public string UserName {get; set;}
    }
}
