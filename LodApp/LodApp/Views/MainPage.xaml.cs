using System;
using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage, IView<MainPageViewModel>
    {
	    public MainPage()
        {
	        InitializeComponent();
		}

	    public MainPageViewModel ViewModel
	    {
		    get => _mainPageViewModel;
		    set
		    {
			    _mainPageViewModel = value;
			    BindingContext = value;
			    _masterPage = new MainPageMaster
			    {
				    ViewModel = value
			    };
			    _masterPage.MenuList.ItemSelected += MenuListOnItemSelected;
			    Master = _masterPage;
			    value.PropertyChanged += (sender, args) =>
			    {
				    if (args.PropertyName == nameof(value.CurrentPage))
				    {
					    Detail = value.CurrentPage;
				    }
			    };
		    } 
	    }

		private async void MenuListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
			if (e?.SelectedItem == null)
		    {
			    return;
		    }

		    await _mainPageViewModel.SelectMenuItemAsync(e.SelectedItem as MainPageMenuItem);
		    Detail = _mainPageViewModel.CurrentPage;
		    IsPresented = false;
		    _masterPage.MenuList.SelectedItem = null;
		}

	    private MainPageMaster _masterPage;
	    private MainPageViewModel _mainPageViewModel;
    }
}