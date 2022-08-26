using System.Net.Http.Headers;
using fgciams.domain.clsMuniCity;

namespace fgciams.service.MuniCityServices
{
    public class MuniCityService : IMuniCityService
    {
        HttpClient _client;
        public MuniCityService(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<MuniCityModel>> LoadMuniCity(string token)
        {
            try
            {
            var muniCity = new List<MuniCityModel>();
            _client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer",token);
            HttpResponseMessage responseMessage = await _client.GetAsync("muni-city/list");
            if(responseMessage.IsSuccessStatusCode) 
                muniCity = await responseMessage.Content.ReadAsAsync<List<MuniCityModel>>();
            return muniCity;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}