namespace Conditions.Sql
{
	public class BetweenCondition : Condition
	{
		private readonly string _value;
		private readonly string _betweenLow;
		private readonly string _betweenHigh;

		public BetweenCondition(string value, string betweenLow, string betweenHigh)
		{
			_value = value;
			_betweenLow = betweenLow;
			_betweenHigh = betweenHigh;
		}

		public override string ToSql() => $"{_value} between {_betweenLow} and {_betweenHigh}";
	}

	public class BetweenCondition<T> : Condition
	{
		private readonly T _value;
		private readonly T _betweenLow;
		private readonly T _betweenHigh;

		public BetweenCondition(T value, T betweenLow, T betweenHigh)
		{
			_value = value;
			_betweenLow = betweenLow;
			_betweenHigh = betweenHigh;
		}

		public override string ToSql() => $"{_value} between {_betweenLow} and {_betweenHigh}";
	}
}
