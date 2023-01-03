using fgciams.domain.clsEnums;
using fgciams.domain.clsVoucher;

namespace fgciams.domain.clsBIR 
{
    public class VoucherBIRModel 
    {
        public Int64 Id { get; set; }
        public Int64 VoucherBIRId { get; set; }
        public Int64 VoucherId { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public Int64 PayeeId { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public string PayeeName { get; set; } = string.Empty;
        public string PayeeRegisteredAddress { get; set; } = string.Empty;
        public string PayeeZipCode { get; set; } = string.Empty;
        public string PayeeTIN { get; set; } = string.Empty;
        public Int64 PayorId { get; set; }
        public string PayorName { get; set; } = string.Empty;
        public string PayorRegisteredAddress { get; set; } = string.Empty;
        public string PayorZipCode { get; set; } = string.Empty;
        public string PayorTIN { get; set; } = string.Empty;
        public VoucherModel Voucher { get; set; } = new();
        public List<VoucherDetailModel> VoucherDetails = new();
        public string PreparedBy 
        {     
            get
                {
                    return Personnel +" / "+PersonnelTin;
                }
            set{}
        }
        public string Personnel {get;set;}  = string.Empty;
        public string PersonnelTin {get;set;} = string.Empty;
    }
}