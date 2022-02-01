using HelloWorldCore6.Data;
using HelloWorldCore6.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddFile(@"C:\Logs\HelloWorldCore6\HelloWorldCore6-{Date}.log");

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Database.UpgradeDatabase(connectionString);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<MyDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
