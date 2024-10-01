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

    public partial class frmMain : Form
    {
        
        frmLogin frm = new frmLogin();
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmQuanLyThucUong frm = new frmQuanLyThucUong();
            this.Hide();
            frm.ShowDialog();
            this.Show();
           
           
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
        private void frmMain_Load(object sender, EventArgs e)
        {
            
            
            tsbQLBAN.Enabled = false;
            tsbQLHD.Enabled = false;
            tsbQLNV.Enabled = false;
            tsbQLTK.Enabled = false;
            tsbQLTU.Enabled = false;
            tssLogin.Text = "Chưa đăng nhập";
            
            
        }
        

       
        private void tsbQLNV_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frm = new frmQuanLyNhanVien();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void tsbQLBAN_Click(object sender, EventArgs e)
        {

            frmQuanLyBanHang frm = new frmQuanLyBanHang();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void tsbQLHD_Click(object sender, EventArgs e)
        {
            frmQuanLyHoaDon frm = new frmQuanLyHoaDon();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void tsbQLTK_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan frm = new frmQuanLyTaiKhoan();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
        

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            
            frm.ShowDialog();
            if(Program.IstruePass)
            { 
                int quyen = TaiKhoanBUS.ktQuyen(frm.txtID.Text);
                btnDangNhap.Visible = false;
                btnDangXuat.Visible = true;
                tsbQLBAN.Enabled = true;
                tsbQLHD.Enabled = true;
                tsbQLNV.Enabled = true;
                tsbQLTK.Enabled = true;
                tsbQLTU.Enabled = true;
                if ( quyen == 2)
                {
                    tsbQLNV.Enabled = false;
                    tsbQLTK.Enabled = false;
                    tsbQLTU.Enabled = false;
                }
                Program.tennv  = TaiKhoanBUS.ktTen(frm.txtID.Text);
                tssLogin.Text = Program.tennv + " đang đăng nhập";
                string hinh = TaiKhoanBUS.LayHinh(frm.txtID.Text);
                picNV.Image = LoadImage("hinh\\" + hinh);
                frm.txtID.Text = "";
                frm.txtPass.Text = "";
                Program.IstruePass = false;
            }
        }
        
        private void btnDangXuat_Click(object sender, EventArgs e)
        {

            btnDangXuat.Visible = false;
            tsbQLBAN.Enabled = false;
            tsbQLHD.Enabled = false;
            tsbQLNV.Enabled = false;
            tsbQLTK.Enabled = false;
            tsbQLTU.Enabled = false;
            tssLogin.Text = "Chưa đăng nhập";
            btnDangNhap.Visible = true;
            picNV.Image = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
