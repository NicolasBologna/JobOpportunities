using FluentValidation.AspNetCore;
using JobOpportunities.API.Filters;
using JobOpportunities.Data;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace JobOpportunities.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddControllers(options =>
                    options.Filters.Add<ApiExceptionFilterAttribute>() //Agregar validaciones globales a los controladores
                ).AddJsonOptions(joptions =>
                    joptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                .AddFluentValidation();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true); //Modificamos la configuración default de ApiBehaviorOptions para que la validación automatica que agrega [ApiController] ya no entre en vigor, ya que queremos usar nuestra validación custom.

        services.AddSwaggerGen(setupAction =>
        {
            setupAction.AddSecurityDefinition("BearerTokenBasedAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Description = "Acá pegar el token generado al loguearse."
            });

            setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "BearerTokenBasedAuth" }
                        }, new List<string>() }
            });
        });

        services.AddEndpointsApiExplorer();


        services.AddIdentityCore<ApplicationUser>(opt =>
             {
                 opt.Password.RequiredLength = 6;
                 opt.Password.RequireDigit = false;
                 opt.Password.RequireUppercase = false;
                 opt.User.RequireUniqueEmail = true;
             })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<JobOpportunitiesContext>();

        services.AddIdentityCore<CompanyAgent>(opt =>
        {
            opt.Password.RequiredLength = 6;
            opt.Password.RequireDigit = false;
            opt.Password.RequireUppercase = false;
            opt.User.RequireUniqueEmail = true;
        })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<JobOpportunitiesContext>();

        services.AddIdentityCore<Admin>(opt =>
        {
            opt.Password.RequiredLength = 6;
            opt.Password.RequireDigit = false;
            opt.Password.RequireUppercase = false;
            opt.User.RequireUniqueEmail = true;
        })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<JobOpportunitiesContext>();

        services.AddIdentityCore<Candidate>(opt =>
        {
            opt.Password.RequiredLength = 6;
            opt.Password.RequireDigit = false;
            opt.Password.RequireUppercase = false;
            opt.User.RequireUniqueEmail = true;
        })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<JobOpportunitiesContext>();

        return services;
    }

    public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddHttpContextAccessor()
            .AddAuthorization()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                };
            });

        services.AddCors(options =>
        {
            options.AddPolicy(
                name: "AllowOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
        });

        return services;
    }
}