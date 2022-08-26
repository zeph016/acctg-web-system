using System.Net.Http.Headers;
using fgciams.domain.clsVAT;

namespace fgciams.service.VATServices
{
    public class VATService : IVATService
    {
        private readonly HttpClient _client;
        public VATService(HttpClient client)
        {
            _client = client;
        }
        public async Task<VATModel> AddVAT(VATModel model, string token)
        {
            try{
                var vat = new VATModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("VAT ",model);
                if(responseMessage.IsSuccessStatusCode)
                    vat = await responseMessage.Content.ReadAsAsync<VATModel>();
                return vat;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<VATModel> GetVAT(string token)
        {
           try{
                var vat = new VATModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("VAT");
                if(responseMessage.IsSuccessStatusCode)
                    vat = await responseMessage.Content.ReadAsAsync<VATModel>();
                return vat;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<VATModel> UpdateVAT(VATModel model, string token)
        {
            try{
                var vat = new VATModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("VAT",model);
                if(responseMessage.IsSuccessStatusCode)
                    vat = await responseMessage.Content.ReadAsAsync<VATModel>();
                return vat;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}