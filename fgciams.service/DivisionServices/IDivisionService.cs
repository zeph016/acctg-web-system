using fgciams.domain.clsModeOfPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsDivision;

namespace fgciams.service.DivisionServices
{
    public interface IDivisionService
    {
        #region Implementaions
        Task<List<DivisionModel>> LoadDivisionList(string token);
        Task<DivisionModel> AddDivision(DivisionModel divisionModel,string token);
        Task<DivisionModel> UpdateDivision(DivisionModel divisionModel,string token);
        Task<DivisionModel> GetDivisionSingleValue(Int64 divisionId, string token);
        #endregion
    }
}
