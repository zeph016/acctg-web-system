using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsRequestType
{
    public class RequestTypeModel
    {
       public RequestTypeModel()
       {
         Id = 0;
         TypeName = "";
         IsActive = true;
         Remarks = "";
       }
        public Int64 Id { get; set; }
        public string TypeName { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
    }
}
