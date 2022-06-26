using fgciams.domain.clsAccountingLine;
using fgciams.domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.AccountingLineServices
{
    public class AccountingLineService : IAccountingLineService
    {
        public AccountingLineService(HttpClient client)
        {
            this._client = client;
        }
        #region Properties

        private readonly HttpClient _client;

        #endregion

        #region Methods

        public async Task<AccountLineGroupModel> AddAccountLineGroup(AccountLineGroupModel accountLineGroup, string token)
        {
            try
            {
                var accountLine = new AccountLineGroupModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("account-line-group", accountLineGroup);
                if (responseMessage.IsSuccessStatusCode)
                    accountLine = await responseMessage.Content.ReadAsAsync<AccountLineGroupModel>();
                else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                  string ContentRequest = await responseMessage.Content.ReadAsStringAsync();
                  if(ContentRequest.Contains("UniqueLineGroupName"))
                    throw HttpException.HttpExceptionMessage(accountLineGroup.LineGroupName);
                  else
                    throw HttpException.HttpErrorMessage(ContentRequest);
                }
                 
                return accountLine;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AccountLineGroupModel> UpdateAccountLineGroup(AccountLineGroupModel accountLineGroup, string token)
        {
            try
            {
                var accountLine = new AccountLineGroupModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("account-line-group", accountLineGroup);
                if (responseMessage.IsSuccessStatusCode)
                    accountLine = await responseMessage.Content.ReadAsAsync<AccountLineGroupModel>();
                else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                  string ContentRequest = await responseMessage.Content.ReadAsStringAsync();
                  if(ContentRequest.Contains("UniqueLineGroupName"))
                    throw HttpException.HttpExceptionMessage(accountLineGroup.LineGroupName);
                  else
                    throw HttpException.HttpErrorMessage(ContentRequest);
                }

                return accountLine;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<AccountLineGroupModel>> LoadAccountLineGroup(string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("account-line-group/list");
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsAsync<List<AccountLineGroupModel>>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
