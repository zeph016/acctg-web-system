using fgciams.domain.clsSubConGeneralInformation;
using fgciams.domain.clsSubContractProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.SubConGeneralInformationServices
{
    public interface ISubConGeneralInformationService
    {
        Task<SubConGeneralInformationModel> AddSubConGenInfo(SubConGeneralInformationModel subConGeneral, string token);
        Task<SubConGeneralInformationModel> UpdateSubConGenInfo(SubConGeneralInformationModel subConGeneral, string token);
        Task<List<SubConGeneralInformationModel>> LoadSubConGenInfo(string token);
        Task<List<SubContractorProjectModel>> GetSubConProjects(long id, string token);
        Task<SubContractorProjectModel> AddSubConProjects(SubContractorProjectModel subconProj, string token);
        Task<SubContractorProjectModel> UpdateSubConProjects(SubContractorProjectModel subconProj, string token);
    }
}
