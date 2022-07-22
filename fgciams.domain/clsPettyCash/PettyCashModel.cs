using fgciams.domain.clsEnums;
using fgciams.domain.clsPettyCashAuditTrail;

namespace fgciams.domain.clsPettyCash
{
    public class PettyCashModel : PettyCashAuditTrail
    {
        public PettyCashModel()
        {
            ControlCount = 0;
            ControlNumber = "";
            MRARTypeId = Enums.MRARType.None;
        }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? RequestDate { get; set; }
        public Int64 PayeeId { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public Int64 StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string Particular { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string PayeeName { get; set; } = string.Empty;
        public string PayeeDepartment { get; set; } = string.Empty;
        public string PayeeSection { get; set; } = string.Empty;
        public string PayeePosition { get; set; } = string.Empty;
        public DateTime? DateNeeded { get; set; }
        public Int64 RequestedById { get; set; }
        public string RequestedByName { get; set; } = string.Empty;
        public string RequestedByDepartment { get; set; } = string.Empty;
        public string RequestedBySection { get; set; } = string.Empty;
        public string RequestedByPosition { get; set; } = string.Empty;
        public Int64 ReceivedById { get; set; }
        public string ReceivedByName { get; set; } = string.Empty;
        public string ReceivedByDepartment { get; set; } = string.Empty;
        public string ReceivedBySection { get; set; } = string.Empty;
        public string ReceivedByPosition { get; set; } = string.Empty;
        public Int64 ApprovedById { get; set; }
        public string ApprovedByName { get; set; } = string.Empty;
        public string ApprovedByDepartment { get; set; } = string.Empty;
        public string ApprovedBySection { get; set; } = string.Empty;
        public string ApprovedByPosition { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string ControlNumber { get; set; } = string.Empty;
        public int ControlCount { get; set; }
        public Enums.MRARType MRARTypeId { get; set; }
        public Enums.AccountingStatusEnumCategory statusCategoryId { get; set; }
        public bool ShowReport {get; set;}
        ////response code
        public HttpResponseMessage responseMessage { get; set; } = new();
    }
}