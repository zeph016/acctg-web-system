using fgciams.domain.clsCheck;
using fgciams.domain.clsFilterParameter;

namespace fgciams.service.CheckServices
{
    public interface ICheckService
    {
        Task<CheckModel> AddCheck(CheckModel mode,string token);
        Task<List<CheckModel>> LoadCheck(FilterParameter param,string token);
        Task<CheckModel> UpdateCheckStatus(CheckModel check,string token);
        Task<CheckModel> UpdateCheck(CheckModel check,string token);
        Task<string> GetCheckReport(CheckModel model);
    }
}