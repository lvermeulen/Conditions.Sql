using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public class ChainedCondition : Condition, IChainedCondition
	{
		public ConditionTypes ConditionType { get; }
		public ICondition Condition { get; }

		protected ChainedCondition(ConditionTypes conditionType)
		{
			ConditionType = conditionType;
		}

		public ChainedCondition(ConditionTypes conditionType, ICondition condition)
			: this(conditionType)
		{
			Condition = condition;
		}

		public override string ToSql() => $"{Condition.ToSql()}";
	}
}
