using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.DepartmentService.Dto;

namespace VolunteeringManagementSystem.Services.DepartmentService
{
    public class DepartmentAppService:ApplicationService,IDepartmentAppService
    {
        private readonly IRepository<Department, Guid> _repository;
   
        public DepartmentAppService(IRepository<Department, Guid> repository)
        {
            _repository = repository;
            
        }

        public async Task<DepartmentDto> CreateAsync(DepartmentDto input)
        {
            if (input == null) throw new UserFriendlyException("No deatails was Provided");
            var department = ObjectMapper.Map<Department>(input);
            return ObjectMapper.Map<DepartmentDto>(await _repository.InsertAsync(department));
        }

        public async Task DeleteAsnyc(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<DepartmentDto>> GetAllAsnyc()
        {
            var department =await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<DepartmentDto>>(department);
        }

        public async Task<DepartmentDto> GetAsnyc(Guid id)
        {
            var departmentId=await _repository.GetAsync(id);

            return ObjectMapper.Map<DepartmentDto>(departmentId);


        }

        public async Task<DepartmentDto> UpdateAsync(DepartmentDto input)
        {
           var department = await _repository.GetAsync(input.Id);
            ObjectMapper.Map( input, department);

            return ObjectMapper.Map<DepartmentDto>(_repository.UpdateAsync(department));
        }
    }
}
