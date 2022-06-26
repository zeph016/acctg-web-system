using fgciams.domain.clsPayee;
using fgciams.domain.common;
using System.Net;
using System.Net.Http.Headers;

namespace fgciams.service.PayeeServices{
    public class PayeeService: IPayeeService
    {
        List<PayeeModel> payeeList;
        PayeeModel payeeModel;
        HttpClient client;
        public PayeeService(HttpClient _client)
        {
            this.client = _client;
        }
        public async Task<List<PayeeModel>> LoadPayee(string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.GetAsync("payee/list");
                if (httpResponse.IsSuccessStatusCode)
                {
                    payeeList = await httpResponse.Content.ReadAsAsync<List<PayeeModel>>();
                }
                return payeeList.OrderBy(x => x.PayeeName).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<PayeeModel> AddPayee(PayeeModel model, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.PostAsJsonAsync("payee", model);
                if (httpResponse.IsSuccessStatusCode)
                    payeeModel = await httpResponse.Content.ReadAsAsync<PayeeModel>();
                else if(httpResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    string errorContent = await httpResponse.Content.ReadAsStringAsync();
                    if(errorContent.Contains("UniqueAccountingStatus"))
                        throw HttpException.HttpExceptionMessage(model.PayeeName);
                    else
                        throw HttpException.HttpErrorMessage(errorContent);
                }
                return payeeModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public async Task<PayeeModel> UpdatePayee(PayeeModel model, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.PutAsJsonAsync("payee", model);
                if (httpResponse.IsSuccessStatusCode)
                {
                    payeeModel = await httpResponse.Content.ReadAsAsync<PayeeModel>();
                }
                return payeeModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}