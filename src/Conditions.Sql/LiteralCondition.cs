using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public class LiteralCondition : Condition
	{
		public string Condition { get; }

		public LiteralCondition(ConditionTypes conditionType, string literalCondition)
			: base(conditionType)
		{
			Condition = literalCondition;
		}

		public LiteralCondition(string literalCondition)
			: this(ConditionTypes.And, literalCondition)
		{ }

		public override string ToSql() => Condition;
	}
}
