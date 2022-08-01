using JobOpportunities.API.Controllers;
using JobOpportunities.Core.Features.JobOffers.Queries;
using JobOpportunities.Data;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("ConsultaAlumnosApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
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
                    Id = "ConsultaAlumnosApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>() }
    });
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var connectionString = builder.Configuration.GetConnectionString("JobOpportunitiesContextConnection") ?? throw new InvalidOperationException("Connection string 'JobOpportunitiesContextConnection' not found.");
builder.Services.AddDbContext<JobOpportunitiesContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<JobOpportunitiesContext>();

//builder.Services.AddTransient<IRepository<Company>, Repository<Company>>();
builder.Services.AddTransient<IReadRepository<JobOffer>, Repository<JobOffer>>();
//builder.Services.AddTransient<IRepository<Skill>, Repository<Skill>>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadOnlyRepository<>));

/*
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                //TODO
                //ApplicationUser

                var userMachine = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
                var user = userMachine.GetUserAsync(context.HttpContext.User);
                if (user == null)
                    context.Fail("UnAuthorized");
                return Task.CompletedTask;
            }
        };
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);*/

//builder.Services.AddMediatR();
builder.Services.AddMediatR(typeof(JobOfferController).Assembly, typeof(GetJobOfferQuery).Assembly);

var assembly = Assembly.GetExecutingAssembly();
var domains = AppDomain.CurrentDomain.GetAssemblies();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
