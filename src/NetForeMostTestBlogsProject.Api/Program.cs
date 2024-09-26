using NetForeMostTestBlogsProject.Api.Services;
using NetForeMostTestBlogsProject.Application;
using NetForeMostTestBlogsProject.Application.Interfaces.Services;
using NetForeMostTestBlogsProject.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using NetForeMostTestBlogsProject.Infrastructure.Persistence.DataServices.UserService;
using Microsoft.EntityFrameworkCore;
using NetForeMostTestBlogsProject.Infrastructure.Persistence;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.User;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        // Configure Services
        var builder = WebApplication.CreateBuilder(args);
        // TODO: Remove this line if you want to return the Server header
        builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

        builder.Services.AddSingleton(builder.Configuration);
        // Agregar DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IUserService, UserService>();

        // Adds in Application dependencies
        builder.Services.AddApplication(builder.Configuration);
        // Adds in Infrastructure dependencies
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddHealthChecks();


        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))

            };
        });

        // Agregar la interfaz y la implementación del contexto de la aplicación
        builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });


        builder.Services.AddScoped<IPrincipalService, PrincipalService>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllPolicy", builder =>
            {
                builder.AllowAnyOrigin()   // Permitir cualquier origen
                       .AllowAnyHeader()   // Permitir cualquier encabezado
                       .AllowAnyMethod();  // Permitir cualquier método (GET, POST, etc.)
            });
        });


        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        });
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetForeMostTestBlogsProject.Api", Version = "v1" });
        });

        // Configure Application
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetForeMostTestBlogsProject.Api v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.Use(async (httpContext, next) =>
        {
            var apiMode = httpContext.Request.Path.StartsWithSegments("/api");
            if (apiMode)
            {
                httpContext.Request.Headers[HeaderNames.XRequestedWith] = "XMLHttpRequest";
            }
            await next();
        });

        app.UseAuthorization();

        app.MapHealthChecks("/health");
        app.MapControllers();

        app.Run();
    }
        // Método Configure necesario para que las pruebas funcionen correctamente
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
} 

