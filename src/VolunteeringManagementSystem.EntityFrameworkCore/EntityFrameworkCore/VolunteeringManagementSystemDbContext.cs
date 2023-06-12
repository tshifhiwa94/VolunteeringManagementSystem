using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using VolunteeringManagementSystem.Authorization.Roles;
using VolunteeringManagementSystem.Authorization.Users;
using VolunteeringManagementSystem.MultiTenancy;
using VolunteeringManagementSystem.Domain;

namespace VolunteeringManagementSystem.EntityFrameworkCore
{
    public class VolunteeringManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, VolunteeringManagementSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TaskAssign> TaskAssigns { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<VolunteerSkill> VolunteerSkills { get; set; } 
        public DbSet<TaskSkill> TaskSkills { get; set; }

        public DbSet<VolunteerTaskEvaluation> VolunteerTaskEvaluations { get; set; }
        
        public VolunteeringManagementSystemDbContext(DbContextOptions<VolunteeringManagementSystemDbContext> options)
            : base(options)
        {
        }
    }
}
