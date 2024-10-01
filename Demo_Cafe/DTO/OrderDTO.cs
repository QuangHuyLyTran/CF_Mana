using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        private int p;

        public OrderDTO(int p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public OrderDTO()
        {
            // TODO: Complete member initialization
        }
        public int STT { set; get; }
        public int MaBan { set; get; }
        public int MaTU { set; get; }
        public int DonGia { set; get; }
        public int SoLuong { set; get; }
        public int ThanhTien { set; get; }
    }
}
