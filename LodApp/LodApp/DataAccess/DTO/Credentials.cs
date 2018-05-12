using System;

namespace LodApp.DataAccess.DTO
{
	public class Credentials
	{
		public Credentials(string email, string password)
		{
			Email = email ?? throw new ArgumentNullException(nameof(email));
			Password = password ?? throw new ArgumentNullException(nameof(password));
		}

		public string Email { get; }

		public string Password { get; }
	}
}