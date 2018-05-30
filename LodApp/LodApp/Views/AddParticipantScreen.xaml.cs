using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddParticipantScreen : ContentPage
	{
		public AddParticipantScreen (AddParticipantViewModel viewModel)
		{
			InitializeComponent ();
			BindingContext = viewModel;
		}
	}
}