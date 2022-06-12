using fgciams.domain.clsBillingDocument;
using fgciams.domain.clsRFPBillingDocuments;
using System.Net.Http.Headers;

namespace fgciams.service.BillingDocumentServices
{
    public class BillingDocumentService : IBillingDocumentService
    {
        #region Properties
        HttpClient client;
        BillingDocumentModel billingDocumentModel;
        List<BillingDocumentModel> billingDocumentList;
        #endregion
        public BillingDocumentService(HttpClient _client)
        {
            this.client = _client;
        }
        public async Task<List<BillingDocumentModel>> LoadListOfBillingDocuments(string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                HttpResponseMessage responseMessage = await client.GetAsync("billing-document/list");
                if (responseMessage.IsSuccessStatusCode)
                {
                    billingDocumentList = await responseMessage.Content.ReadAsAsync<List<BillingDocumentModel>>();
                }
                return billingDocumentList.OrderBy(x => x.DocumentName).ToList();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<BillingDocumentModel> AddBillingDocument(BillingDocumentModel model, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("billing-document", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    billingDocumentModel = await responseMessage.Content.ReadAsAsync<BillingDocumentModel>();
                }
                return billingDocumentModel;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<BillingDocumentModel> UpdateBillingDocument(BillingDocumentModel model, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("billing-document", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    billingDocumentModel = await responseMessage.Content.ReadAsAsync<BillingDocumentModel>();
                }
                return billingDocumentModel;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }

    public async Task<List<RFPBillingDocumentModel>> GetBillingDocument(long Id, string token)
    {
      var RFPDocs = new List<RFPBillingDocumentModel>();
      client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await client.GetAsync("billing-document/rfp/" + Id);
      if(responseMessage.IsSuccessStatusCode)
        RFPDocs = await responseMessage.Content.ReadAsAsync<List<RFPBillingDocumentModel>>();
        return RFPDocs;
    }
  }
}
