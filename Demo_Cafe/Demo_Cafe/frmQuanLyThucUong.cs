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
using System.Globalization;

namespace Demo_Cafe
{
    public partial class frmQuanLyThucUong : Form
    {
        
        public frmQuanLyThucUong()
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
        private void frmQuanLyThucUong_Load(object sender, EventArgs e)
        {
            List<ThucUongDTO> lstThucUong = ThucUongBUS.LayDSTU();
            lvwQLThucUong.View = View.Details;
            lvwQLThucUong.Columns.Add("Mã thức uống", 100);
            lvwQLThucUong.Columns.Add("Tên thức uống", 100);
            lvwQLThucUong.Columns.Add("Loại thức uống", 100);
            lvwQLThucUong.Columns.Add("Mô tả", 115);
            lvwQLThucUong.Columns.Add("Đơn giá", 80);
            lvwQLThucUong.Columns.Add("Số lượng", 70);

            openFileDialog1.Filter = "JPG FILE|*.jpg|PNG FILE|*.png";

            List<LoaiTUDTO> lstLoaiTU = LoaiTUBUS.LayDSLoaiTU();
            cboLoaiTU.DisplayMember = "TenLoaiTU";
            cboLoaiTU.ValueMember = "MaLoaiTU";
            cboLoaiTU.DataSource = lstLoaiTU;

            List<LoaiTUDTO> LoaiTU = LoaiTUBUS.LayDSLoaiTU();

            cboTKLoai.DisplayMember = "TenLoaiTU";
            cboTKLoai.ValueMember = "MaLoaiTU";
            cboTKLoai.DataSource = LoaiTU;


            ImageList imgLarge = new ImageList(); //tạo mới một danh sách hình
            imgLarge.ImageSize = new Size(128, 128); //chỉnh kích thước
            imgLarge.ColorDepth = ColorDepth.Depth32Bit; //chỉnh độ phân giải

            ImageList imgSmall = new ImageList(); //tạo mới một danh sách hình
            imgSmall.ImageSize = new Size(45, 30); //chỉnh kích thước
            imgSmall.ColorDepth = ColorDepth.Depth32Bit; //chỉnh độ phân giải

            lvwQLThucUong.LargeImageList = imgLarge; //thêm hình vào listview

            lvwQLThucUong.SmallImageList = imgSmall; //thêm hình vào listview


            for (int i = 0; i < lstThucUong.Count; i++) // duyệt danh sách sản phẩm
            {
                 string tenTU =ThucUongBUS.LayTenLoaiThucUongTheoMa(lstThucUong[i].LoaiTU);//lấy tên thức uống theo mã
                ListViewItem lst = new ListViewItem(); // tạo mới một đối tượng kiểu ListViewItem
                lst.ImageKey = lstThucUong[i].Hinh;
                lst.Text = lstThucUong[i].MaTU.ToString(); // gán giá trị cho đối tượng vừa tạo bằng với mã sản phẩm
                lst.SubItems.Add(lstThucUong[i].TenTU);//hiện tên  loại thức uống thay vì hiện mã
                lst.SubItems.Add(tenTU.ToString());
                lst.SubItems.Add(lstThucUong[i].MoTa);
                lst.SubItems.Add(lstThucUong[i].DonGia.ToString("#,# VND"));
                lst.SubItems.Add(lstThucUong[i].SoLuong.ToString());
                imgSmall.Images.Add(lstThucUong[i].Hinh, LoadImage("hinh\\" + lstThucUong[i].Hinh));
                imgLarge.Images.Add(lstThucUong[i].Hinh, LoadImage("hinh\\" + lstThucUong[i].Hinh));
                lst.Tag = lstThucUong[i];
                lvwQLThucUong.Items.Add(lst);
            }
        }

