using System.Net.Http.Headers;
using fgciams.domain.clsPayeeCategory;

namespace fgciams.service.PayeeCategoryServices
{
    public interface  IPayeeCategoryService
    {
        #region Implementations
        Task<List<PayeeCategoryModel>> LoadListOfPayeeCategory(string token);
        Task<PayeeCategoryModel> AddPayeeCategory(PayeeCategoryModel model,string token);
        Task<PayeeCategoryModel> UpdatePayeeCategory(PayeeCategoryModel model,string token);
        Task<PayeeCategoryModel> GetSingleValuePayeeCategory(Int64 payeeCategoryId, string token);
        #endregion
    }
}