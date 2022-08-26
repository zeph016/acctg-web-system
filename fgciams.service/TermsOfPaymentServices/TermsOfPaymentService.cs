using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsTermsOfPayment;

namespace fgciams.service.TermsOfPaymentServices
{
  public class TermsOfPaymentService : ITermsOfPaymentService
  {
    public TermsOfPaymentService(HttpClient client)
    {
      this._client = client;
    }
    private readonly HttpClient _client;
    public async Task<TermsOfPaymentModel> AddTermsOfPayment(TermsOfPaymentModel terms, string token)
    {
      var termsOfPay = new TermsOfPaymentModel();
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/terms-of-payment", terms);
      if(responseMessage.IsSuccessStatusCode)
        termsOfPay = await responseMessage.Content.ReadAsAsync<TermsOfPaymentModel>();
      return termsOfPay;
    }

    public async Task<List<TermsOfPaymentModel>> LoadTermsOfPayment(string token)
    {
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.GetAsync("/terms-of-payment/list");
      responseMessage.EnsureSuccessStatusCode();
      return await responseMessage.Content.ReadAsAsync<List<TermsOfPaymentModel>>();
    }

    public async Task<TermsOfPaymentModel> UpdateTermsOfPayment(TermsOfPaymentModel terms, string token)
    {
      var termsOfPay = new TermsOfPaymentModel();
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("/terms-of-payment", terms);
      if(responseMessage.IsSuccessStatusCode)
        termsOfPay = await responseMessage.Content.ReadAsAsync<TermsOfPaymentModel>();
      return termsOfPay;
    }
  }
}