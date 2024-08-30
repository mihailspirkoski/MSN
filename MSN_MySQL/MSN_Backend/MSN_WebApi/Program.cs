using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MSN_Application.Interfaces;
using MSN_Application.Services.Implementation;
using MSN_Application.Services.Interface;
using MSN_Domain.Entities;
using MSN_Infrastructure.Data;
using MSN_Infrastructure.Emails;
using MSN_Infrastructure.Repositories;
using MSN_WebApi.Hub;
using MSN_WebApi.ViewModels_DTO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var apiCorsPolicy = "ApiCorsPolicy";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentityApiEndpoints<MSNUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: apiCorsPolicy,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                          //.WithMethods("OPTIONS", "GET");
                      });
});

builder.Services.AddSwaggerGen();
builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 102400000;
});
builder.Services.AddSingleton<IDictionary<string, UserChatDTO>>(opt =>
    new Dictionary<string, UserChatDTO>());
builder.Services.AddScoped(typeof(IMusicRecordRepository<MusicRecord>), typeof(MusicRecordRepository));
builder.Services.AddScoped(typeof(IForumPostRepository<ForumPost>), typeof(ForumPostRepository));
builder.Services.AddScoped(typeof(IUserRepository<MSNUser>), typeof(UserRepository));
builder.Services.AddScoped<IMusicRecordService, MusicRecordService>();
builder.Services.AddScoped<IForumPostService, ForumPostService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDbInitialiser, DbInitialiser>();
//builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();
app.MapIdentityApi<MSNUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(apiCorsPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoint =>
{
    endpoint.MapHub<ChatHub>("/chat");
});


app.UseHttpsRedirection();



SeedDatabase();
app.MapControllers();

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitialiser = scope.ServiceProvider.GetRequiredService<IDbInitialiser>();
        dbInitialiser.Initialize();
    }
}