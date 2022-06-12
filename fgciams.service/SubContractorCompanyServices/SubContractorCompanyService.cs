using fgciams.domain.clsSubcon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.SubContractorCompanyServices
{
    public class SubContractorCompanyService : ISubContractorCompanyService
    {
        public SubContractorCompanyService(HttpClient client)
        {
            _client = client;
        }
        #region Properties
        private readonly HttpClient _client;
        #endregion

        #region Methods
        public async Task<List<SubContractorCompanyModel>> LoadSubContractorCompany(string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("subcon-company/list");
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsAsync<List<SubContractorCompanyModel>>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SubContractorCompanyModel> AddSubContractorCompany(SubContractorCompanyModel subContractorCompany, string token)
        {
            try
            {
                var subCon = new SubContractorCompanyModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("subcon-company", subContractorCompany);
                if (responseMessage.IsSuccessStatusCode)
                    subCon = await responseMessage.Content.ReadAsAsync<SubContractorCompanyModel>();
                return subCon;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SubContractorCompanyModel> UpdateSubContractorCompany(SubContractorCompanyModel subContractorCompany, string token)
        {
            try
            {
                var subCon = new SubContractorCompanyModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("subcon-company", subContractorCompany);
                if (responseMessage.IsSuccessStatusCode)
                    subCon = await responseMessage.Content.ReadAsAsync<SubContractorCompanyModel>();
                return subCon;
            }
            catch (Exception)
            {

                throw;
            }
        }

    public async Task<SubContractorCompanyModel> GetSubContractorCompanyId(long Id, string token)
    {
      try
      {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage responseMessage = await _client.GetAsync("subcon-company/" + Id);
        responseMessage.EnsureSuccessStatusCode();
        return await responseMessage.Content.ReadAsAsync<SubContractorCompanyModel>();
      }
     catch (Exception)
     {

      throw;
     }
    }
    #endregion
  }
}
