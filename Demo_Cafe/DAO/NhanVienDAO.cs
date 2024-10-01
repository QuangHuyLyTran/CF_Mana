using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class NhanVienDAO
    {
        //phương thức lấy danh sách nhân viên
        public static List<NhanVienDTO> LayDSNV()
        {
            List<NhanVienDTO> Result = new List<NhanVienDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NHAN_VIEN", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        NhanVienDTO NV = new NhanVienDTO();
                        NV.MaNV = dr.GetInt32(0);
                        NV.TenNV = dr.GetString(1);
                        NV.GioiTinh = dr.GetString(2);
                        NV.DiaChi = dr.GetString(3);
                        NV.SDT = dr.GetString(4);
                        NV.Hinh = dr.GetString(5);
                        NV.ChucVu = dr.GetInt32(6);
                        Result.Add(NV);
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



        //phương thức lấy tên chức vụ theo mã chức vụ
        public static string LayTenTheoMaCV(int id)
        {
            string Result = "";
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CHUC_VU.TenCV  FROM NHAN_VIEN,CHUC_VU WHERE NHAN_VIEN.ChucVu = CHUC_VU.MaCV AND NHAN_VIEN.ChucVu = @id ", con);
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


        //phương thức cập nhật nhân viên
        public static bool CapNhatNV(NhanVienDTO nv)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE NHAN_VIEN SET TenNV=@tennv, GioiTinh=@gioitinh,DiaChi=@diachi,SDT=@sdt,Hinh=@hinh,ChucVu=@chucvu WHERE MaNV=@manv", con);
                cmd.Parameters.Add("@tennv", System.Data.SqlDbType.NVarChar, 50).Value = nv.TenNV;
                cmd.Parameters.Add("@gioitinh", System.Data.SqlDbType.NVarChar,3).Value = nv.GioiTinh;
                cmd.Parameters.Add("@diachi", System.Data.SqlDbType.NVarChar,255).Value = nv.DiaChi;
                cmd.Parameters.Add("@sdt", System.Data.SqlDbType.NVarChar,50).Value = nv.SDT;
                cmd.Parameters.Add("@chucvu", System.Data.SqlDbType.Int).Value = nv.ChucVu;
                cmd.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = nv.Hinh;
                cmd.Parameters.Add("@manv", System.Data.SqlDbType.Int).Value = nv.MaNV;
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


        //phương thức thêm nhân viên
        public static int ThemNV(NhanVienDTO nv)
        {
            int Result = -1;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO NHAN_VIEN(TenNV,GioiTinh,DiaChi,SDT,Hinh,ChucVu) VALUES (@tennv,@gioitinh,@diachi,@sdt,@hinh,@chucvu)", con);
                cmd.Parameters.Add("@tennv", System.Data.SqlDbType.NVarChar, 50).Value = nv.TenNV;
                cmd.Parameters.Add("@gioitinh", System.Data.SqlDbType.NVarChar, 3).Value = nv.GioiTinh;
                cmd.Parameters.Add("@diachi", System.Data.SqlDbType.NVarChar, 255).Value = nv.DiaChi;
                cmd.Parameters.Add("@sdt", System.Data.SqlDbType.NVarChar, 50).Value = nv.SDT;
                cmd.Parameters.Add("@chucvu", System.Data.SqlDbType.Int).Value = nv.ChucVu;
                cmd.Parameters.Add("@hinh", System.Data.SqlDbType.NVarChar, 255).Value = nv.Hinh;

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



        //phương thức xóa nhân viên
        public static bool XoaNV(NhanVienDTO nv)
        {
            bool Result = false;
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM NHAN_VIEN WHERE MaNV = @manv", con);
                cmd.Parameters.Add("@manv", System.Data.SqlDbType.Int).Value = nv.MaNV;
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


        //phương thức tìm kiếm nhân viên theo tên chính xác
        public static List<NhanVienDTO> TKNVTen9Xac(string ten)
        {
            List<NhanVienDTO> Result = new List<NhanVienDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NHAN_VIEN WHERE TenNV LIKE @ten", con);
                cmd.Parameters.Add("@ten", System.Data.SqlDbType.NVarChar, 50).Value = ten;
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

        //phương thức tìm kiếm nhân viên theo tên gần chính xác
        public static List<NhanVienDTO> TKTenGan9Xac(string ten)
        {
            List<NhanVienDTO> Result = new List<NhanVienDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NHAN_VIEN WHERE TenNV LIKE N'%'+@ten+'%'", con);
                cmd.Parameters.Add("@ten", System.Data.SqlDbType.NVarChar, 50).Value = ten;
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


        //hàm read data(đọc mỗi lần 1 sản phẩm)
        private static SqlDataReader ReadData(List<NhanVienDTO> lstNV, SqlCommand caulenh)
        {
            SqlDataReader dr = caulenh.ExecuteReader();
            if (dr.HasRows) // kiểm tra có dòng dữ liệu nào không
            {
                while (dr.Read())// mỗi lần đọc được 1 dòng dữ liệu
                {
                    NhanVienDTO NV = new NhanVienDTO();
                    NV.MaNV = dr.GetInt32(0);
                    NV.TenNV = dr.GetString(1);
                    NV.GioiTinh = dr.GetString(2);
                    NV.DiaChi = dr.GetString(3);
                    NV.SDT = dr.GetString(4);
                    NV.Hinh = dr.GetString(5);
                    NV.ChucVu = dr.GetInt32(6);
                    lstNV.Add(NV);
                }
                dr.Close();
            }
            return dr;

        }
    }
}
