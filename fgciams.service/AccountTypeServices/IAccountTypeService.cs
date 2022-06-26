using fgciams.domain.clsAccountType;

namespace fgciams.service.AccountTypeServices
{
    public interface IAccountTypeService
    {
        Task<AccountTypeModel> AddAccountType(AccountTypeModel accountTypeModel, string token);
        Task<AccountTypeModel> UpdateAccountType(AccountTypeModel accountTypeModel, string token);
        Task<List<AccountTypeModel>> LoadAccountType(string token);
        Task<AccountTypeModel> GetAccountType(Int64 Id, string token);
    }
}