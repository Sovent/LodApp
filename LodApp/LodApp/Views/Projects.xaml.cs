using System;
using System.Linq;
using LodApp.Service;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Projects : ContentPage
	{
		public Projects(ProjectsViewModel viewModel)
		{
			_viewModel = viewModel;
			InitializeComponent();
			BindingContext = viewModel;
		}

		private void Projects_OnAppearing(object sender, EventArgs e)
		{
			_viewModel.InitializeAsync();
		}
		
		private async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			var projectItem = e.Item as ProjectItemViewModel;
			if (projectItem?.ProjectId == _viewModel.ProjectItems.LastOrDefault()?.ProjectId)
			{
				_viewModel.LoadMoreAsync();
			}
		}
		
		private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (!(e.SelectedItem is ProjectItemViewModel))
			{
				return;
			}

			await _viewModel.GoToProjectDetails((ProjectItemViewModel)e.SelectedItem);
			ProjectItems.SelectedItem = null;
		}

		private readonly ProjectsViewModel _viewModel;
	}
}