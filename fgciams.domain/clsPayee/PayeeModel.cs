using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsPayeeCategory;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsPayee
{
    public class PayeeModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public string PayeeName { get; set; } = string.Empty;
        public string PayeeAddress { get; set; } = string.Empty;
        public string ShortcutName { get; set; } = string.Empty;
        public string PayeeContactNo { get; set; } = string.Empty;
        public bool HasInvoice { get; set; }
        public string TINNo { get; set; } = string.Empty;
        public PayeeCategoryModel PayeeCategory { get; set; } = default!;
        public Int64 PayeeCategoryId { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public bool subTable { get; set; }
    }
}