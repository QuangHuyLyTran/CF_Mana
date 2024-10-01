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
using System.IO;

namespace Demo_Cafe
{
    public partial class frmQuanLyBanHang : Form
    {
        
        public int maban { set; get; }
        public frmGoiMon frm = new frmGoiMon();
        public frmQuanLyBanHang()
        {
            InitializeComponent();
            
        }
       
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            frmChiTietHoaDon frm = new frmChiTietHoaDon();
            frm.Show();
        }
        Bitmap LoadImage(string path)// hàm load ảnh lên listview
        {
            Bitmap result;
            using (Image img = Image.FromFile(path)) //dùng xong tự hủy
            {
                result = new Bitmap(img);
            }
            return result;
        }

        
        private void frmQuanLyBanHang_Load(object sender, EventArgs e)
        {
            LoadBan();
            List<BanDTO> lstBan = BanBUS.LayDSBan();
            ImageList imgLarge = new ImageList(); //tạo mới một danh sách hình
            imgLarge.ImageSize = new Size(128, 128); //chỉnh kích thước
            imgLarge.ColorDepth = ColorDepth.Depth32Bit; //chỉnh độ phân giải

            ImageList imgSmall = new ImageList(); //tạo mới một danh sách hình
            imgSmall.ImageSize = new Size(45, 30); //chỉnh kích thước
            imgSmall.ColorDepth = ColorDepth.Depth32Bit; //chỉnh độ phân giải

            lvwQLBan.LargeImageList = imgLarge; //thêm hình vào listview

            lvwQLBan.SmallImageList = imgSmall; //thêm hình vào listview

            lvwDSTU.View = View.Details;
            lvwDSTU.Columns.Add("STT", 50);
            lvwDSTU.Columns.Add("Mã bàn", 50);
            lvwDSTU.Columns.Add("Tên thức uống",100);
            lvwDSTU.Columns.Add("Đơn giá",70);
            lvwDSTU.Columns.Add("Số lượng",80);
            lvwDSTU.Columns.Add("Thành tiên",100);


            lvwQLBan.View = View.SmallIcon;
            for (int i = 0; i < lstBan.Count; i++) // duyệt danh sách sản phẩm
            {

                ListViewItem lst = new ListViewItem(); // tạo mới một đối tượng kiểu ListViewItem
                lst.ImageKey = lstBan[i].Hinh;
                lst.Text = lstBan[i].TenBan.ToString();
                imgSmall.Images.Add(lstBan[i].Hinh, LoadImage("hinh\\" + lstBan[i].Hinh));
                imgLarge.Images.Add(lstBan[i].Hinh, LoadImage("hinh\\" + lstBan[i].Hinh));
                lst.Tag = lstBan[i];
                lvwQLBan.Items.Add(lst);
            }
        }
        int tongtien = 0;
        private void lvwQLBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBan();

        }
       
        private void LoadBan()
        {
            lvwDSTU.Items.Clear();
            if (lvwQLBan.SelectedItems.Count > 0)
            {
                
                tongtien = 0;
                ListViewItem item = lvwQLBan.SelectedItems[0];
                BanDTO ban = (BanDTO)item.Tag;
                
                List<OrderDTO> ds = OrderBUS.LayDSThucUongTheoMa(ban.MaBan);
                List<BanDTO> lstBan = BanBUS.LayDSBanChuyen(ban.MaBan);
                cboBanDich.DisplayMember = "TenBan";
                cboBanDich.ValueMember = "MaBan";
                cboBanDich.DataSource = lstBan;
                lblMaBan.Text = ban.MaBan.ToString();
                lblTenBan.Text = ban.TenBan.ToString();


                //int tt = BanBUS.LayTinhTrang(ban.MaBan);
                if (ds.Count >= 1)
                {
                    lblTrangThai.Text = "Có khách";
                    BanBUS.CapNhatTrangThai(ban.MaBan, "Khach.png");
                    
                }
                if (ds.Count < 1)
                {
                    lblTrangThai.Text = "Trống";
                    BanBUS.CapNhatTrangThai(ban.MaBan, "ban.png");
                }

                for (int i = 0; i < ds.Count; i++)
                {

                    ListViewItem lvi = new ListViewItem();
                    OrderDTO dsTU = new OrderDTO();
                    lvi.Text = (i + 1).ToString();
                    string tenTU = ThucUongBUS.LayTenTheoMa(Convert.ToInt32(ds[i].MaTU));
                    lvi.SubItems.Add(ban.MaBan.ToString());
                    lvi.SubItems.Add(tenTU.ToString());
                    lvi.SubItems.Add(ds[i].DonGia.ToString());
                    lvi.SubItems.Add(ds[i].SoLuong.ToString());
                    lvi.SubItems.Add(ds[i].ThanhTien.ToString("#,# VND"));
                    lvwDSTU.Items.Add(lvi);
                    tongtien += Convert.ToInt32(ds[i].ThanhTien.ToString());

                }
                lblTongTien.Text = tongtien.ToString("#,# VND");

            }
        }
        void frm1_ThemTUEvent(ListViewItem item)
        {
            ListViewItem lstDS = new ListViewItem();
            lstDS.Text = item.Text;
            lstDS.SubItems.Add(item.SubItems[1]);
            lstDS.SubItems.Add(item.SubItems[2]);
            lstDS.SubItems.Add(item.SubItems[3]);
            lstDS.SubItems.Add(item.SubItems[4]);
            lstDS.SubItems.Add(item.SubItems[5]);
            lvwDSTU.Items.Add(lstDS);

        }

        private void btnGoiMon_Click(object sender, EventArgs e)
        {
            if (lvwQLBan.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwQLBan.SelectedItems[0];
                BanDTO ban = (BanDTO)item.Tag;
                maban = ban.MaBan;
                frmGoiMon frm1 = new frmGoiMon(maban);
                frm1.ThemTUEvent += frm1_ThemTUEvent;
                frm1.ShowDialog();
                BanBUS.CapNhatTrangThai(maban, "Khach.png");

            }
            else
            {
                MessageBox.Show("Chọn bàn", "Thông  báo");
            }
            LoadBan();
            LoadList();
            
        }
       
        private void btnLapHD_Click(object sender, EventArgs e)
        {
            if (lvwQLBan.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwQLBan.SelectedItems[0];
                BanDTO ban = (BanDTO)item.Tag;

                List<OrderDTO> ds = OrderBUS.LayDSThucUongTheoMa(ban.MaBan);
                if(ds.Count >= 1)
                { 
                    Program.select = true;
                    maban = ban.MaBan;
                    HoaDonDTO hd;
                    hd= new HoaDonDTO();
                    hd.TongTien = tongtien;
                    hd.TrangThai = 0;
                    hd.MaBan = maban;
                    hd.NgayLap = DateTime.Now;
                    hd.NVLap = Program.tennv;
                    HoaDonBUS.ThemHD(hd);
                    frmChiTietHoaDon frm1 = new frmChiTietHoaDon(maban,hd);
                    this.Hide();
                    frm1.ShowDialog();
                    this.Show();
                    LoadBan();
                }
                else
                {
                    MessageBox.Show("Chưa gọi món ???", "Thông  báo");
                }

            }
            else
            {
                MessageBox.Show("Chọn bàn", "Thông  báo");
            }
            LoadList();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (lvwQLBan.SelectedItems.Count > 0)
            {

                
                ListViewItem item = lvwQLBan.SelectedItems[0];
                BanDTO ban = (BanDTO)item.Tag;
                int mabanChuyen = ban.MaBan;
                int mabanDich = (int)cboBanDich.SelectedValue;
                List<OrderDTO> ds = OrderBUS.LayDSThucUongTheoMa(ban.MaBan);
                if(ds.Count >= 1 )
                { 
                    if(BanBUS.ChuyenBan(mabanChuyen,mabanDich))
                    {
                        MessageBox.Show("Chuyển thành công", "Thông  báo");
                        BanBUS.CapNhatTrangThai(mabanDich,"Khach.png");
                        BanBUS.CapNhatTrangThai(mabanChuyen, "ban.png");
                    }
                    else
                    {
                        MessageBox.Show("Chuyển thất bại", "Thông  báo");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có thức uống chuyển kiểu gì ???", "Thông  báo");
                }
                

            }
            else
            {
                MessageBox.Show("Chọn bàn", "Thông  báo");
            }
            LoadBan();
            LoadList();
        }
        
        private void LoadList()
        {
            List<BanDTO> lstBan = BanBUS.LayDSBan();
            lvwQLBan.Items.Clear();
            lvwQLBan.LargeImageList.Images.Clear();
            lvwQLBan.SmallImageList.Images.Clear();
            for (int i = 0; i < lstBan.Count; i++) // duyệt danh sách sản phẩm
                {

                    ListViewItem lst = new ListViewItem(); // tạo mới một đối tượng kiểu ListViewItem
                    lst.ImageKey = lstBan[i].Hinh;
                    lst.Text = lstBan[i].TenBan.ToString();
                    lvwQLBan.SmallImageList.Images.Add(lstBan[i].Hinh, LoadImage("hinh\\" + lstBan[i].Hinh));
                    lvwQLBan.LargeImageList.Images.Add(lstBan[i].Hinh, LoadImage("hinh\\" + lstBan[i].Hinh));
                    lst.Tag = lstBan[i];
                    lvwQLBan.Items.Add(lst);
                }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }
        
    }
}
