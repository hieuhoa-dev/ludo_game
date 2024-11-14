using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ludogame_v4.login
{
	internal class Connection
	{
		private static string connectionString = "server = hoangphuc;database= ludoGame; integrated security= true";
		public static SqlConnection GetSqlConnection()
		{
			return new SqlConnection(connectionString);
		}
	}
}
