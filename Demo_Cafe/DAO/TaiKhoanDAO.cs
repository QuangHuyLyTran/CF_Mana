using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class TaiKhoanDAO
    {
        //phương thức kiểm tra tài khoản
        public static bool ktTaiKhoan(string id, string pass)
        {
            bool Result =false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TAI_KHOAN WHERE TenDN LIKE @tendangnhap AND MatKhau LIKE @matkhau ", con);
                cmd.Parameters.Add("@tendangnhap", System.Data.SqlDbType.NVarChar, 50).Value = id;
                cmd.Parameters.Add("@matkhau", System.Data.SqlDbType.NVarChar, 50).Value = pass;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TaiKhoanDTO TK = new TaiKhoanDTO();
                        TK.MaTK = dr.GetInt32(0);
                        TK.TenDN = dr.GetString(1);
                        TK.MatKhau = dr.GetString(2);
                        TK.MaNV = dr.GetInt32(3);
                        TK.Quyen = dr.GetInt32(4);
                        TK.TrangThai = dr.GetInt32(5);
                        //TK.Hinh = dr.GetString(7);
                        Result = true;
                    }
                    dr.Close();
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


        //phương thức kiểm tra quyền
        public static int ktQuyen(string id)
        {
            int Result = 0;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Quyen FROM TAI_KHOAN WHERE TenDN=@id", con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar,50).Value = id;
                if(cmd.ExecuteScalar() !=null)
                {
                    Result = (int)cmd.ExecuteScalar();
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

        //phương thức lấy tên nhân viên theo id
        public static string ktTen(string id)
        {
            string Result = "";
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT NHAN_VIEN.TenNV  FROM NHAN_VIEN,TAI_KHOAN WHERE NHAN_VIEN.MaNV = TAI_KHOAN.MaNV AND NHAN_VIEN.MaNV = (SELECT MaNV FROM TAI_KHOAN WHERE TenDN =@id)", con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar, 50).Value = id;
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


        //phương thức lấy hình nhân viên theo id
        public static string LayHinh(string id)
        {
            string Result = "";
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT NHAN_VIEN.Hinh  FROM NHAN_VIEN,TAI_KHOAN WHERE NHAN_VIEN.MaNV = TAI_KHOAN.MaNV AND NHAN_VIEN.MaNV = (SELECT MaNV FROM TAI_KHOAN WHERE TenDN =@id)", con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar, 50).Value = id;
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



        


       


        //hàm read data(đọc mỗi lần 1 sản phẩm)
        private static SqlDataReader ReadData(List<TaiKhoanDTO> lstTK, SqlCommand caulenh)
        {
            SqlDataReader dr = caulenh.ExecuteReader();
            if (dr.HasRows) // kiểm tra có dòng dữ liệu nào không
            {
                while (dr.Read())// mỗi lần đọc được 1 dòng dữ liệu
                {
                    TaiKhoanDTO TK = new TaiKhoanDTO();
                    TK.MaTK = dr.GetInt32(0);
                    TK.TenDN = dr.GetString(1);
                    TK.MatKhau = dr.GetString(2);
                    TK.MaNV = dr.GetInt32(3);
                    TK.Quyen = dr.GetInt32(4);
                    TK.TrangThai = dr.GetInt32(5);
                    //TK.Hinh = dr.GetString(7);
                    lstTK.Add(TK);
                }
                dr.Close();
            }
            return dr;

        }


        //phương thức lấy danh sách tài khoản
        public static List<TaiKhoanDTO> LayDSTK()
        {
            List<TaiKhoanDTO> Result = new List<TaiKhoanDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TAI_KHOAN", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TaiKhoanDTO TK = new TaiKhoanDTO();
                        TK.MaTK = dr.GetInt32(0);
                        TK.TenDN = dr.GetString(1);
                        TK.MatKhau = dr.GetString(2);
                        TK.MaNV = dr.GetInt32(3);
                        TK.Quyen = dr.GetInt32(4);
                        TK.TrangThai = dr.GetInt32(5);
                        //TK.Hinh = dr.GetString(7);
                        Result.Add(TK);
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



        //phương thức lấy tên nhân viên theo mã nhân viên
        public static string LayTenTheoMaNV(int id)
        {
            string Result = "";
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT NHAN_VIEN.TenNV  FROM NHAN_VIEN,TAI_KHOAN WHERE NHAN_VIEN.MaNV = TAI_KHOAN.MaNV AND NHAN_VIEN.MaNV = @id ", con);
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


        

    }
}
