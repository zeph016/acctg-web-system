using System.Net.Http.Headers;
using fgciams.domain.clsPayeeCategory;

namespace fgciams.service.PayeeCategoryServices
{
    public class PayeeCategoryService : IPayeeCategoryService
    {
        #region Properties
        HttpClient client;
        List<PayeeCategoryModel> payeeCategoryModelList;
        PayeeCategoryModel payeeCategoryModel;
        #endregion
        #region Constructor
        public PayeeCategoryService(HttpClient _client){
            client = _client;
        }
        #endregion
        public async Task<List<PayeeCategoryModel>> LoadListOfPayeeCategory(string token){
            try{
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.GetAsync("payee-category/list");
            if(responseMessage.IsSuccessStatusCode){
                payeeCategoryModelList = await responseMessage.Content.ReadAsAsync<List<PayeeCategoryModel>>();
            }
            return payeeCategoryModelList.OrderBy(x=> x.CategoryName).ToList();
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<PayeeCategoryModel> AddPayeeCategory(PayeeCategoryModel model,string token){
            try{
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("payee-category",model);
            if(responseMessage.IsSuccessStatusCode){
                payeeCategoryModel = await responseMessage.Content.ReadAsAsync<PayeeCategoryModel>();
            }
            return payeeCategoryModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<PayeeCategoryModel> UpdatePayeeCategory(PayeeCategoryModel model,string token){
            try{
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync("payee-category",model);
            if(responseMessage.IsSuccessStatusCode){
                payeeCategoryModel = await responseMessage.Content.ReadAsAsync<PayeeCategoryModel>();
            }
            return payeeCategoryModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<PayeeCategoryModel> GetSingleValuePayeeCategory(Int64 payeeCategoryId, string token){
            try
            {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await client.GetAsync("payee-category/"+payeeCategoryId);
            if(responseMessage.IsSuccessStatusCode)
            {
                payeeCategoryModel = await responseMessage.Content.ReadAsAsync<PayeeCategoryModel>();
            }
            return payeeCategoryModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
    }
}