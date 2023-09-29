using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DTO;

namespace TracNghiemManager.DAO
{
    public class PhanQuyenDAO : IDAO<PhanQuyenDTO>
    {
        public bool Add(PhanQuyenDTO t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PhanQuyenDTO> GetAll()
        {
            List<PhanQuyenDTO> quyenList = new List<PhanQuyenDTO>();
            using (SqlConnection connection = DbConnection.GetSqlConnection())
            {
                string query = "";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PhanQuyenDTO quyen = new PhanQuyenDTO();
                            {
                                quyen.ma_quyen = Convert.ToInt32(reader["ma_quyen"]);
                                quyen.trang_thai = Convert.ToInt32(reader["trang_thai"]);
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

        public PhanQuyenDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(PhanQuyenDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
