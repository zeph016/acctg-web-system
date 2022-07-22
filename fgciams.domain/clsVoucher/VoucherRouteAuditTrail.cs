namespace fgciams.domain.clsVoucher
{
    public class VoucherRouteAuditTrailModel
    {
        public Int64 Id { get; set; }
        public Int64 VoucherRouteId { get; set; }
        public DateTime LogDateTime { get; set; }
        public Int64 UserId { get; set; }
        public string Activity { get; set; } = string.Empty; 
        public string UserName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}