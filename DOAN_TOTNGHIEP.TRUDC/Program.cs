using Microsoft.Extensions.DependencyInjection;
using DOAN_TOTNGHIEP.TRUDC.BL.BaseBL;
using DOAN_TOTNGHIEP.TRUDC.DL.BaseDL;
using DOAN_TOTNGHIEP.TRUDC.DL;
using DOAN_TOTNGHIEP.TRUDC.BL.ProductBL;
using DOAN_TOTNGHIEP.TRUDC.DL.ProductDL;
using static System.Net.WebRequestMethods;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependency Injection
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<IProductDL, ProductDL>();
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

var app = builder.Build();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
