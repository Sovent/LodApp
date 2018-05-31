using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LodApp.DataAccess.DTO;

namespace LodApp.Service
{
	public interface IProjectsService
	{
		Task<Project> GetProject(int projectId);

		Task<IEnumerable<ProjectPreview>> GetProjects(int offset, int limit);

		Task<Result<string>> UpdateProject(int projectId, ProjectActionRequest request);

		Task<Image> UploadProjectPicture(string imagePath, Stream photoStream);

		Task DeleteDeveloperFromProject(int projectId, int userId);
	}
}