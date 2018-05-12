using System;
using Xamarin.Forms;

namespace LodApp.Views
{
	public class MainPageMenuItem
    {
	    public MainPageMenuItem(string title, ImageSource image, Type targetType)
	    {
		    Title = title ?? throw new ArgumentNullException(nameof(title));
		    Image = image ?? throw new ArgumentNullException(nameof(image));
		    TargetType = targetType ?? throw new ArgumentNullException(nameof(targetType));
	    }

	    public string Title { get; set; }

		public ImageSource Image { get; set; }

        public Type TargetType { get; set; }
    }
}