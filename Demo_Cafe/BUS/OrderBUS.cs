using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public static class OrderBUS
    {
        public static List<OrderDTO> LayDSThucUongTheoMa(int id)
        {
            return OrderDAO.LayDSThucUongTheoMa(id);
        }

         public static int ThemDSTU(OrderDTO ds)
        {
            return OrderDAO.ThemDSTU(ds);
        }
        public static bool XoadsTU(OrderDTO ds)
         {
             return OrderDAO.XoadsTU(ds);
         }
        public static bool XoadsOD(int stt,int maban)
        {
            return OrderDAO.XoadsOD(stt,maban);
        }
    }
}
