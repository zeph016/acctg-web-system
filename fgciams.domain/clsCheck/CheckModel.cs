using fgciams.domain.clsEnums;

namespace fgciams.domain.clsCheck
{
    public class CheckModel : CheckAuditTrailModel
    {
        public CheckModel()
        {
            CheckVouchers = new List<CheckVoucherModel>();
        }
        public bool IsActive { get; set; } = true;
        public Int64 Id { get; set; } = 0;
        public Int64 UserId { get; set; } = 0;
        public DateTime? CheckDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; } = 0.0m;
        public DateTime? IssuedDate { get; set; } =DateTime.Now;
        public string CheckNo { get; set; } = string.Empty;
        public Int64 BankId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public Int64 PayeeId { get; set; } = 0;
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public string PayeeName { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public Int64 PreparedById { get; set; }
        public string PreparedByName { get; set; } = string.Empty;
        public Int64 AccountingStatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public List<CheckVoucherModel> CheckVouchers { get; set; }
        public List<CheckVoucherModel> RemovedCheckVouchers { get; set; } = new();
        public int ControlCount { get; set; }
        public string ControlNumber { get; set; } = string.Empty;
        public string Activity {get;set;} = string.Empty;
        public string AmountInWords {get;set;} = "***Zero***";
        public string Description {get;set;} = string.Empty;
        public bool isShowChild {get;set;}
        public bool showReport {get;set;}
        public DateTime? StatusDate {get;set;} = DateTime.Now;
        public Enums.CheckCategory CheckCategoryId { get; set; }
        public string CheckCategory
        {
            get
            {
                DateTime checkDate = Convert.ToDateTime(CheckDate?.ToString("MM/dd/yyyy"));
                var months = (DateTime.Now.Year - checkDate.Year) * 12 + DateTime.Now.Month - checkDate.Month + (checkDate.Day >= DateTime.Now.Day ? 0 : -1);
                if(AccountingStatusId == 17 && months < 6 && checkDate > DateTime.Now) //Check not cleared and within 6months
                    return "In-Transit";
                if(AccountingStatusId == 17  && months > 6) //Check not cleared and greater then 6 months, 17 is C-Issued
                    return "Stale Check";
                return "Post-Dated";
            }
        }
    }
}