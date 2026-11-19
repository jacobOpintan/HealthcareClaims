using HealthcareClaims.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// configure SQL Server and Entity Framework core
builder.Services.AddDbContext<HealthcareClaimsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



app.UseHttpsRedirection();

app.MapControllers();

app.Run();