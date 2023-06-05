using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Services.RefListHelper
{
    public static class RefListHelper
    {
        public static string GetnumDescription<T>(this T Value) where T : struct, Enum
        {

            FieldInfo fi = Value.GetType().GetField(Value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return Value.ToString();
            }
        }
    }
}
