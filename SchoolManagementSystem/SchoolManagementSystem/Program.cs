using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Infrastructure.Shared.HttpCall;
using SchoolManagementSystem.Mapster;
using SchoolManagementSystem.Services.Services.Account_Services;
using SchoolManagementSystem.Services.Services.Interfaces;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add session support
builder.Services.AddDistributedMemoryCache(); // Required for session storage
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true; // Secure cookie
    options.Cookie.IsEssential = true; // Ensure session is always available
});

//// Configure Mapster
//MapsterConfiguration.Configure();
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(UpateStudentProfiles).Assembly); // Scan for mapping profiles
builder.Services.AddSingleton(config);
//builder.Services.AddScoped<IMapper, ServiceMapper>(); // Register Mapster Mapper

//builder.Services.AddSingleton(config);

//JSON Format
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

// Register HttpContextAccessor (required for session)
builder.Services.AddHttpContextAccessor();
    
// Register HttpClient and HttpService
builder.Services.AddHttpClient<IHttpService, HttpService>();

// Register AccountServices
builder.Services.AddScoped<IAccountServices, AccountServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session before authentication
app.UseSession(); // <-- This line is crucial

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SchoolManagementSystem}/{action=Login}/{id?}");

app.Run();