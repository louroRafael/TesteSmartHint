using Microsoft.EntityFrameworkCore;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Domain.Services;
using TesteSmartHint.Infra.Context;
using TesteSmartHint.Infra.Repositories;
using TesteSmartHint.Infra.Settings;
using TesteSmartHint.Web.Mapper;

var builder = WebApplication.CreateBuilder(args);
var settings = builder.Configuration.Get<Settings>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(CustomerMapProfile));
builder.Services.AddAutoMapper(typeof(ConfigMapProfile));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IConfigRepository, ConfigRepository>();
builder.Services.AddScoped<IConfigService, ConfigService>();

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(
        settings.MainDbConnection, 
        ServerVersion.AutoDetect(settings.MainDbConnection),
        options => options.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        ));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
