using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DiscriminatorValueAttribute:Attribute
    {
        public object Value { get; set; }

        public DiscriminatorValueAttribute(object value)
        {
            Value = value;
        }

    }
}
