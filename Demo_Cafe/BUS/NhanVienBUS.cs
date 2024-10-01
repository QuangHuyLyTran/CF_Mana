using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.IO;

namespace BUS
{
    public static class NhanVienBUS
    {
        public static List<NhanVienDTO> LayDSNV()
        {
            return NhanVienDAO.LayDSNV();
        }

        public static string LayTenTheoMaCV(int id)
        {
            return NhanVienDAO.LayTenTheoMaCV(id);
        }

        public static bool CapNhatTU(NhanVienDTO nv, string filePath)
        {
            if (filePath != "")
            {

                string newFileName = nv.MaNV.ToString() + DateTime.Now.ToString("yyyyMMdd-HHmmss") + Path.GetExtension(filePath);
                File.Copy(filePath, "hinh\\" + newFileName);
                nv.Hinh = newFileName;
            }
            return NhanVienDAO.CapNhatNV(nv);
        }


        public static int ThemNV(NhanVienDTO nv, string filePath)
        {
            nv.Hinh = "smile.png";
            nv.MaNV = NhanVienDAO.ThemNV(nv);

            if (nv.MaNV > 0 && filePath != "")
            {
                string newFileName = nv.MaNV.ToString() + DateTime.Now.ToString("yyyyMMdd-HHmmss") + Path.GetExtension(filePath);
                File.Copy(filePath, "hinh\\" + newFileName);
                nv.Hinh = newFileName;
                NhanVienDAO.CapNhatNV(nv);
            }
            return nv.MaNV;
        }


        public static bool XoaNV(NhanVienDTO nv)
        {
            return NhanVienDAO.XoaNV(nv);
        }

        public static List<NhanVienDTO> TKNVTen9Xac(string ten)
        {
            return NhanVienDAO.TKNVTen9Xac(ten);
        }

        public static List<NhanVienDTO> TKTenGan9Xac(string ten)
        {
            return NhanVienDAO.TKTenGan9Xac(ten);
        }
    }
}
