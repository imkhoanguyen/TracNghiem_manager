using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
    public class QuyenDAO : IDAO<QuyenDTO>
    {
        public static QuyenDAO instance = new QuyenDAO();
        public bool Add(QuyenDTO t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuyenDTO> GetAll()
        {
            List<QuyenDTO> list = new List<QuyenDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "SELECT * FROM quyen WHERE trang_thai = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            QuyenDTO quyen = new QuyenDTO();
                            {
                                quyen.ma_quyen = Convert.ToInt32(reader["ma_quyen"]);
                                quyen.ten_quyen = reader["ten_quyen"].ToString();
                                quyen.trang_thai = Convert.ToInt32(reader["trang_thai"]);
                            };
                            list.Add(quyen);
                        }
                    }

                }
                connection.Close();
            }
            return list;
        }

        public QuyenDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(QuyenDTO t)
        {
            throw new NotImplementedException();
        }

        public List<QuyenDTO> GetQuyenByUserId(int user_id)
        {
            List<QuyenDTO> list = new List<QuyenDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "SELECT q.ma_quyen, q.ten_quyen, q.trang_thai FROM quyen AS q JOIN chi_tiet_quyen AS ct ON q.ma_quyen = ct.ma_quyen " +
                    "JOIN users AS u ON ct.user_id = u.id WHERE ct.cho_phep = 1 AND u.trang_thai = 1 AND q.trang_thai = 1 AND u.id = " + user_id;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            QuyenDTO quyen = new QuyenDTO();
                            {
                                quyen.ma_quyen = Convert.ToInt32(reader["ma_quyen"]);
                                quyen.ten_quyen = reader["ten_quyen"].ToString();
                                quyen.trang_thai = Convert.ToInt32(reader["trang_thai"]);
                            };
                            list.Add(quyen);
                        }
                    }

                }
                connection.Close();
            }
            return list;
        }
    }
}
