using fgciams.domain.clsDebit;
using fgciams.domain.clsFilterParameter;

namespace fgciams.service.DebitServices
{
    public interface  IDebitService
    {
        Task<List<DebitModel>> GetDebits(FilterParameter param, string token);
        Task<DebitModel> SaveDebit(DebitModel debit, string token);
        Task<DebitModel> UpdateDebit(DebitModel debit, string token);
        Task<List<DebitAuditTrailModel>> DebitAuditTrail(long ID, string token);
        Task<int> DebitListRowCount(FilterParameter param, string token);
    }
}