using System;
using System.Collections.Generic;

namespace LodApp.DataAccess.DTO
{
	public class PaginableObject<T>
	{
		public PaginableObject(IEnumerable<T> data, int countOfEntities)
		{
			Data = data ?? throw new ArgumentNullException(nameof(data));
			CountOfEntities = countOfEntities;
		}

		public IEnumerable<T> Data { get; }

		public int CountOfEntities { get; }
	}
}