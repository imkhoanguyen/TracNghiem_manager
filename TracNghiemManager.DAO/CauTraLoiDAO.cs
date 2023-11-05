using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
    public class CauTraLoiDAO : IDAO<CauTraLoiDTO>
    {
        public static CauTraLoiDAO getInstance()
        {
            return new CauTraLoiDAO();
        }
        public bool Add(CauTraLoiDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "INSERT INTO cau_tra_loi (ma_cau_hoi, noi_dung, la_dap_an)" +
                        "VALUES (@idCauHoi, @noiDung, @laDapAn)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idCauHoi", t.MaCauHoi);
                        command.Parameters.AddWithValue("@noiDung", t.NoiDung);
                        command.Parameters.AddWithValue("@laDapAn", t.DapAn);
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

        public bool Update(CauTraLoiDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "Update cau_tra_loi Set noi_dung = @noi_dung , la_dap_an = @la_dap_an Where ma_cau_tra_loi = @ma_cau_tra_loi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ma_cau_tra_loi", t.MaCauTraLoi);
                        command.Parameters.AddWithValue("@noi_dung", t.NoiDung);
                        command.Parameters.AddWithValue("@la_dap_an", t.DapAn);
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
                    string query = "delete from cau_tra_loi where ma_cau_tra_loi = " + id;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        public List<CauTraLoiDTO> GetAll()
        {
            List<CauTraLoiDTO> cauTraLoiList = new List<CauTraLoiDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "Select * from cau_tra_loi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CauTraLoiDTO cauTraLoi = new CauTraLoiDTO
                            {
                                MaCauHoi = Convert.ToInt32(reader["ma_cau_hoi"]),
                                MaCauTraLoi = Convert.ToInt32(reader["ma_cau_tra_loi"]),
                                NoiDung = reader["noi_dung"].ToString(),
                                DapAn = Convert.ToBoolean(reader["la_dap_an"]),
                            };
                            cauTraLoiList.Add(cauTraLoi);
                        }
                    }

                }
            }
            return cauTraLoiList;
        }

        public CauTraLoiDTO GetById(int id)
        {
            CauTraLoiDTO cauTraLoi = new CauTraLoiDTO();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "Select * from cau_tra_loi Where ma_cau_tra_loi = " + id;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cauTraLoi.MaCauHoi = Convert.ToInt32(reader["ma_cau_hoi"]);
                            cauTraLoi.MaCauTraLoi = Convert.ToInt32(reader["ma_cau_tra_loi"]);
                            cauTraLoi.NoiDung = reader["noi_dung"].ToString();
                            cauTraLoi.DapAn = Convert.ToBoolean(reader["la_dap_an"]);
                        }
                    }
                }
            }
            return cauTraLoi;
        }
        public int GetAutoIncrement()
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "SELECT ma_cau_tra_loi from cau_tra_loi ";
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
        public List<CauTraLoiDTO> getByMaCauHoi(int mch)
        {
            List<CauTraLoiDTO> cauTraLoiList = new List<CauTraLoiDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "SELECT * from cau_tra_loi where ma_cau_hoi = " + mch;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CauTraLoiDTO cauTraLoi = new CauTraLoiDTO
                            {
                                MaCauHoi = Convert.ToInt32(reader["ma_cau_hoi"]),
                                MaCauTraLoi = Convert.ToInt32(reader["ma_cau_tra_loi"]),
                                NoiDung = reader["noi_dung"].ToString(),
                                DapAn = Convert.ToBoolean(reader["la_dap_an"]),
                            };
                            cauTraLoiList.Add(cauTraLoi);
                        }
                    }

                }
            }
            return cauTraLoiList;
        }
    }
}
