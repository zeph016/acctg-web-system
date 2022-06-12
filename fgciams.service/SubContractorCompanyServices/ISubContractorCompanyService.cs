using fgciams.domain.clsSubcon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.SubContractorCompanyServices
{
    public interface ISubContractorCompanyService
    {
        Task<List<SubContractorCompanyModel>> LoadSubContractorCompany(string token);
        Task<SubContractorCompanyModel> AddSubContractorCompany(SubContractorCompanyModel subContractorCompany, string token);
        Task<SubContractorCompanyModel> UpdateSubContractorCompany(SubContractorCompanyModel subContractorCompany, string token);
        Task<SubContractorCompanyModel> GetSubContractorCompanyId(Int64 Id, string token);

    }
}
