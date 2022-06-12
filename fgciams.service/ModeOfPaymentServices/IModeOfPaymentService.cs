using fgciams.domain.clsModeOfPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.ModeOfPaymentServices
{
    public interface IModeOfPaymentService
    {
        #region Implementaions
        Task<List<ModeOfPaymentModel>> LoadModeOfPaymentList(string token);
        Task<ModeOfPaymentModel> AddModeOfPayment(ModeOfPaymentModel model,string token);
        Task<ModeOfPaymentModel> UpdateModeOfpayment(ModeOfPaymentModel model,string token);
        Task<ModeOfPaymentModel> GetModeOfPaymentSingleValue(Int64 modeOfPaymentId, string token);
        #endregion
    }
}
