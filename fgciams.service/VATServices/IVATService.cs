using fgciams.domain.clsVAT;

namespace fgciams.service.VATServices
{
    public interface IVATService
    {
        Task<VATModel> AddVAT(VATModel model,string token);
        Task<VATModel> UpdateVAT(VATModel model,string token);
        Task<VATModel> GetVAT(string token);
    }
}