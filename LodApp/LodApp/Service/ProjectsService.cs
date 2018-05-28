using System.Collections.Generic;
using System.Threading.Tasks;
using LodApp.DataAccess;
using LodApp.DataAccess.DTO;

namespace LodApp.Service
{
	public class ProjectsService : IProjectsService
	{
		public ProjectsService(ILodClient lodClient)
		{
			_lodClient = lodClient;
		}

		public Task<Project> GetProject(int projectId)
		{
			return _lodClient.GetProjectAsync(projectId);
		}

		public Task<IEnumerable<ProjectPreview>> GetProjects(int offset, int limit)
		{
			return _lodClient.GetProjectsPreviewAsync(offset, limit);
		}

		public Task DeleteDeveloperFromProject(int projectId, int userId)
		{
			return Task.CompletedTask;
		}

		private readonly ILodClient _lodClient;
	}
}