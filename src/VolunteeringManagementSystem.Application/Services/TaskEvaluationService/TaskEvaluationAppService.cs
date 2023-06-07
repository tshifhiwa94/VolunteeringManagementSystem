using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.TaskAssignService;
using VolunteeringManagementSystem.Services.TaskAssignService.Dto;
using VolunteeringManagementSystem.Services.TaskEvaluationService.Dto;

namespace VolunteeringManagementSystem.Services.TaskEvaluationService
{
    public class TaskEvaluationAppService : ApplicationService, ITaskEvaluationAppService
    {
        private readonly IRepository<VolunteerTaskEvaluation, Guid> _repository;
        private readonly IRepository<Volunteer, Guid> _volunteerRepository;
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<TaskAssign, Guid> _taskAssignRepository;
        public TaskEvaluationAppService(IRepository<VolunteerTaskEvaluation, Guid> repository, IRepository<Volunteer, Guid> volunteerRepository, IRepository<Employee, Guid> employeeRepository, IRepository<TaskAssign, Guid> taskAssignRepository)
        {
            _repository = repository;
            _volunteerRepository = volunteerRepository;
            _employeeRepository = employeeRepository;
            _taskAssignRepository = taskAssignRepository;
        }

        public async Task<VolunteerTaskEvaluationDto> CreateAsync(VolunteerTaskEvaluationDto input)
        {
            var volunteerTaskEvaluation = ObjectMapper.Map<VolunteerTaskEvaluation>(input);

            volunteerTaskEvaluation.TaskAssign =  _taskAssignRepository.Get(input.TaskAssignId);
            volunteerTaskEvaluation.Volunteer=_volunteerRepository.Get(input.VolunteerId);
            volunteerTaskEvaluation.Employee=_employeeRepository.Get(input.EmployeeId);

            return ObjectMapper.Map<VolunteerTaskEvaluationDto>(await _repository.InsertAsync(volunteerTaskEvaluation));

        }

        public async Task DeleteAsync(Guid id)
        {
           await _repository.DeleteAsync(id);
        }

        public async Task<List<VolunteerTaskEvaluationDto>> GetAllAsync()
        {
            var taskEvaluations =  _repository.GetAllIncluding(a => a.TaskAssign, b => b.Employee, z => z.Volunteer).ToList();
            return  ObjectMapper.Map<List<VolunteerTaskEvaluationDto>>(taskEvaluations);
        }

        public async Task<VolunteerTaskEvaluationDto> GetAsync(Guid id)
        {
            var taskEvaluation = _repository.GetAllIncluding(a => a.TaskAssign, b => b.Employee, z => z.Volunteer).FirstOrDefault(x=>x.Id==id);
            return ObjectMapper.Map<VolunteerTaskEvaluationDto>(taskEvaluation);
        }

        public async Task<VolunteerTaskEvaluationDto> UpdateAsync(VolunteerTaskEvaluationDto input)
        {
            var taskEvaluation = _repository.GetAllIncluding(a => a.TaskAssign, b => b.Employee, z => z.Volunteer).FirstOrDefault(x => x.Id == input.Id);

            ObjectMapper.Map(input, taskEvaluation);
            return ObjectMapper.Map<VolunteerTaskEvaluationDto>(await _repository.UpdateAsync(taskEvaluation));
        }

        public async Task<VolunteerTaskEvaluationAnalysisDto> PerformAnalysisAsync()
        {
            var taskEvaluations = await _repository.GetAllListAsync();

            var analysis = new VolunteerTaskEvaluationAnalysisDto();

            analysis.TotalEvaluations = taskEvaluations.Count;
            analysis.AverageRating = taskEvaluations.Any() ? taskEvaluations.Average(te => te.Rating) : 0;

            return analysis;
        }






    }
}
