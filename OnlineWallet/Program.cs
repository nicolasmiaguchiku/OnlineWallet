using DotNetEnv;
using OnlineWallet.Settings;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
var syncfusionLicense = Env.GetString("SYNCFUSION_LICENSE");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncfusionLicense);

// Configurar banco de dados
builder.Services.ConfigureDataBase(builder.Configuration);

// Configurar serviços personalizados
builder.Services.ConfigureCustomServices();

var secretKey = Env.GetString("SECRET_KEY");
SecretKey.Secret = secretKey ?? string.Empty;
builder.Services.ConfigureAuthentication(SecretKey.Secret);

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline
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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
