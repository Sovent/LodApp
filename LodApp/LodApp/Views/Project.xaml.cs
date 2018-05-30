using System;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Project : TabbedPage, IView<ProjectViewModel>
	{
		public Project()
		{
			try
			{
				InitializeComponent();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public ProjectViewModel ViewModel
		{
			get => _viewModel;
			set
			{
				_viewModel = value;
				BindingContext = value;
				value.PropertyChanged += (sender, args) =>
				{
					if (args.PropertyName == nameof(value.Screenshots))
					{
						InitializeScreenshots();
					}
				};
			}
		}

		private void DeveloperSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}

			DevelopersList.SelectedItem = null;
		}

		private void InitializeScreenshots()
		{
			Screenshots.Children.Clear();
			foreach (var source in _viewModel.Screenshots)
			{
				var image = new Image
				{
					Source = source,
					Aspect = Aspect.AspectFill
				};
				var frame = new Frame
				{
					Content = image,
					Padding = new Thickness(2),
					HeightRequest = 300
				};
				FlexLayout.SetBasis(frame, new FlexBasis(0.5F, true));
				Screenshots.Children.Add(frame);
			}
		}

		private ProjectViewModel _viewModel;
	}
}