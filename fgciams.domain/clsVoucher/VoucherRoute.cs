using fgciams.domain.clsEnums;

namespace fgciams.domain.clsVoucher
{
    public class VoucherRouteModel : VoucherRouteAuditTrailModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; } = true;
        public Int64 VoucherId { get; set; }
        public DateTime? RouteDate { get; set; } = DateTime.Now;
        public Int64 LocationId { get; set; }
        public Enums.ProjectCategory LocationCategoryId { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime? DateLastFollowUp { get; set; }
        public string  VoucherControlNumber { get; set; } = string.Empty;
        public DateTime VoucherDate { get; set; }
        public List<VoucherModel> VoucherList { get; set; } = new();
    }
}