using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsTermsOfPayment;

namespace fgciams.service.TermsOfPaymentServices
{
  public interface ITermsOfPaymentService
  {
    Task<TermsOfPaymentModel> AddTermsOfPayment(TermsOfPaymentModel terms , string token);
    Task<TermsOfPaymentModel> UpdateTermsOfPayment(TermsOfPaymentModel terms, string token);
    Task<List<TermsOfPaymentModel>> LoadTermsOfPayment(string token);
  }
}