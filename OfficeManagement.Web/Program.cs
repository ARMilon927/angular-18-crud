using Microsoft.EntityFrameworkCore;
using OfficeManagement.Web.Repository.Context;
using OfficeManagement.Web.Repository.Implementation;
using OfficeManagement.Web.Repository.Interface;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
// Add services to the container.

builder.Services.AddControllers();
#region CORS

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", c =>
{
    c
    //.AllowAnyMethod()
    //.AllowAnyHeader()
    //.AllowAnyOrigin();

    .AllowAnyHeader()
                  .AllowAnyMethod()
                  .SetIsOriginAllowed((host) => true)
                  .AllowCredentials();
}));

#endregion CORS
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Connection String

var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connetionString));


#endregion

#region Services and Repository

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");  // Use Cors

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
