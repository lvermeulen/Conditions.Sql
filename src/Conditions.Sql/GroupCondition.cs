using System.Collections.Generic;
using System.Linq;
using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public class GroupCondition : ChainedCondition
	{
		public IEnumerable<IChainedCondition> Conditions { get; }

		public GroupCondition(ConditionTypes conditionType, IEnumerable<IChainedCondition> conditions)
			: base(conditionType)
		{
			Conditions = conditions;
		}

		public GroupCondition(ConditionTypes conditionType, IEnumerable<ICondition> conditions)
			: this(conditionType, conditions.Select(x => new ChainedCondition(conditionType, x)))
		{ }

		public override string ToSql() => string.Join($" {ConditionType.ToSql()} ", Conditions.Select(x => x.ToSql()));
	}
}
