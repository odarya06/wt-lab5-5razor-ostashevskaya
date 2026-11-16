using System.Globalization;
using Microsoft.AspNetCore.HttpOverrides;
using wt_lab5_5razor_ostashevskaya.Infrastructure;

// Единая культура для форматирования цен и дат в интерфейсе.
var culture = new CultureInfo("ru-RU");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

var builder = WebApplication.CreateBuilder(args);

// Razor Pages + нестандартный связыватель decimal,
// который принимает цену и с точкой, и с запятой.
builder.Services
    .AddRazorPages()
    .AddMvcOptions(options => options.ModelBinderProviders.Insert(0, new InvariantDecimalModelBinderProvider()));

// Render передаёт порт через переменную окружения PORT.
// По умолчанию используется 10000 — стандартный порт Web Service на Render.
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Render завершает HTTPS на балансировщике и передаёт запрос по HTTP.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
