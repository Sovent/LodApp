using System;
using System.Threading.Tasks;
using LodApp.DataAccess;
using LodApp.DataAccess.DTO;
using LodApp.Extensions;
using Plugin.Settings;

namespace LodApp.Service
{
	public class AuthenticationService : IAuthenticationService
	{
		public AuthenticationService(ILodClient lodClient)
		{
			_lodClient = lodClient ?? throw new ArgumentNullException(nameof(lodClient));
		}

		public async Task<Result<string>> AuthenticateAsync(Credentials credentials)
		{
			try
			{
				CrossSettings.Current.Remove(TokenDataPropertyName);
				var authentication = await _lodClient.LoginAsync(credentials);
				CrossSettings.Current.AddOrUpdate(TokenDataPropertyName, authentication);
				_lodClient.AuthorizeBy(authentication.Token);
				return Result<string>.Successful(authentication.UserId.ToString());
			}
			catch (LodClientException exception)
			{
				return Result<string>.Failed(exception.Message);
			}
		}

		public async Task<CurrentUser> GetCurrentUserAsync()
		{
			var token = CrossSettings.Current.Get<AuthorizationTokenInfo>(TokenDataPropertyName);
			if (token?.Role != AccountRole.Administrator)
			{
				return null;
			}
			
			try
			{
				_lodClient.AuthorizeBy(token.Token);
				var me = await _lodClient.GetDeveloperAsync(token.UserId);
				return new CurrentUser($"{me.FirstName} {me.LastName}", me.PhotoUri);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Task LogoutAsync()
		{
			CrossSettings.Current.Remove(TokenDataPropertyName);
			return Task.CompletedTask;
		}

		private const string TokenDataPropertyName = "TokenData";
		private readonly ILodClient _lodClient;
	}
}