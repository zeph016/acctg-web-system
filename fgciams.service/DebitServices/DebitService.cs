using System.Net.Http.Headers;
using fgciams.domain.clsDebit;
using fgciams.domain.clsFilterParameter;

namespace fgciams.service.DebitServices
{
    public class DebitService : IDebitService
    {
        HttpClient _client;
        public DebitService(HttpClient client)
        {
            this._client = client;
        }
        public async Task<List<DebitModel>> GetDebits(FilterParameter param, string token)
        {
            try
            {
                var debits = new List<DebitModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("debit-list", param);
                if (responseMessage.IsSuccessStatusCode)
                    debits = await responseMessage.Content.ReadAsAsync<List<DebitModel>>();
                return debits;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<DebitModel> SaveDebit(DebitModel model, string token)
        {
            try
            {
                var debit = new DebitModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("debit", model);
                if (responseMessage.IsSuccessStatusCode)
                    debit = await responseMessage.Content.ReadAsAsync<DebitModel>();
                return debit;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<DebitModel> UpdateDebit(DebitModel model, string token)
        {
            try
            {
                var debit = new DebitModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("debit", model);
                if (responseMessage.IsSuccessStatusCode)
                    debit = await responseMessage.Content.ReadAsAsync<DebitModel>();
                return debit;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<List<DebitAuditTrailModel>> DebitAuditTrail(long ID, string token)
        {
            var auditTrail = new List<DebitAuditTrailModel>();
            try{
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await _client.GetAsync("/debit/audit-trail/"+ID);
                if(responseMessage.IsSuccessStatusCode){
                    auditTrail = await responseMessage.Content.ReadAsAsync<List<DebitAuditTrailModel>>();
                }
                return auditTrail;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<int> DebitListRowCount(FilterParameter param, string token)
        {
          int count = 0;
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("debit-list/count",param);
          if (responseMessage.IsSuccessStatusCode)
              count = await responseMessage.Content.ReadAsAsync<int>();
          return count;
        }
    }
}