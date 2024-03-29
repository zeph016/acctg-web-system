﻿using fgciams.domain.clsEnums;
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
        public string EmployeeName
        {
            get
            {
                return LastName + ", " + FirstName + " " + MiddleName;
            }
        }

    }
}
