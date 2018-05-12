using System;

namespace LodApp.DataAccess.DTO
{
	public class ProjectPreview
	{
		public ProjectPreview(int projectId, Uri photoUri, string name, ProjectStatus projectStatus,
			ProjectType[] projectTypes)
		{
			ProjectId = projectId;
			PhotoUri = photoUri;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			ProjectStatus = projectStatus;
			ProjectTypes = projectTypes ?? throw new ArgumentNullException(nameof(projectTypes));
		}

		public int ProjectId { get; }

		public Uri PhotoUri { get; }

		public string Name { get; }

		public ProjectStatus ProjectStatus { get; }

		public ProjectType[] ProjectTypes { get; }
	}
}