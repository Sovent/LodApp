using System;
using System.Collections.Generic;
using System.IO;
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

		public async Task<Result<string>> UpdateProject(int projectId, ProjectActionRequest request)
		{
			try
			{
				await _lodClient.UpdateProjectAsync(projectId, request);
				return Result<string>.Successful("Everything is fine");
			}
			catch (LodClientException exception)
			{
				return Result<string>.Failed(exception.Message);
			}
		}

		public Task<Image> UploadProjectPicture(string imagePath, Stream photoStream)
		{
			try
			{
				var imageName = Path.GetFileName(imagePath);
				return _lodClient.UploadImage(imageName, photoStream);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Task DeleteDeveloperFromProject(int projectId, int userId)
		{
			return Task.CompletedTask;
		}

		private readonly ILodClient _lodClient;
	}
}