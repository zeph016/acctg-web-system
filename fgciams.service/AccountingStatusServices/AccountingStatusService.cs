using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using fgciams.domain.clsAccountingStatus;
using Newtonsoft.Json;

namespace fgciams.service.AccountingStatusServices
{
    public class AccountingStatusService : IAccountingStatusService
    {
        #region Properties
        List<AccountingStatusModel> accountingStatusList;
        AccountingStatusModel accountingStatusModel;
        HttpClient client;
        #endregion
        #region Constuctor
        public AccountingStatusService(HttpClient _client)
        {
            this.client = _client;
        }
        #endregion
        #region Methods
        #region Get Accounting Status List
        public async Task<List<AccountingStatusModel>> LoadAccountingStatusList(string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.PostAsJsonAsync("accounting-status/list", "");
                if (httpResponse.IsSuccessStatusCode)
                {
                    accountingStatusList = await httpResponse.Content.ReadAsAsync<List<AccountingStatusModel>>();
                }
                return accountingStatusList.OrderBy(x => x.StatusName).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion
        #region Add Accounting Status
        public async Task<AccountingStatusModel> AddAccountingStatus(AccountingStatusModel accountingStatus, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.PostAsJsonAsync("accounting-status", accountingStatus);
                if (httpResponse.IsSuccessStatusCode)
                {
                    accountingStatusModel = await httpResponse.Content.ReadAsAsync<AccountingStatusModel>();
                }
                return accountingStatusModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion
        #region Update Accounting Status
        public async Task<AccountingStatusModel> UpdateAccountingStatus(AccountingStatusModel accountingStatus, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.PutAsJsonAsync("accounting-status", accountingStatus);
                if (httpResponse.IsSuccessStatusCode)
                {
                    accountingStatusModel = await httpResponse.Content.ReadAsAsync<AccountingStatusModel>();
                }
                return accountingStatusModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion
        #region GetSingleValue using Accounting Status ID

        public async Task<AccountingStatusModel> GetAccountingStatusSingleValue(Int64 accountingId, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.GetAsync("accounting-status/" + accountingId);
                if (httpResponse.IsSuccessStatusCode)
                {
                    accountingStatusModel = await httpResponse.Content.ReadAsAsync<AccountingStatusModel>();
                }
                return accountingStatusModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion
        #endregion
    }
}
