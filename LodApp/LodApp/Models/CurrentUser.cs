using System;

namespace LodApp
{
	public class CurrentUser
	{
		public CurrentUser(string displayName, Uri imageUri)
		{
			DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
			ImageUri = imageUri ?? throw new ArgumentNullException(nameof(imageUri));
		}

		public string DisplayName { get; }

		public Uri ImageUri { get; }
	}
}