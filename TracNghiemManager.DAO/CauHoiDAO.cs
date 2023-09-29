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

                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
                connection.Close();
            }
            return cauHoiList;
        }

        public CauHoiDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(CauHoiDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
