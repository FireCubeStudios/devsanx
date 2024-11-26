using devsanx.Database.Domain;
using Microsoft.EntityFrameworkCore;

namespace devsanx.Database.Repository
{
	/*
	 * Implementing the repository pattern. This interface will be registered in the application builder
	 * Repository pattern aims to keep persistence concerns out of the domain model
	 * Repository implementations encapsulates the logic required to access data sources
	 */
	public class ProjectRepository : IProjectRepository
	{
		private ProjectsDBContext dbContext;
		public ProjectRepository(ProjectsDBContext dBContext) 
		{
			this.dbContext = dbContext;
		}

		public async Task<int> Createproject(Project newProject)
		{
			// Define the LINQ query which will be turned into SQL by EFCore
			var query = dbContext.Projects.AddAsync(newProject);
			await dbContext.SaveChangesAsync(); // Persist the changes in the database
			return query.Result.Entity.ProjectId;
		}

		public async Task<List<Project>> GetProjects(string developerName)
		{
			// Define the LINQ query which will be turned into SQL by EFCore
			var query = dbContext.Projects.Where(project => project.Developer.Name == developerName);
			return await query.ToListAsync(); // Execute the query and return the result
		}

		public async Task UpdateProject(Project updatedProject)
		{
			// Define the LINQ query which will be turned into SQL by EFCore
			var query = dbContext.Projects.Update(updatedProject);
			await dbContext.SaveChangesAsync(); // Persist the changes in the database
		}
	}
}
