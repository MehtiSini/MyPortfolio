using InformationManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using MyFramework.Tools.Authentication;
using MyFramework.Tools.Authentication.Password;
using MyFramework.Tools.FileUploader;
using MyPortfolio;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

PersonBootStrapper Person = new();
AccountBootstrapper Account = new();

var Connstring = builder.Configuration.GetSection("ConnString")["MyPortfolio"];

Person.Configure(builder.Services, Connstring);
Account.Configure(builder.Services, Connstring);


builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Login");
        o.LogoutPath = new PathString("/Login");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
