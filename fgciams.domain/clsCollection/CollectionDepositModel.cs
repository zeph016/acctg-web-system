using fgciams.domain.clsBankDeposit;
namespace fgciams.domain.clsCollection
{
    public class CollectionDepositModel : BankDepositModel
    {
        public Int64 Id { get; set; }
        public Int64 CollectionId { get; set; }
        public Int64 BankDepositId { get; set; }
        public bool IsActive { get; set; }
    }
}