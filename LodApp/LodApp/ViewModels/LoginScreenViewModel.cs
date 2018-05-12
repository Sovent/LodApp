using System.Threading.Tasks;
using LodApp.DataAccess.DTO;
using LodApp.Service;
using LodApp.Views;

namespace LodApp.ViewModels
{
	public class LoginScreenViewModel : BaseViewModel
	{
		public LoginScreenViewModel(
			IAuthenticationService authenticationService,
			INavigationService navigationService)
		{
			_authenticationService = authenticationService;
			_navigationService = navigationService;
		}

		public async Task<bool> AuthenticateAsync()
		{
			await _authenticationService.AuthenticateAsync(new Credentials(Email, Password));
			var currentUser = await _authenticationService.GetCurrentUserAsync();
			if (currentUser == null)
			{
				return false;
			}

			var currentUserViewModel = new CurrentUserViewModel(currentUser.DisplayName, currentUser.ImageUri);
			_navigationService.SetRootPage(
				new MainPage(new MainPageViewModel(
					currentUserViewModel,
					_authenticationService,
					_navigationService)));
			return true;
		}

		public string Email
		{
			get => _email;
			set => SetValue(ref _email, value);
		}

		public string Password
		{
			get => _password;
			set => SetValue(ref _password, value);
		}

		private string _email;
		private string _password;

		private readonly IAuthenticationService _authenticationService;
		private readonly INavigationService _navigationService;
	}
}