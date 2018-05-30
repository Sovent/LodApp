using System;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingScreen : ContentPage, IView<LoadingScreenViewModel>
	{
		public LoadingScreen()
		{
			InitializeComponent ();
		}

		private void LoadingScreen_OnAppearing(object sender, EventArgs e)
		{
			_viewModel.CheckAuthenticatedCommand.Execute(null);
		}

		public LoadingScreenViewModel ViewModel
		{
			get => _viewModel;
			set
			{
				_viewModel = value;
				BindingContext = value;
			}
		}

		private LoadingScreenViewModel _viewModel;
	}
}