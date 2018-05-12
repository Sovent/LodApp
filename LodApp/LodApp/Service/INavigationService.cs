using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LodApp.Service
{
	public interface INavigationService
	{
		Page CurrentPage { get; }
		Page GetPage(Type pageType);
		void SetRootPage<T>() where T : Page;
		void SetRootPage<T>(T page) where T : Page;
		Task NavigateModalAsync<T>() where T : Page;
		Task NavigateModalAsync<T>(T page) where T : Page;
		Task NavigateAsync<T>() where T : Page;
		Task NavigateAsync<T>(T page) where T : Page;
		Task GoBack();
	}
}