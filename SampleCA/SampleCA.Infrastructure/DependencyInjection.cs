using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleCA.Application.Common.Interfaces;
using SampleCA.Application.Features.Transaction.Commands;
using SampleCA.Infrastructure.Persistence.Persistence;
using SampleCA.Infrastructure.Services;

namespace SampleCA.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //connection database
            services.AddDbContext<AESTrainingContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("AESTrainingConnection"),
                   b => b.MigrationsAssembly(typeof(AESTrainingContext).Assembly.FullName)));


            //services
            services.AddScoped<IValidator<TransactionCreateCommand>, TransactionCreateCommandValidator>();
            services.AddScoped<IValidator<TransactionUpdateCommand>, TransactionUpdateCommandValidator>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IJwtUserService, JwtUserService>();

            return services;
        }
    }
}