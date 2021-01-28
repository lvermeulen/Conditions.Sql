namespace Conditions.Sql.Abstractions
{
	public static class StringExtensions
	{
		public static string ToSqlString(this string s) => s.SingleQuoted();

		public static string ToSqlDateTime(this string s) => $"convert(datetime,{s.SingleQuoted()}, 103)";

		public static string SingleQuoted(this string s) => $"'{s}'";

		public static string InParentheses(this string s) => $"({s})";

		public static string WithTrailingSpace(this string s) => $"{s} ";

		public static string AddWhere(this string s, IFindPhrase phraseFinder)
		{
			const string where = "where";

			(bool hasGroupBy, int groupByIndex) = phraseFinder.FindPhrase(s, "group by");
			(bool hasOrderBy, int orderByIndex) = phraseFinder.FindPhrase(s, "order by");

			int insertionIndex = hasGroupBy
				? groupByIndex - 1
				: orderByIndex - 1;

			if (hasGroupBy || hasOrderBy)
			{
				s = s.Insert(insertionIndex, $"\n{where}\n");
			}
			else
			{
				s += $"\n{where}\n";
			}

			return s;
		}

		public static string AddWhere(this string s)
		{
			IFindPhrase phraseFinder = new RegexPhraseFinder();
			return s.AddWhere(phraseFinder);
		}
	}
}
