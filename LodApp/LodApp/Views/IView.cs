using LodApp.ViewModels;

namespace LodApp.Views
{
	public interface IView<TViewModel> where TViewModel : BaseViewModel
	{
		TViewModel ViewModel { get; set; }
	}
}