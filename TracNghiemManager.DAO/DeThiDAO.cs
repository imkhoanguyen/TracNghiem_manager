using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
    public class DeThiDAO : IDAO<DeThiDTO>
    {
        public static DeThiDAO getInstance()
        {
            return new DeThiDAO();
        }
        public bool Add(DeThiDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "INSERT INTO de_thi (ma_mon_hoc, ma_nguoi_tao, ten_de_thi, thoi_gian_lam_bai, trang_thai)" +
                        "VALUES (@ma_mon_hoc, @ma_nguoi_tao, @ten_de_thi, @thoi_gian_lam_bai, @trang_thai)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
						command.Parameters.AddWithValue("@ma_mon_hoc", t.MaNguoiTao);
						command.Parameters.AddWithValue("@ma_nguoi_tao", t.MaNguoiTao);
                        command.Parameters.AddWithValue("@ten_de_thi", t.TenDeThi);
                        command.Parameters.AddWithValue("@thoi_gian_lam_bai", t.ThoiGianLamBai);
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
                    string query = "update de_thi set trang_thai = @trang_thai where ma_de_thi = @ma_de_thi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ma_de_thi", id);
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

        public List<DeThiDTO> GetAll()
        {
            List<DeThiDTO> dtList = new List<DeThiDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "Select * from de_thi Where trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DeThiDTO dt = new DeThiDTO
                            {
                                MaDeThi = Convert.ToInt32(reader["ma_de_thi"]),
                                MaNguoiTao = Convert.ToInt32(reader["ma_nguoi_tao"]),
                                MaMonHoc = Convert.ToInt32(reader["ma_nguoi_tao"]),
								TenDeThi = reader["ten_de_thi"].ToString(),
                                ThoiGianLamBai = Convert.ToInt32(reader["thoi_gian_lam_bai"]),
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
                            };
                            dtList.Add(dt);
                        }
                    }

                }
            }
            return dtList;
        }

        public DeThiDTO GetById(int id)
        {
            DeThiDTO result = null;
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "select * from de_thi where ma_de_thi = @id and trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new DeThiDTO
                            {
                                MaDeThi = Convert.ToInt32(reader["ma_de_thi"]),
                                MaNguoiTao = Convert.ToInt32(reader["ma_nguoi_tao"]),
                                MaMonHoc = Convert.ToInt32((reader["ma_mon_hoc"])),
                                TenDeThi = reader["ten_de_thi"].ToString(),
                                ThoiGianLamBai = Convert.ToInt32(reader["thoi_gian_lam_bai"]),
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
                            };
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(DeThiDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "update de_thi set ten_de_thi = @ten_de_thi, thoi_gian_lam_bai = @thoi_gian_lam_bai, ma_mon_hoc = @ma_mon_hoc where ma_de_thi = @ma_de_thi and trang_thai = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
						command.Parameters.AddWithValue("@ma_mon_hoc", t.MaMonHoc);
						command.Parameters.AddWithValue("@ma_de_thi", t.MaDeThi);
                        command.Parameters.AddWithValue("@ten_de_thi", t.TenDeThi);
                        command.Parameters.AddWithValue("@thoi_gian_lam_bai", t.ThoiGianLamBai);
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
                    string query = "SELECT ma_de_thi from de_thi";
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
    }
}
