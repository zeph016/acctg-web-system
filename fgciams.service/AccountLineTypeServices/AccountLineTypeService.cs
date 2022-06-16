using fgciams.domain.clsAccountingLine;
using fgciams.domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.AccountLineTypeServices
{
    public class AccountLineTypeService : IAccountLineTypeService
    {
        public AccountLineTypeService(HttpClient client)
        {
            this._client = client;
        }

        #region Properties
        private readonly HttpClient _client;

        #endregion

        #region Methods
        public async Task<AccountLineTypeModel> AddAccountLineType(AccountLineTypeModel type, string token)
        {
            try
            {
              var lineType = new AccountLineTypeModel();
              _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("account-line-type", type);
              if(responseMessage.IsSuccessStatusCode)
                lineType = await responseMessage.Content.ReadAsAsync<AccountLineTypeModel>();
              else if(responseMessage.StatusCode == HttpStatusCode.BadRequest) {
                string str = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(str);
                // if (str.Contains("UniqueLineTypeName"))
                //   Console.WriteLine("Hello World");
                throw HttpException.HttpExceptionMessage(type.LineTypeName);
              }
                

              return lineType;
            }
            catch (System.Exception ex)
            {
               // TODO HttpExceptionMessage(HttpStatusCode statusCode, string customMessage)
               throw new ApplicationException(ex.Message);
            }
        }

        public async Task<AccountLineTypeModel> UpdateAccountLineType(AccountLineTypeModel type, string token)
        {
            try
            {
              var lineType = new AccountLineTypeModel();
              _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("account-line-type", type);
              if(responseMessage.IsSuccessStatusCode)
                lineType = await responseMessage.Content.ReadAsAsync<AccountLineTypeModel>();
              else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                throw HttpException.HttpExceptionMessage(type.LineTypeName);

              return lineType;
            }
            catch (System.Exception ex)
            {
               // TODO
               throw;
            }
        }

        public async Task<List<AccountLineTypeModel>> LoadAccountLineType(string token)
        {
            try
            {
              _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage responseMessage = await _client.GetAsync("account-line-type/list");
              responseMessage.EnsureSuccessStatusCode();
              return await responseMessage.Content.ReadAsAsync<List<AccountLineTypeModel>>();
            }
            catch (System.Exception ex)
            {
               // TODO
               throw;
            }
        }
        #endregion
    }
}
