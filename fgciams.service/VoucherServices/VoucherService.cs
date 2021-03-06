using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsRequest;
using fgciams.domain.clsVoucher;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.VoucherServices
{
    public class VoucherService : IVoucherService
    {
        public VoucherService(HttpClient client, IConfiguration config)
        {
            this._client = client;
            this._config = config;
        }

        #region Properties

        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        #endregion

        #region Methods

        #region Not in Voucher
        public async Task<List<RequestForPaymentModel>> NotInVoucher(string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("request-for-payment/list/not-in-voucher");
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsAsync<List<RequestForPaymentModel>>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Add Voucher
        public async Task<VoucherModel> AddVoucher(VoucherModel voucher, string token)
        {
            VoucherModel voucherModel = new VoucherModel();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("voucher", voucher);
            if (responseMessage.IsSuccessStatusCode)
                voucherModel = await responseMessage.Content.ReadAsAsync<VoucherModel>();
            return voucherModel;
        }

    #endregion
     public async Task<List<VoucherModel>> LoadVouchers(FilterParameter filterParameter, string token)
    {
      try
      {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("voucher-list", filterParameter);
        responseMessage.EnsureSuccessStatusCode();
        return await responseMessage.Content.ReadAsAsync<List<VoucherModel>>();
      }
      catch (System.Exception ex)
      {
         throw;
      }
    }

    public async Task<VoucherModel> UpdateVoucher(VoucherModel voucher, string token)
    {
      try
      {
        var voucherModel = new VoucherModel();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("voucher", voucher);
        if(responseMessage.IsSuccessStatusCode)
          voucherModel = await responseMessage.Content.ReadAsAsync<VoucherModel>();
        return voucherModel;
      }
      catch (System.Exception ex)
      {
         throw;
      }
    }

    public async Task<VoucherModel> UpdateVoucherStatus(VoucherModel voucher, string token)
    {
      try
      {
        var voucerStatus = new VoucherModel();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("/voucher-list/update-status", voucher);
        if(responseMessage.IsSuccessStatusCode)
          voucerStatus = await responseMessage.Content.ReadAsAsync<VoucherModel>();
        return voucerStatus;
      }
      catch (System.Exception ex)
      {
         // TODO
         throw;
      }
    }

    public async Task<string> GenerateReport(VoucherModel voucher)
    {
      var pdfContent = "data:application/pdf;base64,";
      HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(_config["ReportServer"] + "/ams-voucher/GetVoucherReport", voucher);
      if(responseMessage.IsSuccessStatusCode)
        pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
      return pdfContent;
    }

    #endregion
  }
}
