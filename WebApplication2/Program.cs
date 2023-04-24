using Auth0.AspNetCore.Authentication;
using EntityFramework.Exceptions.Sqlite;
using Microsoft.EntityFrameworkCore;
using WebApplication2;
using WebApplication2.Data;
using WebApplication2.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// builder.Services.Configure<CookiePolicyOptions>(options =>
// {
//     options.MinimumSameSitePolicy = SameSiteMode.None;
// });

builder.Services.ConfigureSameSiteNoneCookies();

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.ClientId = builder.Configuration["Auth0:ClientId"]!;
});

builder.Services.AddDbContext<HistoryFiguresDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["Database:ConnectionString"]);
    options.UseExceptionProcessor();
});

builder.Services.AddScoped<IHistoricalFiguresRepository, HistoricalFiguresRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

await app.InitDb();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
