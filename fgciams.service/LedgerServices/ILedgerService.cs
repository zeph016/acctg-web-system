using fgciams.domain.clsBank;
using fgciams.domain.clsCheckLedger;
using fgciams.domain.clsCollection;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsVoucher;

namespace fgciams.service.LedgerServices
{
    public interface ILedgerService
    {
        Task<List<CollectionModel>> GetARLedger(FilterParameter parameter, string token);
        Task<List<BankLedgerModel>> GetBankLedger(FilterParameter parameter, string token);
        Task<List<CollectionModel>> GetAPLegder(FilterParameter parameter, string token);
        Task<List<CollectionModel>> GetProjectLeger(FilterParameter parameter, string token);
        Task<List<CheckLedgerModel>> GetCheckLedger(FilterParameter parameter, string token);
        Task<string> GetAPReport(List<CollectionModel> vDetails);
        Task<string> GetARReport(List<CollectionModel> vDetails);
        Task<string> GetProjectLedgerReport(List<CollectionModel> coll);
        Task<string> GetBankLedgerReport(List<BankLedgerModel> coll);
        Task<string> GetSubConARReport(List<VoucherDetailModel> vDetails);
        Task<string> GetSubConAPReport(List<VoucherDetailModel> vDetails);

    }
}