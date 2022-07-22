using fgciams.domain.clsEnums;
using fgciams.domain.clsProject;
using fgciams.domain.clsExpenseLine;
using fgciams.domain.clsDivision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal Amount { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public Int64 DivisionId { get; set; }
        public string DivisionName { get; set; } = string.Empty;
        public bool IsActive {get; set;}
        public int TemporaryId {get; set;}
        ///
        public bool showDesc { get; set; }
        public Project selProj = new Project();
        public ExpenseLineModel selExp = new ExpenseLineModel();
        public DivisionModel selDiv = new DivisionModel();
    }
}
