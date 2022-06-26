using System.Net;
using System.Net.Http.Headers;
using fgciams.domain.clsAccountType;
using fgciams.domain.common;

namespace fgciams.service.AccountTypeServices
{
    public class AccountTypeService : IAccountTypeService
    {
        #region Constructor
        public AccountTypeService(HttpClient client)
        {
            _client = client;
        }
        #endregion
        #region Properties
        private readonly HttpClient _client;
        private AccountTypeModel accountTypeModel;
        private List<AccountTypeModel> listOfAccountType;
        #endregion
        #region Methods
        #region Add
        public async Task<AccountTypeModel> AddAccountType(AccountTypeModel accountType, string token)
        {
            try
            {
                accountTypeModel = new();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("account-type", accountType);
                if (responseMessage.IsSuccessStatusCode)
                    accountTypeModel = await responseMessage.Content.ReadAsAsync<AccountTypeModel>();
                else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                string errorContent = await responseMessage.Content.ReadAsStringAsync();
                if(errorContent.Contains("UniqueAccountingStatus"))
                    throw HttpException.HttpExceptionMessage(accountType.TypeName);
                else
                    throw HttpException.HttpErrorMessage(errorContent);
                }
                return accountTypeModel;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                throw;
            }
        }
        #endregion
        #region Get
        public async Task<AccountTypeModel> GetAccountType(long Id, string token)
        {
            try
            {
                accountTypeModel = new();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("account-type/"+Id);
                if (responseMessage.IsSuccessStatusCode)
                    accountTypeModel = await responseMessage.Content.ReadAsAsync<AccountTypeModel>();
                return accountTypeModel;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                throw;
            }
        }
        #endregion
        #region Load List
        public async Task<List<AccountTypeModel>> LoadAccountType(string token)
        {
            try
            {
                listOfAccountType = new();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("account-type/list/");
                if (responseMessage.IsSuccessStatusCode)
                    listOfAccountType = await responseMessage.Content.ReadAsAsync<List<AccountTypeModel>>();
                return listOfAccountType;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                throw;
            }
        }
        #endregion
        #region Update
        public async Task<AccountTypeModel> UpdateAccountType(AccountTypeModel accountType, string token)
        {
            try
            {
                accountTypeModel = new();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("account-type",accountType);
                if (responseMessage.IsSuccessStatusCode)
                    accountTypeModel = await responseMessage.Content.ReadAsAsync<AccountTypeModel>();
                return accountTypeModel;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                throw;
            }
        }
        #endregion
        #endregion
    }
}