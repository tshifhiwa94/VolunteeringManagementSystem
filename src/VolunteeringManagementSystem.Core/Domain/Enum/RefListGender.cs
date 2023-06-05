using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Domain.Enum
{
    public enum RefListGender:int
    {
        [Description("Male")]
        male = 1,

        [Description("Female")]
        female = 2,

        [Description("Other")]
        other = 3,
    }
}
