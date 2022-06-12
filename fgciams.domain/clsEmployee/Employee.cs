using fgciams.domain.clsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsEmployee
{
    public class Employee
    {
        public Int64 EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NameExtension { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string SectionName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public DateTime DateHired { get; set; }
        public string Address { get; set; } = string.Empty;
        public byte[] Picture { get; set; } = default!;
        public string EmployeeName
        {
            get
            {
                var _employeename = "";
                if (!string.IsNullOrEmpty(NameExtension))
                    _employeename = FirstName + " " + LastName + " " + NameExtension;
                else
                    _employeename = FirstName + " " + LastName;
                return _employeename;
            }
        }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string SystemName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        //public Enums.AccessLevel AccessLevel { get; set; }
    }
}
