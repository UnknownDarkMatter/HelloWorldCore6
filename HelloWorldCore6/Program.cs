using HelloWorldCore6.Data;
using HelloWorldCore6.Infrastructure;
using System.Net;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

//configure logs
var logPath = builder.Configuration.GetValue<string>("LogPath");
builder.Logging.ClearProviders();
builder.Logging.AddFile(logPath);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Database.UpgradeDatabase(connectionString);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<MyDbContext>();

//configure HTTPS
//builder.WebHost.ConfigureKestrel((context, options) =>
//{
//    options.Listen(IPAddress.Any, 5001, listenOptions =>
//    {
//        var certificate = LoadCertificate();
//        listenOptions.UseHttps(certificate);
//    });
//});
//X509Certificate2 LoadCertificate()
//{
//    var x509certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(
//        $"{Environment.CurrentDirectory}/token-jwt-secret-http2.pfx", "token-jwt-secret-http2");
//    return x509certificate;
//}

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
