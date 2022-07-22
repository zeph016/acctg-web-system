namespace fgciams.domain.clsCheck
{
    public class CheckVoucherModel
    {
        public Int64 Id { get; set; }
        public Int64 VoucherId { get; set; }
        public Int64 CheckId { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal Amount { get; set; } = 0.0m;
    }
}