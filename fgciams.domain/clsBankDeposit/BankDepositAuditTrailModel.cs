namespace fgciams.domain.clsBankDeposit
{
    public class BankDepositAuditTrailModel
    {
        public Int64 Id { get; set; }
        public Int64 BankDepositId { get; set; }
        public DateTime LogDateTime { get; set; }
        public Int64 UserId { get; set; }
        public string Activity { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public Int64 StatusId { get; set; }
        public DateTime StatusDate { get; set; }
    }
}