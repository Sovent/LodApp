using System;
using System.Collections.Generic;
using System.Linq;
using LodApp.DataAccess.DTO;
using LodApp.ViewModels;
using Xamarin.Forms;

namespace LodApp.Extensions
{
	public static class ProjectMapper
	{
		public static ProjectDeveloperViewModel ToViewModel(this ProjectMembership membership, int projectId, ProjectViewModel viewModel)
		{
			return new ProjectDeveloperViewModel(
				membership.DeveloperId,
				membership.FirstName + " " + membership.LastName,
				membership.Role,
				viewModel.DeleteDeveloperCommand);
		}

		public static ProjectActionRequest ToUpdateRequest(this ProjectViewModel viewModel)
		{
			var projectTypes = new List<ProjectType>();
			if (viewModel.IsDesktop) projectTypes.Add(ProjectType.Desktop);
			if (viewModel.IsGame) projectTypes.Add(ProjectType.Game);
			if (viewModel.IsMobile) projectTypes.Add(ProjectType.MobileApp);
			if (viewModel.IsWeb) projectTypes.Add(ProjectType.Website);
			if (viewModel.IsOther) projectTypes.Add(ProjectType.Other);

			return new ProjectActionRequest(
				viewModel.ProjectName,
				projectTypes,
				viewModel.Description,
				viewModel.ProjectStatus,
				viewModel.Image is UriImageSource uriImageSource 
				? new DataAccess.DTO.Image(uriImageSource.Uri, uriImageSource.Uri) 
				: null,
				viewModel.Screenshots.Cast<UriImageSource>().Select(screen => new DataAccess.DTO.Image(screen.Uri, screen.Uri)),
				viewModel.RepositoriesUrl.Select(url => new Uri(url)));
		}
	}
}