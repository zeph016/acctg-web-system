
namespace fgciams.domain.clsBillingDocument
{
    public class BillingDocumentModel
    {
        public Int64 Id { get; set; }
        public string DocumentName { get; set; } = default!;
        public string Remarks { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}