using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsVoucher;
using fgciams.domain.clsVoucherRouteBatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.VoucherRouteBatchServices
{
    public interface IVoucherRouteBatchService
    {
        Task<VoucherRouteBatchModel> AddVoucherRouteBatch(VoucherRouteBatchModel voucherRouteBatch, string token);
        Task<VoucherRouteBatchModel> UpdateVoucherRouteBatch(VoucherRouteBatchModel voucherRouteBatch, string token);
        Task<List<VoucherRouteBatchModel>> LoadAllBatchVoucher(FilterParameter filterParameter, string token);
        Task<List<VoucherRouteBatchDetailModel>> GetVoucherRouteBatchDetails(Int64 Id, string token);
        Task<List<VoucherRouteBatchAuditTrailModel>> GetVoucherRouteBatchAuditTrail(Int64 voucherRouteId, string token);
        Task<List<VoucherModel>> VoucherList(FilterParameter filterParameter, string token);
        Task<string> GetBatchVouchersReport(VoucherRouteBatchModel batch);
    }
}
