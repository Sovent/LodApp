using System.Threading.Tasks;
using LodApp.DataAccess.DTO;

namespace LodApp.Service
{
	public interface IAuthenticationService
	{
		Task<Result<string>> AuthenticateAsync(Credentials credentials);
		Task<CurrentUser> GetCurrentUserAsync();
		Task LogoutAsync();
	}
}