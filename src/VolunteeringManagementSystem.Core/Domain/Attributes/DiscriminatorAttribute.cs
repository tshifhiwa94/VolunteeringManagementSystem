using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Domain.Attributes
{
    public class DiscriminatorAttribute:Attribute
    {
        public string DiscriminatorColumn { get; set; }

        public bool UseDiscriminator { get; set; }

        public bool FilterUnknownDiscriminators { get; set; }
        public DiscriminatorAttribute() {

            DiscriminatorColumn = "Frwk.Discriminator";

            UseDiscriminator = true;

            FilterUnknownDiscriminators = false;
        }

    }
}
