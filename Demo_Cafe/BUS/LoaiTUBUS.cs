using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class LoaiTUBUS
    {

        public static List<LoaiTUDTO> LayDSLoaiTU()
        {
            return LoaiTUDAO.LayDSLoaiTU();
        }
    }
}
