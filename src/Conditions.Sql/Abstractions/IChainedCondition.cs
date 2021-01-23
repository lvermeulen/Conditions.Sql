namespace Conditions.Sql.Abstractions
{
	public interface IChainedCondition : ICondition
	{
		ConditionTypes ConditionType { get; }
	}
}
