using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsExpenseLine
{
    public class ExpenseLineModel
    {
        public Int64 Id { get; set; }
        public string ExpenseName { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
    }
}
