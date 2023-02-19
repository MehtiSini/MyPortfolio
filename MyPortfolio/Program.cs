using InformationManagement.Configuration;
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

builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
