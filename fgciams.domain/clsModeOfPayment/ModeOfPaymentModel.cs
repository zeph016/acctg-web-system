using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsModeOfPayment
{
    public class ModeOfPaymentModel
    {
        public Int64 Id { get; set; }
        public string ModeName { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
