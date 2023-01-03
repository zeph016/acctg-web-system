using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsVoucher;

namespace fgciams.service.JournalServices
{
    public interface IJournalService
    {
        Task<List<VoucherDetailModel>> GetJournals(FilterParameter param, string token);
        Task<decimal> GetBankBeginningBal(FilterParameter param, string token);
    }
}