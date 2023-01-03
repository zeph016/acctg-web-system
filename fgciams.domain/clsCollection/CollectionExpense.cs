using System.ComponentModel.DataAnnotations;
using fgciams.domain.clsExpenseLine;

namespace fgciams.domain.clsCollection
{
public class CollectionExpenseModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; } = true;
        public Int64 CollectionId { get; set; }
        public Int64 ExpenseId { get; set; }
        [Required(ErrorMessage = "Required*")]
        public string ExpenseName { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Required*")]
        public decimal Amount { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public ExpenseLineModel rowExpenseLine{get;set;} = new();
        public bool isExpenseNameEmpty {
        get
            {
                return String.IsNullOrEmpty(ExpenseName);
            }
        set{}
        }
        public bool isAmountNotValid {
        get
            {
            return Amount < 1;
            }
        set{}
        }
    }
}