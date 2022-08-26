using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsSupplier;
namespace fgciams.service.SupplierServices
{
    public interface ISupplierService
    {
        Task<List<SupplierModel>> LoadListOfSupplier(FilterParameter param, string token);
        Task<SupplierModel> AddSupplier(SupplierModel supplier, string token);
        Task<SupplierModel> UpdateSupplier(SupplierModel supplier, string token);
        Task<List<SupplierContactModel>> GetSupplierContacts(long supplierID, string token);
        Task<SupplierContactModel> SaveContact(SupplierContactModel supplier, string token);
        Task<SupplierContactModel> UpdateContact(SupplierContactModel supplier, string token);
        Task<SupplierModel> GetSupplier(long supplierID, string token);
    }
}