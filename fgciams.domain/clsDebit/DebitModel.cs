using System.ComponentModel.DataAnnotations;

namespace fgciams.domain.clsDebit
{
public class DebitModel : DebitAuditTrailModel
    {
        public Int64 Id { get; set; }
        public DateTime? DebitDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; } = 0.00m;
        public int ControlCount { get; set; }
        public string ControlNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        [Range(1, int.MaxValue, ErrorMessage = "Required*")]
        public Int64 BankId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public Int64 PreparedById  { get; set; }
        public string PreparedByName { get; set; } = string.Empty;
    }
}