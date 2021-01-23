using Conditions.Sql.Abstractions;

namespace Conditions.Sql
{
	public class TypedCondition<T> : Condition, ICondition<T>
	{
		public string Left { get; }
		public Operators Op { get; }
		public T Right { get; }

		public TypedCondition(string left, Operators op, T right)
		{
			Left = left;
			Op = op;
			Right = right;
		}

		public override string ToSql()
		{
			string right = Right.GetTypeToSql();
			return $"{Left} {Op.ToSql()} {right}";
		}
	}
}
