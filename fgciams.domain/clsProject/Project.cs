using fgciams.domain.clsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsProject
{
    public class Project
    {
        public Int64 ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectNameFormat { get 
        {
            return (ProjectName != null ? ProjectName.Length > 30 ? ProjectName.Substring(0,15)+"...":ProjectName:"");
        } set{} }
        public Enums.ProjectCategory ProjectCategoryId { get; set; }
        public Enums.ProjectCategory ProjectCategory { get; set; }
        public string Location { get; set; } = default!;
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public string ActualEndDate { get; set; } = default!;
        public DateTime? EndDate
        {
            get
            {
                if (String.IsNullOrEmpty(ActualEndDate))
                    return null;
                else
                    return Convert.ToDateTime(ActualEndDate);
            }
        }
        public string ProjectStatus { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public Int64 SubLedgerId { get; set; }
        public Enums.ProjectCategory SubLedgerCategoryId { get; set; }
        public string SubLedgerName { get; set; } = String.Empty;
        public Int64 scopeOfWorkId {get;set;}
        public string scopeOfWork {get;set;} = String.Empty;
        public decimal contractAmount {get;set;} = 0.00m;
        public string subContractorName {get;set;} = String.Empty;

    }
}
