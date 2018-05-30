using System.Threading.Tasks;
using LodApp.ViewModels;
using Xamarin.Forms;

namespace LodApp.Service
{
	public interface INavigationService
	{
		Task<Page> GetPage<TViewModel>() where TViewModel : BaseViewModel;
		Task GoBack();
		Task SetRootViewModelAsync<TViewModel>() where TViewModel : BaseViewModel;
		Task SetRootViewModelAsync<TViewModel, TParam>(TParam parameter) where TViewModel : ParameterizedViewModel<TParam>;
		Task NavigateModalAsync<TViewModel>() where TViewModel : BaseViewModel;
		Task NavigateModalAsync<TViewModel, TParam>(TParam parameter) where TViewModel : ParameterizedViewModel<TParam>;
		Task NavigateAsync<TViewModel>() where TViewModel : BaseViewModel;
		Task NavigateAsync<TViewModel, TParam>(TParam parameter) where TViewModel : ParameterizedViewModel<TParam>;
	}
}