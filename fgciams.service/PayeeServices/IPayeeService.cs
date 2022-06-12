using fgciams.domain.clsPayee;

namespace fgciams.service.PayeeServices{
    public interface IPayeeService{
        Task<List<PayeeModel>> LoadPayee(string token);
        Task<PayeeModel> AddPayee(PayeeModel model,string token);
        Task<PayeeModel> UpdatePayee(PayeeModel model,string token);
    }
}