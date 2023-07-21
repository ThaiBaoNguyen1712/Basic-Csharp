using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DoAn_NguyenThaiBao_K17CNTT
{

    class PhanQuyen
    {
       
   
            public static List<string> list_per(string id_per)
        {
            List<string> termsList = new List<string>();
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=DoAn_NguyenThaiBao;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM QuyenChucNang WHERE Ma_Quyen ='" + id_per + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        termsList.Add(dr["ChucNang"].ToString());
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return termsList;
        }
        public static List<string> list_detail;

        public static Boolean checkper(string code)
        {
            list_detail = PhanQuyen.list_per(FrmLogin.ID_USER);
            Boolean check = false;
            foreach (string item in list_detail)
            {
                if (item == code)
                {
                    check = true;
                }
            }
            return check;
        }
    }
}
