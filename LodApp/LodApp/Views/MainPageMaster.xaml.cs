using LodApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage, IView<MainPageViewModel>
    {
		public MainPageMaster()
        {
	        InitializeComponent();
		}

	    public ListView MenuList => MenuItemsListView;

	    public MainPageViewModel ViewModel
	    {
		    get => _viewModel;
		    set
		    {
			    _viewModel = value;
			    BindingContext = value;
			    MenuItemsListView.ItemsSource = value.MenuItems;
		    } 
	    }

	    private MainPageViewModel _viewModel;
	}
}