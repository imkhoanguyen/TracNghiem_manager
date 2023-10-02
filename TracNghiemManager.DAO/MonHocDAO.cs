using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
    public class MonHocDAO : IDAO<MonHocDTO>
    {
        public static MonHocDAO getInstance()
        {
            return new MonHocDAO();
        }
        public bool Add(MonHocDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "INSERT INTO mon_hoc (ten_mon_hoc, trang_thai)" +
                        "Values (@ten_mon_hoc, @trang_thai)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ten_mon_hoc", t.TenMonHoc);
                        command.Parameters.AddWithValue("@trang_thai", 1);
                        int rowsChanged = command.ExecuteNonQuery();
                        return rowsChanged > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "update mon_hoc set trang_thai = 0 where ma_mon_hoc = @ma_mon_hoc";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ma_mon_hoc", id);
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

        public List<MonHocDTO> GetAll()
        {
            List<MonHocDTO> monHocList = new List<MonHocDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "Select * from mon_hoc Where trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MonHocDTO monHoc = new MonHocDTO
                            {
                                MaMonHoc = Convert.ToInt32(reader["ma_mon_hoc"]),
                                TenMonHoc = reader["ten_mon_hoc"].ToString(),
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
                            };
                            monHocList.Add(monHoc);
                        }
                    }
                }
            }
            return monHocList;
        }

        public MonHocDTO GetById(int id)
        {
            MonHocDTO result = null;
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "select * from mon_hoc where ma_mon_hoc = @id and trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new MonHocDTO
                            {
                                MaMonHoc = Convert.ToInt32(reader["ma_mon_hoc"]),
                                TenMonHoc = reader["ten_mon_hoc"].ToString(),
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
                            };
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(MonHocDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "update mon_hoc set ten_mon_hoc = @ten_mon_hoc where ma_mon_hoc = @ma_mon_hoc; ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ten_mon_hoc", t.TenMonHoc);
                        command.Parameters.AddWithValue("@ma_mon_hoc", t.MaMonHoc);
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
                    string query = "select ma_mon_hoc from mon_hoc where trang_thai = 1";
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
