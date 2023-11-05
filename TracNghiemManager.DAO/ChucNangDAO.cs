using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
	public class ChucNangDAO : IDAO<ChucNangDTO>
	{
		public static ChucNangDAO Instance = new ChucNangDAO();
		public bool Add(ChucNangDTO t)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<ChucNangDTO> GetAll()
		{
			List<ChucNangDTO> list = new List<ChucNangDTO>();
			using (SqlConnection connection = DbConnection.GetSqlConnection())
			{
				string query = "SELECT * FROM chuc_nang WHERE trang_thai = 1";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							ChucNangDTO chucNang = new ChucNangDTO();
							{
								chucNang.ma_chuc_nang = Convert.ToInt32(reader["ma_chuc_nang"]);
								chucNang.ten_chuc_nang = reader["ten_chuc_nang"].ToString();
								chucNang.trang_thai = Convert.ToInt32(reader["trang_thai"]);
							};
							list.Add(chucNang);
						}
					}

				}
				connection.Close();
			}
			return list;
		}

		public ChucNangDTO GetById(int id)
		{
			throw new NotImplementedException();
		}

		public bool Update(ChucNangDTO t)
		{
			throw new NotImplementedException();
		}

		public List<ChucNangDTO> GetTenChucNangBangUserId(int userID)
		{
			List<ChucNangDTO> list = new List<ChucNangDTO>();
			using (SqlConnection connection = DbConnection.GetSqlConnection())
			{
				string query = "SELECT cn.ten_chuc_nang, cn.ma_chuc_nang, ctcn.cho_phep FROM quyen AS q " +
					"JOIN chi_tiet_quyen AS ct ON q.ma_quyen = ct.ma_quyen " +
					"JOIN users AS u ON ct.user_id = u.id " +
					"JOIN chi_tiet_chuc_nang AS ctcn ON ctcn.ma_quyen = q.ma_quyen " +
					"JOIN chuc_nang AS cn ON cn.ma_chuc_nang = ctcn.ma_chuc_nang " +
					"WHERE ct.cho_phep = 1 AND u.trang_thai = 1 AND q.trang_thai = 1 AND u.id = " + userID;
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							ChucNangDTO chucNang = new ChucNangDTO();
							{
								chucNang.ten_chuc_nang = reader["ten_chuc_nang"].ToString();
								chucNang.ma_chuc_nang = Convert.ToInt32(reader["ma_chuc_nang"]);
								chucNang.cho_phep = Convert.ToBoolean(reader["cho_phep"]);
							};
							list.Add(chucNang);
						}
					}

				}
				connection.Close();
			}
			return list;
		}
	}
}
