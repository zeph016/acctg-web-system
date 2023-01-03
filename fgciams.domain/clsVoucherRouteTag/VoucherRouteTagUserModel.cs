using fgciams.domain.clsEnums;

namespace fgciams.domain.clsVoucherRouteTag
{
    public class VoucherRouteTagUserModel
    {
        
        public Int64 Id { get; set; }
        public Int64 EmployeeId { get; set; }
        public Enums.RouteTag RouteTagId { get; set; }
        public bool IsActive { get; set; }
	    public string EmployeeName { get; set;} = string.Empty;
        public string SectionName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string VoucherRouteTags  { get; set; } = string.Empty;
        public bool isNone 
        { 
            get
            {
                if(VoucherRouteTags.Contains("None"))
                    return true;
                return false;
            } 
            set{ } 
        }
        public bool isBilling
        { 
            get
            {
                if(VoucherRouteTags.Contains("Billing"))
                    return true;
                return false;
            } 
            set{ } 
        }
        public bool isGovernment
        { 
            get
            {
                if(VoucherRouteTags.Contains("Benefits"))
                    return true;
                return false;
            } 
            set{ } 
        }
        public bool isIssuance
        { 
            get
            {
                if(VoucherRouteTags.Contains("Issuance"))
                    return true;
                return false;
            } 
            set{ } 
        }
        public bool isOthers{ 
            get
            {
                if(VoucherRouteTags.Contains("Others"))
                    return true;
                return false;
            } 
            set{ } 
        }

    }
}