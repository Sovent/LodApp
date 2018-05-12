using LodApp.DataAccess;
using LodApp.Service;
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

			container.RegisterSingleton<ILodClient, LodClient>();
			container.RegisterSingleton<IAuthenticationService, AuthenticationService>();
			container.RegisterSingleton<IProjectsService, ProjectsService>();
			var navigationService = new NavigationService(container);
			container.RegisterInstance<INavigationService>(navigationService);

			navigationService.SetRootPage<LoadingScreen>();
		}

		protected override void OnStart ()
		{
		}

		protected override void OnSleep ()
		{
		}

		protected override void OnResume ()
		{
		}
	}
}
