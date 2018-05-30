using System.Collections.Generic;
using System.Threading.Tasks;
using LodApp.DataAccess.DTO;

namespace LodApp.DataAccess
{
	public interface ILodClient
	{
		Task<AuthorizationTokenInfo> LoginAsync(Credentials credentials);

		Task<Developer> GetDeveloperAsync(int userId);

		Task<IEnumerable<ProjectPreview>> GetProjectsPreviewAsync(int offset, int limit);

		Task<Project> GetProjectAsync(int projectId);

		Task UpdateProjectAsync(int projectId, ProjectActionRequest request);

		Task<IEnumerable<DeveloperPageDeveloper>> GetDevelopers(int page);

		Task<IEnumerable<DeveloperPageDeveloper>> SearchDevelopers(string searchString);

 		void AuthorizeBy(string token);
	}
}