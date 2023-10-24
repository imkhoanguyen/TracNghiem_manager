using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
	public class DeThiCuaLopDAO : IDAO<DeThiCuaLopDTO>
	{
		public static DeThiCuaLopDAO GetInstance()
		{
			return new DeThiCuaLopDAO();
		}

		public bool Add(DeThiCuaLopDTO t)
		{
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "INSERT INTO bai_thi (ma_de_thi, ma_lop, tg_bat_dau, tg_ket_thuc, trang_thai)" +
						"VALUES (@ma_de_thi, @ma_lop, @tg_bat_dau, @tg_ket_thuc, @trang_thai)";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ma_de_thi", t.MaDeThi);
						command.Parameters.AddWithValue("@ma_lop", t.MaLop);
						command.Parameters.AddWithValue("@tg_bat_dau", t.ThoiGianBatDau);
						command.Parameters.AddWithValue("@tg_ket_thuc", t.ThoiGianKetThuc);
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
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "update bai_thi set trang_thai = @trang_thai where ma_bai_thi = @ma_bai_thi";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ma_bai_thi", id);
						command.Parameters.AddWithValue("@trang_thai", 0);
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

		public List<DeThiCuaLopDTO> GetAll()
		{
			throw new NotImplementedException();
		}

		public List<DeThiCuaLopDTO> GetAll(int maLop)
		{
			List<DeThiCuaLopDTO> list = new List<DeThiCuaLopDTO>();
			using (SqlConnection connection = DbConnection.GetSqlConnection())
			{
				string query = "Select * from bai_thi where ma_lop = " + maLop;
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							DeThiCuaLopDTO dt = new DeThiCuaLopDTO
							{
								MaBaiThi = Convert.ToInt32(reader["ma_bai_thi"]),
								MaLop = Convert.ToInt32(reader["ma_lop"]),
								MaDeThi = Convert.ToInt32(reader["ma_de_thi"]),
								ThoiGianBatDau = Convert.ToDateTime(reader["tg_bat_dau"]),
								ThoiGianKetThuc = Convert.ToDateTime(reader["tg_ket_thuc"]),
								TrangThai = Convert.ToInt32(reader["trang_thai"])
							};
							list.Add(dt);
						}
					}

				}
			}
			return list;
		}

		public DeThiCuaLopDTO GetById(int id)
		{
			throw new NotImplementedException();
		}

		public bool Update(DeThiCuaLopDTO t)
		{
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "Update bai_thi Set tg_bat_dau = @tg_bat_dau, tg_ket_thuc = @tg_ket_thuc Where ma_bai_thi = @ma_bai_thi";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@tg_bat_dau", t.ThoiGianBatDau);
						command.Parameters.AddWithValue("@tg_ket_thuc", t.ThoiGianKetThuc);
						command.Parameters.AddWithValue("@ma_bai_thi", t.MaBaiThi);
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

		public int GetAutoIncrement()
		{
			int result = -1;
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "SELECT ma_bai_thi from bai_thi";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (!reader.HasRows)
							{
								Console.WriteLine("No data");
							}
							else
							{
								while (reader.Read())
								{
									result = reader.GetInt32(0); // Lấy giá trị cột AUTO_INCREMENT
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			return result + 1;
		}

		public int CheckDeThiCoTrongLop(int ma_de_thi, int ma_lop)
		{
			int count = -1;
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "SELECT COUNT(ma_de_thi) FROM bai_thi WHERE ma_de_thi = " + ma_de_thi + " and ma_lop = " + ma_lop;
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						count = (int)command.ExecuteScalar();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			return count;
		}

		public bool DeleteByMaLopAndMaDeThi(int maLop, int maDeThi)
		{
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "update bai_thi set trang_thai = @trang_thai where ma_lop = @ma_lop and ma_de_thi = @ma_de_thi";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ma_lop", maLop);
						command.Parameters.AddWithValue("@ma_de_thi", maDeThi);
						command.Parameters.AddWithValue("@trang_thai", 0);
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
