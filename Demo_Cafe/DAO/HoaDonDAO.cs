using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public static class HoaDonDAO
    {
        //láy mã hóa đơntheo mã bàn
        public static int LayMaHD(int maban)
        {
            int Result=-1;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaHD FROM HOA_DON WHERE MaBan = @maban", con);
                cmd.Parameters.Add("@maban", System.Data.SqlDbType.Int).Value = maban;
                Result = (int)cmd.ExecuteScalar();
                
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

        //láy mã hóa đơn mới
        public static int LayMaMoi()
        {
            int Result = -1;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT MAX(MaHD) FROM HOA_DON", con);
                Result = (int)cmd.ExecuteScalar();

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


        //phương thức thêm HÓA ĐƠN
        public static int ThemHD(HoaDonDTO hd)
        {
            int Result = -1;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO HOA_DON(TongTien,TrangThai,MaBan,NgayLap,NVLap) VALUES(@tongtien,@trangthai,@maban,@ngaylap,@nvlap)", con);
                cmd.Parameters.Add("@tongtien", System.Data.SqlDbType.Int).Value = hd.TongTien;
                cmd.Parameters.Add("@trangthai", System.Data.SqlDbType.Int).Value = hd.TrangThai;
                cmd.Parameters.Add("@maban", System.Data.SqlDbType.Int).Value = hd.MaBan;
                cmd.Parameters.Add("@ngaylap", System.Data.SqlDbType.DateTime).Value = hd.NgayLap;
                cmd.Parameters.Add("@nvlap", System.Data.SqlDbType.NVarChar,50).Value = hd.NVLap;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cmd = new SqlCommand("SELECT @@IDENTITY", con);
                    decimal tmp = (decimal)cmd.ExecuteScalar();
                    Result = (int)tmp;
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

        public static bool CapNhatTrangThaiHD(HoaDonDTO hd)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE HOA_DON SET TrangThai=@trangthai WHERE MaHD=@mahd", con);
                cmd.Parameters.Add("@trangthai", System.Data.SqlDbType.NVarChar, 50).Value = hd.TrangThai;
                cmd.Parameters.Add("@mahd", System.Data.SqlDbType.Int).Value = hd.MaHD;
                
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



        public static bool CapNhatTongTienHD(HoaDonDTO hd)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE HOA_DON SET TongTien=@tongtien WHERE MaHD=@mahd", con);
                cmd.Parameters.Add("@tongtien", System.Data.SqlDbType.Int).Value = hd.TongTien;
                cmd.Parameters.Add("@mahd", System.Data.SqlDbType.Int).Value = hd.MaHD;

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

        //phương thức kiểm tra tình trạng hóa đơn theo mã bàn
        public static string ktTinhTrang(int maban)
        {
            string Result = "";
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TrangThai FROM HOA_DON WHERE MaBan=@maban", con);
                cmd.Parameters.Add("@maban", System.Data.SqlDbType.Int).Value = maban;
                
                    Result = (string)cmd.ExecuteScalar();
                

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

        //phương thức kiểm tra tình trạng hóa đơn theo mã hóa đơn
        public static string ktTinhTrangTheoMaHD(int mahd)
        {
            string Result = "";
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TrangThai FROM HOA_DON WHERE MaHD=@mahd", con);
                cmd.Parameters.Add("@mahd", System.Data.SqlDbType.Int).Value = mahd;

                Result = (string)cmd.ExecuteScalar();


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




        //phương thức lấy lấy danh sách hóa đơn theo mã hóa đơn
        public static HoaDonDTO LayDSHDTheoMa(int mahd)
        {
            HoaDonDTO Result = new HoaDonDTO();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM HOA_DON WHERE MaHD=@mahd ", con);
                cmd.Parameters.Add("@mahd",System.Data.SqlDbType.Int).Value = mahd;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Result.MaHD = dr.GetInt32(0);
                        Result.TongTien = dr.GetInt32(1);
                        Result.TrangThai = dr.GetInt32(2);
                        Result.MaBan = dr.GetInt32(3);
                        Result.NgayLap = dr.GetDateTime(4);
                        Result.NVLap = dr.GetString(5);
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


        //phương thức lấy lấy danh sách hóa đơn 
        public static List<HoaDonDTO> LayDSHD()
        {
            List<HoaDonDTO> Result = new List<HoaDonDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM HOA_DON ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        HoaDonDTO hd = new HoaDonDTO();
                        hd.MaHD = dr.GetInt32(0);
                        hd.TongTien = dr.GetInt32(1);
                        hd.TrangThai = dr.GetInt32(2);
                        hd.MaBan = dr.GetInt32(3);
                        hd.NgayLap = dr.GetDateTime(4);
                        hd.NVLap = dr.GetString(5);
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



        //phương thức lấy lấy danh sách hóa đơn theo ngày
        public static List<HoaDonDTO> LayDSHDTheoNgay(DateTime tungay,DateTime denngay)
        {
            List<HoaDonDTO> Result = new List<HoaDonDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM HOA_DON WHERE NgayLap >= @tungay AND NgayLap <=@denngay ", con);
                cmd.Parameters.Add("@tungay",System.Data.SqlDbType.DateTime).Value = tungay;
                cmd.Parameters.Add("@denngay", System.Data.SqlDbType.DateTime).Value = denngay;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        HoaDonDTO hd = new HoaDonDTO();
                        hd.MaHD = dr.GetInt32(0);
                        hd.TongTien = dr.GetInt32(1);
                        hd.TrangThai = dr.GetInt32(2);
                        hd.MaBan = dr.GetInt32(3);
                        hd.NgayLap = dr.GetDateTime(4);
                        hd.NVLap = dr.GetString(5);
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
