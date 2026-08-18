using LibraryManagementSystem.BLL.Service;
using LibraryManagementSystem.DAL.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    return new SqlConnection(
        configuration.GetConnectionString("DefaultConnection")
    );
});

builder.Services.AddScoped<IBookRepositroy, BookRepositroy>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService,MemberService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library Management API",
        Version = "v1",
        Description = "Library Management System API"
    });
});

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