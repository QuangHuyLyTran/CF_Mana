using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class OrderDAO
    {

        //phương thức lấy danh sách thức uống theo mã bàn
        public static List<OrderDTO> LayDSThucUongTheoMa(int id)
        {
            List<OrderDTO> Result = new List<OrderDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DS_ORDER WHERE MaBan=@id", con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        OrderDTO ds = new OrderDTO();
                        ds.STT = dr.GetInt32(0);
                        ds.MaBan = dr.GetInt32(1);
                        ds.MaTU = dr.GetInt32(2);
                        ds.DonGia = dr.GetInt32(3);
                        ds.SoLuong = dr.GetInt32(4);
                        ds.ThanhTien = dr.GetInt32(5);
                        Result.Add(ds);
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


        //phương thức thêm thức uống
        public static int ThemDSTU(OrderDTO ds)
        {
            int Result = -1;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO DS_ORDER(STT,MaBan,MaTU,DonGia,SoLuong,ThanhTien) VALUES (@stt,@maban,@matu,@dongia,@soluong,@thanhtien)", con);
                cmd.Parameters.Add("@stt", System.Data.SqlDbType.Int).Value = ds.STT;
                cmd.Parameters.Add("@maban", System.Data.SqlDbType.Int).Value = ds.MaBan;
                cmd.Parameters.Add("@matu", System.Data.SqlDbType.Int).Value = ds.MaTU;
                cmd.Parameters.Add("@dongia", System.Data.SqlDbType.Int).Value = ds.DonGia;
                cmd.Parameters.Add("@soluong", System.Data.SqlDbType.Int).Value = ds.SoLuong;
                cmd.Parameters.Add("@thanhtien", System.Data.SqlDbType.Int).Value = ds.ThanhTien;
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


        //phương thức xóa thức uống theo mã bàn
        public static bool XoadsTU(OrderDTO ds)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM DS_ORDER WHERE MaBan = @maban", con);
                cmd.Parameters.Add("@maban", System.Data.SqlDbType.Int).Value = ds.MaBan;
                cmd.ExecuteNonQuery();
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


        //phương thức xóa thức uống
        public static bool XoadsOD(int stt,int maban)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM DS_ORDER WHERE STT = @stt AND MaBan = @maban", con);
                cmd.Parameters.Add("@stt", System.Data.SqlDbType.Int).Value = stt;
                cmd.Parameters.Add("@maban",System.Data.SqlDbType.Int).Value = maban;
                cmd.ExecuteNonQuery();
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
    }
}
