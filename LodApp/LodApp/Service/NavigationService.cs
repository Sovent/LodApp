using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LodApp.ViewModels;
using LodApp.Views;
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

		public async Task<Page> GetPage<TViewModel>() where TViewModel : BaseViewModel
		{
			var (viewModel, page) = GetView<TViewModel>();
			await viewModel.InitializeAsync();
			return page;
		}

		public Task SetRootViewModelAsync<TViewModel>() where TViewModel : BaseViewModel
		{
			var (viewModel, page) = GetView<TViewModel>();
			SetRootPage(page);
			return viewModel.InitializeAsync();
		}

		public Task SetRootViewModelAsync<TViewModel, TParam>(TParam parameter) where TViewModel : ParameterizedViewModel<TParam>
		{
			var (viewModel, page) = GetView<TViewModel, TParam>(parameter);
			SetRootPage(page);
			return viewModel.InitializeAsync();
		}

		public async Task NavigateModalAsync<TViewModel>() where TViewModel : BaseViewModel
		{
			var (viewModel, page) = GetView<TViewModel>();
			await NavigateModalAsync(page);
			await viewModel.InitializeAsync();
		}

		public async Task NavigateModalAsync<TViewModel, TParam>(TParam parameter) where TViewModel : ParameterizedViewModel<TParam>
		{
			var (viewModel, page) = GetView<TViewModel, TParam>(parameter);
			await NavigateModalAsync(page);
			await viewModel.InitializeAsync();
		}

		public async Task NavigateAsync<TViewModel>() where TViewModel : BaseViewModel
		{
			var (viewModel, page) = GetView<TViewModel>();
			await NavigateAsync(page);
			await viewModel.InitializeAsync();
		}

		public async Task NavigateAsync<TViewModel, TParam>(TParam parameter) where TViewModel : ParameterizedViewModel<TParam>
		{
			var (viewModel, page) = GetView<TViewModel, TParam>(parameter);
			await NavigateAsync(page);
			await viewModel.InitializeAsync();
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

		private (TViewModel, Page) GetView<TViewModel>() where TViewModel : BaseViewModel
		{
			var viewModel = _container.GetInstance<TViewModel>();
			var view = _container.GetInstance<IView<TViewModel>>();
			view.ViewModel = viewModel;
			return (viewModel, (Page) view);
		}

		private (TViewModel, Page) GetView<TViewModel, TParam>(TParam parameter) where TViewModel : ParameterizedViewModel<TParam>
		{
			var viewModel = _container.GetInstance<TViewModel>();
			viewModel.Prepare(parameter);
			var view = _container.GetInstance<IView<TViewModel>>();
			view.ViewModel = viewModel;
			return (viewModel, (Page)view);
		}

		private void SetRootPage<T>(T page) where T : Page
		{
			_navigationPageStack.Clear();
			NavigationPage.SetHasNavigationBar(page, false);
			var mainPage = new NavigationPage(page);
			_navigationPageStack.Push(mainPage);
			Application.Current.MainPage = mainPage;
		}

		private async Task NavigateModalAsync<T>(T page) where T : Page
		{
			NavigationPage.SetHasNavigationBar(page, false);
			var modalNavigationPage = new NavigationPage(page);
			await CurrentNavigationPage.Navigation.PushModalAsync(modalNavigationPage, true);
			_navigationPageStack.Push(modalNavigationPage);
		}

		private async Task NavigateAsync<T>(T page) where T : Page
		{
			await CurrentNavigationPage.Navigation.PushAsync(page, true);
		}

		private readonly Container _container;
		private readonly Stack<NavigationPage> _navigationPageStack = new Stack<NavigationPage>();
		private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();
	}
}