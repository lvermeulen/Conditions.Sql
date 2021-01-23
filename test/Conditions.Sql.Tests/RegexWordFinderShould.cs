using Conditions.Sql.Abstractions;
using Xunit;

namespace Conditions.Sql.Tests
{
	public class RegexWordFinderShould
	{
		private readonly IFindPhrase _finder;

		public RegexWordFinderShould()
		{
			_finder = new RegexPhraseFinder();
		}

		[Theory]
		[InlineData(null, false)]
		[InlineData("", false)]
		[InlineData("where", true)]
		[InlineData(" wHeRe ", true)]
		[InlineData("this \nis where", true)]
		public void FindWhere(string s, bool expectedResult)
		{
			var result = _finder.FindPhrase(s, "where");
			Assert.Equal(expectedResult, result.hasPhrase);
			Assert.True(result.hasPhrase ? result.startIndex > -1 : result.startIndex == -1);
		}

		[Theory]
		[InlineData(null, false)]
		[InlineData("", false)]
		[InlineData("order by", true)]
		[InlineData(" order by ", true)]
		[InlineData("this \nis ORDER by really", true)]
		[InlineData("this is not order\nby ", false)]
		public void FindOrderBy(string s, bool expectedResult)
		{
			var result = _finder.FindPhrase(s, "order by");
			Assert.Equal(expectedResult, result.hasPhrase);
			Assert.True(result.hasPhrase ? result.startIndex > -1 : result.startIndex == -1);
		}
	}
}
