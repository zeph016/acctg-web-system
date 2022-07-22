using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsVoucherRouteBatch
{
   public class VoucherRouteBatchModel : VoucherRouteBatchAuditTrailModel
   {
        public VoucherRouteBatchModel()
        {
            ControlCount = 0;
            ControlNumber = "";
            Remarks = "";
            VoucherRouteBatchDetails = new List<VoucherRouteBatchDetailModel>();
            RemovedVoucherRouteBatchDetails = new List<VoucherRouteBatchDetailModel>();
        }
        
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BatchDate { get; set; }
        public int ControlCount { get; set; }
        public string ControlNumber { get; set; }
        public string Remarks {get; set;}
        public List<VoucherRouteBatchDetailModel> VoucherRouteBatchDetails { get; set; }
        public List<VoucherRouteBatchDetailModel> RemovedVoucherRouteBatchDetails { get; set; } 
        public Int64 PreparedById { get; set; }
        public string PreparedByName { get; set; }
        public bool ShowReport {get;set;}
    }     
}
