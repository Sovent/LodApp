using System;

namespace LodApp.DataAccess.DTO
{
	public class UploadImageResult
	{
		public UploadImageResult(string bigPhotoName, string smallPhotoName)
		{
			BigPhotoName = bigPhotoName ?? throw new ArgumentNullException(nameof(bigPhotoName));
			SmallPhotoName = smallPhotoName ?? throw new ArgumentNullException(nameof(smallPhotoName));
		}

		public string BigPhotoName { get; }
		public string SmallPhotoName { get; }
	}
}