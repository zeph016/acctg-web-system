using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsSubcon
{
    public class SubContractorCompanyModel
    {
      public SubContractorCompanyModel()
      {
        Id = 0;
        IsActive = true;
        CompanyName = "";
        ShortcutName = "";
        Remarks = "";
      }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public string CompanyName { get; set; }
        public string ShortcutName {get; set;}
        public string Remarks { get; set; }
    }
}
