using NS.STMS.MVC.Extensions;
using NS.STMS.MVC.Filters;
using NS.STMS.MVC.Helpers;
using NS.STMS.MVC.Settings;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
	.SetBasePath(builder.Environment.ContentRootPath)
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.Build();

builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

builder.Services.AddLocalization(options =>
{
	options.ResourcesPath = "NS.STMS.Resources.Language.Languages";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var supportedLanguages = LanguageSettingsHelper.GetSupportedLanguageCultures();

	options.SupportedCultures = supportedLanguages;
	options.SupportedUICultures = supportedLanguages;
});

builder.Services.AddHttpContextAccessor();

// inject dependencies
builder.Services.BindCacheServices();
builder.Services.BindSTMSServices();
builder.Services.BindSorageServices();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddMvc(options =>
	{
		options.MaxModelBindingCollectionSize = int.MaxValue;

		options.Filters.Add(typeof(ExceptionHandler));
	})
	.AddViewLocalization()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.PropertyNamingPolicy = null;
		options.JsonSerializerOptions.DictionaryKeyPolicy = null;
	});

builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

app.Run();
