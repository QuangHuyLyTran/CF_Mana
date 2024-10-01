using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class ThucUongDAO
    {

        //phương thức lấy danh sách thức uống
        public static List<ThucUongDTO> LayDSTU()
        {
            List<ThucUongDTO> Result = new List<ThucUongDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM THUC_UONG", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ThucUongDTO TU = new ThucUongDTO();
                        TU.MaTU = dr.GetInt32(0);
                        TU.TenTU = dr.GetString(1);
                        TU.LoaiTU = dr.GetInt32(2);
                        TU.MoTa = dr.GetString(3);
                        if (!dr.IsDBNull(4))
                        {
                            TU.DonGia = dr.GetInt32(4);
                        }
                        TU.SoLuong = dr.GetInt32(5);
                        TU.Hinh = dr.GetString(6);
                        Result.Add(TU);
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

        //phương thức lấy tên thức uống theo mã thức uống
        public static string LayTenLoaiThucUongTheoMa(int id)
        {
            string Result = "";
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT LOAI_THUC_UONG.TenLoaiTU  FROM THUC_UONG,LOAI_THUC_UONG WHERE THUC_UONG.LoaiTU = LOAI_THUC_UONG.MaLoaiTU AND THUC_UONG.LoaiTU = @id ", con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
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


        


        //phương thức cập nhật thức uống
        public static bool CapNhatTU(ThucUongDTO tu)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE THUC_UONG SET TenTU=@tentu, LoaiTU=@loaitu,MoTa=@mota,DonGia=@dongia,SoLuong=@soluong,Hinh=@hinh WHERE MaTU=@matu", con);
                cmd.Parameters.Add("@tentu", System.Data.SqlDbType.NVarChar, 50).Value = tu.TenTU;
                cmd.Parameters.Add("@loaitu", System.Data.SqlDbType.Int).Value = tu.LoaiTU;
                cmd.Parameters.Add("@mota", System.Data.SqlDbType.NVarChar, 255).Value = tu.MoTa;
                cmd.Parameters.Add("@dongia", System.Data.SqlDbType.Int).Value = tu.DonGia;
                cmd.Parameters.Add("@soluong", System.Data.SqlDbType.Int).Value = tu.SoLuong;
                cmd.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = tu.Hinh;
                cmd.Parameters.Add("@matu", System.Data.SqlDbType.Int).Value = tu.MaTU;
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


        //phương thức thêm thức uống
        public static int ThemTU(ThucUongDTO tu)
        {
            int Result = -1;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO THUC_UONG(TenTU,LoaiTU,MoTa,DonGia,SoLuong,Hinh) VALUES (@tentu,@loaitu,@mota,@dongia,@soluong,@hinh)", con);
                cmd.Parameters.Add("@tentu", System.Data.SqlDbType.NVarChar, 50).Value = tu.TenTU;
                cmd.Parameters.Add("@loaitu", System.Data.SqlDbType.Int).Value = tu.LoaiTU;
                cmd.Parameters.Add("@mota", System.Data.SqlDbType.NVarChar, 255).Value = tu.MoTa;
                cmd.Parameters.Add("@dongia", System.Data.SqlDbType.Int).Value = tu.DonGia;
                cmd.Parameters.Add("@soluong", System.Data.SqlDbType.Int).Value = tu.SoLuong;
                cmd.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = tu.Hinh;

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

        //phương thức xóa thức uống
        public static bool XoaTU(ThucUongDTO tu)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE THUC_UONG SET SoLuong=0 WHERE MaTU = @matu", con);
                cmd.Parameters.Add("@matu", System.Data.SqlDbType.Int).Value = tu.MaTU;
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


        //hàm read data(đọc mỗi lần 1 sản phẩm)
        private static SqlDataReader ReadData(List<ThucUongDTO> lstTU, SqlCommand caulenh)
        {
            SqlDataReader dr = caulenh.ExecuteReader();
            if (dr.HasRows) // kiểm tra có dòng dữ liệu nào không
            {
                while (dr.Read())// mỗi lần đọc được 1 dòng dữ liệu
                {
                    ThucUongDTO TU = new ThucUongDTO();
                    TU.MaTU = dr.GetInt32(0);
                    TU.TenTU = dr.GetString(1);
                    TU.LoaiTU = dr.GetInt32(2);
                    TU.MoTa = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        TU.DonGia = dr.GetInt32(4);
                    }
                    TU.SoLuong = dr.GetInt32(5);
                    TU.Hinh = dr.GetString(6);
                    lstTU.Add(TU);
                }
                dr.Close();
            }
            return dr;

        }


        //phương thức tìm kiếm thức uống theo tên gần chính xác
        public static List<ThucUongDTO> TKTenTU(string ten)
        {
            List<ThucUongDTO> Result = new List<ThucUongDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM THUC_UONG WHERE TenTU LIKE N'%'+@ten+'%'", con);
                cmd.Parameters.Add("@ten", System.Data.SqlDbType.NVarChar, 255).Value = ten;
                SqlDataReader dr = ReadData(Result, cmd);

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


        //phương thức tìm kiếm theo từ giá đến giá
        public static List<ThucUongDTO> TKGia(int giatu, int giaden)
        {
            List<ThucUongDTO> Result = new List<ThucUongDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM THUC_UONG WHERE DonGia >= @giatu AND DonGia <= @giaden ", con);
                cmd.Parameters.Add("@giatu", System.Data.SqlDbType.NVarChar, 255).Value = giatu;
                cmd.Parameters.Add("@giaden", System.Data.SqlDbType.NVarChar, 255).Value = giaden;
                SqlDataReader dr = ReadData(Result, cmd);

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


        //phương thức lấy giá thức uống theo mã 
        public static int LayGiaTheoMa(int id)
        {
            int Result =0;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DonGia FROM THUC_UONG WHERE MaTU=@id", con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
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


        //phương thức lấy tên thức uống theo mã 
        public static string LayTenTheoMa(int id)
        {
            string Result = "";
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TenTU FROM THUC_UONG WHERE MaTU=@id", con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
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


        //phương thức lấy ds thức uống theo mã loại
        public static List<ThucUongDTO> LayDSTUTheoMaLoai(int id)
        {
            List<ThucUongDTO> Result = new List<ThucUongDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM THUC_UONG WHERE LoaiTU=(SELECT MaLoaiTU FROM LOAI_THUC_UONG WHERE MaLoaiTU=@id)", con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                ReadData(Result, cmd);

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
