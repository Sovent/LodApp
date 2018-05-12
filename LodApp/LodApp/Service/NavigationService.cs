using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SimpleInjector;
using Xamarin.Forms;

namespace LodApp.Service
{
	public class NavigationService : INavigationService
	{
		public NavigationService(Container container)
		{
			_container = container ?? throw new ArgumentNullException(nameof(container));
		}

		public Page GetPage(Type pageType)
		{
			return (Page)_container.GetInstance(pageType);
		}

		public void SetRootPage<T>() where T : Page
		{
			var rootPage = _container.GetInstance<T>();
			SetRootPage(rootPage);
		}

		public void SetRootPage<T>(T page) where T : Page
		{
			_navigationPageStack.Clear();
			NavigationPage.SetHasNavigationBar(page, false);
			var mainPage = new NavigationPage(page);
			_navigationPageStack.Push(mainPage);
			Application.Current.MainPage = mainPage;
		}

		public Page CurrentPage => CurrentNavigationPage?.CurrentPage;

		public Task NavigateModalAsync<T>() where T : Page
		{
			var page = _container.GetInstance<T>();
			return NavigateModalAsync(page);
		}

		public async Task NavigateModalAsync<T>(T page) where T : Page
		{
			NavigationPage.SetHasNavigationBar(page, false);
			var modalNavigationPage = new NavigationPage(page);
			await CurrentNavigationPage.Navigation.PushModalAsync(modalNavigationPage, true);
			_navigationPageStack.Push(modalNavigationPage);
		}

		public async Task NavigateAsync<T>() where T : Page
		{
			var page = _container.GetInstance<T>();
			await CurrentNavigationPage.Navigation.PushAsync(page, true);
		}

		public async Task NavigateAsync<T>(T page) where T : Page
		{
			await CurrentNavigationPage.Navigation.PushAsync(page, true);
		}

		public async Task GoBack()
		{
			var navigationStack = CurrentNavigationPage.Navigation;
			if (navigationStack.NavigationStack.Count > 1)
			{
				await CurrentNavigationPage.PopAsync();
				return;
			}

			if (_navigationPageStack.Count > 1)
			{
				_navigationPageStack.Pop();
				await CurrentNavigationPage.Navigation.PopModalAsync();
				return;
			}

			await CurrentNavigationPage.PopAsync();
		}

		private readonly Container _container;
		private readonly Stack<NavigationPage> _navigationPageStack =
			new Stack<NavigationPage>();
		private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();
	}
}