using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LodApp.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public virtual Task InitializeAsync()
		{
			return Task.CompletedTask;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingField, value))
			{
				return;
			}

			backingField = value;
			OnPropertyChanged(propertyName);
		}
	}
}