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
        public bool Add(CauTraLoiDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "INSERT INTO cau_tra_loi (ma_cau_hoi, noi_dung, do_kho, la_dap_an, trang_thai)" +
                        "VALUES (@idCauHoi, @noiDung, @doKho, @laDapAn, @trangThai)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idCauHoi", t.MaCauHoi);
                        command.Parameters.AddWithValue("@noiDung", t.NoiDung);
                        command.Parameters.AddWithValue("@doKho", t.DoKho);
                        command.Parameters.AddWithValue("@laDapAn", t.DapAn);
                        command.Parameters.AddWithValue("@trangThai", 1);
                        int rowsChanged = command.ExecuteNonQuery();
                        return rowsChanged > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public bool Update(CauTraLoiDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "Update cau_tra_loi Set ma_cau_hoi = @idCauHoi, noi_dung = @noiDung, " +
                        "do_kho = @doKho, la_dap_an = @laDapAn, trang_thai = @trangThai Where ma_cau_tra_loi = @maCauTraLoi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idCauHoi", t.MaCauHoi);
                        command.Parameters.AddWithValue("@noiDung", t.NoiDung);
                        command.Parameters.AddWithValue("@doKho", t.DoKho);
                        command.Parameters.AddWithValue("@laDapAn", t.DapAn);
                        command.Parameters.AddWithValue("@trangThai", t.TrangThai);
                        command.Parameters.AddWithValue("@maCauTraLoi", t.MaCauTraLoi);
                        int rowsChanged = command.ExecuteNonQuery();
                        return rowsChanged > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "Update cau_tra_loi Set trang_thai = 0 Where ma_cau_tra_loi = " + id;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsChanged = command.ExecuteNonQuery();
                        return rowsChanged > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CauTraLoiDTO> GetAll()
        {
            List<CauTraLoiDTO> cauTraLoiList = new List<CauTraLoiDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "Select * from cau_tra_loi Where trang_thai = 1";
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
                                DoKho = reader["do_kho"].ToString(),
                                DapAn = Convert.ToBoolean(reader["la_dap_an"]),
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
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
                            cauTraLoi.DoKho = reader["do_kho"].ToString();
                            cauTraLoi.DapAn = Convert.ToBoolean(reader["la_dap_an"]);
                            cauTraLoi.DapAn = Convert.ToBoolean(reader["la_dap_an"]);
                            cauTraLoi.TrangThai = Convert.ToInt32(reader["trang_thai"]);
                        }
                    }

                }
            }
            return cauTraLoi;
        }
    }
}
