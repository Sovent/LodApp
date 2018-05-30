using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using LodApp.Service;
using LodApp.Views;
using Xamarin.Forms;

namespace LodApp.ViewModels
{
	public class MainPageViewModel : ParameterizedViewModel<CurrentUserViewModel>
	{
		public MainPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
			InitializeMenuItems();
		}

		public override void Prepare(CurrentUserViewModel currentUserViewModel)
		{
			CurrentUserViewModel = currentUserViewModel;
		}

		public override async Task InitializeAsync()
		{
			await SelectMenuItemAsync(MenuItems.First());
		}

		public async Task SelectMenuItemAsync(MainPageMenuItem menuItem)
		{
			var page = await menuItem.PageFactory();
			CurrentPage = new NavigationPage(page);
		}

		public ObservableCollection<MainPageMenuItem> MenuItems { get; private set; }
		public CurrentUserViewModel CurrentUserViewModel { get; private set; }

		public Page CurrentPage
		{
			get => _currentPage;
			private set => SetValue(ref _currentPage, value);
		}

		private void InitializeMenuItems()
		{
			MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
			{
				new MainPageMenuItem(
					"Проекты",
					ImageSource.FromFile("baseline_computer_black_48.png"), 
					() => _navigationService.GetPage<ProjectsViewModel>()),
				new MainPageMenuItem(
					"Разработчики",
					ImageSource.FromFile("baseline_group_black_48.png"), 
					() => _navigationService.GetPage<ProjectsViewModel>()),
				new MainPageMenuItem(
					"Рупор",
					ImageSource.FromFile("baseline_chat_black_48"), 
					() => _navigationService.GetPage<ProjectsViewModel>())
			});
		}

		private readonly INavigationService _navigationService;
		private Page _currentPage;
	}
}