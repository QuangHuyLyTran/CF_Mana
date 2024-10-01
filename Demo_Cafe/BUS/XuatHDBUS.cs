using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class XuatHDBUS
    {
        public static List<XuatHDDTO> XuatHD(int mahd)
        {
            return XuatHDDAO.XuatHD(mahd);
        }
    }
}
