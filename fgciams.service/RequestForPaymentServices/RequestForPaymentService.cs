using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsLiquidation;
using fgciams.domain.clsRequest;
using fgciams.domain.clsRequestForPaymentAuditTrail;
using Microsoft.Extensions.Configuration;

namespace fgciams.service.RequestForPaymentService
{
  public class RequestForPaymentService : IRequestForPaymentService
  {
    public RequestForPaymentService(HttpClient client, IConfiguration config)
    {
      _client = client;
      _config = config;
    }
    #region Properties
      private readonly HttpClient _client;
        private readonly IConfiguration _config;

    #endregion

    #region Methods

      #region Save Request for payment
      public async Task<RequestForPaymentModel> AddRequestPayment(RequestForPaymentModel requestForPayment, string token)
      {
        try
        {
          var requestPayment = new RequestForPaymentModel();
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("request-for-payment", requestForPayment);
          if(responseMessage.IsSuccessStatusCode)
            requestPayment = await responseMessage.Content.ReadAsAsync<RequestForPaymentModel>();

          return requestPayment;
        }
        catch (System.Exception ex)
        {
           Console.WriteLine(ex.Message);
           throw;
        }     
      }

      #endregion

      #region Load Request for payment list
      public async Task<List<RequestForPaymentModel>> LoadRequestPayment(FilterParameter filterParameter, string token)
      {
        try
        {
          _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("request-for-payment/list", filterParameter);
          responseMessage.EnsureSuccessStatusCode();
          return await responseMessage.Content.ReadAsAsync<List<RequestForPaymentModel>>();
        }
        catch(Exception ex)
        {
          Console.WriteLine(ex.Message);
          throw;
        }
      }

        #endregion

      #region Load Request Payment Detail
        public async Task<List<RequestForPaymentDetailModel>> LoadRequestPaymentDetail(long requestId, string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("request-for-payment/list/detail/" + requestId);
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsAsync<List<RequestForPaymentDetailModel>>();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

      #region Update RFP
        public async Task<RequestForPaymentModel> UpdateRequestPayment(RequestForPaymentModel requestForPayment, string token)
        {
            try
            {
                var requestPayment = new RequestForPaymentModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("request-for-payment", requestForPayment);
                if (responseMessage.IsSuccessStatusCode)
                    requestPayment = await responseMessage.Content.ReadAsAsync<RequestForPaymentModel>();

                return requestPayment;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

      #region Load Liquidation not in RFP
        public async Task<List<LiquidationDetailModel>> LoadLiquidationNotInRFP(string token)
        {
            try
            {
                var liquidationNotRFP = new List<LiquidationDetailModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("liquidation/list/not-rfp/");
                if (responseMessage.IsSuccessStatusCode)
                    liquidationNotRFP = await responseMessage.Content.ReadAsAsync<List<LiquidationDetailModel>>();
                return liquidationNotRFP;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    #endregion

    #region Generate Report

    public async Task<string> GenerateRFPReport(RequestForPaymentModel requestForPayment)
    {
      var pdfContent = "data:application/pdf;base64,";
      HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(_config["ReportServer"] + "ams-rfp-report/GetRequestForPaymentReport", requestForPayment);
      if(responseMessage.IsSuccessStatusCode)
        pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
      return pdfContent;
    }

    #endregion
    
    #region Update Status RFP

    public async Task<RequestForPaymentModel> UpdateRFPStatus(RequestForPaymentModel requestForPayment, string token)
    {
      var RFPStatus = new RequestForPaymentModel();
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("request-for-payment/list/update-status", requestForPayment);
      if(responseMessage.IsSuccessStatusCode)
       RFPStatus = await responseMessage.Content.ReadAsAsync<RequestForPaymentModel>();

       return RFPStatus;
    }

    #endregion

    #region Audit Trail
    public async Task<List<RequestForPaymentAuditTrailModel>> RFPAuditTrails(long reqId, string token)
    {
      try
      {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage responseMessage = await _client.GetAsync("/request-for-payment/audit-trail/" + reqId);
        responseMessage.EnsureSuccessStatusCode();

        return await responseMessage.Content.ReadAsAsync<List<RequestForPaymentAuditTrailModel>>();
      }
      catch (System.Exception ex)
      {
         Console.WriteLine(ex.Message);
         throw;
      }
    }
    #endregion
    public async Task<int> RFPListRowCount(FilterParameter param, string token)
    {
      int count = 0;
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("request-for-payment/list/count",param);
      if (responseMessage.IsSuccessStatusCode)
          count = await responseMessage.Content.ReadAsAsync<int>();
      return count;
    }
    public async Task<RequestForPaymentModel> GetSignatories(long preparedById, string token)
    {
      var signatories = new RequestForPaymentModel();
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.GetAsync("request-for-payment/signatories/"+preparedById);
      if(responseMessage.IsSuccessStatusCode)
        signatories = await responseMessage.Content.ReadAsAsync<RequestForPaymentModel>();
      return signatories;
    }
    #endregion

  }
}
