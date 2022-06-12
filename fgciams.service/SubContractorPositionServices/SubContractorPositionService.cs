using fgciams.domain.clsSubContractorPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.SubContractorPositionServices
{
    public class SubContractorPositionService : ISubContractorPositionService
    {
        public SubContractorPositionService(HttpClient client)
        {
            _client = client;
        }
        #region Properties
        private readonly HttpClient _client;
        #endregion

        #region Methods
        public async Task<SubContractorPositionModel> AddSubContractorPosition(SubContractorPositionModel subConPosition, string token)
        {
            try
            {
                var subContratorPos = new SubContractorPositionModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("subcon-position", subConPosition);
                if (responseMessage.IsSuccessStatusCode)
                    subContratorPos = await responseMessage.Content.ReadAsAsync<SubContractorPositionModel>();
                return subContratorPos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SubContractorPositionModel>> LoadSubContractorPosition(string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("subcon-position/list");
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsAsync<List<SubContractorPositionModel>>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SubContractorPositionModel> UpdateSubContractorPosition(SubContractorPositionModel subConPosition, string token)
        {
            try
            {
                var subContratorPos = new SubContractorPositionModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("subcon-position", subConPosition);
                if (responseMessage.IsSuccessStatusCode)
                    subContratorPos = await responseMessage.Content.ReadAsAsync<SubContractorPositionModel>();
                return subContratorPos;
            }
            catch (Exception)
            {

                throw;
            }
        }

    public async Task<SubContractorPositionModel> GetSubContractorPositionId(long Id, string token)
    {
      try
      {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage responseMessage = await _client.GetAsync("subcon-position/" + Id);
        responseMessage.EnsureSuccessStatusCode();
        return await responseMessage.Content.ReadAsAsync<SubContractorPositionModel>();
      }
      catch (Exception)
      {

        throw;
      }
    }
    #endregion

  }
}
