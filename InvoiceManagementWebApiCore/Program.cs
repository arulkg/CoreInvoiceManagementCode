using Microsoft.EntityFrameworkCore;
using InvoiceManagementWebApiCore.Model;
using System.Text;
using Serilog;
using Microsoft.IdentityModel.Logging;
using System.Collections;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using DataAccessObjects;
using BusinessAccessObjects;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

////Configure Serilog for file logging 
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.File("C:/Serilog/Logs/IMG/logfile.txt", rollingInterval: RollingInterval.Day) // Create daily log files
//    .CreateLogger();  // This line creates an ILogger from the LoggerConfiguration

builder.Host.UseSerilog((context, configuration) => 
configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();


builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}
));

builder.Services.AddDbContext<IMGCoreDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("IMGCoreConnection")));

builder.Services.AddScoped<ICategoryBAL, CategoryBAL>();
builder.Services.AddScoped<ICategoryDAO, CategoryDAO>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthCore API", Version = "v1" });
var securityScheme = new OpenApiSecurityScheme
{
    Name = "JWT Authentication",
    Description = "Enter your JWT token in this field",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    BearerFormat = "JWT"
};

c.AddSecurityDefinition("Bearer", securityScheme);

var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    };

    c.AddSecurityRequirement(securityRequirement);
});

//JWT authenticationk 
var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    var salkKey = builder.Configuration.GetSection("Jwt");
    x.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(salkKey["SaltKey"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromHours(24)
    };
}
    
    //JwtBearerDefaults.AuthenticationScheme, options => {
    //    var salkKey = builder.Configuration.GetSection("Jwt");
    //    var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(salkKey["SaltKey"]));
    //    options.TokenValidationParameters = new TokenValidationParameters
    //    {
    //        ValidateAudience = false,
    //        ValidateIssuer = false,
    //        ValidateIssuerSigningKey = true,
    //        IssuerSigningKey = signingKey,
    //        ValidateLifetime = true,
    //        ClockSkew = TimeSpan.FromHours(24)
    //    };
    //}
);

//Logging to a file 

var app = builder.Build();

app.UseStaticFiles();
app.UseSerilogRequestLogging();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthCore API V1");
    }
        );
}

// Register middleware for exception handling
app.UseMiddleware<InvoiceManagementWebApiCore.Middlewares.ExceptionMiddleware>();

app.UseCors("corsapp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
