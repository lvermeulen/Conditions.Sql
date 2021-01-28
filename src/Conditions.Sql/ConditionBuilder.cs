using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public static class ConditionBuilder
	{
		public static string And(this string s, string condition) => new LiteralCondition(ConditionTypes.And, condition).Apply(s);

		public static string And(this string s, ICondition condition) => condition.Apply(s);
		
		public static string Or(this string s, string condition) => new LiteralCondition(ConditionTypes.Or, condition).Apply(s);
		
		public static string Or(this string s, ICondition condition) => condition.Apply(s);

		public static string WithLiteralCondition(this string s, ConditionTypes conditionType, string condition) => new LiteralCondition(conditionType, condition).Apply(s);

		public static string WithLiteralCondition(this string s, string condition) => s.WithLiteralCondition(ConditionTypes.And, condition);

		public static string WithCondition(this string s, ICondition condition) => condition.Apply(s);

		public static string WithTypedCondition<T>(this string s, ICondition<T> condition) => condition.Apply(s);

		public static string WithGroupCondition(this string s, GroupCondition condition) => condition.Apply(s);

		public static string WithBetweenCondition(this string s, string value, string betweenLow, string betweenHigh) => new BetweenCondition(value, betweenLow, betweenHigh).Apply(s);

		public static string WithBetweenCondition<T>(this string s, T value, T betweenLow, T betweenHigh) => new BetweenCondition<T>(value, betweenLow, betweenHigh).Apply(s);

		public static string WithBetweenCondition(this string s, BetweenCondition condition) => condition.Apply(s);

		public static string WithNotCondition(this string s, string condition) => new NotCondition(new LiteralCondition(condition)).Apply(s);

		public static string WithNotCondition(this string s, ConditionTypes conditionType, string condition) => new NotCondition(conditionType, new LiteralCondition(condition)).Apply(s);

		public static string WithNotCondition(this string s, ICondition condition) => condition.Apply(s);

		public static string WithWhere(this string s) => s.AddWhere();
	}
}
