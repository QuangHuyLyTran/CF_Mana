using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public  static class ChucVuDAO
    {
        //phương thức lấy danh sách chức vụ
        public static List<ChucVuDTO> LayDSCV()
        {
            List<ChucVuDTO> Result = new List<ChucVuDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();//mở kết nối

                SqlCommand cmd = new SqlCommand("SELECT * FROM CHUC_VU", con);// gán câu kết nối
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) // kiểm tra có dòng dữ liệu nào không
                {
                    while (dr.Read())// mỗi lần đọc được 1 dòng dữ liệu
                    {
                        ChucVuDTO CV = new ChucVuDTO();
                        CV.MaCV = dr.GetInt32(0);
                        CV.TenCV = dr.GetString(1);
                        Result.Add(CV);
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
