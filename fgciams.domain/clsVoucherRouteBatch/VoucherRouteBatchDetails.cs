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

      //Added
      public bool ShowDesc { get; set; }
    }
}
