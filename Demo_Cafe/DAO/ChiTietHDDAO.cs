using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class ChiTietHDDAO
    {

        //phương thức thêm chi tiết hóa đơn
        public static int ThemCTHD(ChiTietHDDTO dscthd)
        {
            int Result = -1;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CHI_TIET_HD(MaHD,MaTU,DonGia,SoLuong,ThanhTien) VALUES(@mahd,@matu,@dongia,@soluong,@thanhtien)", con);
                cmd.Parameters.Add("@mahd", System.Data.SqlDbType.Int).Value = dscthd.MaHD;
                cmd.Parameters.Add("@matu", System.Data.SqlDbType.Int).Value = dscthd.MaTU;
                cmd.Parameters.Add("@dongia", System.Data.SqlDbType.Int).Value = dscthd.DonGia;
                cmd.Parameters.Add("@soluong", System.Data.SqlDbType.Int).Value = dscthd.SoLuong;
                cmd.Parameters.Add("@thanhtien", System.Data.SqlDbType.Int).Value = dscthd.ThanhTien;
                Result = cmd.ExecuteNonQuery();
                


            }
            finally
            {

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Result;
        }

        //phương thức lấy danh sách CHI TIET HÓA ĐƠN theo mã hóa đơn
        public static List<ChiTietHDDTO> LayDSCTHD(int mahd)
        {
            List<ChiTietHDDTO> Result = new List<ChiTietHDDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CHI_TIET_HD WHERE MaHD =@mahd", con);
                cmd.Parameters.Add("@mahd",System.Data.SqlDbType.Int).Value = mahd;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ChiTietHDDTO hd = new ChiTietHDDTO();
                        hd.MaHD = dr.GetInt32(0);
                        hd.MaTU = dr.GetInt32(1);
                        hd.SoLuong = dr.GetInt32(2);
                        hd.DonGia = dr.GetInt32(3);
                        hd.ThanhTien = dr.GetInt32(4);
                        Result.Add(hd);
                    }
                    dr.Close();
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)//nếu như file kết nối chưa mở thì đóng kết nối
                {
                    con.Close();
                }
            }
            return Result;
        }
       
    }
}
