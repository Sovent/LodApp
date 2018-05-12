using System;

namespace LodApp.DataAccess.DTO
{
	public class Developer
	{
		public Developer(int userId, string firstName, string lastName, string email, ConfirmationStatus confirmationStatus,
			bool isOauthRegistered, Uri photoUri, DateTime registrationDate, Uri linkToGithubProfile, Uri vkProfileUri,
			string phoneNumber, int? studentAccessionYear, bool isGraduated, string studyingDirection, string instituteName,
			string specialization, string role)
		{
			UserId = userId;
			FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
			LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
			Email = email ?? throw new ArgumentNullException(nameof(email));
			ConfirmationStatus = confirmationStatus;
			IsOauthRegistered = isOauthRegistered;
			PhotoUri = photoUri;
			RegistrationDate = registrationDate;
			LinkToGithubProfile = linkToGithubProfile;
			VkProfileUri = vkProfileUri;
			PhoneNumber = phoneNumber;
			StudentAccessionYear = studentAccessionYear;
			IsGraduated = isGraduated;
			StudyingDirection = studyingDirection;
			InstituteName = instituteName;
			Specialization = specialization;
			Role = role;
		}

		public int UserId { get; }

		public string FirstName { get; }

		public string LastName { get; }

		public string Email { get; }

		public ConfirmationStatus ConfirmationStatus { get; }

		public bool IsOauthRegistered { get; }

		public Uri PhotoUri { get; }

		public DateTime RegistrationDate { get; }

		public Uri LinkToGithubProfile { get; set; }

		public Uri VkProfileUri { get; }

		public string PhoneNumber { get; }

		public int? StudentAccessionYear { get; }

		public bool IsGraduated { get; }

		public string StudyingDirection { get; }

		public string InstituteName { get; }

		public string Specialization { get; }

		public string Role { get; }
	}
}