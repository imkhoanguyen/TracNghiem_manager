using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
	public class KetQuaDAO : IDAO<KetQuaDTO>
	{
		public static KetQuaDAO GetInstance()
		{
			return new KetQuaDAO();
		}

		public bool Add(KetQuaDTO t)
		{
			try
			{
				using (SqlConnection connection = DbConnection.GetSqlConnection())
				{
					string query = "INSERT INTO ket_qua (ma_bai_thi, user_id, so_cau_dung, so_cau_sai, so_cau_chua_chon, diem)" +
						"VALUES (@ma_bai_thi, @user_id, @so_cau_dung, @so_cau_sai, @so_cau_chua_chon, @diem)";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ma_bai_thi", t.MaBaiThi);
						command.Parameters.AddWithValue("@user_id", t.MaThiSinh);
						command.Parameters.AddWithValue("@so_cau_dung", t.SoCauDung);
						command.Parameters.AddWithValue("@so_cau_sai", t.SoCauSai);
						command.Parameters.AddWithValue("@so_cau_chua_chon", t.SoCauChuaChon);
						command.Parameters.AddWithValue("@diem", t.Diem);

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

		public KetQuaDTO Get(int maBaiThi, int userId)
		{
			KetQuaDTO result = null;
			using (SqlConnection connection = DbConnection.GetSqlConnection())
			{
				string query = "select * from ket_qua where ma_bai_thi = @ma_bai_thi and user_id = @user_id";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@ma_bai_thi", maBaiThi);
					command.Parameters.AddWithValue("@user_id", userId);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							result = new KetQuaDTO
							{
								MaBaiThi = Convert.ToInt32(reader["ma_bai_thi"]),
								MaThiSinh = Convert.ToInt32(reader["user_id"]),
								SoCauDung = Convert.ToInt32(reader["so_cau_dung"]),
								SoCauSai = Convert.ToInt32(reader["so_cau_sai"]),
								SoCauChuaChon = Convert.ToInt32(reader["so_cau_chua_chon"]),
								Diem = Convert.ToDouble(reader["diem"]),
							};
						}
					}
				}
			}
			return result;
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<KetQuaDTO> GetAll()
		{
			throw new NotImplementedException();
		}

		public KetQuaDTO GetById(int id)
		{
			throw new NotImplementedException();
		}

		public bool Update(KetQuaDTO t)
		{
			throw new NotImplementedException();
		}
	}
}
