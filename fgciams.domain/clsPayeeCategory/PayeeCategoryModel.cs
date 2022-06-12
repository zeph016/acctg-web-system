using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.domain.clsPayeeCategory
{
    public class PayeeCategoryModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public string CategoryName { get; set; } = default!;

    }
}