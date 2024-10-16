using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StockApplication_UserDomain.Data;
using StockApplication_UserDomain.Services.KYC;
using StockApplication_UserDomain.Services.LoginService;
using StockApplication_UserDomain.Services.SigninService;
using StockApplication_UserDomain.Services.UserDataService;
using StockApplication_UserDomain.Services.WatchlistService;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<ISigninService, SigninService>();
builder.Services.AddTransient<IUserDataService, UserDataService>();
builder.Services.AddTransient<IAddKYC, AddKYC>();
builder.Services.AddTransient<IWatchlistService, WatchlistService>();



builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql("Host=tradexclouduserdomainpostgresdb.cfg860mwu3jf.ap-south-1.rds.amazonaws.com; Database=postgres; Username=TradeXCloudAdmin; password=tradexcloud123");
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TopSecretKeySecretSecretSecretSecret")),
            ValidateIssuer = false,
            ValidateAudience = false,
        };

    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
