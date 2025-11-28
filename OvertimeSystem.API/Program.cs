using Microsoft.EntityFrameworkCore;
using OvertimeSystem.API.Data;
using OvertimeSystem.API.Repositories;
using OvertimeSystem.API.Repositories.Data;
using OvertimeSystem.API.Repositories.Interfaces;
using OvertimeSystem.API.Services;
using OvertimeSystem.API.Services.Interfaces;
using OvertimeSystem.API.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OvertimeSystemDbContext>(options => options.UseSqlServer(connectionString));

// Register Repository Service
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
builder.Services.AddScoped<IApprovedOvertimeRepository, ApprovedOvertimeRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IOvertimeBudgetRepository, OvertimeBudgetRepository>();
builder.Services.AddScoped<IOvertimeRateRepsitory, OvertimeRateRepository>();
builder.Services.AddScoped<IOvertimePolicyRepository, OvertimePolicyRepository>();
builder.Services.AddScoped<IOvertimeRequestRepository, OvertimeRequestRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register Business Logic Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IOvertimePolicyService, OvertimePolicyService>();
builder.Services.AddScoped<IOvertimeService, OvertimeService>();

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
// Learn more about configuring Swagger/OpenAPI
// at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();