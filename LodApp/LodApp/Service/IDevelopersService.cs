using System.Collections.Generic;
using System.Threading.Tasks;
using LodApp.DataAccess.DTO;

namespace LodApp.Service
{
	public interface IDevelopersService
	{
		Task<IEnumerable<DeveloperPageDeveloper>> SearchDevelopers(string searchString);
	}
}