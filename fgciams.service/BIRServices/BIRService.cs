using System.Net.Http.Headers;
using fgciams.domain.clsBIR;
using Microsoft.Extensions.Configuration;

namespace fgciams.service.BIRServices
{
    public class BIRService : IBIRService
    {
        HttpClient client;
        IConfiguration configuration;
        VoucherBIRModel voucher = new();
        public BIRService(HttpClient _client,IConfiguration _configuration){
            client =_client;
            configuration = _configuration;

        }

        public async Task<VoucherBIRModel> AddVoucherBIR(VoucherBIRModel model, string token)
        {
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("voucher-bir",model);
                if(responseMessage.IsSuccessStatusCode){
                    voucher = await responseMessage.Content.ReadAsAsync<VoucherBIRModel>();
                }
                return voucher;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }

        public async Task<string> BIRReport(VoucherBIRModel model)
        {
            var pdfContent = "data:application/pdf;base64,";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(configuration["ReportServer"] + "ams-BIR/GetBIR", model);
            if(responseMessage.IsSuccessStatusCode)
                pdfContent += Convert.ToBase64String(await responseMessage.Content.ReadAsByteArrayAsync());
            return pdfContent;
        }

        public async Task<VoucherBIRModel> GetVoucherBIR(long voucherID, string token)
        {
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync("voucher-bir/list/"+voucherID);
                if(responseMessage.IsSuccessStatusCode){
                    voucher = await responseMessage.Content.ReadAsAsync<VoucherBIRModel>();
                }
                return voucher;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }

        public async Task<VoucherBIRModel> UpdateVoucherBIR(VoucherBIRModel model, string token)
        {
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("voucher-bir",model);
                if(responseMessage.IsSuccessStatusCode){
                    voucher = await responseMessage.Content.ReadAsAsync<VoucherBIRModel>();
                }
                return voucher;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
    }
}