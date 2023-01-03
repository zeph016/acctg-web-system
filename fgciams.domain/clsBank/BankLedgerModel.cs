namespace fgciams.domain.clsBank
{
    public class BankLedgerModel
    {
        public Int64 Id { get; set; }
        public Int64 BankId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string ShortcutName { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public string BankAccountName { get; set; } = string.Empty;
        //public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string Code { get; set; } = string.Empty;
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal RunningBalance { get; set; }
        public decimal BankBalance { get; set; }
        public decimal CheckInTransit { get; set; }
        public decimal BookBalance
        {
            get
            {
                return BankBalance - CheckInTransit;
            }
        }
        public decimal PDCDue { get; set; }
        public decimal Balance
        {
            get
            {
                return Credit - Debit;
            }
        }
    }
    
}