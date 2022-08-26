using fgciams.domain.clsMuniCity;

namespace fgciams.service.MuniCityServices
{
    public interface IMuniCityService
    {
        Task<List<MuniCityModel>> LoadMuniCity(string token);
    }
}