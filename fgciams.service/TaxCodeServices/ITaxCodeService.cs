using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsTaxCode;

namespace fgciams.service.TaxCodeServices
{
  public interface ITaxCodeService
  {
    Task<List<TaxCodeModel>> LoadTaxCode(FilterParameter filterParameter, string token);
    Task<TaxCodeModel> AddTaxCode(TaxCodeModel taxCode, string token);
    Task<TaxCodeModel> UpdateTaxCode(TaxCodeModel taxCode, string token);
    
  }
}