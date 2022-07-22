using System.Net.Http.Headers;
using fgciams.domain.clsVoucher;

namespace fgciams.service.VoucherServices
{
    public class VoucherRouteService : IVoucherRouteService
    {
        public VoucherRouteService(HttpClient client)
        {
            _client = client;
        }
 
        #region Properties
        private readonly HttpClient _client;
        public async Task<VoucherRouteModel> AddVoucherRoute(VoucherRouteModel model, string token)
        {
          try
          {
            VoucherRouteModel voucherModel = new();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/voucher-route",model);
              if(responseMessage.IsSuccessStatusCode)
                voucherModel = await responseMessage.Content.ReadAsAsync<VoucherRouteModel>();
              return voucherModel;
          }
          catch(System.Exception ee)
          {
            Console.WriteLine(ee.Message);
            throw;
          }
        }
        public async Task<List<VoucherRouteModel>> GetVoucherRoutes(long ID,string token)
        {
            try{
                var voucherRate = new List<VoucherRouteModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await _client.GetAsync("voucher-route-list/"+ID);
                if(responseMessage.IsSuccessStatusCode){
                    voucherRate = await responseMessage.Content.ReadAsAsync<List<VoucherRouteModel>>();
                }
                return voucherRate;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }
        public async Task<VoucherRouteModel> UpdateVoucherRoute(VoucherRouteModel model, string token)
        {
          try
          {
            VoucherRouteModel voucherModel = new();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("/voucher-route",model);
              if(responseMessage.IsSuccessStatusCode)
                voucherModel = await responseMessage.Content.ReadAsAsync<VoucherRouteModel>();
              return voucherModel;
          }
          catch(System.Exception ee)
          {
            Console.WriteLine(ee.Message);
            throw;
          }
        }

        public async Task<List<VoucherRouteAuditTrailModel>> GetAuditTrail(long id, string token)
        {
          try{
                var voucherRoute = new List<VoucherRouteAuditTrailModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await _client.GetAsync("voucher-route-audit-trail/"+id);
                if(responseMessage.IsSuccessStatusCode){
                    voucherRoute = await responseMessage.Content.ReadAsAsync<List<VoucherRouteAuditTrailModel>>();
                }
                return voucherRoute;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }

        public async Task<VoucherRouteModel> SaveRouteVouchers(VoucherRouteModel model, string token)
        {
          try
          {
            VoucherRouteModel voucherModel = new();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/voucher-route/list",model);
              if(responseMessage.IsSuccessStatusCode)
                voucherModel = await responseMessage.Content.ReadAsAsync<VoucherRouteModel>();
              return voucherModel;
          }
          catch(System.Exception ee)
          {
            Console.WriteLine(ee.Message);
            throw;
          }
        }
        #endregion
    }
}