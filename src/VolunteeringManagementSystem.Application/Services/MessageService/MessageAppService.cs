using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.MessageService.Dto;

namespace VolunteeringManagementSystem.Services.MessageService
{
    public class MessageAppService : ApplicationService, IMessageAppService
    {
        private readonly IRepository<Message, Guid> _messageRepository;
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<Volunteer, Guid> _volunteerRepository;
        private readonly IRepository<TaskAssign, Guid> _taskAssignRepository;

        public MessageAppService(IRepository<Message, Guid> messageRepository, IRepository<Employee, Guid> employeeRepository, IRepository<Volunteer, Guid> volunteerRepository, IRepository<TaskAssign, Guid> taskAssignRepository)
        {
            _messageRepository = messageRepository;
            _employeeRepository = employeeRepository;
            _volunteerRepository = volunteerRepository;
            _taskAssignRepository = taskAssignRepository;
        }

        [HttpPost]
        public async Task<MessageDto> CreateMessageByUsers(MessageDto input)
        {
            var message = ObjectMapper.Map<Message>(input);
            if (message == null)
            {
                throw new UserFriendlyException("message does not exist");
            }
                message.Volunteer = _volunteerRepository.Get(input.VolunteerId);
                message.Employee = _employeeRepository.Get(input.EmployeeId);
                message.SentDate = DateTime.Now;
                message.IsRead = false;

                return ObjectMapper.Map<MessageDto>(await _messageRepository.InsertAsync(message));
            

         
        }


        [HttpGet]
        public async Task<List<MessageDto>> GetMessagesByUserAsync(Guid userId)
        {
            var messages = await _messageRepository.GetAllListAsync(m => m.Employee.Id == userId || m.Volunteer.Id == userId);
            if (messages == null)
            {
                throw new UserFriendlyException("Messages do not exist for this user.");
            }

            return ObjectMapper.Map<List<MessageDto>>(messages);
        }


        [HttpGet]
        public async Task<List<MessageDto>> GetMessagesBetweenUsersAsync(Guid senderId, Guid recipientId)
        {
            var messages = await _messageRepository.GetAllListAsync( m => (m.Employee.Id == senderId && m.Volunteer.Id == recipientId) ||(m.Employee.Id == recipientId && m.Volunteer.Id == senderId));
            if (messages == null)
            {
                throw new UserFriendlyException("Messages does not exist");
            }
            return ObjectMapper.Map<List<MessageDto>>(messages);
        }


        public async Task DeleteMessagesByUserAsync(Guid userId)
        {
            var messages = await _messageRepository.GetAllListAsync(m => m.Employee.Id == userId || m.Volunteer.Id == userId);
            if (messages == null)
            {
                throw new UserFriendlyException("Messages does not exist of this User");
            }

            foreach (var message in messages)
            {
                await _messageRepository.DeleteAsync(message);
            }
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _messageRepository.DeleteAsync(id);
        }
    }

}
