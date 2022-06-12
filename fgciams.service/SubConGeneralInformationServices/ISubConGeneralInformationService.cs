using fgciams.domain.clsSubConGeneralInformation;
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
    }
}
