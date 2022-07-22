namespace fgciams.domain.clsAccountType
{
    public class AccountTypeModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}