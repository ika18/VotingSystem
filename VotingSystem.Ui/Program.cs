using Microsoft.EntityFrameworkCore;
using VotingSystem;
using VotingSystem.Application;
using VotingSystem.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("Database");
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IVotingPollFactory, VotingPollFactory>();
builder.Services.AddSingleton<ICounterManager, CounterManager>();
builder.Services.AddScoped<StatisticsInteractor>();
builder.Services.AddScoped<VotingInteractor>();
builder.Services.AddScoped<VotingPollInteractor>();
builder.Services.AddScoped<IVotingSystemPersistance, VotingSystemPersistance>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();