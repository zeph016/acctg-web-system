using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsRequest;
using fgciams.domain.clsVoucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.VoucherServices
{
    public interface IVoucherService
    {
        Task<List<RequestForPaymentModel>> NotInVoucher(string token);
        Task<VoucherModel> AddVoucher(VoucherModel voucher, string token);
        Task<List<VoucherModel>> LoadVouchers(FilterParameter filterParameter, string token);
        Task<VoucherModel> UpdateVoucher(VoucherModel voucher, string token);
        Task<VoucherModel> UpdateVoucherStatus(VoucherModel voucher, string token);
        Task<List<VoucherAuditTrailModel>> VoucherAuditTrail(Int64 voucherId, string token);
        Task<string> GenerateReport(VoucherModel voucher);
    }
}
