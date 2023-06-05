using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace VolunteeringManagementSystem.Domain.Enum
{
    public enum RefListStatus:int
    {

        [Description("Not Started")]
        notStarted = 1,

        [Description("Progress")]
        progress= 2,

        [Description("Completed")]
        completed= 3,
        [Description("Other")]
        other = 4,
    }
}


