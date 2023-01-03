using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsFilterParameter
{
    public class FilterParameter
    {
        public bool isActive {get; set;}
        public bool IsName { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsLookUp {get; set;}
        public bool IsProject {get; set;}
        public string ProjectName {get; set;} = string.Empty;
        public bool IsId {get; set;}
        public bool IsControlNumber { get; set; }
        public bool IsPayee { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public Int64 PayeeId { get; set; }
        public string PayeeName { get; set; } = string.Empty;
        public string ControlNumber { get; set; } = string.Empty;
        public bool IsDate { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsAccountingStatus {get; set;}
        public string AccountingStatusId {get; set;}
        public bool IsPreparedBy { get; set; }
        public Int64 PreparedById { get; set; }
        public bool IsRequestCategory { get; set; }
        public string RequestCategoryId { get; set; } = string.Empty;
        public bool IsRequestType{ get; set; }
        public string RequestTypeId { get; set; } = string.Empty;
        public bool IsModeOfPayment { get; set; }
        public string ModeOfPaymentId { get; set; } = string.Empty;
        public bool IsLiqudationControlNumber { get; set; }
        public string LiquidationControlNumber { get; set; } = string.Empty;
        public bool IsPOControlNumber { get; set; }
        public string POControlNumber { get; set; } = string.Empty;
        public bool IsPOBillingControlNumber { get; set; }
        public string POBillingControlNumber { get; set; } = string.Empty;
        public bool IsPeriodDate { get; set; }
        public DateTime PeriodDateFrom { get; set; }
        public DateTime PeriodDateTo { get; set; }
        public bool IsPettyCash { get; set; }
        public string PettyCash { get; set; }        
        public bool IsPONumber {get; set; }
        public string PONumber {get;set;} = string.Empty;
        public bool IsSupplier { get; set; }
        public Int64 SupplierId { get; set; }
        public Enums.SupplierCategory POSupplierCategory { get; set; }
        //Others
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public int OffSet
        {
            get
            {
                return PageSize * PageNo;
            }
        }
        public string SortColumnName { get; set; } = string.Empty;
        public string SortDirection { get; set; } = string.Empty;
        //Accounting
        public Enums.AccountingAccessLevel AccountingAccessLevel { get; set; }
        public bool IsVoid { get; set; }
        public bool IsRequestor { get; set; }
        public Int64 RequestorId { get; set; }
        public bool IsBank { get; set; }
        [Required(ErrorMessage = "Required*")]
        public string BankId { get; set; }
        public bool IsCheckNumber { get; set; }
        public string CheckNumber { get; set; }
        public bool IsTermsOfPayment { get; set; }
        public string TermsOfPaymentId { get; set; }
        public bool IsMuniCity { get; set; }
        public string MuniCityId { get; set; }
        public bool IsTaxCode { get; set; }
        public string TaxCodeId { get; set; }        
        public bool HasVAT { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Required*")]
        public Int64 SubledgerId { get; set; }
        public Enums.ProjectCategory SubLedgerCategoryId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Required*")]
        public Int64 ScopeOfWorkId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Required*")]
        public Int64 ProjectId {get;set;}
        public Enums.ProjectCategory ProjectCategoryId {get;set;}
        [Range(1, int.MaxValue, ErrorMessage = "Required*")]
        public Int64 ExpenseId {get;set;}
        public bool IsExpense {get;set;}
        public bool IsDepositDate {get;set;}
        public DateTime DepositDateFrom { get; set; }
        public DateTime DepositDateTo { get; set; }
        //AR Ledger Filter
        public bool IsVoucherControlNumber { get; set; }
        public string VoucherControlNumber { get; set; }
        public bool IsReferenceNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public bool IsOR { get; set; }
        public string OR { get; set; }
        public bool IsAR { get; set; }
        public bool IsAP { get; set; }
        public bool IsCollection { get; set; }
        public bool IsBilling { get; set; }
        public bool IsCharged { get; set; }
        public Int64 ChargedId { get; set; }
        public Enums.ProjectCategory ChargedCategoryId { get; set; }
        public bool IsDepositCategoryId { get; set; }
        public Enums.CollectionPaymentType DepositCategoryId { get; set; }

        public FilterParameter()
        {
            isActive = true;
            IsName = false;
            Name = "";
            IsDate = false;
            DateFrom = DateTime.Now;
            DateTo = DateTime.Now;
            IsProject = false;
            ProjectName = "";
            PageSize = 0;
            IsPayee = false;
            PayeeCategoryId = 0;
            PayeeId = 0;
            IsVoid = false;
            IsRequestor = false;
            IsAccountingStatus = false;
            AccountingStatusId = string.Empty;
            RequestorId = 0;
            IsControlNumber = false;
            IsBank = false;
            BankId = string.Empty;
            IsCheckNumber = false;
            CheckNumber = string.Empty;
            IsTermsOfPayment = false;
            TermsOfPaymentId = string.Empty;
            IsMuniCity = false;
            MuniCityId = string.Empty;
            IsTaxCode = false;
            TaxCodeId = string.Empty;
            HasVAT = false;
        }
    }
}