        private void lvwQLThucUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwQLThucUong.SelectedItems.Count > 0)
            {

                ListViewItem lstv = lvwQLThucUong.SelectedItems[0];
                ThucUongDTO TU = (ThucUongDTO)lstv.Tag;
                picHinh.Image = lvwQLThucUong.LargeImageList.Images[TU.Hinh];
                lblMaTU.Text = TU.MaTU.ToString();
                txtTenTU.Text = TU.TenTU;
                cboLoaiTU.SelectedValue = TU.LoaiTU;
                txtDonGia.Text = TU.DonGia.ToString();
                txtSoLuong.Text = TU.SoLuong.ToString();
                txtMoTa.Text = TU.MoTa;
            }
        }

        void LoadDulieuListView(List<ThucUongDTO> lstDSTU)
        {
            lvwQLThucUong.Items.Clear();
            lvwQLThucUong.LargeImageList.Images.Clear();
            lvwQLThucUong.SmallImageList.Images.Clear();
            for (int i = 0; i < lstDSTU.Count; i++) // duyệt danh sách sản phẩm
            {
                string tenTU = ThucUongBUS.LayTenLoaiThucUongTheoMa(lstDSTU[i].LoaiTU);//lấy tên thức uống theo mã
                ListViewItem lst = new ListViewItem(); // tạo mới một đối tượng kiểu ListViewItem
                lst.ImageKey = lstDSTU[i].Hinh;
                lst.Text = lstDSTU[i].MaTU.ToString(); // gán giá trị cho đối tượng vừa tạo bằng với mã sản phẩm
                lst.SubItems.Add(lstDSTU[i].TenTU);//hiện tên  loại thức uống thay vì hiện mã
                lst.SubItems.Add(tenTU.ToString());//hiện tên nhà cung cấp thay vì hiện mã
                lst.SubItems.Add(lstDSTU[i].MoTa);
                lst.SubItems.Add(lstDSTU[i].DonGia.ToString("#,# VND"));
                lst.SubItems.Add(lstDSTU[i].SoLuong.ToString());
                lvwQLThucUong.LargeImageList.Images.Add(lstDSTU[i].Hinh, LoadImage("hinh\\" + lstDSTU[i].Hinh));
                lvwQLThucUong.SmallImageList.Images.Add(lstDSTU[i].Hinh, LoadImage("hinh\\" + lstDSTU[i].Hinh));
                lst.Tag = lstDSTU[i];
                lvwQLThucUong.Items.Add(lst);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            { 
                if (lvwQLThucUong.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvwQLThucUong.SelectedItems[0];
                    ThucUongDTO TU = (ThucUongDTO)item.Tag;
               
                    TU.TenTU = txtTenTU.Text;
                    TU.LoaiTU = (int)cboLoaiTU.SelectedValue;
                    int gia;
                    if (int.TryParse(txtDonGia.Text, out gia))
                    {
                        TU.DonGia = gia;
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập  đơn giá !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    TU.SoLuong = Convert.ToInt32(txtSoLuong.Text);
                    TU.MoTa = txtMoTa.Text;
                    string filepath = "";
                    if (openFileDialog1.Tag != null)
                    {
                    
                        filepath = (string)openFileDialog1.Tag;
                    }
                    if (ThucUongBUS.CapNhatTU(TU, filepath))
                    {
                        MessageBox.Show("Cập nhật thành công :" + TU.TenTU, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<ThucUongDTO> lstDSTU = ThucUongBUS.LayDSTU();
                        LoadDulieuListView(lstDSTU);
                    }

                }
                else
                {
                    MessageBox.Show("Chưa chọn sản phẩm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi !!!", "Thông báo");
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            { 
                ThucUongDTO tu = new ThucUongDTO();
                tu.TenTU = txtTenTU.Text;
                tu.LoaiTU = (int)cboLoaiTU.SelectedValue;
                int gia;
                if (int.TryParse(txtDonGia.Text, out gia))
                {
                    tu.DonGia = gia;
                }
                else
                {
                    MessageBox.Show("Chưa nhập  đơn giá !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                tu.SoLuong = Convert.ToInt32(txtSoLuong.Text);
                tu.MoTa = txtMoTa.Text;
                string filepath = "";
                if (openFileDialog1.Tag != null)
                {
                    filepath = (string)openFileDialog1.Tag;
                }
                if (ThucUongBUS.ThemTU(tu, filepath) == tu.MaTU)
                {
                    MessageBox.Show("Thêm thành công : " + tu.TenTU, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<ThucUongDTO> lstDSTU = ThucUongBUS.LayDSTU();
                    LoadDulieuListView(lstDSTU);

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi !!!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            { 
                if (lvwQLThucUong.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = lvwQLThucUong.SelectedItems[0];
                    DialogResult kq = MessageBox.Show("Bạn chắc chắn xóa ???", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (kq != DialogResult.Cancel)
                    {
                        ThucUongDTO tu = (ThucUongDTO)lvi.Tag;
                        ThucUongBUS.XoaTU(tu);
                        MessageBox.Show("Xoá thành công :" + tu.TenTU, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<ThucUongDTO> lstDSTU = ThucUongBUS.LayDSTU();
                        LoadDulieuListView(lstDSTU);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn sản phẩm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi !!!", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lblMaTU.Text = "";
            txtTenTU.Text = "";
            txtSoLuong.Text = "";
            txtMoTa.Text = "";
            txtDonGia.Text = "";
            picHinh.Image = null;
            List<ThucUongDTO> lstDSTU = ThucUongBUS.LayDSTU();
            LoadDulieuListView(lstDSTU);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            
            
            if((int)cboTKLoai.SelectedValue != 0)
            {
                List<ThucUongDTO> lst = ThucUongBUS.LayDSTUTheoMaLoai((int)cboTKLoai.SelectedValue);
                LoadDulieuListView(lst);
               
               
            }
            if (txtTKTen.Text != "")
            {
                List<ThucUongDTO> lstTen = ThucUongBUS.TKTenTU(txtTKTen.Text);
                if (lstTen.Count != 0)
                {
                    LoadDulieuListView(lstTen);
                }
                else
                {
                    MessageBox.Show("Không tồn tại", "Thông báo");
                }
            }
            if (txtGiaTu.Text != "" && txtDenGia.Text != "")
            {
                List<ThucUongDTO> lstGia = ThucUongBUS.TKGia(Convert.ToInt32(txtGiaTu.Text), Convert.ToInt32(txtDenGia.Text));
                LoadDulieuListView(lstGia);
            }

            
        }

        private void cboTKLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTKTen.Text = "";
            txtDenGia.Text = "";
            txtGiaTu.Text = "";
        }

        private void txtTKTen_TextChanged(object sender, EventArgs e)
        {
            txtGiaTu.Text = "";
            txtDenGia.Text = "";
        }

        
    }
}
