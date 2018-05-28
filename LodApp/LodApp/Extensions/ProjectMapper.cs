using System.Collections.ObjectModel;
using System.Linq;
using LodApp.DataAccess.DTO;
using LodApp.Service;
using LodApp.ViewModels;
using Xamarin.Forms;

namespace LodApp.Extensions
{
	public static class ProjectMapper
	{
		public static ProjectViewModel ToViewModel(
			this Project project,
			IProjectsService projectsService,
			INavigationService navigationService)
		{
			var viewModel = new ProjectViewModel(
				new ObservableCollection<string>(project.LinksToGithubRepositories.Select(link => link.ToString())),
				project.Name,
				project.ProjectStatus,
				project.ProjectId,
				project.ProjectType.Contains(ProjectType.Other),
				project.ProjectType.Contains(ProjectType.Game),
				project.ProjectType.Contains(ProjectType.Desktop),
				project.ProjectType.Contains(ProjectType.Website),
				project.ProjectType.Contains(ProjectType.MobileApp),
				project.Info, 
				ImageSource.FromUri(project.LandingImage.BigPhotoUri),
				new ObservableCollection<ImageSource>(project.Screenshots.Select(screen => ImageSource.FromUri(screen.BigPhotoUri))),
				projectsService,
				navigationService);
			viewModel.Developers = new ObservableCollection<ProjectDeveloperViewModel>(
				project.ProjectMemberships.Select(membership => membership.ToViewModel(project.ProjectId, viewModel)));
			return viewModel;
		}

		public static ProjectDeveloperViewModel ToViewModel(this ProjectMembership membership, int projectId, ProjectViewModel viewModel)
		{
			return new ProjectDeveloperViewModel(
				membership.DeveloperId,
				membership.FirstName + " " + membership.LastName,
				membership.Role,
				viewModel.DeleteDeveloperCommand);
		}
	}
}