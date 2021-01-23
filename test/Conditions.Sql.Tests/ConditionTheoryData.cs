using Xunit;

namespace Conditions.Sql.Tests
{
	public class ConditionTheoryData : TheoryData<bool, bool, bool>
	{
		public ConditionTheoryData()
		{
			Add(false, false, false);
			Add(false, false, true);
			Add(true, false, false);
			Add(true, true, false);
			Add(true, false, true);
			Add(true, true, true);
		}
	}
}
