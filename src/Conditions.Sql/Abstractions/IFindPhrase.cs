namespace Conditions.Sql.Abstractions
{
	public interface IFindPhrase
	{
		(bool hasPhrase, int startIndex) FindPhrase(string s, string word);
	}
}
