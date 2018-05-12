using System;
using LodApp.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Projects : ContentPage
	{
		public Projects()
		{
			InitializeComponent();
		}

		private async void Projects_OnAppearing(object sender, EventArgs e)
		{

		}
		
	}
}