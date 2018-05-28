using System.Collections.Generic;
using System.Threading.Tasks;
using LodApp.DataAccess.DTO;

namespace LodApp.Service
{
	public interface IProjectsService
	{
		Task<Project> GetProject(int projectId);

		Task<IEnumerable<ProjectPreview>> GetProjects(int offset, int limit);

		Task DeleteDeveloperFromProject(int projectId, int userId);
	}
}