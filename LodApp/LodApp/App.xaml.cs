using Acr.UserDialogs;
using LodApp.DataAccess;
using LodApp.Service;
using LodApp.ViewModels;
using LodApp.Views;
using SimpleInjector;
using Xamarin.Forms;

namespace LodApp
{
	public partial class App : Application
	{
		public App ()
		{
			LiveReload.Init();
			InitializeComponent();

			var container = new Container();

			RegisterViews(container);
			container.RegisterSingleton<ILodClient, LodClient>();
			container.RegisterSingleton<IAuthenticationService, AuthenticationService>();
			container.RegisterSingleton<IProjectsService, ProjectsService>();
			container.RegisterSingleton<IDevelopersService, DevelopersService>();
			container.RegisterInstance(UserDialogs.Instance);
			_navigationService = new NavigationService(container);
			container.RegisterInstance(_navigationService);
		}

		protected override async void OnStart ()
		{
			await _navigationService.SetRootViewModelAsync<LoadingScreenViewModel>();
		}

		protected override void OnSleep ()
		{
		}

		protected override void OnResume ()
		{
		}

		private void RegisterViews(Container container)
		{
			container.Register<IView<AddParticipantViewModel>, AddParticipantScreen>();
			container.Register<IView<LoginScreenViewModel>, LoginScreen>();
			container.Register<IView<LoadingScreenViewModel>, LoadingScreen>();
			container.Register<IView<MainPageViewModel>, MainPage>();
			container.Register<IView<ProjectsViewModel>, Projects>();
			container.Register<IView<ProjectViewModel>, Project>();
		}

		private readonly INavigationService _navigationService;
	}
}
