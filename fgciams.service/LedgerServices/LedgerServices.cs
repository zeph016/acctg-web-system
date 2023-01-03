using System.Net.Http.Headers;
using fgciams.domain.clsBank;
using fgciams.domain.clsCheckLedger;
using fgciams.domain.clsCollection;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsVoucher;
using Microsoft.Extensions.Configuration;

namespace fgciams.service.LedgerServices
{
    public class LedgerService : ILedgerService
    {
        private readonly HttpClient client;
        private readonly IConfiguration config;
        public LedgerService(HttpClient _client,IConfiguration _config)
        {
            this.client = _client;
            this.config = _config;
        }
        public async Task<List<CollectionModel>> GetARLedger(FilterParameter parameter, string token)
        {
            List<CollectionModel> subledgers = new List<CollectionModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("ledger/ar", parameter);
            if (responseMessage.IsSuccessStatusCode)
                subledgers = await responseMessage.Content.ReadAsAsync<List<CollectionModel>>();
            return subledgers;
        }
        public async Task<List<BankLedgerModel>> GetBankLedger(FilterParameter parameter, string token)
        {
            List<BankLedgerModel> bankLedger = new List<BankLedgerModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("ledger/bank", parameter);
            if (responseMessage.IsSuccessStatusCode)
                bankLedger = await responseMessage.Content.ReadAsAsync<List<BankLedgerModel>>();
            return bankLedger;
        }
        public async Task<List<CollectionModel>> GetAPLegder(FilterParameter parameter, string token)
        {
            List<CollectionModel> bankLedger = new List<CollectionModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/ledger/ap", parameter);
            if (responseMessage.IsSuccessStatusCode)
                bankLedger = await responseMessage.Content.ReadAsAsync<List<CollectionModel>>();
            return bankLedger;
        }
        public async Task<List<CollectionModel>> GetProjectLeger(FilterParameter parameter, string token)
        {
            List<CollectionModel> bankLedger = new List<CollectionModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/ledger/project", parameter);
            if (responseMessage.IsSuccessStatusCode)
                bankLedger = await responseMessage.Content.ReadAsAsync<List<CollectionModel>>();
            return bankLedger;
        }
        public async Task<List<CheckLedgerModel>> GetCheckLedger(FilterParameter parameter, string token)
        {
            List<CheckLedgerModel> checkLedger = new List<CheckLedgerModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("ledger/bank-detail", parameter);
            if (responseMessage.IsSuccessStatusCode)
                checkLedger = await responseMessage.Content.ReadAsAsync<List<CheckLedgerModel>>();
            return checkLedger;
        }
        public async Task<string> GetAPReport(List<CollectionModel> vDetails)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(config["ReportServer"] + "/ams-ledger-report/GetAPLedgerReport", vDetails);
            if(responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent;
        }
        public async Task<string> GetARReport(List<CollectionModel> vDetails)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(config["ReportServer"] + "/ams-ledger-report/GetARLedgerReport", vDetails);
            if(responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent;
        }
        public async Task<string> GetProjectLedgerReport(List<CollectionModel> coll)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(config["ReportServer"] + "/ams-ledger-report/GetProjectLedgerReport", coll);
            if(responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent;
        }
        public async Task<string> GetBankLedgerReport(List<BankLedgerModel> coll)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(config["ReportServer"] + "/ams-ledger-report/GetBankLedgerReport", coll);
            if(responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent;
        }
        public async Task<string> GetSubConARReport(List<VoucherDetailModel> vDetails)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(config["ReportServer"] + "/ams-ledger-report/GetSubConARLedgerReport", vDetails);
            if(responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent+"#toolbar=0";
        }
        public async Task<string> GetSubConAPReport(List<VoucherDetailModel> vDetails)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(config["ReportServer"] + "/ams-ledger-report/GetSubConAPLedgerReport", vDetails);
            if(responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent;
        }
    }
}