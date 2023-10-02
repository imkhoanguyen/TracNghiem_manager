using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
    public class LopDAO : IDAO<LopDTO>
    {
        public static LopDAO getInstance()
        {
            return new LopDAO();
        }
        public bool Add(LopDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "INSERT INTO lop (ma_giao_vien, ten_lop, ma_moi, trang_thai)" +
                        "VALUES (@ma_giao_vien, @ten_lop, @ma_moi, @trang_thai)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ma_giao_vien", t.MaGiaoVien);
                        command.Parameters.AddWithValue("@ten_lop", t.TenLop);
                        command.Parameters.AddWithValue("@ma_moi", t.MaMoi);
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
                    string query = "update lop set trang_thai = @trang_thai where ma_lop = @ma_lop";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ma_lop", id);
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

        public List<LopDTO> GetAll()
        {
            List<LopDTO> lopList = new List<LopDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "Select * from lop Where trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LopDTO lop = new LopDTO
                            {
                                MaLop = Convert.ToInt32(reader["ma_lop"]),
                                MaGiaoVien = Convert.ToInt32(reader["ma_giao_vien"]),
                                TenLop = reader["ten_lop"].ToString(),
                                MaMoi = reader["ma_moi"].ToString(),
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
                            };
                            lopList.Add(lop);
                        }
                    }

                }
            }
            return lopList;
        }

        public LopDTO GetById(int id)
        {
            LopDTO result = null;
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "select * from lop where ma_lop = @id and trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new LopDTO
                            {
                                MaLop = Convert.ToInt32(reader["ma_lop"]),
                                MaGiaoVien = Convert.ToInt32(reader["ma_giao_vien"]),
                                TenLop = reader["ten_lop"].ToString(),
                                MaMoi = reader["ma_moi"].ToString(),
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
                            };
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(LopDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "update lop set ten_lop = @ten_lop where ma_lop = @ma_lop";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ma_lop", t.MaLop);
                        command.Parameters.AddWithValue("@ten_lop", t.TenLop);
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
                    string query = "SELECT ma_lop from lop where trang_thai = 1";
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
