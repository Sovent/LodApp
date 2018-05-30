namespace LodApp.ViewModels
{
	public abstract class ParameterizedViewModel<T> : BaseViewModel
	{
		public abstract void Prepare(T initialParameter);
	}
}