using System.Net.Http.Headers;
using fgciams.domain.clsAccessLevel;
using fgciams.domain.clsEnums;

namespace fgciams.service.AccessLevelServices
{
    public class AccessLevelService : IAccessLevelService
    {
        public AccessLevelService(HttpClient client)
        {
            this._client = client;
        }

        private readonly HttpClient _client;

        public async Task<ModuleAssigmentModel> AddModuleAssignment(ModuleAssigmentModel module, string token)
        {
            try
            {
                var newModule = new ModuleAssigmentModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("ais-user-assigment/module", module);
                if (responseMessage.IsSuccessStatusCode)
                    newModule = await responseMessage.Content.ReadAsAsync<ModuleAssigmentModel>();
                return newModule;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public async Task<FunctionAssigmentModel> AddFunctionAssignment(FunctionAssigmentModel module, string token)
        {
            try
            {
                var newFunc = new FunctionAssigmentModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/ais-user-assigment/function", module);
                if (responseMessage.IsSuccessStatusCode)
                    newFunc = await responseMessage.Content.ReadAsAsync<FunctionAssigmentModel>();
                return newFunc;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public async Task<ModuleAssigmentModel> UpdateModuleAssignment(ModuleAssigmentModel module, string token)
        {
            try
            {
                var newModule = new ModuleAssigmentModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("ais-user-assigment/module", module);
                if (responseMessage.IsSuccessStatusCode)
                    newModule = await responseMessage.Content.ReadAsAsync<ModuleAssigmentModel>();
                return newModule;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public async Task<FunctionAssigmentModel> UpdateFunctionAssignment(FunctionAssigmentModel module, string token)
        {
            try
            {
                var newFunc = new FunctionAssigmentModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("/ais-user-assigment/function", module);
                if (responseMessage.IsSuccessStatusCode)
                    newFunc = await responseMessage.Content.ReadAsAsync<FunctionAssigmentModel>();
                return newFunc;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public async Task<List<ModuleAssigmentModel>> GetActiveModules(Enums.AISUserAccessLevel access, string token)
        {
            try
            {
                var modules = new List<ModuleAssigmentModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync(String.Format("ais-user-assigment/module-list/{0}", (int) access));
                if (responseMessage.IsSuccessStatusCode)
                    modules = await responseMessage.Content.ReadAsAsync<List<ModuleAssigmentModel>>();
                return modules;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public async Task<List<FunctionAssigmentModel>> GetActiveFuctions(Enums.AISUserAccessLevel access, Enums.AISModules functions, string token)
        {
            try
            {
                var funcs = new List<FunctionAssigmentModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync(String.Format("ais-user-assigment/function-list/{0}/{1}", (int) access, (int) functions));
                if (responseMessage.IsSuccessStatusCode)
                    funcs = await responseMessage.Content.ReadAsAsync<List<FunctionAssigmentModel>>();
                return funcs;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}