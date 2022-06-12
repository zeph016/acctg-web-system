using fgciams.domain.clsSubConGeneralInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.SubConGeneralInformationServices
{
    public class SubConGeneralInformationService : ISubConGeneralInformationService
    {
        public SubConGeneralInformationService(HttpClient client)
        {
            _client = client;
        }
        #region Properties
        private readonly HttpClient _client;
        #endregion

        #region Methods
        public async Task<SubConGeneralInformationModel> AddSubConGenInfo(SubConGeneralInformationModel subConGeneral, string token)
        {
            try
            {
                var subConGenInfo = new SubConGeneralInformationModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("subcon-general-information", subConGeneral);
                if (responseMessage.IsSuccessStatusCode)
                    subConGenInfo = await responseMessage.Content.ReadAsAsync<SubConGeneralInformationModel>();
                return subConGenInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SubConGeneralInformationModel>> LoadSubConGenInfo(string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("subcon-general-information/list");
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsAsync<List<SubConGeneralInformationModel>>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SubConGeneralInformationModel> UpdateSubConGenInfo(SubConGeneralInformationModel subConGeneral, string token)
        {
            try
            {
                var subConGenInfo = new SubConGeneralInformationModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("subcon-general-information", subConGeneral);
                if (responseMessage.IsSuccessStatusCode)
                    subConGenInfo = await responseMessage.Content.ReadAsAsync<SubConGeneralInformationModel>();
                return subConGenInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
