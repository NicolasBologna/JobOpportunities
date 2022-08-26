using EndavaCareers.API.Contracts;
using EndavaCareers.API.Data;
using EndavaCareers.API.Data.Repositories;
using EndavaCareers.API.Integrations;
using EndavaCareers.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<IJobOfferRepository, JobOfferRepository>();

builder.Services.AddTransient<ISender, Sender>();

builder.Services.AddTransient<IJobOfferServices, JobOfferServices>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
