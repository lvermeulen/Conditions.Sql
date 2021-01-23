using System.Data;
using Microsoft.Data.SqlClient;

namespace Conditions.Sql.Tests
{
	public abstract class BaseDapperTest
	{
		protected IDbConnection GetConnection(string connectionString)
		{
			return new SqlConnection(connectionString);
		}
	}
}
