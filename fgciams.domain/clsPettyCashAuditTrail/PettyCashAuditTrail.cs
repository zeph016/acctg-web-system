using fgciams.domain.clsEnums;

namespace fgciams.domain.clsPettyCashAuditTrail
{
    public class PettyCashAuditTrail
    {
        public Int64 Id { get; set; }
        public Int64 PettyCashId { get; set; }
        public DateTime LogDateTime { get; set; }
        public Int64 UserId { get; set; }
        public string Activity { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public Enums.AccountingStatusEnumCategory StatusEnumCategoryId { get; set; }
    }
}