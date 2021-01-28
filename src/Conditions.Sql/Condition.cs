using System.Text;
using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public abstract class Condition : ICondition
	{
		private readonly IFindPhrase _phraseFinder;

		protected Condition()
		{
			_phraseFinder = new RegexPhraseFinder();
		}

		protected Condition(ConditionTypes conditionType)
			: this()
		{
			ConditionType = conditionType;
		}

		public ConditionTypes ConditionType { get; }

		public abstract string ToSql();

		public virtual string Apply(string s)
		{
			const string where = "where";
			const int whereLength = 6;
			const string groupBy = "group by";
			const string orderBy = "order by";

			var sb = new StringBuilder(s);

			bool hasWhere = _phraseFinder.FindPhrase(s, where).hasPhrase;
			(bool hasGroupBy, int groupByIndex) = _phraseFinder.FindPhrase(s, groupBy);
			(bool hasOrderBy, int orderByIndex) = _phraseFinder.FindPhrase(s, orderBy);

			int insertionIndex = hasGroupBy
				? groupByIndex - 1
				: orderByIndex - 1;
			
			if (!hasWhere)
			{
				if (hasGroupBy || hasOrderBy)
				{
					sb.Insert(insertionIndex, $"{where}\n");
				}
				else
				{
					sb.AppendLine(where);
				}
				insertionIndex = _phraseFinder.FindPhrase(sb.ToString(), where).startIndex + whereLength;
			}

			string conditionType = hasWhere
				? ConditionType.ToSql().WithTrailingSpace()
				: "";
			string conditionString = $"\t{conditionType}{ToSql().InParentheses()}";

			if (hasGroupBy || hasOrderBy)
			{
				sb.Insert(insertionIndex, $"{conditionString}\n");
			}
			else
			{
				sb.AppendLine(conditionString);
			}

			string result = sb.ToString();
			return result;
		}
	}
}
