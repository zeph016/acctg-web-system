using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsProjectChargingLine
{
    public class ProjectChargingLineModel
    {
      public ProjectChargingLineModel()
      {
        Id = 0;
        IsActive = true;
        ProjectName = "";
        Remarks = "";
      }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public string ProjectName { get; set; }
        public string Remarks { get; set; }
        public Int64 PayeeCategoryId { get; set; }
        public string PayeeCategoryName { get; set; }
    }
}
