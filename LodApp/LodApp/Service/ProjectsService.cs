using System.Threading.Tasks;
using LodApp.DataAccess.DTO;

namespace LodApp.Service
{
	public class ProjectsService : IProjectsService
	{
		public Task<ProjectPreview> GetProjects(int offset, int limit)
		{
			throw new System.NotImplementedException();
		}
	}
}