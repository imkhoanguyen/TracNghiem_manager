using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
    public class UserDAO : IDAO<UserDTO>
    {
        public static UserDAO instance = new UserDAO();
        public bool Add(UserDTO t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetSqlConnection())
                {
                    string query = "Update users Set trang_thai = 0 Where id = " + id;
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

        public List<UserDTO> GetAll()
        {
            List<UserDTO> List = new List<UserDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "SELECT * FROM users WHERE trang_thai = 1 AND ho_va_ten LIKE '%'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserDTO user = new UserDTO();
                            user.Id = Convert.ToInt32(reader["id"]);
                            user.avatar = reader["avartar"].ToString();
                            user.Email = reader["email"].ToString();
                            user.HoVaTen = reader["ho_va_ten"].ToString();
                            user.trangThai = Convert.ToInt32(reader["trang_thai"]);
                            user.ngaySinh = Convert.ToDateTime(reader["ngay_sinh"]);
                            user.gioiTinh = Convert.ToInt32(reader["gioi_tinh"]);
                            user.UserName = reader["usename"].ToString();
                            user.Password = reader["mat_khau"].ToString();
                            List.Add(user);
                        }
                    }

                }
                connection.Close();
            }
            return List;
        }

        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
