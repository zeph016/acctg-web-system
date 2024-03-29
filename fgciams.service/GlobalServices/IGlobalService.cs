﻿using fgciams.domain.clsEmployee;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsProject;
using fgciams.domain.clsUserAccount;
using fgciams.domain.clsPayee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsProjectChargingLine;
using fgciams.domain.clsPO;

namespace fgciams.service.GlobalServices
{
    public interface IGlobalService
    {
        Task<List<UserAccount>> LoadAllEmployee(FilterParameter filterParameter, string token);
        Task<UserAccount> GetEmployeeById(Int64 EmployeeId, string token);
        Task<List<Project>> LoadProjects(FilterParameter filterParameter, string token);
        Task<List<Project>> LoadPayees(FilterParameter filterParameter, string token);
        Task<List<ProjectChargingLineModel>> LoadProjectLine(FilterParameter filterParameter, string token);
        Task<List<ProjectChargingLineModel>> projectChargingLine(FilterParameter filterParameter, string token);
        Task<List<POModel>> LoadPOs(FilterParameter filterParameter, string token);
    }
}
