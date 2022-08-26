using fgciams.domain.clsEnums;
using fgciams.domain.clsVoucher;

namespace fgciams.domain.clsBIR 
{
    public class VoucherBIRModel 
    {
        public VoucherBIRModel()
        {
            VoucherDetails = new List<VoucherDetailModel>();
        }
        public Int64 Id { get; set; }
        public Int64 VoucherBIRId { get; set; }
        public Int64 VoucherId { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public Int64 PayeeId { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public string PayeeName { get; set; }
        public string PayeeRegisteredAddress { get; set; }
        public string PayeeZipCode { get; set; }
        public string PayeeTIN { get; set; }
        public Int64 PayorId { get; set; }
        public string PayorName { get; set; }
        public string PayorRegisteredAddress { get; set; }
        public string PayorZipCode { get; set; }
        public string PayorTIN { get; set; }
        public List<VoucherDetailModel> VoucherDetails { get; set; }
        public VoucherModel Voucher { get; set; }
        public string PreparedBy 
        {     
            get
                {
                    return Personnel +" / "+PersonnelTin;
                }
            set{}
        }
        public string Personnel {get;set;}
        public string PersonnelTin {get;set;}
    }
}