using DynacityFront.profile;
using DynacityFront.Services;
using DynacityFront.Services.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddHttpClient<IDynacityService, DynacityService>();
builder.Services.AddScoped<IDynacityService, DynacityService>();

builder.Services.AddHttpClient<IPropertyService, PropertyService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();

builder.Services.AddHttpClient<IRentService, RentService>();
builder.Services.AddScoped<IRentService, RentService>();

builder.Services.AddHttpClient<IBidService, BidService>();
builder.Services.AddScoped<IBidService, BidService>();

builder.Services.AddHttpClient<ISellService, SellService>();
builder.Services.AddScoped<ISellService, SellService>();

builder.Services.AddHttpClient<IEventService, EventService>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.SlidingExpiration = true;
    }
    );


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseAuthentication();

app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
