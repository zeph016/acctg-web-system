
namespace fgciams.domain.clsDivision
{
    public class DivisionModel
    {
        public Int64 Id { get; set; }
        public string divisionName { get; set; } = default!;
        public string shortcutName { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}