using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Settings;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
	.SetBasePath(builder.Environment.ContentRootPath)
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.Build();

builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

builder.Services.AddHttpContextAccessor();

// inject dependencies
builder.Services.BindSTMSServices();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddMvc(options =>
	{
		options.MaxModelBindingCollectionSize = int.MaxValue;
	})
	.AddViewLocalization()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.PropertyNamingPolicy = null;
		options.JsonSerializerOptions.DictionaryKeyPolicy = null;
	});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

app.Run();
