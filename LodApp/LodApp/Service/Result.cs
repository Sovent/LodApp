namespace LodApp.Service
{
	public class Result<T>
	{
		public static Result<T> Successful(T value)
		{
			return new Result<T>
			{
				Value = value
			};
		}

		public static Result<T> Failed(string errorMessage)
		{
			return new Result<T>
			{
				ErrorMessage = errorMessage
			};
		}

		public T Value { get; private set; }

		public string ErrorMessage { get; private set; }

		public bool IsError => Value == null;

		private Result() {}
	}
}