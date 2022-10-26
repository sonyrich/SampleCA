using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SampleCA.Application;
using SampleCA.Domain.Constants;
using SampleCA.Infrastructure;
using System.Reflection;
using System.Text;

namespace SampleCA.WebAPI.Installers
{
    public class Installer : IInstaller
    {
        public void InstallService(IConfiguration configuration, IServiceCollection service)
        {
            service.AddApplication();
            service.AddInfrastructure(configuration);

            //service.AddFluentValidation(x =>
            //{
            //   // x.RegisterValidatorsFromAssemblyContaining<IVODbContext>();
            //    x.AutomaticValidationEnabled = false;
            //});
            service.AddHttpContextAccessor();
            service.AddControllers();
            service.AddEndpointsApiExplorer();

            //config swagger
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Livethere CMS API",
                    Description = "Livethere CMS API",
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition(JwtAuthenticationDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = JwtAuthenticationDefaults.HeaderName, // Authorization
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtAuthenticationDefaults.AuthenticationScheme
                        }
                    },
                    new List<string>()
                }
                });
            });
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = configuration["Jwt:Issuer"],
                  ValidAudience = configuration["Jwt:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
              };
          });



            service.AddCors(p => p.AddPolicy("corsapp", builder =>
                {
                    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                }));

            // Add services to the container.
            service.AddOptions();
            service.AddResponseCaching();

        }
    }
}