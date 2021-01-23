using System;

namespace Conditions.Sql.Abstractions
{
	public static class TypeExtensions
	{
		public static string GetTypeToSql<T>(this T t)
		{
			var targetType = typeof(T);
			string result = t.ToString();

			if (targetType == typeof(string))
			{
				result = result.ToSqlString();
			}
			else if (targetType == typeof(DateTime))
			{
				result = result.ToSqlDateTime();
			}

			return result;
		}
	}
}
