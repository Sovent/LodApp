using System;
using System.Collections.Generic;

namespace LodApp.DataAccess.DTO
{
	public class ProjectActionRequest
	{
		public ProjectActionRequest(string name, IEnumerable<ProjectType> projectTypes, string info,
			ProjectStatus projectStatus, Image landingImage, IEnumerable<Image> screenshots,
			IEnumerable<Uri> linksToGithubRepositories)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
			ProjectTypes = projectTypes ?? throw new ArgumentNullException(nameof(projectTypes));
			Info = info ?? throw new ArgumentNullException(nameof(info));
			ProjectStatus = projectStatus;
			LandingImage = landingImage;
			Screenshots = screenshots ?? throw new ArgumentNullException(nameof(screenshots));
			LinksToGithubRepositories =
				linksToGithubRepositories ?? throw new ArgumentNullException(nameof(linksToGithubRepositories));
		}

		public string Name { get; }

		public IEnumerable<ProjectType> ProjectTypes { get; }

		public string Info { get; }

		public ProjectStatus ProjectStatus { get; }

		public Image LandingImage { get; }

		public IEnumerable<Image> Screenshots { get; }

		public IEnumerable<Uri> LinksToGithubRepositories { get; }

		public int AccessLevel = 0;
	}
}