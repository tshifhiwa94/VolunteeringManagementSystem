using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Domain.Enum
{
    public enum RefListTaskStatus:int
    {
        [Description("Not Started")]
        notStarted = 1,
        [Description("Assigned")]
        assigned = 2,
        [Description("Completed")]
        completed= 3,
        [Description("OverDue")]
        overdue = 4,

    }
}
