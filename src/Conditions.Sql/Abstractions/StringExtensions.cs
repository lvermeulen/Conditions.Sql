namespace Conditions.Sql.Abstractions
{
	public static class StringExtensions
	{
		public static string ToSqlString(this string s) => s.SingleQuoted();

		public static string ToSqlDateTime(this string s) => $"convert(datetime,{s.SingleQuoted()}, 103)";

		public static string SingleQuoted(this string s) => $"'{s}'";

		public static string InParentheses(this string s) => $"({s})";

		public static string WithTrailingSpace(this string s) => $"{s} ";
	}
}
