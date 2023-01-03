using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsRequest;
using fgciams.domain.clsVoucher;
using fgciams.domain.clsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsSubContractProject;

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
        Task<List<VoucherModel>> VoucherNotInCheck(FilterParameter param,string token);
        Task<VoucherModel> GetVATandEWT(Project voucher, string token);
        Task<List<VoucherDetailModel>> GetProjectSubledgers(FilterParameter parameter, string token);
        Task<SubContractorProjectModel> GetContractAmount(long subContractorId, long projectId, long SOWId, string token);
        Task<List<VoucherDetailModel>> GetSunbConProjects(FilterParameter parameter, string token);
    }
}
