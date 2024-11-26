using devsanx.Database.Domain;
using Microsoft.EntityFrameworkCore;

namespace devsanx.Database
{
	/*
	 * Provide EFCore with a database context class exposing top-level db entries
	 * Used to query the database
	 * Registered in Program.cs with builder.Services.AddDbContext<ProjectsDBContext>(...);
	 */
	public class ProjectsDBContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Project> Projects { get; set; }

		public ProjectsDBContext(DbContextOptions<ProjectsDBContext> options) : base(options) { }
	}
}
