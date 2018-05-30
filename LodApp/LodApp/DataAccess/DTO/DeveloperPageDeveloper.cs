using System;

namespace LodApp.DataAccess.DTO
{
	public class DeveloperPageDeveloper
	{
		public DeveloperPageDeveloper(int userId, string firstName, string lastName, Uri photoUri, string role,
			DateTime registrationDate, int projectCount, Uri vkPageUri, AccountRole accountRole,
			ConfirmationStatus confirmationStatus, bool isHidden)
		{
			UserId = userId;
			FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
			LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
			PhotoUri = photoUri;
			Role = role ?? throw new ArgumentNullException(nameof(role));
			RegistrationDate = registrationDate;
			ProjectCount = projectCount;
			VkPageUri = vkPageUri;
			AccountRole = accountRole;
			ConfirmationStatus = confirmationStatus;
			IsHidden = isHidden;
		}

		public int UserId { get; }

		public string FirstName { get; }

		public string LastName { get; }

		public Uri PhotoUri { get; }

		public string Role { get; }

		public DateTime RegistrationDate { get; }

		public int ProjectCount { get; }

		public Uri VkPageUri { get; }

		public AccountRole AccountRole { get; }

		public ConfirmationStatus ConfirmationStatus { get; }

		public bool IsHidden { get; }
	}
}