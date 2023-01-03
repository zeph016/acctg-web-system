using fgciams.domain.clsBankDeposit;
using fgciams.domain.clsCollection;
using fgciams.domain.clsFilterParameter;
using System.Net.Http.Headers;

namespace fgciams.service.BankDepositServices
{
    public class BankDepositService : IBankDepositService
    {
        private readonly HttpClient client;
        public BankDepositService(HttpClient _client)
        {
            this.client = _client;
        }
        public async Task<BankDepositModel> AddBankDeposit(BankDepositModel model, string token)
        {
            BankDepositModel bankDeposit = new();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("bank-deposit",model);
            if(responseMessage.IsSuccessStatusCode)
                bankDeposit = await responseMessage.Content.ReadAsAsync<BankDepositModel>();
            return bankDeposit;
        }

        public async Task<BankDepositModel> GetBankDeposit(long collectionId, string token)
        {
            BankDepositModel bankDeposit = new();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.GetAsync(String.Format("bank-deposit/collection/{0}",collectionId));
            if(responseMessage.IsSuccessStatusCode)
                bankDeposit = await responseMessage.Content.ReadAsAsync<BankDepositModel>();
            return bankDeposit;
        }
        public async Task<BankDepositModel> UpdateBankDeposit(BankDepositModel model, string token)
        {
            BankDepositModel bankDeposit = new();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync("bank-deposit",model);
            if(responseMessage.IsSuccessStatusCode)
                bankDeposit = await responseMessage.Content.ReadAsAsync<BankDepositModel>();
            return bankDeposit;
        }
        public async Task<List<BankDepositModel>> GetListOfBankDeposits(FilterParameter param,string token)
        {
            List<BankDepositModel> bankDeposits = new();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("bank-deposit/list",param);
            if(responseMessage.IsSuccessStatusCode)
                bankDeposits = await responseMessage.Content.ReadAsAsync<List<BankDepositModel>>();
            return bankDeposits;
        }
        public async Task<List<CollectionModel>> GetBankDepositCollections(long bankDepositId, string token)
        {
            List<CollectionModel> bankDeposit = new();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.GetAsync(String.Format("bank-deposit/collections/{0}",bankDepositId));
            if(responseMessage.IsSuccessStatusCode)
                bankDeposit = await responseMessage.Content.ReadAsAsync<List<CollectionModel>>();
            return bankDeposit;
        }
    }
}