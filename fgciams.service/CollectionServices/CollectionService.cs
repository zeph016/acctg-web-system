using System.Net.Http.Headers;
using fgciams.domain.clsBankDeposit;
using fgciams.domain.clsCollection;
using fgciams.domain.clsFilterParameter;

namespace fgciams.service.CollectionServices
{
    public class CollectionService : ICollectionService
    {
        private readonly HttpClient client;
        public CollectionService(HttpClient _client)
        {
            this.client = _client;
        }
        public async Task<List<CollectionAuditTrailModel>> GetAuditTrail(long Id, string token)
        {
            var auditTrails = new List<CollectionAuditTrailModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.GetAsync(String.Format("collection/audit-trail/{0}",Id));
            if (responseMessage.IsSuccessStatusCode)
                auditTrails = await responseMessage.Content.ReadAsAsync<List<CollectionAuditTrailModel>>();
            return auditTrails;
        }
        public async Task<List<CollectionModel>> GetCollections(FilterParameter param, string token)
        {
            var listCollections = new List<CollectionModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/collection/list",param);
            if (responseMessage.IsSuccessStatusCode)
                listCollections = await responseMessage.Content.ReadAsAsync<List<CollectionModel>>();
            return listCollections;
        }

        public async Task<CollectionModel> SaveCollection(CollectionModel collection, string token)
        {
           var coll = new CollectionModel();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/collection",collection);
            if (responseMessage.IsSuccessStatusCode)
                coll = await responseMessage.Content.ReadAsAsync<CollectionModel>();
            return coll;
        }

        public async Task<CollectionModel> UpdateCollection(CollectionModel collection, string token)
        {
            var coll = new CollectionModel();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync("/collection",collection);
            if (responseMessage.IsSuccessStatusCode)
                coll = await responseMessage.Content.ReadAsAsync<CollectionModel>();
            return coll;
        }
        public async Task<CollectionModel> GetCollection(long ID, string token)
        {
            var coll = new CollectionModel();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.GetAsync(String.Format("collection/{0}",ID));
            if (responseMessage.IsSuccessStatusCode)
                coll = await responseMessage.Content.ReadAsAsync<CollectionModel>();
            return coll;
        }
        public async Task<decimal> GetCashOnHands(string token)
        {
            var cashOnHands = 0.00m;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.GetAsync("collection/cash-on-hand");
            if (responseMessage.IsSuccessStatusCode)
                cashOnHands = await responseMessage.Content.ReadAsAsync<decimal>();
            return cashOnHands;
        }

        public async Task<List<BankDepositAuditTrailModel>> GetBankDepositTrail(long Id, string token)
        {
            var auditTrails = new List<BankDepositAuditTrailModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.GetAsync(String.Format("bank-deposit/audit-trail/{0}",Id));
            if (responseMessage.IsSuccessStatusCode)
                auditTrails = await responseMessage.Content.ReadAsAsync<List<BankDepositAuditTrailModel>>();
            return auditTrails;
        }
    }
}