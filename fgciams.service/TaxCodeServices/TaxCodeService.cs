using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsTaxCode;

namespace fgciams.service.TaxCodeServices
{
  public class TaxCodeService : ITaxCodeService
  {
    public TaxCodeService(HttpClient client)
    {
      this._client = client;
    }
    private readonly HttpClient _client;
    public async Task<TaxCodeModel> AddTaxCode(TaxCodeModel taxCode, string token)
    {
      var tax = new TaxCodeModel();
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/tax-code/", taxCode);
      if(responseMessage.IsSuccessStatusCode)
        tax = await responseMessage.Content.ReadAsAsync<TaxCodeModel>();
      return tax;
    }

    public async Task<List<TaxCodeModel>> LoadTaxCode(FilterParameter filterParameter, string token)
    {
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.GetAsync("/tax-code/list");
      responseMessage.EnsureSuccessStatusCode();
      return await responseMessage.Content.ReadAsAsync<List<TaxCodeModel>>();
    }

    public async Task<TaxCodeModel> UpdateTaxCode(TaxCodeModel taxCode, string token)
    {
      var tax = new TaxCodeModel();
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("/tax-code/", taxCode);
      if(responseMessage.IsSuccessStatusCode)
        tax = await responseMessage.Content.ReadAsAsync<TaxCodeModel>();
      return tax;
    }
  }
}