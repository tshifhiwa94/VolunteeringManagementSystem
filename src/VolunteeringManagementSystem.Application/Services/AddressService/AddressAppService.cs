using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.AddressService.Dto;
using VolunteeringManagementSystem.Services.SkillService.Dto;

namespace VolunteeringManagementSystem.Services.AddressService
{
    public class AddressAppService:ApplicationService,IAddressAppService
    {
        private readonly IRepository<Address,Guid> _addressAppService;
        public AddressAppService(IRepository<Address, Guid> addressAppService)
        {
            _addressAppService = addressAppService;
        }

        [HttpPost]
        public async Task<AddressDto> CreateAsync(AddressDto input)
        {
            var address = ObjectMapper.Map<Address>(input); 
            return ObjectMapper.Map<AddressDto>(await _addressAppService.InsertAsync(address));
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _addressAppService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<List<AddressDto>> GetAllAsync()
        {
            var address = await _addressAppService.GetAllListAsync();
            return ObjectMapper.Map<List<AddressDto>>(address);
        }

        [HttpGet]
        public async Task<AddressDto> GetAsync(Guid id)
        {
            var address= await _addressAppService.GetAsync(id); 
            return ObjectMapper.Map<AddressDto>(address);
        }

        [HttpPut]
        public async Task<AddressDto> UpdateAsync(AddressDto input)
        {

            var address = _addressAppService.Get(input.Id);
            var update = await _addressAppService.UpdateAsync(ObjectMapper.Map(input, address));
            return ObjectMapper.Map<AddressDto>(update);
        }
    }
}
