var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddControllersWithViews(options => options.EnableEndpointRouting = false);

string? connectionString = configuration.GetValue<string>("Database:ConnectionString");
services.AddDbContext<StorageeDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseMvcWithDefaultRoute();
app.UseRouting();

app.Run();
