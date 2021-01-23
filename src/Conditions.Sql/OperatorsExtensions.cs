using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public static class OperatorsExtensions
	{
		public static string ToSql(this Operators op)
		{
			return op switch
			{
				Operators.Equals => "=",
				Operators.NotEquals => "<>",
				Operators.LessThan => "<",
				Operators.LessThanOrEquals => "<=",
				Operators.GreaterThan => ">",
				Operators.GreaterThanOrEquals => ">=",
				Operators.Like => "like",
				Operators.In => "in",
				_ => ""
			};
		}
	}
}
