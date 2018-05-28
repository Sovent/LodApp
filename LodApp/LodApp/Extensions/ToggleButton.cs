using Xamarin.Forms;

namespace LodApp.Extensions
{
	public class ToggleButton : Button
	{
		public ToggleButton()
		{
			Pressed += (sender, args) => IsToggled = !IsToggled;
		}

		public static readonly BindableProperty ToggledColorProperty = 
			BindableProperty.Create(
				propertyName: nameof(ToggledColor),
				returnType: typeof(Color), 
				declaringType: typeof(ToggleButton),
				defaultValue:default(Color),
				defaultValueCreator: bindable => ((Button)bindable).BackgroundColor);
		public Color ToggledColor
		{
			get => (Color)GetValue(ToggledColorProperty);
			set => SetValue(ToggledColorProperty, value);
		}

		public static readonly BindableProperty DefaultColorProperty =
			BindableProperty.Create(
				propertyName:nameof(DefaultColor), 
				returnType: typeof(Color), 
				declaringType:typeof(ToggleButton),
				defaultValue: default(Color),
				defaultValueCreator: bindable => ((Button)bindable).BackgroundColor);
		public Color DefaultColor
		{
			get => (Color)GetValue(DefaultColorProperty);
			set => SetValue(DefaultColorProperty, value);
		}

		public static readonly BindableProperty IsToggledProperty =
			BindableProperty.Create(
				propertyName: nameof(IsToggled),
				returnType: typeof(bool),
				declaringType: typeof(ToggleButton),
				defaultValue:false,
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					if (newValue.Equals(oldValue)) return;
					var button = (ToggleButton)bindable;
					var isToggled = (bool) newValue;
					button.BackgroundColor = isToggled ? button.ToggledColor : button.DefaultColor;
				});
		public bool IsToggled
		{
			get => (bool)GetValue(IsToggledProperty);
			set => SetValue(IsToggledProperty, value);
		}
	}
}