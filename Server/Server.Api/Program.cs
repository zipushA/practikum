using Microsoft.OpenApi.Models;
using Server.Api;
using Server.Core;
using Server.Core.Interfaces.IRepository;
using Server.Core.Interfaces.Services;
using Server.Data;
using Server.Data.Repositorys;
using Server.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IPrincipalRepository,PrincipalReposirory>();
builder.Services.AddScoped<IPrincipalService, PrincipalService>();
builder.Services.AddScoped<IMatchingDataRepository, MatchingDataRepository>();
builder.Services.AddScoped<IMatchingDataService, MatchingDataService>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped(typeof(IGeneryRepository<>), typeof(GeneryRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(MappingPostProfile));

builder.Services.AddDbContext<DataContext>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // כדי שה-Swagger UI יופיע ב-root URL
});
app.Run();
