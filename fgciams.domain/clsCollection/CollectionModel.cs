using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fgciams.domain.clsEnums;
using fgciams.domain.clsExpenseLine;
using fgciams.domain.clsProject;

namespace fgciams.domain.clsCollection
{
    public class CollectionModel : CollectionAuditTrailModel
    {
        public Int64 Id { get; set; }
        public Int64 ChargeId { get; set; }
        public Enums.ProjectCategory ChargeCategoryId { get; set; }
        public string ControlNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select a project")]
        public string ChargeName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        [Required(ErrorMessage = "Date is required")]
        public DateTime? TransactionDate { get; set; }  = DateTime.Now;
        [Required(ErrorMessage = "Date is required")]
        public string TransactionDateString { get; set; } = string.Empty;
        public Int64 ExpenseId { get; set; }
        [Required(ErrorMessage = "Please select an Expense")]
        public string ExpenseName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Reference no. is required")]
        public string ReferenceNo { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Tax is required")]
        public decimal Tax { get; set; } = 1.00m;
        public decimal Mobilization { get; set; }
        public decimal Retention { get; set; }
        public decimal Others { get; set; }
        [Required(ErrorMessage = "Required*")]
        public decimal NetAmount { get; set; }
        [Required(ErrorMessage = "Official receipt is required")]
        public string OfficialReceipt { get; set; } = "0";
        public string Remarks { get; set; } = string.Empty;
        [Required(ErrorMessage = "Check number is required")]
        public string CheckNumber { get; set; } = string.Empty;
        public Enums.CollectionCategory CollectionCategoryId { get; set; }
        public Project rowCharging {get;set;} = new();
        public ExpenseLineModel rowExpenseLine {get;set;} = new();
        public bool isDeposit {get;set;}
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;
        public List<CollectionExpenseModel> CollectionExpenses { get; set; } = new();
        public List<CollectionExpenseModel> RemovedCollectionExpenses { get; set; } = new();
        public Enums.CollectionType CollectionTypeId { get; set; }
        public Int64 CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public Enums.ProjectCategory CustomerCategoryId { get; set; }
        public bool IsPDC { get; set; }
        public bool IsCollection {get;set;}
        public bool IsBilling {get;set;}
        public Enums.CollectionPaymentType PaymentTypeId { get; set; }
        public Enums.CollectionType CollectionType { get; set; }
        public bool IsVoid { get; set; }
        public decimal RunningBalance {get;set;}
        public DateTime? CheckDate {get;set;} = DateTime.Now;
        public bool IsShowCollectionsExpenses { get; set;}
        public Int64 StatusId { get; set; }
        public decimal TotalGrossAmount
        {
            get
            {
                return CollectionExpenses.Sum( x => x.Amount) + NetAmount;
            }
            set
            {
                GrossAmount = value;
            }
        }
        public decimal Percentage { get; set; }
        public decimal ContractAmount { get; set; }
        public string License { get; set; } = string.Empty;
        public decimal PrevPercentage { get; set; }
        public decimal PresPercentage { get; set; }
        public decimal ToDatePercentage { get; set; }
        public decimal PrevNetAmount { get; set; }
        public decimal ToDateNetAmount { get; set; }
        public decimal ToDateAmount { get; set; }
        public decimal PresentAmount { get; set; }
        public string ReportDate { get; set; } = string.Empty;
        public string ReportHeader { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PayeeName { get; set; } = string.Empty;
        public string ReportTitle { get; set; } = string.Empty;
        //Extra do not pass to service
        [NotMapped]
        public bool showSubDetails { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
    }
}