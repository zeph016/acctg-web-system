using System;
using System.Collections.Generic;
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
        public DateTime PeriodToFrom { get; set; }
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
        public string BankId { get; set; }
        public bool IsCheckNumber { get; set; }
        public string CheckNumber { get; set; }
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
            CheckNumber = "";
        }
    }
}