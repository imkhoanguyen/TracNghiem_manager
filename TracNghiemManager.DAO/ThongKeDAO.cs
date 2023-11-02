using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO.ViewModel;

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
		public List<HocSinhTrongLop> GetAllDiemTBCuaHs(int maLop)
		{
			List<HocSinhTrongLop> list = new List<HocSinhTrongLop>();
			using (SqlConnection conn = DbConnection.GetSqlConnection())
			{
				string query = "SELECT top 5 users.id, users.ho_va_ten,  Sum(ket_qua.diem) as tong_diem FROM users " +
					"JOIN ket_qua ON users.id = ket_qua.user_id " +
					"JOIN bai_thi ON ket_qua.ma_bai_thi = bai_thi.ma_bai_thi " +
					"JOIN lop ON bai_thi.ma_lop = lop.ma_lop " +
					"JOIN chi_tiet_quyen ON users.id = chi_tiet_quyen.user_id " +
					" WHERE chi_tiet_quyen.ma_quyen = 3 AND ket_qua.ma_bai_thi = bai_thi.ma_bai_thi AND lop.ma_lop = " + maLop +
					" GROUP BY users.id, users.ho_va_ten Order by tong_diem desc";
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							HocSinhTrongLop diemTBCuaHS = new HocSinhTrongLop
							{
								MaHocSinh = Convert.ToInt32(reader["id"]),
								HoTen = reader["ho_va_ten"].ToString(),
								Diem = Convert.ToDouble(reader["tong_diem"]),
							};
							list.Add(diemTBCuaHS);
						}
					}
				}
			}
				return list;
		}

		public int getSlHsDaNopBai(int maLop, int maDeThi)
		{
			int result = -1;
			using (SqlConnection conn = DbConnection.GetSqlConnection())
			{
				string query = "SELECT count(users.id) as sLHSDaNopBai " +
					"FROM users JOIN ket_qua ON users.id = ket_qua.user_id " +
					"JOIN bai_thi ON ket_qua.ma_bai_thi = bai_thi.ma_bai_thi " +
					"JOIN lop ON bai_thi.ma_lop = lop.ma_lop " +
					"JOIN de_thi ON bai_thi.ma_de_thi = de_thi.ma_de_thi " +
					"JOIN chi_tiet_quyen ON users.id = chi_tiet_quyen.user_id " +
					"WHERE chi_tiet_quyen.ma_quyen = 3 AND ket_qua.ma_bai_thi = bai_thi.ma_bai_thi " +
					"AND lop.ma_lop = " + maLop + " AND de_thi.ma_de_thi = " + maDeThi;
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					result = (int)command.ExecuteScalar();
				}
			}
			return result;
		}

		public List<HocSinhTrongLop> GetTop5HsCoDiemCaoNhatTheoDeThi(int maLop, int maDeThi)
		{
			List<HocSinhTrongLop> list =  new List<HocSinhTrongLop>();
			using (SqlConnection conn = DbConnection.GetSqlConnection())
			{
				string query = "SELECT top 5 users.id, users.ho_va_ten,ket_qua.diem FROM users " +
					"JOIN ket_qua ON users.id = ket_qua.user_id " +
					"JOIN bai_thi ON ket_qua.ma_bai_thi = bai_thi.ma_bai_thi " +
					"JOIN lop ON bai_thi.ma_lop = lop.ma_lop " +
					"JOIN de_thi on de_thi.ma_de_thi = bai_thi.ma_de_thi " +
					"JOIN chi_tiet_quyen ON users.id = chi_tiet_quyen.user_id " +
					"WHERE chi_tiet_quyen.ma_quyen = 3 AND ket_qua.ma_bai_thi = bai_thi.ma_bai_thi AND lop.ma_lop = " + maLop +
					" And bai_thi.ma_de_thi = " + maDeThi + " GROUP BY users.id, users.ho_va_ten, ket_qua.diem" +
					" order by ket_qua.diem desc";
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							HocSinhTrongLop diemTBCuaHS = new HocSinhTrongLop
							{
								MaHocSinh = Convert.ToInt32(reader["id"]),
								HoTen = reader["ho_va_ten"].ToString(),
								Diem = Convert.ToDouble(reader["diem"]),
							};
							list.Add(diemTBCuaHS);
						}
					}
				}
			}
			return list;
		}

		public double getDiemCuaDeThiByUserId(int maLop, int maDeThi, int userId)
		{
			double result = -1;
			using (SqlConnection conn = DbConnection.GetSqlConnection())
			{
				string query = "SELECT ket_qua.diem FROM users " +
					"JOIN ket_qua ON users.id = ket_qua.user_id " +
					"JOIN bai_thi ON ket_qua.ma_bai_thi = bai_thi.ma_bai_thi " +
					"JOIN lop ON bai_thi.ma_lop = lop.ma_lop " +
					"JOIN de_thi on de_thi.ma_de_thi = bai_thi.ma_de_thi " +
					"JOIN chi_tiet_quyen ON users.id = chi_tiet_quyen.user_id " +
					"WHERE chi_tiet_quyen.ma_quyen = 3 AND ket_qua.ma_bai_thi = bai_thi.ma_bai_thi AND lop.ma_lop = " + maLop +
					" And bai_thi.ma_de_thi = " + maDeThi + " and users.id = " +  userId +
					" GROUP BY ket_qua.diem";
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					var resultObject = command.ExecuteScalar();
					if (resultObject != null && resultObject != DBNull.Value)
					{
						result = Convert.ToDouble(resultObject);
					}
				}
			}
			return result;
		}
	}
}
