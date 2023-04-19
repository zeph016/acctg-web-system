
namespace fgciams.domain.clsDivision
{
    public class DivisionModel
    {
        public Int64 Id { get; set; }
        public string divisionName { get; set; } = string.Empty;
        public string shortcutName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}