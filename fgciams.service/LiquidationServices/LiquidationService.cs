using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsLiquidation;
using fgciams.domain.clsPayee;
using fgciams.domain.clsPettyCash;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.LiquidationServices
{
    public class LiquidationService : ILiquidationService
    {
        public LiquidationService(HttpClient client, IConfiguration configuration)
        {
            this._client = client;
            this._configuration = configuration;
        }

        #region Properties

        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        #endregion

        #region Methods

        #region Add Liquidation
        public async Task<LiquidationModel> AddLiquidation(LiquidationModel liquidationModel, string token)
        {
            try
            {
                var liquidation = new LiquidationModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("liquidation", liquidationModel);
                if (responseMessage.IsSuccessStatusCode)
                    liquidation = await responseMessage.Content.ReadAsAsync<LiquidationModel>();
                return liquidation;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get liquidation by ID

        public async Task<List<LiquidationModel>> GetLiquidationById(long liquidationId, string token)
        {
            try
            {
                var liquidations = new List<LiquidationModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("liquidation/list/details/" + liquidationId);
                if (responseMessage.IsSuccessStatusCode)
                    liquidations = await responseMessage.Content.ReadAsAsync<List<LiquidationModel>>();
                return liquidations;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Get Liquidation Details

        public Task<LiquidationDetailModel> GetLiquidationDetail(long liquidationDetailId, string token)
        {
            throw new NotImplementedException();
        }
      
        public async Task<List<PettyCashModel>> GetPettyCashNotLiquidated(FilterParameter filterParameter, string token)
        {
            try
            {
                var notLiquidated = new List<PettyCashModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("petty-cash/list/not-in-liquidation", filterParameter);
                if (responseMessage.IsSuccessStatusCode)
                    notLiquidated = await responseMessage.Content.ReadAsAsync<List<PettyCashModel>>();
                return notLiquidated;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Liquidation Detail List
        
        public async Task<List<LiquidationDetailModel>> LiquidationDetails(long liquidationId, string token)
        {
             try
            {
                var liquidations = new List<LiquidationDetailModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("liquidation/list/details/" + liquidationId);
                if (responseMessage.IsSuccessStatusCode)
                    liquidations = await responseMessage.Content.ReadAsAsync<List<LiquidationDetailModel>>();
                return liquidations;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Liquidation List
       
        public async Task<List<LiquidationModel>> LiquidationList(FilterParameter filterParameter, string token)
        {
            try
            {
                var liquidationList = new List<LiquidationModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("liquidation/list", filterParameter);
                if (responseMessage.IsSuccessStatusCode)
                    liquidationList = await responseMessage.Content.ReadAsAsync<List<LiquidationModel>>();
                return liquidationList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Update Liquidation

        public async Task<LiquidationModel> UpdateLiquidation(LiquidationModel liquidationModel, string token)
        {
            try
            {
                var liquidation = new LiquidationModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("liquidation", liquidationModel);
                if (responseMessage.IsSuccessStatusCode)
                    liquidation = await responseMessage.Content.ReadAsAsync<LiquidationModel>();
                return liquidation;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region View and Print Report
        public async Task<string> PrintSaveLiquidation(LiquidationModel liquidation)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(_configuration["ReportServer"] + "ams-liquidation/GetLiquidationReport", liquidation);
            if (responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent;
        }

        #endregion

        #region Update Liquidation Status
        public async Task<LiquidationModel> UpdateLiquidationStatus(LiquidationModel liquidation, string token)
        {
            try
            {
                var liquidationStatus = new LiquidationModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("liquidation/list/update-status", liquidation);
                if (responseMessage.IsSuccessStatusCode)
                    liquidationStatus = await responseMessage.Content.ReadAsAsync<LiquidationModel>();
                return liquidationStatus;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region Liquidation Audit trail
        public async Task<List<LiquidationAuditTrailModel>> LiquidationAuditTrail(long liquidationId, string token)
        {
            try
            {
                var auditTrails = new List<LiquidationAuditTrailModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("liquidation-audit-trail/list/" + liquidationId);
                if (responseMessage.IsSuccessStatusCode)
                    auditTrails = await responseMessage.Content.ReadAsAsync<List<LiquidationAuditTrailModel>>();
                return auditTrails;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region Liquidation Not in RFP
        public async Task<List<LiquidationModel>> LiquidationNotRFP(string token)
        {
            try
            {
                var notInRFP = new List<LiquidationModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("liquidation/list/not-rfp/");
                if (responseMessage.IsSuccessStatusCode)
                    notInRFP = await responseMessage.Content.ReadAsAsync<List<LiquidationModel>>();
                return notInRFP;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #endregion
    }
}
