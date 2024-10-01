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
    public partial class frmLogin : Form
    {
        
        
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool kt = TaiKhoanBUS.ktTaiKhoan(txtID.Text,txtPass.Text);
            if(kt)
            {
                Program.IstruePass = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtID.Text = "";
                txtPass.Text = "";
                txtID.Focus();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtPass.Text = "";
            this.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Program.IstruePass == false)
            { 
                txtID.Text = "";
                txtPass.Text = "";
            }
            frmMain frm = new frmMain();
            frm.tsbQLBAN.Enabled = false;
            frm.tsbQLHD.Enabled = false;
            frm.tsbQLNV.Enabled = false;
            frm.tsbQLTK.Enabled = false;
            frm.tsbQLTU.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
