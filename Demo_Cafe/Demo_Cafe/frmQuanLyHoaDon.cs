using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace Demo_Cafe
{
    public partial class frmQuanLyHoaDon : Form
    {
        public int mahd { set; get; }
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwQLHD.SelectedItems.Count > 0)
                {
                    Program.select = false;
                    ListViewItem lvi = lvwQLHD.SelectedItems[0];
                    HoaDonDTO hd = (HoaDonDTO)lvi.Tag;
                    mahd = Convert.ToInt32(lvi.Text);
                    frmChiTietHoaDon frm = new frmChiTietHoaDon(mahd);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Chưa chọn hóa đơn", "Thông báo");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
        }

        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            lvwQLHD.View = View.Details;
            lvwQLHD.Columns.Add("Mã hóa đơn",80);
            lvwQLHD.Columns.Add("Tổng tiền",120);
            lvwQLHD.Columns.Add("Trạng thái",100);
            lvwQLHD.Columns.Add("Mã bàn",80);
            lvwQLHD.Columns.Add("Ngày lập", 150);
            lvwQLHD.Columns.Add("Nhân viên lập", 140);

            List<HoaDonDTO> lstHD = HoaDonBUS.LayDSHD();
            for(int i=0;i<lstHD.Count;i++)
            {
                DateTime ngaylap = Convert.ToDateTime(lstHD[i].NgayLap);
                ListViewItem item = new ListViewItem();
                item.Text = lstHD[i].MaHD.ToString();
                item.SubItems.Add(lstHD[i].TongTien.ToString("#,# VND"));
                int tt =lstHD[i].TrangThai;
                if(tt == 0)
                {
                    item.SubItems.Add("Chưa tính");
                }
                if (tt == 1)
                {
                    item.SubItems.Add("Đã tính");
                }
                item.SubItems.Add(lstHD[i].MaBan.ToString());
                item.SubItems.Add(ngaylap.ToString());
                item.SubItems.Add(lstHD[i].NVLap);
                lvwQLHD.Items.Add(item);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();
            frm.XuatBaoCao(dtpkTuNgay.Value,dtpkDenNgay.Value);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
