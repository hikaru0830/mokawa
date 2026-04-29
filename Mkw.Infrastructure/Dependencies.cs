using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mkw.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mkw.Infrastructure
{
    public static class Dependencies
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MokawaDb");
            services.AddDbContext<MkwContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
