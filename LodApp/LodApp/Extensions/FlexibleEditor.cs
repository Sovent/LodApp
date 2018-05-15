using Xamarin.Forms;

namespace LodApp.Extensions
{
	public class FlexibleEditor : Editor
	{
		public FlexibleEditor()
		{
			TextChanged += (sender, args) =>
			{
				InvalidateMeasure();
			};
		}
	}
}