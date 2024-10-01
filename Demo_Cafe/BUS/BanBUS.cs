using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class BanBUS
    {
        public static List<BanDTO> LayDSBan()
        {
            return BanDAO.LayDSBan();
        }

        public static int LayTinhTrang(int maban)
        {
            return BanDAO.LayTinhTrang(maban);
        }

        public static BanDTO LayDSBanTheoMa(int id)
        {
            return BanDAO.LayDSBanTheoMa(id);
        }

        public static List<BanDTO> LayDSBanChuyen(int maban)
        {
            return BanDAO.LayDSBanChuyen(maban);
        }

        public static bool ChuyenBan(int mabanChuyen,int mabanDich)
        {
            return BanDAO.ChuyenBan(mabanChuyen,mabanDich);
        }

        public static bool CapNhatTrangThai(int maban,string filePath)
        {
            return BanDAO.CapNhatTrangThai(maban, filePath);
        }
    }
}
