using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Domain.Enums
{
    public enum GenderType
    {
        [Description("بدون جنسیت")]
        Unknown = 0,
        [Description("مرد")]
        Male,
        [Description("زن")]
        Female
    }

}
