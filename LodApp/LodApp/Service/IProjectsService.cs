using System.Collections.Generic;
using System.Threading.Tasks;
using LodApp.DataAccess.DTO;

namespace LodApp.Service
{
	public interface IProjectsService
	{
		Task<IEnumerable<ProjectPreview>> GetProjects(int offset, int limit);
	}
}