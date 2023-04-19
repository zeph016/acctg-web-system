namespace fgciams.domain.clsCustomer
{
    public class CustomerTypeModel
    {
        public Int64 Id { get; set; }
        public string CustomerTypeName { get; set; } = string.Empty;
        public string CustomerSubTypeName { get; set; } = string.Empty;
        public string CustomerSubTypeShortcut { get; set; } = string.Empty;
        public byte[] LogoPicture { get; set; } = new byte[]{};
    }
}