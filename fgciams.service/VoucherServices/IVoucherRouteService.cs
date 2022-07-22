using fgciams.domain.clsVoucher;

namespace fgciams.service.VoucherServices
{
    public interface IVoucherRouteService
    {
        Task<VoucherRouteModel> AddVoucherRoute(VoucherRouteModel model,string token);
        Task<List<VoucherRouteModel>> GetVoucherRoutes(long ID,string token);
        Task<VoucherRouteModel> UpdateVoucherRoute(VoucherRouteModel model,string token);
        Task<List<VoucherRouteAuditTrailModel>> GetAuditTrail(long id,string token);
        Task<VoucherRouteModel> SaveRouteVouchers(VoucherRouteModel model,string token);
    }
}