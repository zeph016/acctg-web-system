namespace fgciams.domain.clsScopeOfWork
{
    public class ScopeOfWorkModel
    {
        public long Id { get; set; }
        public string ScopeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}