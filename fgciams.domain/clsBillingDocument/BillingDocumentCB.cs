using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsBillingDocument
{
    public class BillingDocumentModelCB
    {
        public Int64 Id { get; set; }
        public bool IsChecked { get; set; }
        public Int64 BillingDocumentId {get; set;}
        public BillingDocumentModel selectedBillingDoc = new BillingDocumentModel();
    }
}
