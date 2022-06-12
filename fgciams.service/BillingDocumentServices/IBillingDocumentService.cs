using fgciams.domain.clsBillingDocument;
using fgciams.domain.clsRFPBillingDocuments;

namespace fgciams.service.BillingDocumentServices
{
    public interface IBillingDocumentService
    {
      Task<List<BillingDocumentModel>> LoadListOfBillingDocuments(string token);
      Task<BillingDocumentModel> AddBillingDocument(BillingDocumentModel model, string token);
      Task<BillingDocumentModel> UpdateBillingDocument(BillingDocumentModel model, string token);
      Task<List<RFPBillingDocumentModel>> GetBillingDocument(Int64 Id, string token);
    }
}
