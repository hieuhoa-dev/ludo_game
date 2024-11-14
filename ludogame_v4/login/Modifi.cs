using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ludogame_v4.login
{
	internal class Modifi
	{
		public Modifi()
		{

		}

		SqlCommand sqlCommand;
		SqlDataReader dataReader;
		public List<TaiKhoan> TaiKhoans(string query)
		{
			List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
			using (SqlConnection sqlConnection = Connection.GetSqlConnection())
			{
				sqlConnection.Open();
				sqlCommand = new SqlCommand(query, sqlConnection);
				dataReader = sqlCommand.ExecuteReader();
				while (dataReader.Read())
				{
					taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
				}
				sqlConnection.Close();
			}

			return taiKhoans;
		}
		public void Command(string query)//dung de dang ky tai khoan
		{
			using (SqlConnection sqlConnection = Connection.GetSqlConnection())
			{
				sqlConnection.Open();
				sqlCommand = new SqlCommand(query, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
		//public string SelectPassword(string query)
		//{
		//	string pw = "";
		//	using (SqlConnection sqlConnection = Connection.GetSqlConnection())
		//	{
		//		sqlConnection.Open();
		//		sqlCommand = new SqlCommand(query, sqlConnection);
		//		dataReader = sqlCommand.ExecuteReader();

		//		pw = dataReader.GetString(0);
		//		sqlConnection.Close();
		//		return pw;
		//	}
		//}

	}
}
