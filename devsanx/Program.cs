using devsanx.Database;
using devsanx.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace devsanx
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();




			#region EFCore database

			// Register the database context in the application builder
			// Then we can access it via dependency injection
			// Loaded from configuration in appsettings.json
			// Migrations are generated with dotnet-ef tool at the project folder (dotnet-ef needs to match project .NET version)
			// Run "dotnet ef migrations add InitialProjectsDBSchema" 
			// This creates a "Migrations" folder
			// To execute the migration run "dotnet ef database update"
			string? SQLiteConnection = builder.Configuration.GetConnectionString("SQLiteProjectsDatabaseConnection");
			builder.Services.AddDbContext<ProjectsDBContext>(options => options.UseSqlite(SQLiteConnection));

			// Execute the migration in code:
			/*using (var scope = app.Services.CreateScope()) // Create a disposable service scope
			{
				// From the scope, get an instance of our database context.
				// Through the `using` keyword, we make sure to dispose it after we are done.
				using var context = scope.ServiceProvider.GetService<ProjectsDBContext>();

				// Execute the migration from code.
				context.Database.Migrate();
			}*/


			// Repository pattern, classes to ecnapsulate the logic of accessing our data
			// Dependency injection will pass our ProjectsDBContext to the repository classes
			builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
			#endregion




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

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}
