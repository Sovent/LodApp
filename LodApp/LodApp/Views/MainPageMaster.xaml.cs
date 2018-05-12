using System;
using System.Linq;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
		public MainPageMaster(MainPageViewModel viewModel)
        {
	        _viewModel = viewModel;
	        InitializeComponent();

	        BindingContext = viewModel;
	        MenuItemsListView.ItemsSource = viewModel.MenuItems;
		}

	    public ListView MenuList => MenuItemsListView;

		private readonly MainPageViewModel _viewModel;
    }
}