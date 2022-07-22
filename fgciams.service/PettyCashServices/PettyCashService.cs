using System.Net.Http.Headers;
using fgciams.domain.clsPettyCash;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsPettyCashReport;
using fgciams.domain.clsPettyCashAuditTrail;
using Microsoft.Extensions.Configuration;

namespace fgciams.service.PettyCashServices
{
    public class PettyCashService : IPettyCashService
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;
        PettyCashModel pettyCash = new();
        List<PettyCashModel> listOfPettyCash = new();
        public PettyCashService(HttpClient _client,IConfiguration _config)
        {
            client = _client;
            configuration = _config;
        }
        public async Task<List<PettyCashModel>> LoadPettyCashList(FilterParameter filter,string token)
        {
            try{ 
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("petty-cash/list",filter);
            if(responseMessage.IsSuccessStatusCode){
                listOfPettyCash = await responseMessage.Content.ReadAsAsync<List<PettyCashModel>>();
            }
            return listOfPettyCash.ToList();
            }catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }

        public async Task<PettyCashModel> AddPettyCash(PettyCashModel model, string token)
        {
            try{
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("petty-cash",model);
            if(responseMessage.IsSuccessStatusCode){
                pettyCash = await responseMessage.Content.ReadAsAsync<PettyCashModel>();
            }
            return pettyCash;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<PettyCashModel> UpdatePettyCash(PettyCashModel model, string token)
        {
            try{
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync("petty-cash",model);
            if(responseMessage.IsSuccessStatusCode){
                pettyCash = await responseMessage.Content.ReadAsAsync<PettyCashModel>();
            }
            return pettyCash;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }   
        }   
        public async Task<PettyCashModel> GetPettyCash(Int64 Id, string token)
        {
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync($"petty-cash/list/{Id}");
                if(responseMessage.IsSuccessStatusCode){
                    pettyCash = await responseMessage.Content.ReadAsAsync<PettyCashModel>();
                }
                return pettyCash;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<string> GetPettyCashReport(PettyCashModel pettyCash)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(configuration["ReportServer"] + "ams-petty-cash/GetPettyCashReport", pettyCash);
            if(responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent;
        }
        public async Task<List<PettyCashAuditTrail>> GetPettyCashAuditTrail(Int64 Id, string token)
        {
            var auditTrail = new List<PettyCashAuditTrail>();
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync("pc-audit-trail/list/"+Id);
                if(responseMessage.IsSuccessStatusCode){
                    auditTrail = await responseMessage.Content.ReadAsAsync<List<PettyCashAuditTrail>>();
                }
                return auditTrail;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
    }
}