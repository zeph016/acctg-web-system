using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsRequest;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsLiquidation;
using fgciams.domain.clsRequestForPaymentAuditTrail;

namespace fgciams.service.RequestForPaymentService
{
    public interface IRequestForPaymentService
    {
      Task<RequestForPaymentModel> AddRequestPayment(RequestForPaymentModel requestForPayment, string token);
      Task<RequestForPaymentModel> UpdateRequestPayment(RequestForPaymentModel requestForPayment, string token);
      Task<List<RequestForPaymentModel>> LoadRequestPayment(FilterParameter filterParameter, string token);
      Task<List<RequestForPaymentDetailModel>> LoadRequestPaymentDetail(Int64 requestId, string token);
      Task<List<LiquidationDetailModel>> LoadLiquidationNotInRFP(string token);
      Task<RequestForPaymentModel> UpdateRFPStatus(RequestForPaymentModel requestForPayment, string token);
      Task<List<RequestForPaymentAuditTrailModel>> RFPAuditTrails(long reqId, string token);
      Task<string> GenerateRFPReport(RequestForPaymentModel requestForPayment);
      Task<int> RFPListRowCount(FilterParameter param, string token);
      Task<RequestForPaymentModel> GetSignatories(long preparedById, string token);
    }
}
