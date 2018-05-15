using System;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Project : TabbedPage
	{
		public Project (ProjectViewModel viewModel)
		{
			_viewModel = viewModel;
			InitializeComponent ();
			BindingContext = viewModel;
		}

		private readonly ProjectViewModel _viewModel;
	}
}