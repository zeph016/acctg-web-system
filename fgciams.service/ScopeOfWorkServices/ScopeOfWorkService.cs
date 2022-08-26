using System.Net.Http.Headers;
using fgciams.domain.clsScopeOfWork;

namespace fgciams.service.ScopeOfWorkServices
{    public class ScopeOfWorkService : IScopeOfWorkService
    {
        List<ScopeOfWorkModel> scopeOfWorkModelList = new();
        ScopeOfWorkModel scopeOfWorkModel = new();
        HttpClient client;
        public ScopeOfWorkService(HttpClient _client)
        {
            this.client = _client;
        }

        public async Task<ScopeOfWorkModel> AddScopeOfWork(ScopeOfWorkModel model, string token)
        {
            try{   
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("subcon-scope-of-work",model);
                if(responseMessage.IsSuccessStatusCode)
                    scopeOfWorkModel = await responseMessage.Content.ReadAsAsync<ScopeOfWorkModel>();
                return scopeOfWorkModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }

        public async Task<List<ScopeOfWorkModel>> LoadScopeOfWork(string token)
        {
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync("subcon-scope-of-work/list");
                if(responseMessage.IsSuccessStatusCode){
                    scopeOfWorkModelList = await responseMessage.Content.ReadAsAsync<List<ScopeOfWorkModel>>();
                }
                return scopeOfWorkModelList;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }

        public async Task<ScopeOfWorkModel> UpdateScopeOfWork(ScopeOfWorkModel model,string token)
        {
            try{   
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("subcon-scope-of-work",model);
                if(responseMessage.IsSuccessStatusCode)
                    scopeOfWorkModel = await responseMessage.Content.ReadAsAsync<ScopeOfWorkModel>();
                return scopeOfWorkModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
    }
}