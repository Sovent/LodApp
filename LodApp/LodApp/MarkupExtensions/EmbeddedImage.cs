using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LodApp.MarkupExtensions
{
	[ContentProperty("ResourceId")]
	public class EmbeddedImage : IMarkupExtension
	{
		public string ResourceId { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return ResourceId == null ? null : ImageSource.FromResource(ResourceId);
		}
	}
}