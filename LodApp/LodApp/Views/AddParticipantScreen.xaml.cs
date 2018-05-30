using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddParticipantScreen : ContentPage, IView<AddParticipantViewModel>
	{
		public AddParticipantScreen ()
		{
			InitializeComponent ();
		}

		public AddParticipantViewModel ViewModel
		{
			get => _viewModel;
			set
			{
				_viewModel = value;
				BindingContext = _viewModel;
			} 
		}

		protected override bool OnBackButtonPressed()
		{
			_viewModel.Return.Execute(null);
			return true;
		}

		private AddParticipantViewModel _viewModel;
	}
}