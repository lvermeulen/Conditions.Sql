using System.Collections.Generic;
using System.Linq;
using Conditions.Sql.Abstractions;
using Dapper;
using Microsoft.Extensions.Configuration;
using Xunit;
using Xunit.Abstractions;

namespace Conditions.Sql.Tests
{
	public class DapperShould : BaseDapperTest
	{
		private readonly ITestOutputHelper _testOutputHelper;
		private readonly string _connectionString;

		public DapperShould(ITestOutputHelper testOutputHelper)
		{
			_testOutputHelper = testOutputHelper;
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", false, false)
				.Build();
			_connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		private void UseConditions(bool hasWhere, bool hasGroupBy, bool hasOrderBy, IEnumerable<ICondition> conditions)
		{
			// arrange
			string sql = @"select
	b.BasketId
	, b.BuyerId
from
	basket b
";

			if (hasWhere)
			{
				sql += "where 1 = 1\n";
			}
			if (hasGroupBy)
			{
				sql += "group by b.BasketId, b.BuyerId\n";
			}
			if (hasOrderBy)
			{
				sql += "order by 1\n";
			}
			var connection = GetConnection(_connectionString);

			// act
			string sqlWithConditions = sql.WithGroupCondition(new GroupCondition(ConditionTypes.And, conditions));
			_testOutputHelper.WriteLine(sqlWithConditions);
			var result = connection.Query<Basket>(sqlWithConditions).ToList();

			// assert
			Assert.NotNull(result);
		}

		private void UseCondition(bool hasWhere, bool hasGroupBy, bool hasOrderBy, ICondition condition)
		{
			UseConditions(hasWhere, hasGroupBy, hasOrderBy, Enumerable.Repeat(condition, 1));
		}

		[Theory]
		[ClassData(typeof(ConditionTheoryData))]
		public void UseTypedConditionInt(bool hasWhere, bool hasGroupBy, bool hasOrderBy)
		{
			UseCondition(hasWhere, hasGroupBy, hasOrderBy, new TypedCondition<int>("b.BasketId", Operators.Equals, 123));
		}

		[Theory]
		[ClassData(typeof(ConditionTheoryData))]
		public void UseTypedConditionString(bool hasWhere, bool hasGroupBy, bool hasOrderBy)
		{
			UseCondition(hasWhere, hasGroupBy, hasOrderBy, new TypedCondition<string>("b.BuyerId", Operators.NotEquals, "buyer1"));
		}

		[Theory]
		[ClassData(typeof(ConditionTheoryData))]
		public void UseLiteralCondition(bool hasWhere, bool hasGroupBy, bool hasOrderBy)
		{
			UseCondition(hasWhere, hasGroupBy, hasOrderBy, new LiteralCondition("2 = 2"));
		}

		[Theory]
		[ClassData(typeof(ConditionTheoryData))]
		public void UseMultipleConditions(bool hasWhere, bool hasGroupBy, bool hasOrderBy)
		{
			UseConditions(hasWhere, hasGroupBy, hasOrderBy, new List<ICondition>
			{
				new LiteralCondition("2 = 2"),
				new TypedCondition<int>("1", Operators.NotEquals, 2),
				new GroupCondition(ConditionTypes.Or, new List<ICondition>
				{
					new LiteralCondition("3 = 3"),
					new LiteralCondition("4 <> 5")
				})
			});
		}

		[Theory]
		[ClassData(typeof(ConditionTheoryData))]
		public void UseBetweenCondition(bool hasWhere, bool hasGroupBy, bool hasOrderBy)
		{
			UseConditions(hasWhere, hasGroupBy, hasOrderBy, new List<ICondition>
			{
				new BetweenCondition("getdate()", "dateadd(day, 1, '2017/12/1')", "dateadd(day, 1, '2045/01/01')"),
				new BetweenCondition<int>(1, 0, 3)
			});
		}

		[Theory]
		[ClassData(typeof(ConditionTheoryData))]
		public void UseGroupConditions(bool hasWhere, bool hasGroupBy, bool hasOrderBy)
		{
			UseConditions(hasWhere, hasGroupBy, hasOrderBy, new List<ICondition>
			{
				new LiteralCondition("2 = 2"),
				new TypedCondition<int>("1", Operators.NotEquals, 2)
			});
		}

		[Theory]
		[ClassData(typeof(ConditionTheoryData))]
		public void UseNotCondition(bool hasWhere, bool hasGroupBy, bool hasOrderBy)
		{
			UseConditions(hasWhere, hasGroupBy, hasOrderBy, new List<ICondition>
			{
				new NotCondition(new LiteralCondition("2 = 2")),
				new NotCondition(new TypedCondition<int>("1", Operators.NotEquals, 2))
			});
		}

		[Theory]
		[InlineData("select 1")]
		[InlineData("select 1 group by 1")]
		[InlineData("select 1 order by 1")]
		[InlineData("select 1 group by 1 order by 1")]
		public void UseWhere(string sql)
		{
			sql = sql.AddWhere();
			_testOutputHelper.WriteLine(sql);
			Assert.True(new RegexPhraseFinder().FindPhrase(sql, "where").hasPhrase);
		}
	}
}
