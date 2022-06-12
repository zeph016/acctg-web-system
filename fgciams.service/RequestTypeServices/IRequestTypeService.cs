using fgciams.domain.clsRequestType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.RequestTypeServices
{
    public interface IRequestTypeService
    {
        Task<RequestTypeModel> AddRequestType(RequestTypeModel requestType, string token);
        Task<RequestTypeModel> UpdateRequestType(RequestTypeModel requestType, string token);
        Task<RequestTypeModel> GetRequestType(Int64 Id, string token);
        Task<List<RequestTypeModel>> LoadRequestType(string token);
    }
}
