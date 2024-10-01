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
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
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

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            List<NhanVienDTO> lstNhanVien = NhanVienBUS.LayDSNV();
            lvwQLNhanVien.View = View.Details;
            lvwQLNhanVien.Columns.Add("Mã nhân viên", 100);
            lvwQLNhanVien.Columns.Add("Tên nhân viên", 140);
            lvwQLNhanVien.Columns.Add("Giới tính", 70);
            lvwQLNhanVien.Columns.Add("Địa chỉ", 140);
            lvwQLNhanVien.Columns.Add("Số điện thoại", 90);
            lvwQLNhanVien.Columns.Add("Chức vụ", 80);

            openFileDialog1.Filter = "JPG FILE|*.jpg|PNG FILE|*.png";
            List<ChucVuDTO> lstCV = ChucVuBUS.LayDSCV(); 
            cboChucVu.DisplayMember = "TenCV";
            cboChucVu.ValueMember = "Macv";
            cboChucVu.DataSource = lstCV;

            ImageList imgLarge = new ImageList(); //tạo mới một danh sách hình
            imgLarge.ImageSize = new Size(128, 128); //chỉnh kích thước
            imgLarge.ColorDepth = ColorDepth.Depth32Bit; //chỉnh độ phân giải

            ImageList imgSmall = new ImageList(); //tạo mới một danh sách hình
            imgSmall.ImageSize = new Size(45, 30); //chỉnh kích thước
            imgSmall.ColorDepth = ColorDepth.Depth32Bit; //chỉnh độ phân giải

            lvwQLNhanVien.LargeImageList = imgLarge; //thêm hình vào listview

            lvwQLNhanVien.SmallImageList = imgSmall; //thêm hình vào listview


            for (int i = 0; i < lstNhanVien.Count; i++) // duyệt danh sách sản phẩm
            {
                string tenCV = NhanVienBUS.LayTenTheoMaCV(lstNhanVien[i].ChucVu);//lấy tên thức uống theo mã
                
                ListViewItem lst = new ListViewItem(); // tạo mới một đối tượng kiểu ListViewItem
                lst.ImageKey = lstNhanVien[i].Hinh;
                lst.Text = lstNhanVien[i].MaNV.ToString();
                lst.SubItems.Add(lstNhanVien[i].TenNV.ToString());
                lst.SubItems.Add(lstNhanVien[i].GioiTinh.ToString());//hiện tên nhà cung cấp thay vì hiện mã
                lst.SubItems.Add(lstNhanVien[i].DiaChi.ToString());
                lst.SubItems.Add(lstNhanVien[i].SDT.ToString());
                lst.SubItems.Add(tenCV.ToString());
                imgSmall.Images.Add(lstNhanVien[i].Hinh, LoadImage("hinh\\" + lstNhanVien[i].Hinh));
                imgLarge.Images.Add(lstNhanVien[i].Hinh, LoadImage("hinh\\" + lstNhanVien[i].Hinh));
                lst.Tag = lstNhanVien[i];
                lvwQLNhanVien.Items.Add(lst);
            }
        }

        private void lvwQLNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwQLNhanVien.SelectedItems.Count > 0)
            {

                ListViewItem lstv = lvwQLNhanVien.SelectedItems[0];
                NhanVienDTO NV = (NhanVienDTO)lstv.Tag;
                picHinh.Image = lvwQLNhanVien.LargeImageList.Images[NV.Hinh];
                lblMaNV.Text = NV.MaNV.ToString();
                txtHoTen.Text = NV.TenNV;
                txtGioiTinh.Text = NV.GioiTinh;
                txtDiaChi.Text = NV.DiaChi;
                txtSDT.Text = NV.SDT;
                cboChucVu.SelectedValue = NV.ChucVu;
            }
        }

        void LoadDulieuListView(List<NhanVienDTO> lstNhanVien)
        {
            lvwQLNhanVien.Items.Clear();
            lvwQLNhanVien.LargeImageList.Images.Clear();
            lvwQLNhanVien.SmallImageList.Images.Clear();
            for (int i = 0; i < lstNhanVien.Count; i++) // duyệt danh sách sản phẩm
            {
                string tenCV = NhanVienBUS.LayTenTheoMaCV(lstNhanVien[i].ChucVu);//lấy tên thức uống theo mã
                
                ListViewItem lst = new ListViewItem(); // tạo mới một đối tượng kiểu ListViewItem
                lst.ImageKey = lstNhanVien[i].Hinh;
                lst.Text = lstNhanVien[i].MaNV.ToString();
                lst.SubItems.Add(lstNhanVien[i].TenNV.ToString());
                lst.SubItems.Add(lstNhanVien[i].GioiTinh.ToString());//hiện tên nhà cung cấp thay vì hiện mã
                lst.SubItems.Add(lstNhanVien[i].DiaChi.ToString());
                lst.SubItems.Add(lstNhanVien[i].SDT.ToString());
                lst.SubItems.Add(tenCV.ToString());
                lvwQLNhanVien.LargeImageList.Images.Add(lstNhanVien[i].Hinh, LoadImage("hinh\\" + lstNhanVien[i].Hinh));
                lvwQLNhanVien.SmallImageList.Images.Add(lstNhanVien[i].Hinh, LoadImage("hinh\\" + lstNhanVien[i].Hinh));
                lst.Tag = lstNhanVien[i];
                lvwQLNhanVien.Items.Add(lst);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvwQLNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwQLNhanVien.SelectedItems[0];
                NhanVienDTO NV = (NhanVienDTO)item.Tag;

                NV.TenNV = txtHoTen.Text;
                NV.GioiTinh = txtGioiTinh.Text;
                NV.DiaChi = txtDiaChi.Text;
                NV.SDT = txtSDT.Text;
                NV.ChucVu = (int)cboChucVu.SelectedValue;
                string filepath = "";
                if (openFileDialog1.Tag != null)
                {
                    
                    filepath = (string)openFileDialog1.Tag;
                }
                if (NhanVienBUS.CapNhatTU(NV, filepath))
                {
                    MessageBox.Show("Cập nhật thành công :" + NV.TenNV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<NhanVienDTO> lstDSNV = NhanVienBUS.LayDSNV();
                    LoadDulieuListView(lstDSNV);
                }

            }
            else
            {
                MessageBox.Show("Chưa chọn nhân viên !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
            openFileDialog1.Tag = openFileDialog1.FileName;
            picHinh.Image = LoadImage(openFileDialog1.FileName);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO NV = new NhanVienDTO();
            NV.TenNV = txtHoTen.Text;
            NV.GioiTinh = txtGioiTinh.Text;
            NV.DiaChi = txtDiaChi.Text;
            NV.SDT = txtSDT.Text;
            NV.ChucVu = (int)cboChucVu.SelectedValue;
            string filepath = "";
            if (openFileDialog1.Tag != null)
            {
                filepath = (string)openFileDialog1.Tag;
            }
            if (NhanVienBUS.ThemNV(NV, filepath) == NV.MaNV)
            {
                MessageBox.Show("Thêm thành công : " + NV.TenNV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<NhanVienDTO> lstDSNV = NhanVienBUS.LayDSNV();
                LoadDulieuListView(lstDSNV);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvwQLNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvwQLNhanVien.SelectedItems[0];
                DialogResult kq = MessageBox.Show("Bạn chắc chắn xóa ???", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (kq != DialogResult.Cancel)
                {
                    NhanVienDTO NV = (NhanVienDTO)lvi.Tag;
                    NhanVienBUS.XoaNV(NV);
                    MessageBox.Show("Xoá thành công :" + NV.TenNV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<NhanVienDTO> lstDSNV = NhanVienBUS.LayDSNV();
                    LoadDulieuListView(lstDSNV);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn nhân viên !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTuKhoa.Text != "")
            {
                 NhanVienBUS.TKTenGan9Xac(txtTuKhoa.Text);
                 if (NhanVienBUS.TKTenGan9Xac(txtTuKhoa.Text).Count < 1)
                {
                    MessageBox.Show("Không tồn tại nhân viên" + txtTuKhoa.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    List<NhanVienDTO> nv = NhanVienBUS.TKTenGan9Xac(txtTuKhoa.Text);
                    LoadDulieuListView(nv);
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập từ khóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtGioiTinh.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtTuKhoa.Text = "";
            List<NhanVienDTO> lstNV = NhanVienBUS.LayDSNV();
            LoadDulieuListView(lstNV);
        }

    }
}
