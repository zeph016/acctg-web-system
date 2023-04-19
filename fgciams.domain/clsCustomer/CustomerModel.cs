namespace fgciams.domain.clsCustomer
{
    public class CustomerModel
    {
        public Int64 Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public string CustomerTypeNameId { get; set; } = string.Empty;
        public int CustomerType_Id { get; set; }
        public string ContactNo { get; set; } = string.Empty;
    }
}