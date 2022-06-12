using fgciams.domain.clsExpenseLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.ExpenseLineServices
{
    public interface IExpenseLineService
    {
        Task<List<ExpenseLineModel>> LoadExpenseLine(string token);
        Task<ExpenseLineModel> UpdateExpenseLine(ExpenseLineModel model, string token);
        Task<ExpenseLineModel> AddExpenseLine(ExpenseLineModel model, string token);
    }
}
