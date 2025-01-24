using Victor.Movies.WebApp.Extensions;
using Victor.Movies.IOC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region Connect with DbContext
builder.ConfigureDbContext();
#endregion

#region Dependency Injection
builder.Services.StartInjection();
#endregion

var app = builder.Build();

app.ConfigureRouting();

app.Run();