using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsTaxCode 
{
    public class TaxCodeModel
    {
      public TaxCodeModel()
      {
        Id = 0;
        Description = "";
        TaxRate = 0;
        ATCInd = "";
        ATCCorp = "";
        IsActive = true;
        Remarks = "";
      }
      public long Id { get; set; }
      public string Description { get; set; }
      public decimal TaxRate { get; set; }
      public string ATCInd { get; set; }
      public string ATCCorp { get; set; }
      public bool IsActive { get; set; }
      public string Remarks {get; set;}
    }
}