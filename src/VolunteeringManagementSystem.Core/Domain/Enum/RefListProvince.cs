using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Domain.Enum
{
    public enum RefListProvince:int
    {
        [Description("Gauteng")]
        Gauteng = 1,

        [Description("Limpopo")]
        Limpopo = 2,

        [Description("Free State")]
        FreeState = 3,

        [Description("North West")]
        NorthWest = 4,

        [Description("Mpumalanga")]
        Mpumalanga = 5,

        [Description("Eastern Cape")]
        EasternCape = 6,

        [Description("Western Cape")]
        WesternCape = 7,

        [Description("KwaZulu Natal")]
        KwazuluNatal = 8,

        [Description("Northern Cape")]
        NorthernCape = 9,
    }

}