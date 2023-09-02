using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Univan.Application.Abstractions.Security;
using Univan.Application.Abstractions.Storage;
using Univan.Domain.Repositories;
using Univan.Infrastructure.Persistence.Context;
using Univan.Infrastructure.Persistence.Repository;
using Univan.Infrastructure.Security;
using Univan.Infrastructure.Storage;

namespace Univan.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();

            services.Configure<BlobSettings>(configuration.GetSection(BlobSettings.BlobSectionName));
            services.AddScoped<IBlobService, BlobService>();
            services.AddScoped<IPasswordManager, PasswordManager>();

            services.AddDbContext<UnivanContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("UnivanDatabase")));

            return services;
        }
    }
}
