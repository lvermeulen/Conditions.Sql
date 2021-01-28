using System.Collections.Generic;
using System.Linq;
using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public class GroupCondition : Condition
	{
		public IEnumerable<ICondition> Conditions { get; }

		public GroupCondition(ConditionTypes conditionType, IEnumerable<ICondition> conditions)
			: base(conditionType)
		{
			Conditions = conditions;
		}

		public override string ToSql() => string.Join($" {ConditionType.ToSql()} ", Conditions.Select(x => x.ToSql()));
	}
}
