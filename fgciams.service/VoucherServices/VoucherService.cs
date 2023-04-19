using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsPayee;
using fgciams.domain.clsProject;
using fgciams.domain.clsRequest;
using fgciams.domain.clsSubContractProject;
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
        public async Task<List<RequestForPaymentModel>> NotInVoucher(FilterParameter param, string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("request-for-payment/list/not-in-voucher",param);
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
         Console.WriteLine(ex.Message);
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
        Console.WriteLine(ex.Message);
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
         Console.WriteLine(ex.Message);
         throw;
      }
    }

    public async Task<string> GenerateLiquidationVoucherReport(VoucherModel voucher)
    {
      var pdfContent = "data:application/pdf;base64,";
      HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(_config["ReportServer"] + "ams-voucher/GetVoucherLiquidationReport", voucher);
      if(responseMessage.IsSuccessStatusCode)
        pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
      return pdfContent;
    }
    public async Task<string> GenerateReport(VoucherModel voucher)
    {
      var pdfContent = "data:application/pdf;base64,";
      HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(_config["ReportServer"] + "ams-voucher/GetVoucherReport", voucher);
      if(responseMessage.IsSuccessStatusCode)
        pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
      return pdfContent;
    }

    public async Task<List<VoucherAuditTrailModel>> VoucherAuditTrail(long voucherId, string token)
    {
      try
      {
        var auditTrails = new List<VoucherAuditTrailModel>();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage responseMessage = await _client.GetAsync("voucher-audit-trail/" + voucherId);
        if(responseMessage.IsSuccessStatusCode)
          auditTrails = await responseMessage.Content.ReadAsAsync<List<VoucherAuditTrailModel>>();
        return auditTrails;
      }
      catch (System.Exception ex)
      {
         // TODO
         Console.WriteLine(ex.Message);
         throw;
      }
    }

        public async Task<List<VoucherModel>> VoucherNotInCheck(FilterParameter parameter, string token)
        {
          try
          {
            List<VoucherModel> voucherModel = new();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/voucher-list/not-in-check",parameter);
              if(responseMessage.IsSuccessStatusCode)
                voucherModel = await responseMessage.Content.ReadAsAsync<List<VoucherModel>>();
              return voucherModel;
          }
          catch(System.Exception ee)
          {
            Console.WriteLine(ee.Message);
            throw;
          }
        }

        public async Task<VoucherModel> GetVATandEWT(Project payee, string token)
        {
          VoucherModel voucherModel = new VoucherModel();
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("voucher/VAT-EWT", payee);
          if (responseMessage.IsSuccessStatusCode)
              voucherModel = await responseMessage.Content.ReadAsAsync<VoucherModel>();
          return voucherModel;
        }

        public async Task<List<VoucherDetailModel>> GetProjectSubledgers(FilterParameter param, string token)
        {
            List<VoucherDetailModel> subledgers = new List<VoucherDetailModel>();
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("subledger/list", param);
          if (responseMessage.IsSuccessStatusCode)
              subledgers = await responseMessage.Content.ReadAsAsync<List<VoucherDetailModel>>();
          return subledgers;
        }

        public async Task<SubContractorProjectModel> GetContractAmount(long subContractorId, long projectId, long SOWId, string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync(String.Format("subcon-projects/project/{0}/{1}/{2}",subContractorId,projectId,SOWId));
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsAsync<SubContractorProjectModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<VoucherDetailModel>> GetSunbConProjects(FilterParameter param, string token)
        {
            List<VoucherDetailModel> subcons = new List<VoucherDetailModel>();
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/ledger/subcon", param);
          if (responseMessage.IsSuccessStatusCode)
              subcons = await responseMessage.Content.ReadAsAsync<List<VoucherDetailModel>>();
          return subcons;
        }
        public async Task<List<VoucherDetailModel>> GetSubConAPProjects(FilterParameter param, string token)
        {
            List<VoucherDetailModel> subcons = new List<VoucherDetailModel>();
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/ledger/subcon-ap", param);
          if (responseMessage.IsSuccessStatusCode)
              subcons = await responseMessage.Content.ReadAsAsync<List<VoucherDetailModel>>();
          return subcons;
        }
        public async Task<int> VoucherListRowCount(FilterParameter param, string token)
        {
          int count = 0;
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/voucher-list/count",param);
          if (responseMessage.IsSuccessStatusCode)
              count = await responseMessage.Content.ReadAsAsync<int>();
          return count;
        }
        public async Task<VoucherModel> GetSignatories(long preparedById, string token)
        {
          var signatories = new VoucherModel();
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.GetAsync("voucher/signatories/"+preparedById);
          if(responseMessage.IsSuccessStatusCode)
            signatories = await responseMessage.Content.ReadAsAsync<VoucherModel>();
          return signatories;
        }
        public async Task<List<VoucherDetailModel>> VoucherDetailListForReport(FilterParameter param, string token)
        {
           List<VoucherDetailModel> vouchers = new List<VoucherDetailModel>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("voucher-report/voucher-details", param);
            if (responseMessage.IsSuccessStatusCode)
                vouchers = await responseMessage.Content.ReadAsAsync<List<VoucherDetailModel>>();
            return vouchers;
        }
        public async Task<string> GenerateNewVoucherReport(FilterParameter filterParameter,string token)
        {
          var pdfContent = "data:application/pdf;base64,";
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(_config["ReportServer"] + "ams-report-voucher/GetVoucherDetailReport", filterParameter);
          if(responseMessage.IsSuccessStatusCode)
            pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
          return pdfContent;
        }
        public async Task<string> GenerateVoucherSOA(List<VoucherDetailModel> details,string token)
        {
          var pdfContent = "data:application/pdf;base64,";
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(_config["ReportServer"] + "ams-report-voucher/GetVoucherSOAReport", details);
          if(responseMessage.IsSuccessStatusCode)
            pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
          return pdfContent;
        }
        public async Task<List<VoucherDetailModel>> VoucherDetailSOAList(FilterParameter param, string token)
        {
           List<VoucherDetailModel> vouchers = new List<VoucherDetailModel>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("voucher-report/soa", param);
            if (responseMessage.IsSuccessStatusCode)
                vouchers = await responseMessage.Content.ReadAsAsync<List<VoucherDetailModel>>();
            return vouchers;
        }
        public async Task<byte[]> VoucherReportGetExcel(FilterParameter param, string token)
        {
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(_config["ReportServer"] + "ams-report-voucher/GetVoucherDetailReportEXCEL",param);
          if(responseMessage.IsSuccessStatusCode)
            return await responseMessage.Content.ReadAsByteArrayAsync();
          else
            return new byte[]{};
        }
        #endregion
    }
}
