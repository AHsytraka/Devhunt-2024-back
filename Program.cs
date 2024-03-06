using System.Security.Claims;
using System.Text;
using Devhunt_2024_back.Data;
using Devhunt_2024_back.Repositories.AgendaRepository;
using Devhunt_2024_back.Repositories.FileRepository;
using Devhunt_2024_back.Repositories.InterestRepository;
using Devhunt_2024_back.Repositories.ProfRepository;
using Devhunt_2024_back.Repositories.SubjectRepository;
using Devhunt_2024_back.Repositories.UserRepository;
using Devhunt_2024_back.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInterestRepository, InterestRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IProfRepository, ProfRepository>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();

//DBContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Setting up SwaggerGen
builder.Services.AddSwaggerGen( c=>
    {
        //SwaggerDoc Name, version
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Authentication_api", Version = "v1" });
        // Add security definition : Authentication && Authorization
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        //Security requirement
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                Array.Empty<string>()
            }
        });
    }
);

//Add Authentication scheme : Issuer & Audience to false
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SecureKey"] ?? string.Empty)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//Authorization policy and role claim
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
});

//CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsPolicy");


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
