using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class HoaDonBUS
    {
        public static int LayMaHD(int maban)
        {
            return HoaDonDAO.LayMaHD(maban);
        }
        public static int ThemHD(HoaDonDTO hd)
        {
            return HoaDonDAO.ThemHD(hd);
        }
        public static bool CapNhatTrangThaiHD(HoaDonDTO hd)
        {
            return HoaDonDAO.CapNhatTrangThaiHD(hd);
        }

        public static string ktTinhTrang(int maban)
        {
            return HoaDonDAO.ktTinhTrang(maban);
        }

        public static HoaDonDTO LayDSHDTheoMa(int mahd)
        {
            return HoaDonDAO.LayDSHDTheoMa(mahd);
        }

        public static bool CapNhatTongTienHD(HoaDonDTO hd)
        {
            return HoaDonDAO.CapNhatTongTienHD(hd);
        }

         public static string ktTinhTrangTheoMaHD(int mahd)
        {
            return HoaDonDAO.ktTinhTrangTheoMaHD(mahd);
        }

        public static int LayMaMoi()
        {
            return HoaDonDAO.LayMaMoi();
        }

        public static List<HoaDonDTO> LayDSHD()
        {
            return HoaDonDAO.LayDSHD();
        }

        public static List<HoaDonDTO> LayDSHDTheoNgay(DateTime tungay,DateTime denngay)
        {
            return HoaDonDAO.LayDSHDTheoNgay(tungay, denngay);
        }
    }
}
