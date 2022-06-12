using fgciams.domain.clsPettyCash;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsPettyCashReport;
using fgciams.domain.clsPettyCashAuditTrail;

namespace fgciams.service.PettyCashServices
{
    public interface IPettyCashService
    {
        Task<PettyCashModel> AddPettyCash(PettyCashModel pettyCash,string token);
        Task<PettyCashModel> UpdatePettyCash(PettyCashModel pettyCash,string token);
        Task<List<PettyCashModel>> LoadPettyCashList(FilterParameter filter,string token);
        Task<PettyCashModel> GetPettyCash(Int64 Id, string token);
        Task<string> GetPettyCashReport(PettyCashModel pettyCash);
        Task<List<PettyCashAuditTrail>> GetPettyCashAuditTrail(Int64 Id, string token);
    }
}