using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsVoucher;
using fgciams.domain.clsVoucherRouteBatch;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.VoucherRouteBatchServices
{
    public class VoucherRouteBatchService : IVoucherRouteBatchService
    {
        public VoucherRouteBatchService(HttpClient client,IConfiguration config)
        {
            this._client = client;
            this._config = config;
        }
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        public async Task<VoucherRouteBatchModel> AddVoucherRouteBatch(VoucherRouteBatchModel voucherRouteBatch, string token)
        {
            var voucherBatch = new VoucherRouteBatchModel();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("voucher-route-batch", voucherRouteBatch);
            if (responseMessage.IsSuccessStatusCode)
                voucherRouteBatch = await responseMessage.Content.ReadAsAsync<VoucherRouteBatchModel>();
            return voucherRouteBatch;
        }

        public async Task<List<VoucherRouteBatchModel>> LoadAllBatchVoucher(FilterParameter filterParameter, string token)
        {
           var voucherBatches = new List<VoucherRouteBatchModel>();
           _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
           HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("voucher-route-batch-list", filterParameter);
           if(responseMessage.IsSuccessStatusCode)
              voucherBatches = await responseMessage.Content.ReadAsAsync<List<VoucherRouteBatchModel>>();
            return voucherBatches;

        }

        public async Task<List<VoucherRouteBatchDetailModel>> GetVoucherRouteBatchDetails(long Id, string token)
        {
          var voucherRoute = new List<VoucherRouteBatchDetailModel>();
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.GetAsync("/voucher-route-batch-list/details/" + Id);
          if(responseMessage.IsSuccessStatusCode)
            voucherRoute = await responseMessage.Content.ReadAsAsync<List<VoucherRouteBatchDetailModel>>();
          return voucherRoute;
        }

        public async Task<VoucherRouteBatchModel> UpdateVoucherRouteBatch(VoucherRouteBatchModel voucherRouteBatch, string token)
        {
            var voucherBatch = new VoucherRouteBatchModel();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("voucher-route-batch", voucherRouteBatch);
            if (responseMessage.IsSuccessStatusCode)
                voucherRouteBatch = await responseMessage.Content.ReadAsAsync<VoucherRouteBatchModel>();
            return voucherRouteBatch;
        }

      public async Task<List<VoucherRouteBatchAuditTrailModel>> GetVoucherRouteBatchAuditTrail(long voucherRouteId, string token)
      {
        var auditTrails = new List<VoucherRouteBatchAuditTrailModel>();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage responseMessage = await _client.GetAsync("/voucher-route-batch-audit-trail/" + voucherRouteId);
        if(responseMessage.IsSuccessStatusCode)
          auditTrails = await responseMessage.Content.ReadAsAsync<List<VoucherRouteBatchAuditTrailModel>>();
        return auditTrails;
      }

    public async Task<List<VoucherModel>> VoucherList(FilterParameter filterParameter, string token)
    {
      var vouchers = new List<VoucherModel>();
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/voucher-route-batch-list/vouchers", filterParameter);
      if(responseMessage.IsSuccessStatusCode)
        vouchers = await responseMessage.Content.ReadAsAsync<List<VoucherModel>>();
      return vouchers;
    }
    public async Task<string> GetBatchVouchersReport(VoucherRouteBatchModel batch)
    {
        var pdfContent = "data:application/pdf;base64,";
        HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(_config["ReportServer"] + "ams-batch/BatchVouchersReport", batch);
        if(responseMessage.IsSuccessStatusCode)
            pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
        return pdfContent;
    }
  }
}
