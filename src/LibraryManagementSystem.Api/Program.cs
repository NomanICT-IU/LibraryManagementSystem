
var builder = WebApplication.CreateBuilder(args);

// Serilog
builder.Services.AddSerilog((services, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services);
});

// Controllers
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalValidationFilter>();
});

// Application Services
builder.Services.AddApplicationDallServices(
    builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddApplicationServices();

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

// Custom Exception Handler
app.UseMiddleware<CustomExceptionHandler>();

// Serilog request logging
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();