using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
    public class ChiTietQuyenDAO : IDAO<ChiTietQuyenDTO>
    {
        public static ChiTietQuyenDAO Instance = new ChiTietQuyenDAO();
        public bool Add(ChiTietQuyenDTO t)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "INSERT INTO chi_tiet_quyen (ma_quyen, user_id, cho_phep) VALUES (@ma_quyen, @user_id, 1)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ma_quyen", t.ma_quyen);
                        command.Parameters.AddWithValue("@user_id", t.user_id);

                        int rowsChanged = command.ExecuteNonQuery();
                        return rowsChanged > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ChiTietQuyenDTO> GetAll()
        {
            List<ChiTietQuyenDTO> quyenList = new List<ChiTietQuyenDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "SELECT u.id, u.ho_va_ten, q.ten_quyen FROM users as u JOIN chi_tiet_quyen as ct " +
                    "ON ct.user_id = u.id JOIN quyen as q ON ct.ma_quyen = " +
                    "q.ma_quyen WHERE u.trang_thai = 1 AND ct.cho_phep = 1 AND q.trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChiTietQuyenDTO quyen = new ChiTietQuyenDTO();
                            {
                                quyen.user_id = Convert.ToInt32(reader["id"]);
                                quyen.ho_va_ten = reader["ho_va_ten"].ToString();
                                quyen.ten_quyen = reader["ten_quyen"].ToString();
                            };
                            quyenList.Add(quyen);
                        }
                    }

                }
                connection.Close();
            }
            return quyenList;
        }

        public ChiTietQuyenDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ChiTietQuyenDTO t)
        {
            throw new NotImplementedException();
        }

        public List<ChiTietQuyenDTO> GetRoleByUserId(int id)
        {
            List<ChiTietQuyenDTO> List = new List<ChiTietQuyenDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "SELECT u.id, u.ho_va_ten, q.ten_quyen FROM users as u JOIN chi_tiet_quyen as ct " +
                    "ON ct.user_id = u.id JOIN quyen as q ON ct.ma_quyen = " +
                    "q.ma_quyen WHERE u.trang_thai = 1 AND ct.cho_phep = 1 AND q.trang_thai = 1 and u.id = " + id;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChiTietQuyenDTO quyen = new ChiTietQuyenDTO();
                            {
                                quyen.user_id = Convert.ToInt32(reader["id"]);
                                quyen.ho_va_ten = reader["ho_va_ten"].ToString();
                                quyen.ten_quyen = reader["ten_quyen"].ToString();
                            };
                            List.Add(quyen);
                        }
                    }

                }
                connection.Close();
            }
            return List;
        }
    }
}
