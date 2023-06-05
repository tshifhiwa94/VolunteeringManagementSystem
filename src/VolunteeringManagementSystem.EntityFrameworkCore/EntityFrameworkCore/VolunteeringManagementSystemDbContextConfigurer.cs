using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace VolunteeringManagementSystem.EntityFrameworkCore
{
    public static class VolunteeringManagementSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<VolunteeringManagementSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<VolunteeringManagementSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
