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
    public partial class frmGoiMon : Form
    {
        public delegate void ThemTU(ListViewItem lvi);
        public event ThemTU ThemTUEvent;
        public frmGoiMon()
        {
            InitializeComponent();
            btnThem.Click+=btnThem_Click;
        }
        public frmGoiMon(int maBan)
        {
            InitializeComponent();
            lblMaBan.Text = maBan.ToString();
        }
        int dem = 0;
        private void frmThemThucUong_Load(object sender, EventArgs e)
        {
            lvwGoiMon.View = View.Details;
            lvwGoiMon.Columns.Add("STT", 50);
            lvwGoiMon.Columns.Add("Mã bàn", 50);
            lvwGoiMon.Columns.Add("Tên thức uống", 100);
            lvwGoiMon.Columns.Add("Đơn giá", 100);
            lvwGoiMon.Columns.Add("Số lượng", 80);
            lvwGoiMon.Columns.Add("Thành tiên", 100);

            List<OrderDTO> ds = OrderBUS.LayDSThucUongTheoMa(Convert.ToInt32(lblMaBan.Text));
            dem = ds.Count + 1 ;
            for (int i = 0; i < ds.Count; i++)
            {

                ListViewItem lvi = new ListViewItem();
                OrderDTO dsTU = new OrderDTO();
                lvi.Text = (i + 1).ToString();
                string tenTU = ThucUongBUS.LayTenTheoMa(Convert.ToInt32(ds[i].MaTU));
                lvi.SubItems.Add(lblMaBan.Text);
                lvi.SubItems.Add(tenTU.ToString());
                lvi.SubItems.Add(ds[i].DonGia.ToString());
                lvi.SubItems.Add(ds[i].SoLuong.ToString());
                lvi.SubItems.Add(ds[i].ThanhTien.ToString("#,# VND"));
                lvwGoiMon.Items.Add(lvi);
            }

            List<LoaiTUDTO> lstLoai = LoaiTUBUS.LayDSLoaiTU();
            cboLTU.DisplayMember = "TenLoaiTU";
            cboLTU.ValueMember = "MaLoaiTU";
            cboLTU.DataSource = lstLoai;


            
            

        }
        private void LoadDSOrder(List<OrderDTO> lst)
        {
            lvwGoiMon.Items.Clear();
            for (int i = 0; i < lst.Count; i++)
            {

                ListViewItem lvi = new ListViewItem();
                OrderDTO dsTU = new OrderDTO();
                lvi.Text = lst[i].STT.ToString();
                string tenTU = ThucUongBUS.LayTenTheoMa(Convert.ToInt32(lst[i].MaTU));
                lvi.SubItems.Add(lblMaBan.Text);
                lvi.SubItems.Add(tenTU.ToString());
                lvi.SubItems.Add(lst[i].DonGia.ToString());
                lvi.SubItems.Add(lst[i].SoLuong.ToString());
                lvi.SubItems.Add(lst[i].ThanhTien.ToString("#,# VND"));
                lvwGoiMon.Items.Add(lvi);
            }
        }


        private  void btnThem_Click(object sender, EventArgs e)
        {
            if(txtSL.Text == "")
            {
                txtSL.Text = "1";
            }
            if(Convert.ToInt32(txtSL.Text) < 1)
            {
                MessageBox.Show("Số lượng sai !!!","Thông báo");
                return;
            }
            int thanhtien;
            int gia = Convert.ToInt32(lblGia.Text);
            int sl = Convert.ToInt32(txtSL.Text);

            string ten = ThucUongBUS.LayTenTheoMa((int)cboTenMon.SelectedValue);

            OrderDTO lst = new OrderDTO();
            lst.STT = dem;
            lst.MaBan = Convert.ToInt32(lblMaBan.Text);
            lst.MaTU = (int)cboTenMon.SelectedValue;
            lst.DonGia =gia;
            lst.SoLuong = sl;
            lst.ThanhTien = (gia * sl);
            OrderBUS.ThemDSTU(lst);



            
            ListViewItem lstDSGoi = new ListViewItem();
            lstDSGoi.Text = dem.ToString();
            lstDSGoi.SubItems.Add(lblMaBan.Text);
            lstDSGoi.SubItems.Add(ten);
            lstDSGoi.SubItems.Add(lblGia.Text);
            lstDSGoi.SubItems.Add(txtSL.Text);
            thanhtien = gia * sl;
            lstDSGoi.SubItems.Add(thanhtien.ToString("#,# VND"));
            ListViewItem lvi= lvwGoiMon.Items.Add(lstDSGoi);//tạo mới listviewitem và gán = listviewitem hiện tại form GoiMon
            ThemTUEvent(lvi);//add listviewitem vao sự kiện thêm,sự kiện thêm khai báo ở form hiện tại và xử lí ở form QLBanHang
            dem += 1;
            
        }

        private void lvwThemTU_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       
        private void cboTenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int gia = ThucUongBUS.LayGiaTheoMa(((int)cboTenMon.SelectedValue));
            lblGia.Text = gia.ToString();
        }

        
        private void cboLTU_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maloai = Convert.ToInt32(cboLTU.SelectedValue);
            List<ThucUongDTO> lstTU = ThucUongBUS.LayDSTUTheoMaLoai(maloai);
            cboTenMon.DisplayMember = "TenTU";
            cboTenMon.ValueMember = "MaTU";
            cboTenMon.DataSource = lstTU;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lvwGoiMon.SelectedItems.Count > 0)
            {
                List<OrderDTO> ds = OrderBUS.LayDSThucUongTheoMa(Convert.ToInt32(lblMaBan.Text));

                ListViewItem lst = lvwGoiMon.SelectedItems[0];
                for (int i = 0; i < ds.Count; i++)
                {
                    if((i+1).ToString() == lst.Text)
                    {
                        OrderBUS.XoadsOD(Convert.ToInt32(lst.Text),(Convert.ToInt32(lblMaBan.Text)));
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Chọn thức uống cần xóa!!!","Thông báo");
            }
            List<OrderDTO> lstds = OrderBUS.LayDSThucUongTheoMa((Convert.ToInt32(lblMaBan.Text)));
            LoadDSOrder(lstds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
    }
}
