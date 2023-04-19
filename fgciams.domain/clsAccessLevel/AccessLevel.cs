using fgciams.domain.clsEnums;
using System.ComponentModel.DataAnnotations.Schema;

namespace fgciams.domain.clsAccessLevel
{
    public class ModuleAssigmentModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public Enums.AISUserAccessLevel UserAccessLevelId { get; set; }
        public Enums.AISModules ModuleId { get; set; }
    }
    public class FunctionAssigmentModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public Enums.AISUserAccessLevel UserAccessLevelId { get; set; }
        public Enums.AISModules ModuleId { get; set; }
        public Enums.AISModuleFunctions ModuleFunctionId { get; set; }
    }
    public class ModuleModel
    {
        public Int64 Id { get; set; }
        public Enums.AISModules Module { get; set; }
        public bool isChecked { get; set; }
        //For sorting
        [NotMapped]
        public string ModuleName { get; set; } = string.Empty;
        [NotMapped]
        public bool IsSelected { get; set; }
    }
    public class ModuleFunctionsModel
    {
        public Int64 Id { get; set; }
        public Enums.AISModuleFunctions Function { get; set; }
        public bool isChecked { get; set; }
        [NotMapped]
        public string FunctionName { get; set; } = string.Empty;
    }

    public class ModuleParentModel
    {
        public long Id { get; set; }
        public Enums.AISParentModules ParentModule { get; set; }
        public List<ModuleModel> ModuleList { get; set; } = new();
        public bool IsSelected { get; set; }
    }
}