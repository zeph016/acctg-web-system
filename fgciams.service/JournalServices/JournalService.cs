using System.Net.Http.Headers;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsVoucher;

namespace fgciams.service.JournalServices
{
    public class JournalService : IJournalService
    {
        private HttpClient client;
        public JournalService(HttpClient _client)
        {
            this.client = _client;
        }

        public async Task<decimal> GetBankBeginningBal(FilterParameter param, string token)
        {
            decimal bal = 0.0m;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("ledger/journal-check-amount",param);
            if (responseMessage.IsSuccessStatusCode)
                bal = await responseMessage.Content.ReadAsAsync<decimal>();
            return bal;
        }

        public async Task<List<VoucherDetailModel>> GetJournals(FilterParameter param, string token)
        {
            var journals = new List<VoucherDetailModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("ledger/journal",param);
            if (responseMessage.IsSuccessStatusCode)
                journals = await responseMessage.Content.ReadAsAsync<List<VoucherDetailModel>>();
            return journals;
        }
    }
}