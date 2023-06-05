using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;

namespace VolunteeringManagementSystem.Services.AddressService.Dto
{
    [AutoMap(typeof(Address))]
    public class AddressDto:EntityDto<Guid>
    {
        public  string StreetName { get; set; }
        public string City { get; set; }
        public  string Province { get; set; }
        public string PostalCode { get; set; }
    }
}
