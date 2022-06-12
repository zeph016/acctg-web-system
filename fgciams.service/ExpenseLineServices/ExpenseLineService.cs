using fgciams.domain.clsExpenseLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsFilterParameter;

namespace fgciams.service.ExpenseLineServices
{
    public class ExpenseLineService : IExpenseLineService
    {
        public ExpenseLineService(HttpClient client)
        {
            this._client = client;
        }
        #region Properties
        private readonly HttpClient _client;
        #endregion

        #region Methods

        #region Load Expense Line
        public async Task<List<ExpenseLineModel>> LoadExpenseLine(string token)
        {
            var expenses = new List<ExpenseLineModel>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.GetAsync("expense-line/list/");
            if (responseMessage.IsSuccessStatusCode)
                expenses = await responseMessage.Content.ReadAsAsync<List<ExpenseLineModel>>();
            return expenses;
        }

        #endregion
        #region Add Expense Line
        public async Task<ExpenseLineModel> AddExpenseLine(ExpenseLineModel model, string token)
        {
            var expenses = new ExpenseLineModel();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("expense-line",model);
            if (responseMessage.IsSuccessStatusCode)
                expenses = await responseMessage.Content.ReadAsAsync<ExpenseLineModel>();
            return expenses;
        }

        #endregion
        #region Update Expense Line
        public async Task<ExpenseLineModel> UpdateExpenseLine(ExpenseLineModel model, string token)
        {
            var expenses = new ExpenseLineModel();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("expense-line",model);
            if (responseMessage.IsSuccessStatusCode)
                expenses = await responseMessage.Content.ReadAsAsync<ExpenseLineModel>();
            return expenses;
        }

        #endregion

        #endregion

    }
}
