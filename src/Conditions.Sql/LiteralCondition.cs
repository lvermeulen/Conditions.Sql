namespace Conditions.Sql
{
	public class LiteralCondition : Condition
	{
		public string Condition { get; }

		public LiteralCondition(string literalCondition)
		{
			Condition = literalCondition;
		}

		public override string ToSql() => Condition;
	}
}
