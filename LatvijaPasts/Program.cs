using Microsoft.EntityFrameworkCore;
using LatvijasPasts.Data;
using LatvijaPasts.Models;
using LatvijasPasts.Core.Services;
using LatvijasPasts.Core.Models;
using LatvijasPasts.Services;
using LatvijasPasts.UseCases;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database
builder.Services.AddDbContextPool<LatvijasPastsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("latvijas-pasts"));
});

//Service
builder.Services.AddTransient<ILatvijasPastsDbContext, LatvijasPastsDbContext>();
builder.Services.AddTransient<IDbService, DbService>();
builder.Services.AddTransient<IEntityService<PersonalData>, EntityService<PersonalData>>();
builder.Services.AddTransient<IEntityService<Education>, EntityService<Education>>();
builder.Services.AddTransient<IEntityService<WorkExperience>, EntityService<WorkExperience>>();
builder.Services.AddTransient<ICvService, CvService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(routes =>
{
    routes.WithHeaders().AllowAnyHeader();
    routes.WithOrigins("http://localhost:3000");
    routes.WithMethods().AllowAnyMethod();
});
app.Run();
