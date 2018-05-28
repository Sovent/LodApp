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
			try
			{
				InitializeComponent ();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			BindingContext = viewModel;
			InitializeScreenshots(viewModel);
		}

		private readonly ProjectViewModel _viewModel;

		private void DeveloperSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}

			DevelopersList.SelectedItem = null;
		}

		private void InitializeScreenshots(ProjectViewModel viewModel)
		{
			foreach (var source in viewModel.Screenshots)
			{
				var image = new Image()
				{
					Source = source,
					Aspect = Aspect.AspectFill
				};
				var frame = new Frame
				{
					Content = image,
					Padding = new Thickness(2)
				};
				FlexLayout.SetBasis(frame, new FlexBasis(0.5F, true));
				Screenshots.Children.Add(frame);
			}
		}
	}
}