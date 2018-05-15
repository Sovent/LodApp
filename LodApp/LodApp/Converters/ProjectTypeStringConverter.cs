using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LodApp.DataAccess.DTO;
using Xamarin.Forms;

namespace LodApp.Converters
{
	public class ProjectTypeStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is ProjectType type)
			{
				var descriptionFound = EnumDescriptions.TryGetValue(type, out var description);
				return descriptionFound ? description : "Другое";
			}

			return "Неизвестно";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var foundDescription = EnumDescriptions.FirstOrDefault(pair => pair.Value == value.ToString());
			return foundDescription.Equals(default) ? ProjectType.Other : foundDescription.Key;
		}

		private static readonly Dictionary<ProjectType, string> EnumDescriptions = new Dictionary<ProjectType, string>
		{
			{ProjectType.Website, "Веб"},
			{ProjectType.Desktop, "Десктоп"},
			{ProjectType.Game, "Игра"},
			{ProjectType.MobileApp, "Мобильное"},
			{ProjectType.Other, "Другое" }
		};
	}
}