using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class BanDAO
    {

        //phương thức lấy danh sách bàn
        public static List<BanDTO> LayDSBan()
        {
            List<BanDTO> Result = new List<BanDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BAN", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        BanDTO BAN = new BanDTO();
                        BAN.MaBan = dr.GetInt32(0);
                        BAN.TenBan = dr.GetString(1);
                        BAN.Hinh = dr.GetString(2);
                        Result.Add(BAN);
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

        //phương thức lấy danh sách bàn chuyển
        public static List<BanDTO> LayDSBanChuyen(int maban)
        {
            List<BanDTO> Result = new List<BanDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BAN WHERE MaBan != @maban", con);
                cmd.Parameters.Add("@maban",System.Data.SqlDbType.Int).Value =maban;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        BanDTO BAN = new BanDTO();
                        BAN.MaBan = dr.GetInt32(0);
                        BAN.TenBan = dr.GetString(1);
                        BAN.Hinh = dr.GetString(2);
                        Result.Add(BAN);
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

        //phương thức chuyển bàn
        public static bool ChuyenBan(int mabanChuyen,int mabanDich)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE DS_ORDER SET MaBan = @mabanDich WHERE MaBan = @mabanChuyen", con);
                cmd.Parameters.Add("mabanChuyen",System.Data.SqlDbType.Int).Value = mabanChuyen;
                cmd.Parameters.Add("mabanDich", System.Data.SqlDbType.Int).Value = mabanDich;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Result = true;
                }
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

        //phương thức lấy tình trạng bàn
        public static int LayTinhTrang(int maban)
        {
            int Result =0;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TinhTrang FROM BAN WHERE MaBan = @maban", con);
                cmd.Parameters.Add("@maban",System.Data.SqlDbType.Int).Value = maban;
                Result = (int)cmd.ExecuteScalar();
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


        //phương thức lấy danh sách bàn theo mã
        public static BanDTO LayDSBanTheoMa(int id)
        {
            BanDTO Result = new BanDTO();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BAN WHERE MaBan =@id", con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        BanDTO BAN = new BanDTO();
                        Result.MaBan = dr.GetInt32(0);
                        Result.TenBan = dr.GetString(1);
                        Result.Hinh = dr.GetString(2);
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


        //phương thức cập nhật trạng thái bàn
        public static bool CapNhatTrangThai(int maban,string filePath)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE BAN SET Hinh=@filePath WHERE MaBan = @maban", con);
                cmd.Parameters.Add("@maban",System.Data.SqlDbType.Int).Value = maban;
                cmd.Parameters.Add("@filePath",System.Data.SqlDbType.NVarChar,255).Value = filePath;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Result = true;
                }
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
