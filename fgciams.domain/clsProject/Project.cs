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
        public string ProjectName { get; set; } = default!;
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
        public string ProjectStatus { get; set; } = default!;
        public string Area { get; set; } = default!;

    }
}
