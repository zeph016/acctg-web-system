using fgciams.domain.clsAccessLevel;
using fgciams.domain.clsEnums;
using fgciams.domain.clsLiquidation;
using fgciams.domain.clsPettyCash;
using fgciams.domain.clsRequest;
using fgciams.domain.clsVoucher;
using fgciams.Pages.ConfigurationPages.AccessLevelPage;
using fgciams.service.AccessLevelServices;
using MudBlazor;

namespace fgciams.Common
{
    public class Privileges
    {
        private static List<ModuleAssigmentModel> modules = new();
        private static List<FunctionAssigmentModel> functions = new();
        public static async Task<Privileges> InitializedClass(IAccessLevelService alService)
        {
            modules = await alService.GetActiveModules(GlobalClass.currentUserAccount.AccessLevel, GlobalClass.token);
            return new Privileges();
        }
        public static async Task<Privileges> GetAllowedFunctions(IAccessLevelService alService, Enums.AISModules module)
        {
            functions = await alService.GetActiveFuctions(GlobalClass.currentUserAccount.AccessLevel , module, GlobalClass.token);
            return new Privileges();
        }
        #region Signal R
        public static async Task<Privileges> InitializedClass(IAccessLevelService alService, Enums.AISUserAccessLevel accessLevel)
        {
            modules = await alService.GetActiveModules(accessLevel, GlobalClass.token);
            return new Privileges();
        }
        public static async Task<Privileges> GetAllowedFunctions(IAccessLevelService alService, Enums.AISModules module,Enums.AISUserAccessLevel accessLevel)
        {
            functions = await alService.GetActiveFuctions(accessLevel , module, GlobalClass.token);
            return new Privileges();
        }
        #endregion
        public static bool IsPrivilegeModule(Enums.AISModules module)
        {
            return modules.Any( m => m.ModuleId == module);
        }
        public static bool isPrivilegeFunction(Enums.AISModuleFunctions function)
        {
            return functions.Any( f => f.ModuleFunctionId == function);
        }
        public static bool isAllowEdit(PettyCashModel PettyCashModel)
        {
            if(isPrivilegeFunction(Enums.AISModuleFunctions.Edit))
            {
                return true;
            }
            else if(isPrivilegeFunction(Enums.AISModuleFunctions.EditDepartment))
            {
                if(PettyCashModel.RequestedByDepartment == GlobalClass.currentUserAccount.DepartmentName)
                    return true;
                else
                    return false;
            }
            else if(isPrivilegeFunction(Enums.AISModuleFunctions.EditOwn))
            {
                if(PettyCashModel.RequestedById == GlobalClass.currentUserAccount.EmployeeId)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static bool isAllowEdit(LiquidationModel liquidationModel)
        {
            if(isPrivilegeFunction(Enums.AISModuleFunctions.Edit))
            {
                return true;
            }
            else if(isPrivilegeFunction(Enums.AISModuleFunctions.EditDepartment))
            {
                if(liquidationModel.PreparedByDepartment == GlobalClass.currentUserAccount.DepartmentName)
                    return true;
                else
                    return false;
            }
            else if(isPrivilegeFunction(Enums.AISModuleFunctions.EditOwn))
            {
                if(liquidationModel.PreparedById == GlobalClass.currentUserAccount.EmployeeId)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static bool isAllowEdit(RequestForPaymentModel rfpModel)
        {
            if(isPrivilegeFunction(Enums.AISModuleFunctions.Edit))
            {
                return true;
            }
            else if(isPrivilegeFunction(Enums.AISModuleFunctions.EditDepartment))
            {
                if(rfpModel.PreparedByDepartment == GlobalClass.currentUserAccount.DepartmentName)
                    return true;
                else
                    return false;
            }
            //  ||rfpModel.RequestedById == GlobalClass.currentUserAccount.EmployeeId
            else if(isPrivilegeFunction(Enums.AISModuleFunctions.EditOwn))
            {
                if(rfpModel.PreparedById == GlobalClass.currentUserAccount.EmployeeId)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static bool isAllowEdit(VoucherModel voucher)
        {
            if(isPrivilegeFunction(Enums.AISModuleFunctions.Edit))
            {
                return true;
            }
            else if(isPrivilegeFunction(Enums.AISModuleFunctions.EditDepartment))
            {
                if(voucher.PreparedByDepartment == GlobalClass.currentUserAccount.DepartmentName)
                    return true;
                else
                    return false;
            }
            else if(isPrivilegeFunction(Enums.AISModuleFunctions.EditOwn))
            {
                if(voucher.PreparedById == GlobalClass.currentUserAccount.EmployeeId)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}