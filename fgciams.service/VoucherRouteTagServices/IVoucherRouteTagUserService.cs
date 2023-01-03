using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsVoucherRouteTag;

namespace fgciams.service.VoucherRouteTagServices
{
    public interface IVoucherRouteTagUserService
    {
        Task<List<VoucherRouteTagUserModel>> GetVoucherTagUsers(string token);
        Task<VoucherRouteTagUserModel> AddUserTagVoucher(VoucherRouteTagUserModel model , string token);
        Task<VoucherRouteTagUserModel> UpdateUSerTagVoucher(VoucherRouteTagUserModel model , string token);
        Task<List<VoucherRouteTagUserModel>> GetUserTags(long employeeId , string token);
    }
}