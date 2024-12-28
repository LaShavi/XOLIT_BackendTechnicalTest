// Configuramos Log4Net
using Microsoft.OpenApi.Models;
using System.Reflection;
using Infrastructure.Persistence;
using Api.Middleware;

try
{
    string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          builder =>
                          {
                              builder.AllowAnyOrigin()
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();
                          });
    });

    builder.Services.AddMvc();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(options =>
    {
        //options.ExampleFilters();

        // Configuracion Swagger
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = builder.Configuration["SwaggerDoc:Version"],
            Title = builder.Configuration["SwaggerDoc:Title"],
            Description = builder.Configuration["SwaggerDoc:Description"],
            Contact = new OpenApiContact
            {
                Name = "Contact the developer"
            },
            License = new OpenApiLicense
            {
                Name = "License",
            }
        });

        // Agregar información sobre seguridad
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            new string[]{}
            }
        });
    });

    //builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

    // Configure the AppDbContext
    builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("dbContext"));

    // Add Dependency Injection for Repositories and other services
    builder.Services.RegisterDependencies();

    // Add services to the container.
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

    // Iniciamos App.
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseCors(MyAllowSpecificOrigins);

    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();
    //app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    //logger.Error("Error inicializando program.cs", ex);
    throw;
}
finally
{
    //LogManager.Shutdown();
}