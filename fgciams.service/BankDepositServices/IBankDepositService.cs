using fgciams.domain.clsBankDeposit;
using fgciams.domain.clsCollection;
using fgciams.domain.clsFilterParameter;

namespace fgciams.service.BankDepositServices
{
    public interface IBankDepositService
    {
        public Task<BankDepositModel> GetBankDeposit(long collectionId, string token);
        public Task<BankDepositModel> AddBankDeposit(BankDepositModel model, string token);
        public Task<BankDepositModel> UpdateBankDeposit(BankDepositModel model, string token);
        public Task<List<BankDepositModel>> GetListOfBankDeposits(FilterParameter param, string token);
        public Task<List<CollectionModel>> GetBankDepositCollections(long bankDepositId, string token);
    }
}