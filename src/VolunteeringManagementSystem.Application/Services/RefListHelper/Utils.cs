using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;

namespace VolunteeringManagementSystem.Services.RefListHelper
{
    public class Utils
    {
        public static string GenerateVulonteerNum()
        {
            var uow = IocManager.Instance.Resolve<IUnitOfWorkManager>();
            var volunteer = IocManager.Instance.Resolve<IRepository<Volunteer, Guid>>();
            using (uow.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var list = volunteer.GetAll();
                var current = list.Count();

                return $"VOL_{current++}";
            }
        }


        public static string GenerateEmployeeNum()
        {
            var uow = IocManager.Instance.Resolve<IUnitOfWorkManager>();
            var employee = IocManager.Instance.Resolve<IRepository<Employee, Guid>>();
            using (uow.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var list = employee.GetAll();
                var current = list.Count();

                return $"EMP_{current++}";
            }
        }


    }
}
