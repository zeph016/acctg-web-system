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
        public string ControlNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public Int64 PayeeId { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public string PayeeName { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public Int64 PreparedById { get; set; }
        public string PreparedByName { get; set; }
        public string PreparedByDesignation { get; set; }
        public string PreparedByDepartment { get; set; }
        public Int64 VerifiedById { get; set; }
        public string VerifiedByName { get; set; }
        public string VerifiedByDesignation { get; set; }
        public string VerifiedByDepartment { get; set; }
        public Int64 ApprovedById { get; set; }
        public string ApprovedByName { get; set; }
        public string ApprovedByDesignation { get; set; }
        public string ApprovedByDepartment { get; set; }
        public Int64 AccountingStatusId { get; set; }
        public string StatusName { get; set; }
        public string RFP {get; set;}
        public bool IsActive {get;set;}
        public List<VoucherDetailModel> VoucherDetails { get; set; }
        public List<VoucherDetailModel> RemovedVoucherDetails { get; set; }
        public List<VoucherRFPModel> VoucherRFP { get; set; }
        public List<VoucherRFPModel> RemovedVoucherRFP { get; set; }
        public bool ShowReport {get; set;}
    }
}
