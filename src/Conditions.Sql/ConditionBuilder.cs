﻿using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public static class ConditionBuilder
	{
		public static string And(this string s, string condition) => new ChainedCondition(ConditionTypes.And, new LiteralCondition(condition)).Apply(s);

		public static string And(this string s, ICondition condition) => new ChainedCondition(ConditionTypes.And, condition).Apply(s);
		
		public static string Or(this string s, string condition) => new ChainedCondition(ConditionTypes.Or, new LiteralCondition(condition)).Apply(s);
		
		public static string Or(this string s, ICondition condition) => new ChainedCondition(ConditionTypes.Or, condition).Apply(s);

		public static string WithLiteralCondition(this string s, string condition) => new LiteralCondition(condition).Apply(s);

		public static string WithCondition(this string s, ICondition condition) => condition.Apply(s);

		public static string WithTypedCondition<T>(this string s, ICondition<T> condition) => condition.Apply(s);

		public static string WithGroupCondition(this string s, GroupCondition condition) => condition.Apply(s);
	}
}
