using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsRFPBillingDocuments
{
    public class RFPBillingDocumentModel
    {
      public RFPBillingDocumentModel()
      {
        Id = 0;
        IsActive = true;
        RequestForPaymentId = 0;
        BillingDocumentId = 0;
        DatetimeLog = DateTime.Now;
        DocumentName = "";
      }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public Int64 RequestForPaymentId { get; set; }
        public Int64 BillingDocumentId { get; set; }
        public DateTime DatetimeLog { get; set; }
        public string DocumentName { get; set; }

    }

}
