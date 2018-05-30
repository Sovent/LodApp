using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LodApp.Views
{
	public class MainPageMenuItem
	{
		public MainPageMenuItem(string title, ImageSource image, Func<Task<Page>> viewModel)
		{
			Title = title ?? throw new ArgumentNullException(nameof(title));
			Image = image ?? throw new ArgumentNullException(nameof(image));
			PageFactory = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
		}

		public string Title { get; }

		public ImageSource Image { get; }

		public Func<Task<Page>> PageFactory { get; }
	}
}