using System.ComponentModel.DataAnnotations;

namespace fgciams.domain.clsSupplier
{
    public class SupplierModel
    {
        public SupplierModel()
        {
            SupplierContacts = new List<SupplierContactModel>();
            RemovedSupplierContacts = new List<SupplierContactModel>();
        }
        public bool IsActive { get; set; } = true;
        public Int64 Id { get; set; }
        public Int64 SupplierId { get; set; }
        [Required(ErrorMessage = "Supplier Name is required")] 
        public string SupplierName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Short Name is required")] 
        public string ShortcutName { get; set; } = string.Empty;
         [Required(ErrorMessage = "TIN is required")] 
        public string TIN { get; set; }  = string.Empty;
        [Required(ErrorMessage = "DocType is required")] 
        public string DocumentType { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address is required")] 
        public string Address { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Select a Payment Term")]
        public int DefaultTermId { get; set; }
        public string TermName { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Select a location")]
        public int MuniCityId { get; set; }
        public string MuniCityName { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Select a Tax Code")]
        public Int64 TaxCodeId { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxRate { get; set; }
        public bool HasVAT { get; set; }
        public bool HasInvoice { get; set; }
        [Required(ErrorMessage = "Registration No. Permit is required")] 
        public string RegistrationNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Business Permit No. is required")] 
        public string BusinessPermit { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Select a Bank")]
        public Int64 BankId { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        [Required(ErrorMessage = "Account name is required")] 
        public string BankAccountName { get; set; } = string.Empty;
        public bool isShowOthers {get;set;}
        public List<SupplierContactModel> SupplierContacts { get; set; } = new();
        public List<SupplierContactModel> RemovedSupplierContacts { get; set; } = new();
    }
}