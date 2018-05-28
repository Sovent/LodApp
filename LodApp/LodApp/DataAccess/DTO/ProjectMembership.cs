using System;

namespace LodApp.DataAccess.DTO
{
	public class ProjectMembership
	{
		public ProjectMembership(int developerId, string firstName, string lastName, string role)
		{
			DeveloperId = developerId;
			FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
			LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
			Role = role ?? throw new ArgumentNullException(nameof(role));
		}

		public int DeveloperId { get; }

		public string FirstName { get; }

		public string LastName { get; }

		public string Role { get; }
	}
}