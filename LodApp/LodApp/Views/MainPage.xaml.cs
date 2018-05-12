using System;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
	    public MainPage(MainPageViewModel mainPageViewModel)
        {
	        _mainPageViewModel = mainPageViewModel;
	        InitializeComponent();
	        BindingContext = mainPageViewModel;
	        _masterPage = new MainPageMaster(mainPageViewModel);
	        Master = _masterPage;
	        Detail = mainPageViewModel.CurrentPage;
			_masterPage.MenuList.ItemSelected += MenuListOnItemSelected;
        }

	    private void MenuListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
			if (e?.SelectedItem == null)
		    {
			    return;
		    }

		    _mainPageViewModel.SelectMenuItem(e.SelectedItem as MainPageMenuItem);
		    Detail = _mainPageViewModel.CurrentPage;
		    IsPresented = false;
		    _masterPage.MenuList.SelectedItem = null;
		}

	    private readonly MainPageMaster _masterPage;
	    private readonly MainPageViewModel _mainPageViewModel;
	}
}