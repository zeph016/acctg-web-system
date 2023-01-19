using fgciams.domain.clsEnums;
using fgciams.domain.clsSubContractProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsSubConGeneralInformation
{
    public class SubConGeneralInformationModel
    {
      public SubConGeneralInformationModel()
      {
        Id = 0;
        FirstName = "";
        LastName = "";
        MiddleName = "";
        NameExtention = "";
        Gender  = Enums.Gender.Male;
        IsActive = true;
        Age = 0;
        CompanyId = 0;
        CompanyName = "";
        PositionId = 0;
        PositionName = "";
        SubContractorProjects = new List<SubContractorProjectModel>();
        RemovedSubContractorProjects = new List<SubContractorProjectModel>();
      }
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NameExtention { get; set; }
        public Enums.Gender Gender { get; set; }     
        public bool IsActive { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int Age { get; set; }
        public Int64 CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Int64 PositionId { get; set; }
        public string PositionName { get; set; }
        public string WorkSpecialty { get; set; }
        public Enums.LaborType LaborTypeId { get; set; }
        public Enums.FinancialCapabilityCategory FinancialCapabilityCategoryId { get; set; }
        public string ContactNumber { get; set; }
        public int ManPowerNo { get; set; }
        public string Address { get; set; }
        public string BankAccountNo { get; set; }
        public string EmployeeName
        {
            get
            {
                return LastName + ", " + FirstName + " " + MiddleName;
            }
        }
        public List<SubContractorProjectModel> SubContractorProjects { get; set; }
        public List<SubContractorProjectModel> RemovedSubContractorProjects { get; set; }
    }
}
