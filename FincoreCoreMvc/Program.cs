using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using FincoreCoreMvc.Service;
using FincoreCoreMvc.Service.Budget;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);





// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBudgets, BudgetsServices>();
builder.Services.AddScoped<IAssets, AssetsService>();
builder.Services.AddScoped<IRevenue, RevenueServices>();
builder.Services.AddScoped<IARInvoice, ARInvoiceService>();

builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPOService, POService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vendor}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
