using fgciams.domain.clsBillingDocument;
using fgciams.domain.clsEnums;
using fgciams.domain.clsRequestForPaymentAuditTrail;
using fgciams.domain.clsRFPBillingDocuments;
using fgciams.domain.clsVoucher;
using fgciams.domain.clsCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace fgciams.domain.clsRequest
{
    public class RequestForPaymentModel : RequestForPaymentAuditTrailModel
    {
      public RequestForPaymentModel()
      {
            Id = 0;
            IsActive = true;
            RequestDate = DateTime.Now;
            RequestCategoryId = Enums.AccountingRequestCategory.RFP;
            PayeeId = 0;
            PayeeCategoryId = Enums.ProjectCategory.Project;
            PayeeName = "";
            PayeeDepartment = "";
            PayeeSection = "";
            PayeePosition = "";
            DateNeeded = DateTime.Now;
            PreparedById = 0;
            PreparedByName = "";
            PreparedByDepartment = "";
            PreparedBySection = "";
            PreparedByPosition = "";
            RequestedById = 0;
            RequestedByName = "";
            RequestedByDepartment = "";
            RequestedBySection = "";
            RequestedByPosition = "";
            RecommendedById = 0;
            RecommendedByName = "";
            RecommendedByDepartment = "";
            RecommendedBySection = "";
            RecommendedByPosition = "";
            ApprovedById = 0;
            ApprovedByName = "";
            ApprovedByDepartment = "";
            ApprovedBySection = "";
            ApprovedByPosition = "";
            ModeOfPaymentId = 0;
            ModeOfPayment = "";
            AccountingStatusId = 0;
            RequestTypeId = 0;
            RequestTypeName = "";
            AccountingStaus = "";
            Remarks = "";
            RequestForPaymentDetails = new List<RequestForPaymentDetailModel>();
            RemovedRequestForPaymentDetails = new List<RequestForPaymentDetailModel>();
            RFPBillingDocuments = new List<RFPBillingDocumentModel>();
            RemovedRFPBillingDocuments = new List<RFPBillingDocumentModel>();
            BankId = 0;
            BankName = "";
            AccountNo = "";
            ControlCount = 0;
            ControlNumber = "";
            BankAccountNo = "";
            ARPhp = 0;
            RetentionPhp = 0;
            RFPDetailTypeId = 0;
        }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? RequestDate { get; set; } 
        public Enums.AccountingRequestCategory RequestCategoryId { get; set; } 
        public Int64 PayeeId { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public string PayeeName { get; set; } 
        public string PayeeDepartment { get; set; }
        public string PayeeSection { get; set; }
        public string PayeePosition { get; set; }
        public DateTime? DateNeeded { get; set; }
        public Int64 PreparedById { get; set; }
        public string PreparedByName { get; set; }
        public string PreparedByDepartment { get; set; }
        public string PreparedBySection { get; set; }
        public string PreparedByPosition { get; set; }
        public Int64 RequestedById { get; set; }
        public string RequestedByName { get; set; }
        public string RequestedByDepartment { get; set; }
        public string RequestedBySection { get; set; }
        public string RequestedByPosition { get; set; }
        public Int64 RecommendedById { get; set; }
        public string RecommendedByName { get; set; }
        public string RecommendedByDepartment { get; set; }
        public string RecommendedBySection { get; set; }
        public string RecommendedByPosition { get; set; }
        public Int64 ApprovedById { get; set; }
        public string ApprovedByName { get; set; }
        public string ApprovedByDepartment { get; set; }
        public string ApprovedBySection { get; set; }
        public string ApprovedByPosition { get; set; }
        public Int64 ModeOfPaymentId { get; set; }
        public string ModeOfPayment { get; set; }
        public Int64 AccountingStatusId { get; set; }
        public Int64 RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public string AccountingStaus { get; set; }
        public string Remarks { get; set; }
        public List<RequestForPaymentDetailModel> RequestForPaymentDetails { get; set; }
        public List<RequestForPaymentDetailModel> RemovedRequestForPaymentDetails { get; set; }
        public List<RFPBillingDocumentModel> RFPBillingDocuments { get; set; }
        public List<RFPBillingDocumentModel> RemovedRFPBillingDocuments { get; set; }
        public Int64 BankId { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public int ControlCount { get; set; }
        public string ControlNumber { get; set; }
        public string BankAccountNo { get; set; } = string.Empty;
        public decimal ARPhp { get; set; }
        public decimal RetentionPhp { get; set; }
        public decimal Amount {get; set;}
        public string RFP{get; set;} = string.Empty;
        public Enums.RFPDetailTypeId RFPDetailTypeId { get; set; }
        public bool ShowReport {get; set;}
        [NotMapped]
        public byte[] PreparedByPicture {get;set;} = new byte[]{};
        [NotMapped]
        public byte[] RequestedByPicture {get;set;} = new byte[]{};
        [NotMapped]
        public byte[] RecommendedByPicture {get;set;} = new byte[]{};
        [NotMapped]
        public byte[] ApprovedByPicture {get;set;} = new byte[]{};
        public string StatusName {get;set;} = string.Empty;
        public Enums.AccountingStatusEnumCategory StatusEnumCategoryId {get;set;}
        public DateTime? PeriodDateFrom { get; set; } = DateTime.Now;
        public DateTime? PeriodDateTo { get; set; } = DateTime.Now;
        public string VoucherDate { get; set; } = string.Empty;
        public string VoucherNumber { get; set; } = string.Empty;
        public string VoucherStatus { get; set; } = string.Empty;
        public List<VoucherModel> vouchers { get; set; } = new();
        public string CheckDate { get; set; } = string.Empty;
        public string CheckNumber { get; set; } = string.Empty;
        public string CheckStatus { get; set; } = string.Empty;
        public List<CheckModel> checks { get; set; } = new();
    }
}
