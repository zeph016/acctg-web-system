using fgciams.domain.clsBankDeposit;
using fgciams.domain.clsCollection;
using fgciams.domain.clsFilterParameter;

namespace fgciams.service.CollectionServices
{
    public interface ICollectionService
    {
        Task<List<CollectionModel>> GetCollections(FilterParameter param, string token);
        Task<CollectionModel> SaveCollection(CollectionModel collection,string token);
        Task<CollectionModel> UpdateCollection(CollectionModel collection,string token);
        Task<CollectionModel> GetCollection(long ID,string token);
        Task<decimal> GetCashOnHands(string token);
        Task<List<CollectionAuditTrailModel>> GetAuditTrail(long Id, string token);
        Task<List<BankDepositAuditTrailModel>> GetBankDepositTrail(long Id, string token);
    }
}