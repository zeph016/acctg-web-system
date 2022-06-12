using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsFilterParameter
{
    public class FilterParameter
    {
        public bool isActive {get; set;}
        public bool IsName { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsLookUp {get; set;}
        public bool IsProject {get; set;}
        public string ProjectName {get; set;} = string.Empty;
        public bool IsId {get; set;}
        public bool IsControlNumber { get; set; }
        public bool IsPayee { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public Int64 PayeeId { get; set; }
        public string PayeeName { get; set; } = string.Empty;
        public string ControlNumber { get; set; } = string.Empty;
        public bool IsDate { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }
}