using System.Net.Http.Headers;
using fgciams.domain.clsCheck;
using fgciams.domain.clsFilterParameter;
using Microsoft.Extensions.Configuration;

namespace fgciams.service.CheckServices
{
    public class CheckService : ICheckService
    {
        #region Properties
        CheckModel checkModel = new();
        List<CheckModel> listCheck = new();
        private readonly IConfiguration configuration;
        HttpClient client;
        #endregion
        #region  Constructor
        public CheckService(HttpClient _client, IConfiguration _config){
            client =_client;
            configuration = _config;
        }
        #endregion
        #region AddCheck
        public async Task<CheckModel> AddCheck(CheckModel model, string token)
        {
            try
            {
                checkModel = new();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/check",model);
                if(responseMessage.IsSuccessStatusCode){
                    checkModel = await responseMessage.Content.ReadAsAsync<CheckModel>();
                }
                return checkModel;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }
        #endregion
        public async Task<List<CheckModel>> LoadCheck(FilterParameter param ,string token)
        {
            try
            {
                listCheck = new();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/check-list",param);
                if(responseMessage.IsSuccessStatusCode){
                    listCheck = await responseMessage.Content.ReadAsAsync<List<CheckModel>>();
                }
                return listCheck.ToList();
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }

        public async Task<CheckModel> UpdateCheckStatus(CheckModel check, string token)
        {
            try
            {
                checkModel = new();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/check-list/update-status",check);
                if(responseMessage.IsSuccessStatusCode){
                    checkModel = await responseMessage.Content.ReadAsAsync<CheckModel>();
                }
                return checkModel;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }

        public  async Task<CheckModel> UpdateCheck(CheckModel check, string token)
        {
            try
            {
                checkModel = new();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("/check",check);
                if(responseMessage.IsSuccessStatusCode){
                    checkModel = await responseMessage.Content.ReadAsAsync<CheckModel>();
                }
                return checkModel;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }

        public async Task<string> GetCheckReport(CheckModel model)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(configuration["ReportServer"] + "ams-check/GetCheckReport", model);
            if(responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent;
        }

        public async Task<List<CheckAuditTrailModel>> GetAudiTrail(long ID, string token)
        {
            try
            {
                var auditTrails = new List<CheckAuditTrailModel>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format("check/audit-trail/{0}",ID));
                if(responseMessage.IsSuccessStatusCode){
                    auditTrails = await responseMessage.Content.ReadAsAsync<List<CheckAuditTrailModel>>();
                }
                return auditTrails;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }
        public async Task<int> CheckListRowCount(FilterParameter param, string token)
        {
          int count = 0;
          client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await client.PostAsJsonAsync("check-list/count",param);
          if (responseMessage.IsSuccessStatusCode)
              count = await responseMessage.Content.ReadAsAsync<int>();
          return count;
        }
    }
}