using fgciams.domain.clsVoucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsVoucherRouteBatch
{
    public class VoucherRouteBatchDetailModel : VoucherModel
    {
      public VoucherRouteBatchDetailModel()
      {
        Id = 0;
        VoucherId = 0;
        VoucherRouteBatchId = 0;
        IsFiled = true;
      }
      public Int64 Id { get; set; }
      public Int64 VoucherId { get; set; }
      public Int64 VoucherRouteBatchId { get; set; }
      public bool IsFiled {get; set;}
      public decimal TotalAmount {get; set; }
      public string checkNumber { get; set; }

      //send to report
      public string checkNo {
        get { return checkNumber.Trim().Equals("")? "N/A": checkNumber; }
        set {}
      }

      //Added
      public bool ShowDesc { get; set; }
    }
}
