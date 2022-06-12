using fgciams.domain.clsSubContractorPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fgciams.service.SubContractorPositionServices
{
    public interface ISubContractorPositionService
    {
        Task<SubContractorPositionModel> AddSubContractorPosition(SubContractorPositionModel subConPosition, string token);
        Task<SubContractorPositionModel> UpdateSubContractorPosition(SubContractorPositionModel subConPosition, string token);
        Task<List<SubContractorPositionModel>> LoadSubContractorPosition(string token);
        Task<SubContractorPositionModel> GetSubContractorPositionId(Int64 Id, string token);
    }
}
