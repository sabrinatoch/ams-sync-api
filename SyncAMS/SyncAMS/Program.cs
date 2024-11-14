using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SyncAMS.DAL;
using SyncAMS.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var conStrBuilder = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("AMSConnection"));
conStrBuilder.Password = builder.Configuration["dbpwd"];
var connection = conStrBuilder.ConnectionString;

builder.Services.AddDbContext<AmsContext>(options =>
    options.UseSqlServer(connection)
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
