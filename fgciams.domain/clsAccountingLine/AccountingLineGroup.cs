using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsAccountingLine
{
    public class AccountLineGroupModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public string LineGroupName { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
