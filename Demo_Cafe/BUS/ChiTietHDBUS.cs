using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class ChiTietHDBUS
    {
        public static int ThemCTHD(ChiTietHDDTO cthd)
        {
            return ChiTietHDDAO.ThemCTHD(cthd);
        }

        public static List<ChiTietHDDTO> LayDSCTHD(int mahd)
        {
            return ChiTietHDDAO.LayDSCTHD(mahd);
        }
    }
}
