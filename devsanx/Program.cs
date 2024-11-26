using devsanx.Database;
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
			// Loaded from configuration in appsettings.json
			// Migrations are generated with dotnet-ef tool at the project folder (dotnet-ef needs to match project .NET version)
			// Run "dotnet ef migrations add InitialProjectsDBSchema" 
			// This creates a "Migrations" folder
			string? SQLiteConnection = builder.Configuration.GetConnectionString("SQLiteProjectsDatabaseConnection");
			builder.Services.AddDbContext<ProjectsDBContext>(options => options.UseSqlite(SQLiteConnection));

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
