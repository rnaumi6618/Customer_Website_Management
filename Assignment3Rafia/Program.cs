/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Microsoft.EntityFrameworkCore;
using Invoicing.Services;
using Assignment3Rafia.DataAccess;
using Assignment3Rafia.Services;
using Assignment3Rafia.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connStr = builder.Configuration.GetConnectionString("InvoiceDb");
builder.Services.AddDbContext<InvoiceDbContext>(options => options.UseSqlServer(connStr));

// add our invoice manager svc:
builder.Services.AddScoped<IManageInvoice, ManageInvoice>();


builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
}).AddEntityFrameworkStores<InvoiceDbContext>().AddDefaultTokenProviders();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await InvoiceDbContext.CreateAdminUser(scope.ServiceProvider);
}

app.Run();