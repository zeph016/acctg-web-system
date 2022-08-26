using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsTermsOfPayment 
{
    public class TermsOfPaymentModel
    {
      public TermsOfPaymentModel()
      {
        Id = 0;
        IsActive = true;
        TermName = "";
        Remarks = "";
      }
      public int Id { get; set; }
      public bool IsActive { get; set; }
      public string TermName { get; set; }
      public string Remarks { get; set; }

    }
}