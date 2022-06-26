using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsEnums;

namespace fgciams.domain.clsExpenseLine
{
    public class ExpenseLineModel
    {
        public Int64 Id { get; set; }
        public string ExpenseName { get; set; }= string.Empty;
        public bool IsActive { get; set; }
        public string Remarks { get; set; }= string.Empty;
        public Int64 AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }= string.Empty;
        public Int64 AccountLineTypeId { get; set; }
        public string AccountLineTypeName { get; set; }= string.Empty;
        public Int64 AccountLineGroupId { get; set; }
        public string AccountLineGroupName { get; set; } = string.Empty;
        public Enums.AccountReportGroup AccountReportGroupId { get; set; }
        public Enums.AccountDefaultBalance AccountDefaultBalanceId { get; set; }
        public bool WithLedger { get; set; }
        public bool isShowChild { get;set; }
    }
}
