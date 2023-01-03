using fgciams.domain.clsEnums;

namespace fgciams.domain.clsCheck
{
    public class CheckAuditTrailModel
    {
        public Int64? Id { get; set; }
        public Int64? StatusId { get; set; }
        public string StatusName { get; set; } = String.Empty;
        public string Activity { get; set; } = String.Empty;
        public DateTime LogDateTime { get; set; }
        public Int64 UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public Enums.AccountingStatusEnumCategory StatusEnumCategoryId { get; set; }
    }
}