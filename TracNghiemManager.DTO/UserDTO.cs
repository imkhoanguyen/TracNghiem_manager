using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiemManager.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int gioiTinh { get; set; }
        public int trangThai { get; set; }
        public string avatar { get; set; }
        public DateTime ngaySinh { get; set; }
        public DateTime ngayTao { get; set; }


        public UserDTO()
        {
            
        }

        public UserDTO(int Id, string HoVaTen, string Email, string Password, string UserName, int gioiTinh, int trangThai, string avatar, DateTime ngaySinh)
        {
            this.avatar = avatar;
            this.Id = Id;
            this.HoVaTen = HoVaTen;
            this.Email = Email;
            this.Password = Password;
            this.UserName = UserName;
            this.ngaySinh = ngaySinh;
            this.trangThai = trangThai;
            this.gioiTinh = gioiTinh;
        }

    }
}
