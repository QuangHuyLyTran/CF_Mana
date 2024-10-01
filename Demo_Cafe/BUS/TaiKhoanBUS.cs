using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class TaiKhoanBUS
    {
        public static bool ktTaiKhoan(string id, string pass)
        {
            return TaiKhoanDAO.ktTaiKhoan(id,pass);
        }

        public static int ktQuyen(string id)
        {
            return TaiKhoanDAO.ktQuyen(id);
        }

        public static string ktTen(string id)
        {
            return TaiKhoanDAO.ktTen(id);
        }

        public static List<TaiKhoanDTO> LayDSTK()
        {
            return TaiKhoanDAO.LayDSTK();
        }

        public static string LayTenTheoMaNV(int id)
        {
            return TaiKhoanDAO.LayTenTheoMaNV(id);
        }

        public static string LayHinh(string id)
        {
            return TaiKhoanDAO.LayHinh(id);
        }
    }
}
