using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public static class ConditionTypesExtensions
	{
		public static string ToSql(this ConditionTypes conditionType) => conditionType == ConditionTypes.And
			? "and"
			: "or";
	}
}
