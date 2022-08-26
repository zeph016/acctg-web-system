using System.ComponentModel.DataAnnotations;

namespace fgciams.domain.clsSupplier
{
   public class SupplierContactModel
    {
        public Int64 Id { get; set; }
        public Int64 SupplierId { get; set; }
        [Required(ErrorMessage = "Contact Name is required")] 
        public string ContactPerson { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required")] 
        public string ContactNumber { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}