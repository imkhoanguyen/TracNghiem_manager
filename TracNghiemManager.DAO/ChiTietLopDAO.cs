using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;
using TracNghiemManager.DTO.ViewModel;

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

		public List<HocSinhTrongLop> GetAllHSTrongLop(int maLop)
		{
			List<HocSinhTrongLop> l = new List<HocSinhTrongLop>();

			using (SqlConnection connection = DbConnection.GetSqlConnection())
			{
				string query = "select ctl.user_id, u.ho_va_ten, u.email from chi_tiet_lop ctl join users u on ctl.user_id = u.id " +
					"join lop on ctl.ma_lop = lop.ma_lop where ctl.ma_lop = " + maLop;
				using (SqlCommand cmd = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							HocSinhTrongLop hs = new HocSinhTrongLop
							{
								MaHocSinh = Convert.ToInt32(reader["user_id"]),
								HoTen = reader["ho_va_ten"].ToString(),
								Email = reader["email"].ToString(),
							};
							l.Add(hs);
						}
					}
				}
			}
			return l;
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
