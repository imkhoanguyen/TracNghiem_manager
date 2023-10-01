using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
    public class CauHoiDAO : IDAO<CauHoiDTO>
    {
        public static CauHoiDAO getInstance()
        {
            return new CauHoiDAO();
        }
        public bool Add(CauHoiDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "INSERT INTO cau_hoi (noi_dung, ma_nguoi_tao, ma_mon_hoc, do_kho, trang_thai)" +
                        "VALUES (@noi_dung, @ma_nguoi_tao, @ma_mon_hoc, @do_kho, @trangThai)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@noi_dung", t.NoiDung);
                        command.Parameters.AddWithValue("@ma_nguoi_tao", t.MaNguoiTao);
                        command.Parameters.AddWithValue("@ma_mon_hoc", t.MaMonHoc);
                        command.Parameters.AddWithValue("@do_kho", t.DoKho);
                        command.Parameters.AddWithValue("@trangThai", 1);
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

        public bool Update(CauHoiDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "update cau_hoi set noi_dung = @noi_dung, ma_mon_hoc = @ma_mon_hoc, do_kho = @do_kho where ma_cau_hoi = @ma_cau_hoi; ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ma_cau_hoi", t.MaCauHoi);
                        command.Parameters.AddWithValue("@noi_dung", t.NoiDung);
                        command.Parameters.AddWithValue("@ma_mon_hoc", t.MaMonHoc);
                        command.Parameters.AddWithValue("@do_kho", t.DoKho);

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
                    string query = "update cau_hoi set trang_thai = @trang_thai where ma_cau_hoi = @ma_cau_hoi;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ma_cau_hoi", id);
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

        public List<CauHoiDTO> GetAll()
        {
            List<CauHoiDTO> cauHoiList = new List<CauHoiDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "Select * from cau_hoi Where trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CauHoiDTO cauHoi = new CauHoiDTO
                            {
                                MaCauHoi = Convert.ToInt32(reader["ma_cau_hoi"]),
                                NoiDung = reader["noi_dung"].ToString(),
                                DoKho = reader["do_kho"].ToString(),
                                MaMonHoc = Convert.ToInt32(reader["ma_mon_hoc"]),
                                MaNguoiTao = Convert.ToInt32(reader["ma_nguoi_tao"]),
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
                            };
                            cauHoiList.Add(cauHoi);
                        }
                    }

                }
            }
            return cauHoiList;
        }

        public CauHoiDTO GetById(int id)
        {
            CauHoiDTO result = null;
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "select * from cau_hoi where ma_cau_hoi = @id and trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new CauHoiDTO
                            {
                                MaCauHoi = Convert.ToInt32(reader["ma_cau_hoi"]),
                                NoiDung = reader["noi_dung"].ToString(),
                                DoKho = reader["do_kho"].ToString(),
                                MaMonHoc = Convert.ToInt32(reader["ma_mon_hoc"]),
                                MaNguoiTao = Convert.ToInt32(reader["ma_nguoi_tao"]),
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
                            };
                        }
                    }
                }
            }
            return result;
        }

      
        public int GetAutoIncrement()
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "SELECT ma_cau_hoi from cau_hoi where trang_thai = 1";
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
