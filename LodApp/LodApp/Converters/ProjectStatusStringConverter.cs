using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LodApp.DataAccess.DTO;
using Xamarin.Forms;

namespace LodApp.Converters
{
	public class ProjectStatusStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is ProjectStatus projectStatus)
			{
				return EnumDescriptions[projectStatus];
			}

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var foundDescription = EnumDescriptions.FirstOrDefault(pair => pair.Value == value.ToString());
			return foundDescription.Equals(default) ? ProjectStatus.Planned : foundDescription.Key;
		}

		private static readonly Dictionary<ProjectStatus, string> EnumDescriptions = new Dictionary<ProjectStatus, string>
		{
			{ProjectStatus.InProgress, "В процессе"},
			{ProjectStatus.Done, "Завершён" },
			{ProjectStatus.Frozen, "Заморожен"},
			{ProjectStatus.Planned, "Запланирован" }
		};
	}
}