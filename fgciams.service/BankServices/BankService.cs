using fgciams.domain.clsBank;
using fgciams.domain.clsFilterParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.BankServices
{
    public class BankService : IBankService
    {
        public BankService(HttpClient client)
        {
            _client = client;
        }

        #region Properties
        private readonly HttpClient _client;
        #endregion

        #region Methods

        #region Add Bank

        public async Task<BankModel> AddBank(BankModel bankModel, string token)
        {
            try
            {
                var bank = new BankModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("bank", bankModel);
                if (responseMessage.IsSuccessStatusCode)
                    bank = await responseMessage.Content.ReadAsAsync<BankModel>();
                return bank;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Load Banks

        public async Task<List<BankModel>> LoadBanks(string token)
        {
            try
            {
                var banks = new List<BankModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("bank/list/");
                if (responseMessage.IsSuccessStatusCode)
                    banks = await responseMessage.Content.ReadAsAsync<List<BankModel>>();
                return banks;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Update Bank

        public async Task<BankModel> UpdateBank(BankModel bankModel, string token)
        {
            try
            {
                var bank = new BankModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("bank", bankModel);
                if (responseMessage.IsSuccessStatusCode)
                    bank = await responseMessage.Content.ReadAsAsync<BankModel>();
                return bank;
            }
            catch (Exception)
            {

                throw;
            }
        }

    public async Task<BankModel> GetBank(long Id, string token)
    {
      var bank = new BankModel();
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.GetAsync("bank/" + Id);
      if(responseMessage.IsSuccessStatusCode)
        bank = await responseMessage.Content.ReadAsAsync<BankModel>();
      return bank;
    }

    #endregion

    #endregion
  }
}
