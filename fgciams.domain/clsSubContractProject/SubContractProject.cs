using fgciams.domain.clsEnums;

namespace fgciams.domain.clsSubContractProject
{
    public class SubContractorProjectModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; } = true;
        public Int64 SubContractorId { get; set; }
        public string SubContractorName { get; set; } = string.Empty;
        public Enums.ProjectCategory SubContactorCategoryId { get; set; }
        public Int64 ProjectId { get; set; }
        public string ProjectName { get; set; } = String.Empty;
        public Int64 ScopeOfWorkId { get; set; }
        public string ScopeOfWork { get; set; } = String.Empty;
        public decimal ContractAmount { get; set; } = 0.00m;
        public string Remarks { get; set; } = String.Empty;
    }
}