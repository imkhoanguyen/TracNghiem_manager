using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
	public class ChiTietDeThiDAO : IDAO<ChiTietDeThiDTO>
	{
		public static ChiTietDeThiDAO getInstance()
		{
			return new ChiTietDeThiDAO();
		}

		public bool Add(ChiTietDeThiDTO t)
		{
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "INSERT INTO chi_tiet_de_thi (ma_de_thi, ma_cau_hoi)" +
						"VALUES (@ma_de_thi, @ma_cau_hoi)";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ma_de_thi", t.MaDeThi);
						command.Parameters.AddWithValue("@ma_cau_hoi", t.MaCauHoi);
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
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "delete from chi_tiet_de_thi where ma_de_thi = @ma_de_thi";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ma_de_thi", id);
						int rowsChanged = command.ExecuteNonQuery();
						return rowsChanged > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return false;
			}
		}

		public bool Delete(int maDeThi, int maCauHoi)
		{
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "delete from chi_tiet_de_thi where ma_de_thi = @ma_de_thi and ma_cau_hoi = @ma_cau_hoi";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ma_de_thi", maDeThi);
						command.Parameters.AddWithValue("@ma_cau_hoi", maCauHoi);
						int rowsChanged = command.ExecuteNonQuery();
						return rowsChanged > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return false;
			}

		}

		public List<ChiTietDeThiDTO> GetAll()
		{
			List<ChiTietDeThiDTO> list = new List<ChiTietDeThiDTO>();
			using (SqlConnection connection = DbConnection.GetSqlConnection())
			{
				string query = "SELECT * FROM chi_tiet_de_thi";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							ChiTietDeThiDTO ctdt = new ChiTietDeThiDTO
							{
								MaDeThi = Convert.ToInt32(reader["ma_chuc_nang"]),
								MaCauHoi = Convert.ToInt32(reader["ma_cau_hoi"]),

							};
							list.Add(ctdt);
						}
					}

				}
				connection.Close();
			}
			return list;
		}

		public List<CauHoiDTO> GetAllCauHoiOfDeThi(int maDeThi)
		{
			List<CauHoiDTO> list = new List<CauHoiDTO>();
			using (SqlConnection connection = DbConnection.GetSqlConnection())
			{
				string query = "SELECT cau_hoi.* from chi_tiet_de_thi" +
					" inner join cau_hoi on chi_tiet_de_thi.ma_cau_hoi = cau_hoi.ma_cau_hoi" +
					" where chi_tiet_de_thi.ma_de_thi = " + maDeThi;
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							CauHoiDTO ctdt = new CauHoiDTO
							{
								MaCauHoi = Convert.ToInt32(reader["ma_cau_hoi"]),
								NoiDung = reader["noi_dung"].ToString(),
								DoKho = reader["do_kho"].ToString(),
								MaMonHoc = Convert.ToInt32(reader["ma_mon_hoc"]),
								MaNguoiTao = Convert.ToInt32(reader["ma_nguoi_tao"]),
								TrangThai = Convert.ToInt32(reader["trang_thai"])

							};
							list.Add(ctdt);
						}
					}

				}
				connection.Close();
			}
			return list;
		}

		public ChiTietDeThiDTO GetById(int id)
		{
			ChiTietDeThiDTO result = null;
			using (SqlConnection connection = DbConnection.GetSqlConnection())
			{
				string query = "select * from chi_tiet_de_thi where ma_de_thi = @id";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@id", id);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							result = new ChiTietDeThiDTO
							{
								MaDeThi = Convert.ToInt32(reader["ma_lop"]),
								MaCauHoi = Convert.ToInt32(reader["ma_cau_hoi"]),
							};
						}
					}
				}
			}
			return result;
		}

		public bool Update(ChiTietDeThiDTO t)
		{
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "update chi_tiet_de_thi set ma_cau_hoi = @ma_cau_hoi where ma_de_thi = @ma_de_thi";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ma_de_thi", t.MaDeThi);
						command.Parameters.AddWithValue("@ma_cau_hoi", t.MaCauHoi);
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
	}
}
