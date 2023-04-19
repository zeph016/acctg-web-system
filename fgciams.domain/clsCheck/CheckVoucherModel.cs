using System.ComponentModel.DataAnnotations.Schema;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsCheck
{
    public class CheckVoucherModel
    {
        public Int64 Id { get; set; }
        public Int64 VoucherId { get; set; }
        public Int64 CheckId { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal Amount { get; set; } = 0.0m;

        //For mapping in check payee
        public string PayeeName { get; set; } = string.Empty;
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public Int64 PayeeId { get; set; }

        //extra do not map to add/update
        [NotMapped]
        public string VoucherCtrlNo { get; set; } = string.Empty;
        [NotMapped]
        public string VoucherNumber { get; set; } = string.Empty;
    }
}