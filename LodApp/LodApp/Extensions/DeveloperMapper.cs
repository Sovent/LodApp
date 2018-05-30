using System.Collections.Generic;
using System.Linq;
using LodApp.DataAccess.DTO;
using LodApp.ViewModels;

namespace LodApp.Extensions
{
	public static class DeveloperMapper
	{
		public static IEnumerable<ProjectDeveloperViewModel> ToViewModel(this IEnumerable<DeveloperPageDeveloper> developers)
		{
			return developers.Select(ToViewModel);
		}

		public static ProjectDeveloperViewModel ToViewModel(this DeveloperPageDeveloper developer)
		{
			return new ProjectDeveloperViewModel(developer.UserId, developer.FirstName + " " + developer.LastName, developer.Role, null);
		}
	}
}