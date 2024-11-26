using devsanx.Database.Domain;

namespace devsanx.Database.Repository
{
	/*
	 * Implementing the repository pattern. This interface will be registered in the application builder
	 * Repository pattern aims to keep persistence concerns out of the domain model
	 * Repository implementations encapsulates the logic required to access data sources
	 */
	public interface IProjectRepository
	{
		public Task<int> Createproject(Project newProject);
		public Task<List<Project>> GetProjects(string developerName);
		public Task UpdateProject(Project updatedProject);
	}
}
