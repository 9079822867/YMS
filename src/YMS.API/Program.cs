using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using YMS.Application.Interfaces;
using YMS.Application.Services;
using YMS.Domain.Interfaces;
using YMS.Infrastructure.Data;
using YMS.Infrastructure.Repositories;
using YMS.Infrastructure.Services;
using YMS.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<YmsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IUserManagementService, UserManagementService>();
builder.Services.AddScoped<IMasterService, MasterService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IRepository<YMS.Domain.Entities.Project>, Repository<YMS.Domain.Entities.Project>>();
builder.Services.AddScoped<IRepository<YMS.Domain.Entities.Vehicle>, Repository<YMS.Domain.Entities.Vehicle>>();
builder.Services.AddScoped<IRepository<YMS.Domain.Entities.MasterItem>, Repository<YMS.Domain.Entities.MasterItem>>();
builder.Services.AddScoped<IRepository<YMS.Domain.Entities.Client>, Repository<YMS.Domain.Entities.Client>>();
builder.Services.AddScoped<IRepository<YMS.Domain.Entities.Yard>, Repository<YMS.Domain.Entities.Yard>>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddScoped<IExitService, ExitService>();
builder.Services.AddScoped<IExitRepository, ExitRepository>();

// ── KwikCheck blueprint modules ──
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<ITransferRepository, TransferRepository>();
builder.Services.AddScoped<IInspectionService, InspectionService>();
builder.Services.AddScoped<IInspectionRepository, InspectionRepository>();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<IRepository<YMS.Domain.Entities.VehicleDocument>, Repository<YMS.Domain.Entities.VehicleDocument>>();
builder.Services.AddScoped<IRepository<YMS.Domain.Entities.Notification>, Repository<YMS.Domain.Entities.Notification>>();
builder.Services.AddScoped<IRepository<YMS.Domain.Entities.AuditLog>, Repository<YMS.Domain.Entities.AuditLog>>();

var jwtSecret = builder.Configuration["Jwt:Secret"]
    ?? throw new InvalidOperationException("JWT:Secret is not configured");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

// CORS: allow separate dev server (Vite) if running alongside
builder.Services.AddCors(options =>
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:5173", "http://localhost:3000", "http://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "YMS Pro API", Version = "v1", Description = "Yard Inventory Management System" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Auto-migrate on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<YmsDbContext>();
    db.Database.Migrate();
}

// Swagger available in all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "YMS Pro API v1");
    c.RoutePrefix = "swagger";
});

// Serve React SPA from wwwroot
app.UseDefaultFiles();          // serves index.html for /
app.UseStaticFiles();           // serves wwwroot files

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// SPA fallback — non-API routes return index.html (React Router)
app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }
