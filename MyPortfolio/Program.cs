using InformationManagement.Configuration;
using MyFramework.Tools.FileUploader;
using MyPortfolio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

PersonBootSrtapper Person = new();

var Connstring = builder.Configuration.GetSection("ConnString")["MyPortfolio"];

Person.Configure(builder.Services, Connstring);

builder.Services.AddTransient<IFileUploader, FileUploader>();

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
