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

         [Description("Active")]
            active = 1,

        [Description("Completed")]
        completed= 2,

    }
}


