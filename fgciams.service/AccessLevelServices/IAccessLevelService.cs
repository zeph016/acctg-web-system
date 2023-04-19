using fgciams.domain.clsAccessLevel;
using fgciams.domain.clsEnums;

namespace fgciams.service.AccessLevelServices
{
    public interface IAccessLevelService
    {
        Task<ModuleAssigmentModel> AddModuleAssignment(ModuleAssigmentModel module, string token);
        Task<FunctionAssigmentModel> AddFunctionAssignment(FunctionAssigmentModel function, string token);
        Task<ModuleAssigmentModel> UpdateModuleAssignment(ModuleAssigmentModel module, string token);
        Task<FunctionAssigmentModel> UpdateFunctionAssignment(FunctionAssigmentModel function, string token);
        Task<List<ModuleAssigmentModel>> GetActiveModules(Enums.AISUserAccessLevel access, string token);
        Task<List<FunctionAssigmentModel>> GetActiveFuctions(Enums.AISUserAccessLevel access, Enums.AISModules functions, string token);
    }
}