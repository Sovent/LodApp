using System.Collections.ObjectModel;
using System.Linq;
using LodApp.Service;
using LodApp.Views;
using Xamarin.Forms;

namespace LodApp.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
		public MainPageViewModel(
			CurrentUserViewModel currentUserViewModel,
			IAuthenticationService authenticationService, 
			INavigationService navigationService)
		{
			CurrentUserViewModel = currentUserViewModel;
			_authenticationService = authenticationService;
			_navigationService = navigationService;
			InitializeMenuItems();
			SelectMenuItem(MenuItems.First());
		}

		public void SelectMenuItem(MainPageMenuItem menuItem)
		{
			CurrentPage = new NavigationPage(_navigationService.GetPage(menuItem.TargetType));
		}

		public ObservableCollection<MainPageMenuItem> MenuItems { get; private set; }
		public CurrentUserViewModel CurrentUserViewModel { get; }

		public Page CurrentPage
		{
			get => _currentPage;
			private set => SetValue(ref _currentPage, value);
		}

		private void InitializeMenuItems()
		{
			MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
			{
				new MainPageMenuItem("Проекты", ImageSource.FromFile("baseline_computer_black_48.png"), typeof(Projects)),
				new MainPageMenuItem("Разработчики", ImageSource.FromFile("baseline_group_black_48.png"), typeof(Developers)),
				new MainPageMenuItem("Рупор", ImageSource.FromFile("baseline_chat_black_48"), typeof(AdminNotification))
			});
		}

		private readonly IAuthenticationService _authenticationService;
		private readonly INavigationService _navigationService;
		private Page _currentPage;
	}
}