using fgciams.domain.clsCustomer;

namespace fgciams.service.CustomerServices
{
    public interface ICustomerService
    {
        Task<List<CustomerTypeModel>> LaodCustomerTypes(string token);
        Task<CustomerTypeModel> AddCustomerType(CustomerTypeModel model,string token);
        Task<CustomerTypeModel> UpdateCustomerType(CustomerTypeModel model,string token);
        Task<List<CustomerModel>> LoadCustomers(string token);
        Task<CustomerModel> AddCustomer(CustomerModel model,string token);
        Task<CustomerModel> UpdateCustomer(CustomerModel model,string token);
        Task<List<CustomerTypeModel>> GetCustomerSubTypes(long Id, string token);
    } 
}