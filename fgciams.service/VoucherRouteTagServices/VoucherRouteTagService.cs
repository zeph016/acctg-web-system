using System.Net.Http.Headers;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsVoucherRouteTag;

namespace fgciams.service.VoucherRouteTagServices
{
    public class VoucherRouteTagUserService : IVoucherRouteTagUserService
    {
        HttpClient _client;
        
        public VoucherRouteTagUserService(HttpClient client)
        {
            this._client = client;
        }
        public async Task<VoucherRouteTagUserModel> AddUserTagVoucher(VoucherRouteTagUserModel model, string token)
        {
            try
            {
                VoucherRouteTagUserModel userTag = new();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("voucher-routetag-user",model);
                if(responseMessage.IsSuccessStatusCode)
                    userTag = await responseMessage.Content.ReadAsAsync<VoucherRouteTagUserModel>();
                return userTag;
            }
            catch(System.Exception ee)
            {
            Console.WriteLine(ee.Message);
            throw;
            }
        }

        public async Task<List<VoucherRouteTagUserModel>> GetVoucherTagUsers(string token)
        {
            try
            {
                List<VoucherRouteTagUserModel> userTags = new();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("voucher-routetag-user/list");
                if(responseMessage.IsSuccessStatusCode)
                    userTags = await responseMessage.Content.ReadAsAsync<List<VoucherRouteTagUserModel>>();
                return userTags;
            }
            catch(System.Exception ee)
            {
            Console.WriteLine(ee.Message);
            throw;
            }
        }

        public async Task<VoucherRouteTagUserModel> UpdateUSerTagVoucher(VoucherRouteTagUserModel model, string token)
        {
            try
            {
                VoucherRouteTagUserModel userTag = new();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("voucher-routetag-user",model);
                if(responseMessage.IsSuccessStatusCode)
                    userTag = await responseMessage.Content.ReadAsAsync<VoucherRouteTagUserModel>();
                return userTag;
            }
            catch(System.Exception ee)
            {
            Console.WriteLine(ee.Message);
            throw;
            }
        }
        public async Task<List<VoucherRouteTagUserModel>> GetUserTags(long empId, string token)
        {
            try
            {
                List<VoucherRouteTagUserModel> userTags = new();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync(String.Format("voucher-routetag-user/tags/{0}",empId));
                if(responseMessage.IsSuccessStatusCode)
                    userTags = await responseMessage.Content.ReadAsAsync<List<VoucherRouteTagUserModel>>();
                return userTags;
            }
            catch(System.Exception ee)
            {
            Console.WriteLine(ee.Message);
            throw;
            }
        }
    }
}