using System.Threading.Tasks;
using LodApp.DataAccess.DTO;

namespace LodApp.Service
{
	public interface IProjectsService
	{
		Task<ProjectPreview> GetProjects(int offset, int limit);
	}
}