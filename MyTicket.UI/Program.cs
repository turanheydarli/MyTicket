using Microsoft.EntityFrameworkCore;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDistributedMemoryCache();  
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout as needed
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP-only
    options.Cookie.IsEssential = true; // For GDPR compliance, ensure the session is essential
});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("MSSql") ?? string.Empty);
});
builder.Services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));


var app = builder.Build();

app.UseSession();  

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();