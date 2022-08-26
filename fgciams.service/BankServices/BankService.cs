using fgciams.domain.clsBank;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<BankCheckNumberModel> AddBankCheckNumber(BankCheckNumberModel model, string token)
        {
            try
            {
                var bankCheckNumber = new BankCheckNumberModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("bank/check-number", model);
                if (responseMessage.IsSuccessStatusCode)
                    bankCheckNumber = await responseMessage.Content.ReadAsAsync<BankCheckNumberModel>();
                else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    string errorContent = await responseMessage.Content.ReadAsStringAsync();
                    if(errorContent.Contains("UniqueAccountingStatus"))
                        throw HttpException.HttpExceptionMessage("checkRange");
                    else
                        throw HttpException.HttpErrorMessage(errorContent);
                }
                return bankCheckNumber;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<BankCheckNumberModel>> LoadBankCheckNumber(long bankId, string token)
        {
            try
            {
                var bankCheckNumbers = new List<BankCheckNumberModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("bank/check-numbers/"+bankId);
                if (responseMessage.IsSuccessStatusCode)
                    bankCheckNumbers = await responseMessage.Content.ReadAsAsync<List<BankCheckNumberModel>>();
                return bankCheckNumbers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BankCheckNumberModel> UpdateBankCheckNumber(BankCheckNumberModel model, string token)
        {
            try
            {
                var bankCheckNumber = new BankCheckNumberModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("bank/check-number", model);
                if (responseMessage.IsSuccessStatusCode)
                    bankCheckNumber = await responseMessage.Content.ReadAsAsync<BankCheckNumberModel>();
                return bankCheckNumber;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<long> GetCheckNo(long bankId, string token)
        {
            try
            {
                long checkNo = 0;
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("check/check-no/"+bankId);
                if (responseMessage.IsSuccessStatusCode)
                    checkNo = await responseMessage.Content.ReadAsAsync<long>();
                 return checkNo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion
    }
}
