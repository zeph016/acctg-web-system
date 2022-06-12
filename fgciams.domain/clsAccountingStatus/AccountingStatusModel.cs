using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsAccountingStatus
{
    public class AccountingStatusModel
    {
        public Int64 Id { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string StatusIcon { get; set; } = string.Empty;
        public string StatusColor { get; set; } = string.Empty;
        public Enums.AccountingStatusEnumCategory StatusEnumCategoryId { get; set; }
    }
}
