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
using Microsoft.Reporting.WinForms;

namespace Demo_Cafe
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {

            this.rpvHoaDon.RefreshReport();
        }
        public void XuatHoaDon(int mahd)
        {
            List<XuatHDDTO> hd = XuatHDBUS.XuatHD(mahd);
            rpvHoaDon.LocalReport.ReportEmbeddedResource = "Demo_Cafe.rpvHoaDon.rdlc";
            rpvHoaDon.LocalReport.DataSources.Add(new ReportDataSource("dsHoaDon", hd));
            rpvHoaDon.RefreshReport();

        }

        public void XuatBaoCao(DateTime tungay,DateTime denngay)
        {
            string nvlap = Program.tennv;
            DateTime ngaylap = DateTime.Now;
            List<HoaDonDTO> lst = HoaDonBUS.LayDSHDTheoNgay(tungay, denngay);
            rpvHoaDon.LocalReport.ReportEmbeddedResource = "Demo_Cafe.rpvDSHoaDon.rdlc";
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("paNgayBD", tungay.ToString(),false));
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("paNgayKT", denngay.ToString(),false));
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("paNVLap", nvlap.ToString(), false));
            rpvHoaDon.LocalReport.SetParameters(new ReportParameter("paNgayLap", ngaylap.ToString(), false));
            rpvHoaDon.LocalReport.DataSources.Add(new ReportDataSource("dsDoanhThu", lst));
        }



        

       
        
        

        
    }
}
