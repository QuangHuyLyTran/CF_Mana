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
    public partial class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            lvwQLTaiKhoan.View = View.Details;
            lvwQLTaiKhoan.Columns.Add("Mã tài khoản",80);
            lvwQLTaiKhoan.Columns.Add("Tên đăng nhập",100);
            lvwQLTaiKhoan.Columns.Add("Mật khẩu",100);
            lvwQLTaiKhoan.Columns.Add("Tên nhân viên",120);
            lvwQLTaiKhoan.Columns.Add("Quyền",80);
            lvwQLTaiKhoan.Columns.Add("Lịch sử đăng nhập",120);
            lvwQLTaiKhoan.Columns.Add("Trạng thái",100);


            List<NhanVienDTO> lstNV = NhanVienBUS.LayDSNV();
            cboTenNV.DisplayMember = "TenNV";
            cboTenNV.ValueMember = "MaNV";
            cboTenNV.DataSource = lstNV;



            ImageList imgLarge = new ImageList(); //tạo mới một danh sách hình
            imgLarge.ImageSize = new Size(128, 128); //chỉnh kích thước
            imgLarge.ColorDepth = ColorDepth.Depth32Bit; //chỉnh độ phân giải

            ImageList imgSmall = new ImageList(); //tạo mới một danh sách hình
            imgSmall.ImageSize = new Size(45, 30); //chỉnh kích thước
            imgSmall.ColorDepth = ColorDepth.Depth32Bit; //chỉnh độ phân giải

            lvwQLTaiKhoan.LargeImageList = imgLarge; //thêm hình vào listview

            lvwQLTaiKhoan.SmallImageList = imgSmall; //thêm hình vào listview


            List<TaiKhoanDTO> lstTK = TaiKhoanBUS.LayDSTK();
            for (int i = 0; i < lstTK.Count; i++) // duyệt danh sách sản phẩm
            {
                string tennv = TaiKhoanBUS.LayTenTheoMaNV(lstTK[i].MaNV);
                ListViewItem lst = new ListViewItem(); // tạo mới một đối tượng kiểu ListViewItem
                lst.Text = lstTK[i].MaTK.ToString();
                lst.SubItems.Add(lstTK[i].TenDN.ToString());
                lst.SubItems.Add(lstTK[i].MatKhau.ToString());
                lst.SubItems.Add(tennv.ToString());
                lst.SubItems.Add(lstTK[i].Quyen.ToString());
                lst.SubItems.Add(lstTK[i].TrangThai.ToString());
                lst.Tag = lstTK[i];
                lvwQLTaiKhoan.Items.Add(lst);
            }
        }
    }
}
