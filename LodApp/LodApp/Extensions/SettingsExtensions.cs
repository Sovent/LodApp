using Newtonsoft.Json;
using Plugin.Settings.Abstractions;

namespace LodApp.Extensions
{
	public static class SettingsExtensions
	{
		public static T Get<T>(this ISettings settings, string key)
		{
			var value = settings.GetValueOrDefault(key, null);
			if (value == null)
			{
				return default(T);
			}

			try
			{
				var deserialized = JsonConvert.DeserializeObject<T>(value);
				return deserialized;
			}
			catch (JsonException)
			{
				return default(T);
			}
		}

		public static bool AddOrUpdate<T>(this ISettings settings, string key, T value)
		{
			try
			{
				var serialized = JsonConvert.SerializeObject(value);
				return settings.AddOrUpdateValue(key, serialized);
			}
			catch (JsonException)
			{
				return false;
			}
		}
	}
}