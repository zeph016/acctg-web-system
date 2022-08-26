using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsSupplier;
using System.Net;
using System.Net.Http.Headers;

namespace fgciams.service.SupplierServices
{
    public class SupplierService : ISupplierService
    {
        private readonly HttpClient _client;

        public SupplierService(HttpClient client)
        {
            _client = client;
        }

        public async Task<SupplierModel> AddSupplier(SupplierModel supplier, string token)
        {
           try{
                var suppliers = new SupplierModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("supplier ",supplier);
                if(responseMessage.IsSuccessStatusCode)
                    suppliers = await responseMessage.Content.ReadAsAsync<SupplierModel>();
                return suppliers;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<SupplierModel> GetSupplier(long supplierID, string token)
        {
            try{
                var suppliers = new SupplierModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("supplier/"+supplierID);
                if(responseMessage.IsSuccessStatusCode)
                    suppliers = await responseMessage.Content.ReadAsAsync<SupplierModel>();
                return suppliers;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<SupplierContactModel>> GetSupplierContacts(long supplierID, string token)
        {
           try{
                var suppliers = new List<SupplierContactModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("supplier/contacts/"+supplierID);
                if(responseMessage.IsSuccessStatusCode)
                    suppliers = await responseMessage.Content.ReadAsAsync<List<SupplierContactModel>>();
                return suppliers;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<SupplierModel>> LoadListOfSupplier(FilterParameter param,string token)
        {
            try{
                var suppliers = new List<SupplierModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("supplier/list ",param);
                if(responseMessage.IsSuccessStatusCode)
                    suppliers = await responseMessage.Content.ReadAsAsync<List<SupplierModel>>();
                return suppliers;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<SupplierContactModel> SaveContact(SupplierContactModel supplier, string token)
        {
            try{
                var suppliers = new SupplierContactModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("supplier/save-contact ",supplier);
                if(responseMessage.IsSuccessStatusCode)
                    suppliers = await responseMessage.Content.ReadAsAsync<SupplierContactModel>();
                return suppliers;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<SupplierContactModel> UpdateContact(SupplierContactModel supplier, string token)
        {
           try{
                var suppliers = new SupplierContactModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("supplier/update-contact",supplier);
                if(responseMessage.IsSuccessStatusCode)
                    suppliers = await responseMessage.Content.ReadAsAsync<SupplierContactModel>();
                return suppliers;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<SupplierModel> UpdateSupplier(SupplierModel supplier, string token)
        {
            try{
                var suppliers = new SupplierModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("supplier ",supplier);
                if(responseMessage.IsSuccessStatusCode)
                    suppliers = await responseMessage.Content.ReadAsAsync<SupplierModel>();
                return suppliers;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}