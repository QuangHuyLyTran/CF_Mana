using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public static class LoaiTUDAO
    {
        //phương thức lấy danh sách loại thức uống
        public static List<LoaiTUDTO> LayDSLoaiTU()
        {
            List<LoaiTUDTO> Result = new List<LoaiTUDTO>();
            SqlConnection con = DataProvider.GetConnection();
            try
            {
                con.Open();//mở kết nối

                SqlCommand cmd = new SqlCommand("SELECT * FROM LOAI_THUC_UONG", con);// gán câu kết nối
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) // kiểm tra có dòng dữ liệu nào không
                {
                    while (dr.Read())// mỗi lần đọc được 1 dòng dữ liệu
                    {
                        LoaiTUDTO LTU = new LoaiTUDTO();
                        LTU.MaLoaiTU = dr.GetInt32(0);
                        LTU.TenLoaiTU = dr.GetString(1);
                        Result.Add(LTU);
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
