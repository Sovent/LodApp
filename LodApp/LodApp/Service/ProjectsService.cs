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

		public Task<IEnumerable<ProjectPreview>> GetProjects(int offset, int limit)
		{
			return _lodClient.GetProjectsPreviewAsync(offset, limit);
		}

		private readonly ILodClient _lodClient;
	}
}