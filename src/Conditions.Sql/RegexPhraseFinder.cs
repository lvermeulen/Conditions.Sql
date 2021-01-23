using System.Text.RegularExpressions;
using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public class RegexPhraseFinder : IFindPhrase
	{
		public (bool hasPhrase, int startIndex) FindPhrase(string s, string word)
		{
			int index = -1;
			if (s is null)
			{
				return (false, index);
			}

			string pattern = $@"\b{word}\b";
			var regex = new Regex(pattern, RegexOptions.IgnoreCase);
			var match = regex.Match(s);
			if (match.Success)
			{
				index = match.Index;
			}

			return (match.Success, index);
		}
	}
}
