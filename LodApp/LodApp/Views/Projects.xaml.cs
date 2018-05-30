using System;
using System.Linq;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Projects : ContentPage, IView<ProjectsViewModel>
	{
		public Projects()
		{
			InitializeComponent();
		}

		public ProjectsViewModel ViewModel
		{
			get => _viewModel;
			set
			{
				_viewModel = value;
				BindingContext = value;
			}
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

		private ProjectsViewModel _viewModel;
	}
}