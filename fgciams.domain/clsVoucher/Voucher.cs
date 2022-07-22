using fgciams.domain.clsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsVoucher
{
   public class VoucherModel : VoucherAuditTrailModel
    {
        public VoucherModel()
        {
            ControlCount = 0;
            VoucherDetails = new List<VoucherDetailModel>();
            RemovedVoucherDetails = new List<VoucherDetailModel>();

            VoucherRFP = new List<VoucherRFPModel>();
            RemovedVoucherRFP = new List<VoucherRFPModel>();
        }
        public Int64 Id { get; set; }
        public DateTime VoucherDate { get; set; }
        public int ControlCount { get; set; }
        public string ControlNumber { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public Int64 PayeeId { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public string PayeeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public Int64 PreparedById { get; set; }
        public string PreparedByName { get; set; } = string.Empty;
        public string PreparedByDesignation { get; set; } = string.Empty;
        public string PreparedByDepartment { get; set; } = string.Empty;
        public Int64 VerifiedById { get; set; }
        public string VerifiedByName { get; set; } = string.Empty;
        public string VerifiedByDesignation { get; set; } = string.Empty;
        public string VerifiedByDepartment { get; set; } = string.Empty;
        public Int64 ApprovedById { get; set; }
        public string ApprovedByName { get; set; } = string.Empty;
        public string ApprovedByDesignation { get; set; } = string.Empty;
        public string ApprovedByDepartment { get; set; } = string.Empty;
        public Int64 AccountingStatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public Enums.AccountingStatusEnumCategory StatusEnumCategoryId {get;set;}
        public string RFP {get; set;} = string.Empty;
        public bool IsActive {get;set;}
        public List<VoucherDetailModel> VoucherDetails { get; set; }
        public List<VoucherDetailModel> RemovedVoucherDetails { get; set; }
        public List<VoucherRFPModel> VoucherRFP { get; set; }
        public List<VoucherRFPModel> RemovedVoucherRFP { get; set; }
        public decimal CheckTotalAmount {get; set;}
        public decimal currentCheckAmount {get; set;}
        public decimal CheckBalance
        {
            get
            {
                return TotalAmount - CheckTotalAmount;
            }
        }
        public string CheckNumber { get; set; }
        public bool ShowReport {get; set;}
        public bool IsSelected {get; set;}
        public bool ShowDesc { get; set; }
        public bool IsFiled {get; set; }
        public bool isShowChild { get;set; }
        public bool isShowChecks { get;set; }
        public byte[] PreparedByPicture {get; set;} = new byte[]{};
        public byte[] VerifiedByPicture {get; set;} = new byte[]{};
        public byte[] ApprovedByPicture {get; set;} = new byte[]{};
        
    }
}
