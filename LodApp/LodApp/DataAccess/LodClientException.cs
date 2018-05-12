using System;
using System.Runtime.Serialization;

namespace LodApp.DataAccess
{
	[Serializable]
	public class LodClientException : Exception
	{
		public LodClientException()
		{
		}

		public LodClientException(string message) : base(message)
		{
		}

		public LodClientException(string message, Exception inner) : base(message, inner)
		{
		}

		protected LodClientException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
		}
	}
}