using fgciams.domain.clsEnums;
using fgciams.domain.clsProject;
using fgciams.domain.clsExpenseLine;
using fgciams.domain.clsDivision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsScopeOfWork;
using fgciams.domain.clsProjectChargingLine;
using fgciams.domain.clsSubConGeneralInformation;
using fgciams.domain.clsSubContractProject;
using System.ComponentModel.DataAnnotations.Schema;

namespace fgciams.domain.clsVoucher
{
    public class VoucherDetailModel : VoucherModel
    {
        public VoucherDetailModel() => IsActive = true;
        public Int64 Id { get; set; }
        public Int64 VoucherId { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public Int64 ExpenseId { get; set; }
        public string ExpenseName { get; set; } = string.Empty;
        public Int64 ProjectId { get; set; }
        public Enums.ProjectCategory ProjectCategoryId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ControlNumber { get; set; } = string.Empty;
        public DateTime VoucherDate { get; set; }
        public DateTime? PrevVoucherDate { get; set; } = DateTime.Now; 
        private decimal _Amount;
        public decimal Amount { 
        get
        {
            if(IsEWT)
                return -Math.Abs(_Amount);
            else
                return _Amount;
        } set{ _Amount = value;}
        } 
        public string Remarks { get; set; } = string.Empty;
        public Int64 DivisionId { get; set; }
        public string DivisionName { get; set; } = string.Empty;
        public bool IsActive {get; set;}
        public int TemporaryId {get; set;}
        public bool IsEWT { get; set; }
        ///

        [NotMapped]
        public Project selProj = new Project();
        [NotMapped]
        public Project selProjSubLedger = new Project();
        [NotMapped]
        public ExpenseLineModel selExp = new ExpenseLineModel();
        [NotMapped]
        public DivisionModel selDiv = new DivisionModel();
        [NotMapped]
        public SubContractorProjectModel selSubConProject = new SubContractorProjectModel();
        [NotMapped]
        public List<SubContractorProjectModel> selSubConProjectSOWList = new List<SubContractorProjectModel>();
        [NotMapped]
        public SubContractorProjectModel selSOW = new SubContractorProjectModel();
        [NotMapped]
        public string TaxCodeATC { get; set; }
        public string TaxCodeDescription { get; set; }
        public bool IsExcluded { get; set; } = false;
        public bool HasOR { get; set; }
        public Int64 ScopeOfWorkId { get; set; }
        public string ScopeOfWorkName { get; set; }
        public bool isLabor { get;set;} = false;
        public Int64 PayeeId { get; set; }
        public string PayeeName { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public Int64 SubLedgerId { get; set; }
        public Enums.ProjectCategory SubLedgerCategoryId { get; set; }
        public string SubLedgerName { get; set; } = String.Empty;
        public Enums.RFPDetailTypeId RFPDetailType {get;set;}
        public string InvoiceNo { get; set; }
        public DateTime? RFPPeriodDateFrom { get; set; }
        public DateTime? RFPPeriodDateTo { get; set; }
        public DateTime? PeriodFrom { get; set; } = DateTime.Now;
        public DateTime? PeriodTo { get; set; } = DateTime.Now;
        public Int64 BankId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public decimal CheckAmount { get; set; }
        public decimal currentRunningBal { get ;set; }
        public List<BankDetail> bankDetails { get; set;} = new();
        public decimal RunningBalances { get; set; }
        public decimal RunningBalance { get; set; } = 0.0m;
        public string ReportHeader { get; set; } = string.Empty;
        public string ReportDate { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        //For BIR
        public decimal SumOfGroup { get; set; } = 0.00m;
    }
    //use to set running balance in table note: not use in database
    public class BankDetail {
        public decimal runningBalance { get; set; } = 0.0m;
        public long bankID { get; set; }

    }
}
