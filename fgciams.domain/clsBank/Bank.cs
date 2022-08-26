using fgciams.domain.clsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsBank
{
    public class BankModel
    {
        public BankModel()
        {
            Id = 0;
            Remarks = "";
            IsActive = true;
        }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string ShortcutName { get; set; } = string.Empty;
        public string BankBranch { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public Enums.BankCurrency CurrencyId { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public decimal BeginningBalance { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public bool subTable { get; set; }
        public Nullable<Int64> BankCheckNumberId { get; set; } = 0;
        public List<BankCheckNumberModel> BankCheckNumbers { get; set; }
        public List<BankCheckNumberModel> RemovedBankCheckNumbers { get; set; }
    }
}
