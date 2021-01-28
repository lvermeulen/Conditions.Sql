namespace Conditions.Sql.Abstractions
{
	public interface ICondition
	{
		ConditionTypes ConditionType { get; }
		string ToSql();
		string Apply(string s);
	}

	public interface ICondition<out T> : ICondition
	{
		string Left { get; }
		Operators Op { get; }
		T Right { get; }
	}
}
