using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public class NotCondition : Condition
	{
		public ICondition Condition { get; }

		public NotCondition(ConditionTypes conditionType, ICondition condition)
			: base(conditionType)
		{
			Condition = condition;
		}

		public NotCondition(ICondition condition)
			: base(ConditionTypes.And)
		{
			Condition = condition;
		}

		public override string ToSql()
		{
			return $"not {Condition.ToSql().InParentheses()}";
		}
	}
}
