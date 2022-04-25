using Assignment03.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMasaBlazor();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//builder.Services.AddMasaI18n(new[]
//{
//    ("en-US", new Dictionary<string, string>(){ { "Test", "Test" } }),
//    ("zh-CN", new Dictionary<string, string>(){ { "Test", "≤‚ ‘" } }),
//});
builder.Services.AddMasaI18nForServer("wwwroot/i18n");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
