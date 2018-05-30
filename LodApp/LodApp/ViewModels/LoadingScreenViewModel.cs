using System.Threading.Tasks;
using System.Windows.Input;
using LodApp.Service;
using Xamarin.Forms;

namespace LodApp.ViewModels
{
	public class LoadingScreenViewModel : BaseViewModel
	{
		public LoadingScreenViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
		{
			_authenticationService = authenticationService;
			_navigationService = navigationService;
			CheckAuthenticatedCommand = new Command(async () => await CheckAuthenticated());
		}

		public ICommand CheckAuthenticatedCommand { get; }

		private async Task CheckAuthenticated()
		{
			var currentUser = await _authenticationService.GetCurrentUserAsync();
			if (currentUser == null)
			{
				await _navigationService.NavigateModalAsync<LoginScreenViewModel>();
				return;
			}

			await _navigationService.SetRootViewModelAsync<MainPageViewModel, CurrentUserViewModel>(
				new CurrentUserViewModel(currentUser.DisplayName, currentUser.ImageUri));
		}

		private readonly IAuthenticationService _authenticationService;
		private readonly INavigationService _navigationService;
	}
}