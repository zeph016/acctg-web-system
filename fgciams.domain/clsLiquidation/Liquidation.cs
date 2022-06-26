using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsLiquidation
{
    public class LiquidationModel : LiquidationAuditTrailModel
    {
        public LiquidationModel()
        {
            Id = 0;
            IsActive = true;
            LiquidationDate = DateTime.Now;
            ControlNumber = "";
            ControlCount  = 0;
            TotalAmount = 0;
            PreparedById = 0;
            PreparedByName = "";
            PreparedByDesignation = "";
            PayeeId = 0;
            PayeeCategoryId = Enums.ProjectCategory.Project;
            PayeeName = "";
            ApprovedById = 0;
            ApprovedByDesignation = "";
            ApprovedByName = "";
            Remarks = "";
            StatusId = 0;
            StatusName = "";
            LiquidationDetails = new List<LiquidationDetailModel>();
            RemovedLiquidationDetails = new List<LiquidationDetailModel>();
        }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime LiquidationDate { get; set; }
        public string ControlNumber { get; set; }
        public int ControlCount { get; set; }
        public decimal TotalAmount { get; set; }
        public Int64 PreparedById { get; set; }
        public string PreparedByName { get; set; }
        public string PreparedByDesignation { get; set; }
        public Int64 PayeeId { get; set; }
        public string PayeeName { get; set; }
        public Enums.ProjectCategory PayeeCategoryId { get; set; }
        public Int64 ApprovedById { get; set; }
        public string ApprovedByName { get; set; } = string.Empty;
        public string ApprovedByDesignation { get; set; }
        public List<LiquidationDetailModel> LiquidationDetails { get; set; }
        public List<LiquidationDetailModel> RemovedLiquidationDetails { get; set; }
        public string Remarks { get; set; }
        public Int64 StatusId { get; set; }
        public string StatusName { get; set; }

        //extras
        public bool ShowReport {get; set;}
        public string StatusColor { get; set; }
        public bool ShowSubTable { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public byte[] PreparedByPicture {get; set;}
        public byte[] ApprovedByPicture {get; set;}
    }

}
