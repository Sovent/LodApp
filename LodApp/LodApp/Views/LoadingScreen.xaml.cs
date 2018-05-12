using System;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingScreen : ContentPage
	{
		public LoadingScreen(LoadingScreenViewModel viewModel)
		{
			_viewModel = viewModel;
			InitializeComponent ();
		}

		private void LoadingScreen_OnAppearing(object sender, EventArgs e)
		{
			_viewModel.CheckAuthenticatedCommand.Execute(null);
		}

		private readonly LoadingScreenViewModel _viewModel;
	}
}