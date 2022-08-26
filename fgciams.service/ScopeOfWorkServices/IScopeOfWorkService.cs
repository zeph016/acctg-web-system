using fgciams.domain.clsScopeOfWork;

namespace fgciams.service.ScopeOfWorkServices
{
    public interface IScopeOfWorkService
    {
        Task<List<ScopeOfWorkModel>> LoadScopeOfWork(string token);
        Task<ScopeOfWorkModel> AddScopeOfWork(ScopeOfWorkModel model, string token);
        Task<ScopeOfWorkModel> UpdateScopeOfWork(ScopeOfWorkModel model, string token);
    }
}