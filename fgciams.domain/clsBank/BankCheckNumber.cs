namespace fgciams.domain.clsBank
{
    public class BankCheckNumberModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; } = true;
        public Int64 BankId { get; set; }
        public Int64 CheckNoRangeFrom { get; set; }
        public Int64 CheckNoRangeTo { get; set; }
        public DateTime LogDateTime { get; set; }

        //added
        public bool isSelected { get; set; }
    }
}