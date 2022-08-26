using fgciams.domain.clsBIR;
using fgciams.domain.clsVoucher;

namespace fgciams.service.BIRServices
{

    public interface IBIRService
    {
        Task<VoucherBIRModel> GetVoucherBIR(long voucherID,string token);
        Task<VoucherBIRModel> AddVoucherBIR(VoucherBIRModel model,string token);
        Task<VoucherBIRModel> UpdateVoucherBIR(VoucherBIRModel model,string token);
        Task<string> BIRReport(VoucherBIRModel model);
    }
}