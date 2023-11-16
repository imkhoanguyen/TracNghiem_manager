using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TracNghiemManager.DAO;
using TracNghiemManager.DTO;

namespace TracNghiemManager.BUS
{
    public class UserBUS
    {
		public UserDAO UserDAO;
		public UserBUS()
		{
			UserDAO = UserDAO.instance;
		}
		public List<UserDTO> GetAll()
		{
			return UserDAO.GetAll();
		}
		public void Delete(int id)
		{
			UserDAO.Delete(id);
		}

		public int getIdByUsername(string s)
		{
			return UserDAO.GetIdByUsername(s);
		}

		public UserDTO getById(int id)
		{
			return UserDAO.GetById(id);
		}
		public string Add(UserDTO t)
		{
			if (UserDAO.Add(t))
			{
				return "Thêm thành công!";
			}
			return "Thêm thất bại!";
		}
		public string Update(UserDTO t)
		{
			if (UserDAO.Update(t))
			{
				return "Cập nhật thành công!";
			}
			return "Sửa thất bại!";
		}
		public int getNewId()
		{
			return UserDAO.newIdOfUser;
		}

		public bool isExistUsername(string s)
		{
			return UserDAO.isExistUsername(s);
		}

		public List<UserDTO> SearchEvenUsername(string s)
		{
			return UserDAO.SearchEvenUsername(s);
		}

		public List<UserDTO> SearchEvenPermisson(string s)
		{
			List<UserDTO> list = UserDAO.SearchUserIdInPermisson(s);
			List<UserDTO> users = new List<UserDTO>();
			for (int i = 0; i < list.Count; i++)
			{
				users.Add(UserDAO.GetById(list[i].Id));
			}
			return users;
		}

		public List<UserDTO> Search(string s)
		{
			List<UserDTO> list = UserDAO.Search(s);
			List<UserDTO> users = new List<UserDTO>();
			for (int i = 0; i < list.Count; i++)
			{
				users.Add(UserDAO.GetById(list[i].Id));
			}
			return users;
		}

		public List<UserDTO> SearchEvenDate(string s1, string s2)
		{
			return UserDAO.SearchEvenDate(s1, s2);
		}

		public List<UserDTO> getEmailandAvatar(string s)
		{
			return UserDAO.GetMailandAvatar(s);
		}
		public int CheckEmail(string newEmail)
		{
			List<UserDTO> l = UserDAO.GetAll();
			for (int i=0; i<l.Count; i++)
			{
				if (l[i].Email!=null)
				{
					if (l[i].Email.Equals(newEmail))
					{
						return 1;
					}
				}
				
			}

			return -1;
		}
		public void UpdatePassword(string email, string newPassword)
		{
			UserDAO.UpdatePassword(email, newPassword);
		}
		public int GetAutoIncreament()
		{
			return UserDAO.GetAutoIncrement();
		}
	}
}
