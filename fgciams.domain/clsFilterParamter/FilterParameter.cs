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
        public string RequestCategoryId { get; set; }
        public bool IsRequestType{ get; set; }
        public string RequestTypeId { get; set; }
        public bool IsModeOfPayment { get; set; }
        public string ModeOfPaymentId { get; set; }
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
        public string SortColumnName { get; set; }
        public string SortDirection { get; set; }
        //Accounting
        public Enums.AccountingAccessLevel AccountingAccessLevel { get; set; }
        public bool IsVoid { get; set; }
        public bool IsRequestor { get; set; }
        public Int64 RequestorId { get; set; }
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
        }
    }
}