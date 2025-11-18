using ServerApi.Data;
using ServerApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AccountService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Bắt buộc cho Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ServerApi",
        Version = "v1",
        Description = "API quản lý tài khoản người dùng"
    });
});

var app = builder.Build();
app.MapControllers();

app.UseSwagger(); // Tạo /swagger/v1/swagger.json
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServerApi v1");
    c.RoutePrefix = "swagger"; // Giao diện tại /swagger
});

app.Run();
