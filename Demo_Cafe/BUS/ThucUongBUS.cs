using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.IO;
namespace BUS
{
    public static class ThucUongBUS
    {

        public static List<ThucUongDTO> LayDSTU()
        {
            return ThucUongDAO.LayDSTU();
        }

        public static string LayTenLoaiThucUongTheoMa(int id)
        {
            return ThucUongDAO.LayTenLoaiThucUongTheoMa(id);
        }

        

        public static bool CapNhatTU(ThucUongDTO tu,string filePath)
        {
            if (filePath != "")
            {

                string newFileName = tu.MaTU.ToString() + DateTime.Now.ToString("yyyyMMdd-HHmmss") + Path.GetExtension(filePath);
                File.Copy(filePath, "hinh\\" + newFileName);
                tu.Hinh = newFileName;
            }
            return ThucUongDAO.CapNhatTU(tu);
        }

        public static int ThemTU(ThucUongDTO tu, string filePath)
        {
            tu.Hinh = "Computer-icon.png";
            tu.MaTU = ThucUongDAO.ThemTU(tu);

            if (tu.MaTU > 0 && filePath != "")
            {
                string newFileName = tu.MaTU.ToString() + DateTime.Now.ToString("yyyyMMdd-HHmmss") + Path.GetExtension(filePath);
                File.Copy(filePath, "hinh\\" + newFileName);
                tu.Hinh = newFileName;
                ThucUongDAO.CapNhatTU(tu);
            }
            return tu.MaTU;
        }

        public static bool XoaTU(ThucUongDTO tu)
        {
            return ThucUongDAO.XoaTU(tu);
        }

        public static int LayGiaTheoMa(int id)
        {
            return ThucUongDAO.LayGiaTheoMa(id);
        }

        public static string LayTenTheoMa(int id)
        {
            return ThucUongDAO.LayTenTheoMa(id);
        }

        public static List<ThucUongDTO> TKTenTU(string ten)
        {
            return ThucUongDAO.TKTenTU(ten);
        }

        public static List<ThucUongDTO> TKGia(int giatu, int giaden)
        {
            return ThucUongDAO.TKGia(giatu, giaden);
        }

        public static List<ThucUongDTO> LayDSTUTheoMaLoai(int id)
        {
            return ThucUongDAO.LayDSTUTheoMaLoai(id);
        }
    }
}
