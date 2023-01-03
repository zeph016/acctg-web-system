using fgciams.domain.clsEnums;

namespace fgciams.domain.clsCheckLedger
{
    public class CheckLedgerModel
    {
        public Int64 Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ControlNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public Int64 PayeeId { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public string PayeeName { get; set; } = string.Empty;
        public Int64 BankId { get; set; }
        public Int64 AccountingStatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string CheckNo { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string BankName { get; set; } = string.Empty;
        public decimal RunningBalance { get; set; }
    }
}