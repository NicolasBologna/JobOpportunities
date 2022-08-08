using FluentValidation;
using FluentValidation.AspNetCore;
using JobOpportunities.API.Controllers;
using JobOpportunities.API.Extensions;
using JobOpportunities.Core.Behaviours;
using JobOpportunities.Core.Features.JobOffers.Queries;
using JobOpportunities.Core.Filters;
using JobOpportunities.Data;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.SpecificRepositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("JobOpportunitiesContextConnection") ?? throw new InvalidOperationException("Connection string 'JobOpportunitiesContextConnection' not found.");
builder.Services.AddDbContext<JobOpportunitiesContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<JobOpportunitiesContext>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadOnlyRepository<>));
#region SpecificRepositories
builder.Services.AddScoped<IJobOfferRepository, JobOfferRepository>();
builder.Services.AddScoped<ICandidatesRepository, CandidatesRepository>();
#endregion

builder.Services.AddControllers(options =>
        options.Filters.Add<ApiExceptionFilterAttribute>() //Agregar validaciones globales a los controladores
    ).AddJsonOptions(joptions =>
        joptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddFluentValidation();

builder.Services.Configure<ApiBehaviorOptions>(options =>
    options.SuppressModelStateInvalidFilter = true); //Modificamos la configuración default de ApiBehaviorOptions para que la validación automatica que agrega [ApiController] ya no entre en vigor, ya que queremos usar nuestra validación custom.
builder.Services.AddValidatorsFromAssembly(typeof(GetJobOfferQuery).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

builder.Services.AddMediatR(typeof(JobOfferController).Assembly, typeof(GetJobOfferQuery).Assembly);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("TBD", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Ac� pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "TBD" } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>() }
    });
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    string tsDefinitionsFullPath = app.Environment.ContentRootPath.Replace(@"\JobOpportunities.API", @"\JobOpportunities.SPA\src\app\common\models");
    app.GenerateTypeScriptInterfaces(tsDefinitionsFullPath);

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigin");

app.Run();
