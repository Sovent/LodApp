using System;
using Xamarin.Forms;

namespace LodApp.ViewModels
{
	public class CurrentUserViewModel : BaseViewModel
	{
		public CurrentUserViewModel(string displayName, Uri imageUri)
		{
			_displayName = displayName ?? throw new ArgumentNullException(nameof(displayName));

			_imageSource = imageUri == null 
				? ImageSource.FromResource("LodApp.Images.developer-default-photo.png") 
				: new UriImageSource { CachingEnabled = true, CacheValidity = TimeSpan.FromDays(1), Uri = imageUri };
		}

		public string DisplayName
		{
			get => _displayName;
			set => SetValue(ref _displayName, value);
		}

		public ImageSource ImageSource
		{
			get => _imageSource;
			set => SetValue(ref _imageSource, value);
		}

		private string _displayName;
		private ImageSource _imageSource;
	}
}