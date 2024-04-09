var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
services.AddDbContext<StorageeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("storagedb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseMvcWithDefaultRoute();
app.UseRouting();

app.Run();
