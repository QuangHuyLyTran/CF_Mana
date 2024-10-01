using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class XuatHDDAO
    {
        public static List<XuatHDDTO> XuatHD(int mahd)
        {
            List<XuatHDDTO> Result = new List<XuatHDDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CHI_TIET_HD.MaHD,HOA_DON.MaBan,THUC_UONG.TenTU,CHI_TIET_HD.SoLuong,CHI_TIET_HD.DonGia,CHI_TIET_HD.ThanhTien,HOA_DON.TongTien,HOA_DON.NVLap,HOA_DON.NgayLap FROM THUC_UONG,CHI_TIET_HD,HOA_DON WHERE CHI_TIET_HD.MaHD = HOA_DON.MaHD AND THUC_UONG.MaTU = CHI_TIET_HD.MaTU AND HOA_DON.MaHD  = @mahd", con);
                cmd.Parameters.Add("@mahd",System.Data.SqlDbType.Int).Value = mahd;
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        XuatHDDTO hd = new XuatHDDTO();
                        hd.MaHD = dr.GetInt32(0);
                        hd.MaBan = dr.GetInt32(1);
                        hd.TenTU = dr.GetString(2);
                        hd.SoLuong = dr.GetInt32(3);
                        hd.DonGia = dr.GetInt32(4);
                        hd.ThanhTien = dr.GetInt32(5);
                        hd.TongTien = dr.GetInt32(6);
                        hd.NVLap = dr.GetString(7);
                        hd.NgayLap = dr.GetDateTime(8);
                        
                        Result.Add(hd);

                    }
                }
            }
            finally
            {
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Result;
        }
    }
}
