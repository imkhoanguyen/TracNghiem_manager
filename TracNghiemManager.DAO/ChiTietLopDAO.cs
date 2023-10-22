using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
	public class ChiTietLopDAO : IDAO<ChiTietLopDTO>
	{
		public static ChiTietLopDAO GetInstance()
		{
			return new ChiTietLopDAO();
		}
		public bool Add(ChiTietLopDTO t)
		{
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "INSERT INTO chi_tiet_lop (ma_lop, user_id, trang_thai)" +
						"VALUES (@ma_lop, @user_id, @trang_thai)";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ma_lop", t.MaLop);
						command.Parameters.AddWithValue("@user_id", t.UserId);
						command.Parameters.AddWithValue("@trang_thai", 1);
						int rowsChanged = command.ExecuteNonQuery();
						return rowsChanged > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return false;
			}
		}


		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<ChiTietLopDTO> GetAll()
		{
			throw new NotImplementedException();
		}

		public ChiTietLopDTO GetById(int id)
		{
			throw new NotImplementedException();
		}

		public bool Update(ChiTietLopDTO t)
		{
			throw new NotImplementedException();
		}
	}
}
