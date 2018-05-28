using System;

namespace LodApp.DataAccess.DTO
{
	public class Image
	{
		public Image(Uri bigPhotoUri, Uri smallPhotoUri)
		{
			BigPhotoUri = bigPhotoUri ?? throw new ArgumentNullException(nameof(bigPhotoUri));
			SmallPhotoUri = smallPhotoUri ?? throw new ArgumentNullException(nameof(smallPhotoUri));
		}

		public Uri BigPhotoUri { get; }
		public Uri SmallPhotoUri { get;  }
	}
}