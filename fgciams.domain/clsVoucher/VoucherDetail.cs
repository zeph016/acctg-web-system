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

namespace fgciams.domain.clsVoucher
{
    public class VoucherDetailModel
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
        public bool showDesc { get; set; }
        public Project selProj = new Project();
        public ExpenseLineModel selExp = new ExpenseLineModel();
        public DivisionModel selDiv = new DivisionModel();
        public SubContractorProjectModel selSubConProject = new SubContractorProjectModel();
        public List<SubContractorProjectModel> selSubConProjectSOWList = new List<SubContractorProjectModel>();
        public string TaxCodeATC { get; set; }
        public string TaxCodeDescription { get; set; }
        public bool IsExcluded { get; set; } = false;
        public bool HasOR { get; set; }
        public Int64 ScopeOfWorkId { get; set; }
        public string ScopeOfWorkName { get; set; }
        public SubContractorProjectModel selSOW = new SubContractorProjectModel();
        public bool isLabor { get;set;}
        public Int64 PayeeId { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public Int64 SubLedgerId { get; set; }
        public Enums.ProjectCategory SubLedgerCategoryId { get; set; }
        public string SubLedgerName { get; set; } = String.Empty;
        public Enums.RFPDetailTypeId RFPDetailType {get;set;}
    }
}
