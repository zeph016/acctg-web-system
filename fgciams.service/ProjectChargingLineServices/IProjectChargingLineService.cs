using fgciams.domain.clsProjectChargingLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.ProjectChargingLineServices
{
    public interface IProjectChargingLineService
    {
        Task<ProjectChargingLineModel> AddProjectChargingLine(ProjectChargingLineModel projectChargingLineModel, string token);
        Task<ProjectChargingLineModel> UpdateProjectChargingLine(ProjectChargingLineModel projectChargingLineModel, string token);
        Task<List<ProjectChargingLineModel>> LoadProjectChargingLine(string token);
    }
}
