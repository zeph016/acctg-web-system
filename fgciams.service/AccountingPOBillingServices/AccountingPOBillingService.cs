using fgciams.domain.clsAccountingPOBilling;
using fgciams.domain.clsFilterParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.AccountingPOBillingServices
{
    public class AccountingPOBillingService : IAccountingPOBillingService
    {
        public AccountingPOBillingService(HttpClient client)
        {
           _client = client;
        }
        #region Properties
        private readonly HttpClient _client;
        #endregion

        #region Methods
        public async Task<List<AccountingPOBillingModel>> LoadAccountingBillingPO(FilterParameter filterParameter,  string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("po/billing-list", filterParameter);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsAsync<List<AccountingPOBillingModel>>();
        }
        #endregion

    }
}
