using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DAO
{
	public class ThongKeDAO
	{
		public static ThongKeDAO GetInstance()
		{
			return new ThongKeDAO();
		}

		public int getCountCauHoi()
		{
			int result = -1;
			try
			{
				using (SqlConnection conn = DbConnection.GetSqlConnection())
				{
					string query = "select count(ma_cau_hoi) from cau_hoi where trang_thai = 1";
					using (SqlCommand command = new SqlCommand(query, conn))
					{
						result = (int)command.ExecuteScalar();
					}
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			return result;
		}

		public int getCountHs()
		{
			int result = -1;
			try
			{
				using (SqlConnection conn = DbConnection.GetSqlConnection())
				{
					string query = "select count(users.id) from users, chi_tiet_quyen ctq where users.id = ctq.user_id and ctq.ma_quyen = 3 and users.trang_thai = 1";
					using (SqlCommand command = new SqlCommand(query, conn))
					{
						result = (int)command.ExecuteScalar();
					}
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			return result;
		}

		public int getCountGv()
		{
			int result = -1;
			try
			{
				using (SqlConnection conn = DbConnection.GetSqlConnection())
				{
					string query = "select count(users.id) from users, chi_tiet_quyen ctq where users.id = ctq.user_id and ctq.ma_quyen = 2 and users.trang_thai = 1";
					using (SqlCommand command = new SqlCommand(query, conn))
					{
						result = (int)command.ExecuteScalar();
					}
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			return result;
		}
	}
}
