using fgciams.domain.clsCollection;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsBankDeposit
{
    public class BankDepositModel : BankDepositAuditTrailModel
    {
        public BankDepositModel()
        {
            CollectionDeposits = new List<CollectionDepositModel>();
        }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public string CollectionControlNumber  { get; set; }
        public Int64 CollectionId { get; set; }
        public DateTime? DepositDate { get; set; } = DateTime.Now;
        public Enums.CollectionPaymentType DepositCategoryId { get; set; }    
        public Int64 BankId { get; set; }
        public string BankName { get; set; }
        public decimal Amount { get; set; }
        public string StatusName { get; set; }
        public DateTime? StatusDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public string Remarks { get; set; }
        public List<CollectionDepositModel> CollectionDeposits { get; set; }
        public string checkNumber {get;set;}
        public bool IsVoid { get; set; }
        public bool IsShowCollections { get; set;}

    }
}