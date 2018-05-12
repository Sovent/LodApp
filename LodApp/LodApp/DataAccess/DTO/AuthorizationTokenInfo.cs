using System;

namespace LodApp.DataAccess.DTO
{
	public class AuthorizationTokenInfo
	{
		public AuthorizationTokenInfo(int userId, AccountRole role, string token, DateTime creationTime)
		{
			UserId = userId;
			Role = role;
			Token = token;
			CreationTime = creationTime;
		}

		public int UserId { get; }

		public AccountRole Role { get; }

		public string Token { get; }

		public DateTime CreationTime { get; set; }
	}
}