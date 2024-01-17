using Microsoft.Extensions.DependencyInjection;
using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using DOAN_TOTNGHIEP.TRUDC.DL;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductBL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DOAN_TOTNGHIEP.TRUDC.BL.UserBL;
using DOAN_TOTNGHIEP.TRUDC.Common.Entities;
using DOAN_TOTNGHIEP.TRUDC.DL.UserDL;
using DOAN_TOTNGHIEP.TRUDC.BL.CustomerBL;
using DOAN_TOTNGHIEP.TRUDC.DL.CustomerDL;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductCategoryBL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductCategoryDL;
using DOAN_TOTNGHIEP.TRUDC.DL.PaymentDL;
using DOAN_TOTNGHIEP.TRUDC.BL.PaymentBL;
using DOAN_TOTNGHIEP.TRUDC.BL.Configs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependency Injection
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<IProductDL, ProductDL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IUserDL, UserDL>();
builder.Services.AddScoped<ICustomerBL, CustomerBL>();
builder.Services.AddScoped<ICustomerDL, CustomerDL>();
builder.Services.AddScoped<IProductCategoryBL, ProductCategoryBL>();
builder.Services.AddScoped<IProductCategoryDL, ProductCategoryDL>();
builder.Services.AddScoped<IPaymentDL, PaymentDL>();
builder.Services.AddScoped<IPaymentBL, PaymentBL>();

builder.Services.Configure<VnpayConfig>(
               builder.Configuration.GetSection(VnpayConfig.ConfigName));

builder.Services.AddCors();

//Lấy dữ liệu ConnectionString từ file appsettings.Development.json
DataBaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySql");

// Tắt chức năng Validate mặc định
builder.Services.AddControllers().ConfigureApiBehaviorOptions(opions =>
{
    opions.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
var app = builder.Build();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
