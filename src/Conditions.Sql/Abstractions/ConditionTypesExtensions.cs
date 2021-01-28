namespace Conditions.Sql.Abstractions
{
	public static class ConditionTypesExtensions
	{
		public static string ToSql(this ConditionTypes conditionType) => conditionType == ConditionTypes.And
			? "and"
			: "or";
	}
}
