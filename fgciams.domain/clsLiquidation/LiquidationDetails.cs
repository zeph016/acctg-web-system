using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsEnums;
using fgciams.domain.clsPettyCash;

namespace fgciams.domain.clsLiquidation
{
    public class LiquidationDetailModel : PettyCashModel
    {
      public LiquidationDetailModel()
        {
            Id = 0;
            IsActive = true;
            PettyCashId = 0;
            LiquidationId = 0;
            RequestDate = DateTime.Now;
            PayeeId = 0;
            PayeeCategoryId = Enums.ProjectCategory.None;
            StatusId = 0;
            StatusName = "";
            Particular = "";
            Amount = 0;
            PayeeName = "";
            PayeeDepartment = "";
            PayeeSection = "";
            PayeePosition = "";
            DateNeeded = null;
            RequestedById = 0;
            RequestedByName = "";
            RequestedByDepartment = "";
            RequestedBySection = "";
            RequestedByPosition = "";
            RequestedByDepartment = "";
            RequestedBySection = "";
            RequestedByPosition = "";
            ApprovedById = 0;
            ApprovedByName = "";
            ApprovedByDepartment = "";
            ApprovedByPosition = "";
            Remarks = "";
            ControlNumber = "";
            ControlCount = 0;
            MRARTypeId = Enums.MRARType.None;
            ExpenseLineId = 0;
            ExpenseName = "";
            ChargingId = 0;
            ChargingName = "";
            TemporaryId = 0;
            StatusId = 0;
            ChargingCategoryId = Enums.ProjectCategory.Company;
        }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public Int64 PettyCashId { get; set; }
        public Int64 LiquidationId { get; set; }
        public Int64 ExpenseLineId { get; set; }
        public string ExpenseName { get; set; }
        public Int64 ChargingId { get; set; }
        public string ChargingName { get; set; }
        public Enums.ProjectCategory ChargingCategoryId { get; set; }
        
        ////
        public bool ShowSubTable { get; set; }
        public int TemporaryId {get; set;}
    }
    
}
