using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsSubContractorPosition
{
  public class SubContractorPositionModel
  {
    public SubContractorPositionModel()
    {
      Id = 0;
      IsActive = true;
      PositionName = "";
      Remarks = "";
    }
    public Int64 Id { get; set; }
    public bool IsActive { get; set; } 
    public string PositionName { get; set; }
    public string Remarks { get; set; }
  }
}