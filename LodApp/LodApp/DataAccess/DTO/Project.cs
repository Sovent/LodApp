using System;
using System.Collections.Generic;

namespace LodApp.DataAccess.DTO
{
	public class Project
	{
		public Project(int projectId, string name, IEnumerable<ProjectType> projectType, string info,
			ProjectStatus projectStatus, Image landingImage, IEnumerable<ProjectMembership> projectMemberships,
			IEnumerable<Image> screenshots, IEnumerable<Uri> linksToGithubRepositories)
		{
			ProjectId = projectId;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			ProjectType = projectType ?? throw new ArgumentNullException(nameof(projectType));
			Info = info ?? throw new ArgumentNullException(nameof(info));
			ProjectStatus = projectStatus;
			LandingImage = landingImage;
			ProjectMemberships = projectMemberships ?? throw new ArgumentNullException(nameof(projectMemberships));
			Screenshots = screenshots ?? throw new ArgumentNullException(nameof(screenshots));
			LinksToGithubRepositories =
				linksToGithubRepositories ?? throw new ArgumentNullException(nameof(linksToGithubRepositories));
		}

		public int ProjectId { get; }

		public string Name { get; }

		public IEnumerable<ProjectType> ProjectType { get; }

		public string Info { get; }

		public ProjectStatus ProjectStatus { get; }

		public Image LandingImage { get; }

		public IEnumerable<ProjectMembership> ProjectMemberships { get; }

		public IEnumerable<Image> Screenshots { get; }

		public IEnumerable<Uri> LinksToGithubRepositories { get; }
	}
}