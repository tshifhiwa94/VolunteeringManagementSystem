using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Domain.Enum
{
    public enum RefListTitle:int
    {
        [Description("MR")]
        mr = 1,

        [Description("MRS")]
        mrs = 2,

        [Description("DR")]
        dr = 3,

        [Description("Other")]
        other = 4,
    }

}