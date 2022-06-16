using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.common
{
    public class HttpException
    {
        public static ApplicationException HttpExceptionMessage(string customMessage)
        {
            return new ApplicationException(customMessage + " already exists");
        }
    }
}
