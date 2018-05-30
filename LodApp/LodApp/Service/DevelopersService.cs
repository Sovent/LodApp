﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LodApp.DataAccess;
using LodApp.DataAccess.DTO;

namespace LodApp.Service
{
	public class DevelopersService: IDevelopersService
	{
		public DevelopersService(ILodClient lodClient)
		{
			_lodClient = lodClient ?? throw new ArgumentNullException(nameof(lodClient));
		}

		public async Task<IEnumerable<DeveloperPageDeveloper>> SearchDevelopers(string searchString)
		{
			if (string.IsNullOrEmpty(searchString))
			{
				return Enumerable.Empty<DeveloperPageDeveloper>();
			}

			try
			{
				var developers = await _lodClient.SearchDevelopers(searchString);
				return developers;
			}
			catch (LodClientException)
			{
				return Enumerable.Empty<DeveloperPageDeveloper>();
			}
		}

		private readonly ILodClient _lodClient;
	}
}