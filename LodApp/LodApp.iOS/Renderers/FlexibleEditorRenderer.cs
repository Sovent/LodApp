using LodApp.Extensions;
using LodApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FlexibleEditor), typeof(FlexibleEditorRenderer))]
namespace LodApp.iOS.Renderers
{
	public class FlexibleEditorRenderer : EditorRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.ScrollEnabled = false;
			}
		}
	}
}