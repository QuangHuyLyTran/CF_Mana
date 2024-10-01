using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace Demo_Cafe
{
    public partial class frmChiTietHoaDon : Form
    {
        frmQuanLyBanHang frm = new frmQuanLyBanHang();
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }
        public static HoaDonDTO hds;
        public frmChiTietHoaDon(int maBan,HoaDonDTO hd)
        {
            InitializeComponent();
            lblMaBan.Text = maBan.ToString();
             hds = hd;
        }
        public frmChiTietHoaDon(int mahd)
        {
            InitializeComponent();
            lblMaHD.Text = mahd.ToString();
            HoaDonDTO hd = HoaDonBUS.LayDSHDTheoMa(mahd);
            
            lblMaBan.Text = hd.MaBan.ToString(); ;
            lblTongTien.Text = hd.TongTien.ToString("#,# VND");
            lblNgayLap.Text = hd.NgayLap.ToString();
            lblNVLap.Text = hd.NVLap.ToString();
        }
        int tongtien = 0;
        int mahd;
        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            lvwHoaDon.View = View.Details;
            lvwHoaDon.Columns.Add("STT", 35);
            lvwHoaDon.Columns.Add("Mã bàn", 50);
            lvwHoaDon.Columns.Add("Tên thức uống", 100);
            lvwHoaDon.Columns.Add("Đơn giá", 70);
            lvwHoaDon.Columns.Add("Số lượng", 80);
            lvwHoaDon.Columns.Add("Thành tiên", 100);


            if(Program.select)
            { 
            lblNVLap.Text = Program.tennv ;
            lblNgayLap.Text = DateTime.Now.ToString("dd-MM-yyy hh:mm");
            Program.mabanHD = Convert.ToInt32(lblMaBan.Text);

             mahd= HoaDonBUS.LayMaMoi();
            lblMaHD.Text = mahd.ToString();
            
            List<OrderDTO> ds = OrderBUS.LayDSThucUongTheoMa(Program.mabanHD);
            
            for (int i = 0; i < ds.Count; i++)
            {
                string tenTU = ThucUongBUS.LayTenTheoMa(Convert.ToInt32(ds[i].MaTU));
                int dongia = ThucUongBUS.LayGiaTheoMa(Convert.ToInt32(ds[i].MaTU));
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (i+1).ToString();
                lvi.SubItems.Add(Program.mabanHD.ToString());
                lvi.SubItems.Add(tenTU.ToString());
                lvi.SubItems.Add(dongia.ToString());
                lvi.SubItems.Add(ds[i].SoLuong.ToString());
                lvi.SubItems.Add(ds[i].ThanhTien.ToString("#,# VND"));
                lvwHoaDon.Items.Add(lvi);
                tongtien += Convert.ToInt32(ds[i].ThanhTien.ToString());

            }
            lblTongTien.Text = tongtien.ToString("#,# VND");
            }
            else
            {
                btnXuat.Visible = false;
                int mahd = Convert.ToInt32(lblMaHD.Text);
                List<ChiTietHDDTO> lst = ChiTietHDBUS.LayDSCTHD(mahd);
                for (int i = 0; i < lst.Count; i++)
                {
                    string tenTU = ThucUongBUS.LayTenTheoMa(Convert.ToInt32(lst[i].MaTU));
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    lvi.SubItems.Add(lblMaBan.Text);
                    lvi.SubItems.Add(tenTU.ToString());
                    lvi.SubItems.Add(lst[i].DonGia.ToString());
                    lvi.SubItems.Add(lst[i].SoLuong.ToString());
                    lvi.SubItems.Add(lst[i].ThanhTien.ToString("#,# VND"));
                    lvwHoaDon.Items.Add(lvi);
                    tongtien += Convert.ToInt32(lst[i].ThanhTien.ToString());

                }
                //lblTongTien.Text = tongtien.ToString("#,# VND");
            }

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            //lưu danh sách order vào chi tiết hóa đơn
            List<OrderDTO> ds = OrderBUS.LayDSThucUongTheoMa(Program.mabanHD);
            for (int i = 0; i < ds.Count; i++)
            {
                ChiTietHDDTO chHD = new ChiTietHDDTO();
                chHD.MaHD = Convert.ToInt32(lblMaHD.Text);
                chHD.MaTU = Convert.ToInt32(ds[i].MaTU);
                chHD.DonGia = Convert.ToInt32(ds[i].DonGia);
                chHD.SoLuong = Convert.ToInt32(ds[i].SoLuong);
                chHD.ThanhTien = Convert.ToInt32(ds[i].ThanhTien);
                ChiTietHDBUS.ThemCTHD(chHD);
            }

            for (int i = 0; i < ds.Count;i++ )
            { 
                
                OrderBUS.XoadsTU(ds[i]);
            }

            //cập nhật lại trạng thái hóa đơn = đã tính
            hds.MaHD = Convert.ToInt32(lblMaHD.Text);
            hds.TrangThai = 1;
            HoaDonBUS.CapNhatTrangThaiHD(hds);

            
            
            frmBaoCao frm = new frmBaoCao();
            frm.XuatHoaDon(mahd);
            frm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
