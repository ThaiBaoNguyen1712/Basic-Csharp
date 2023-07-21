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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
       


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string getID(string username, string pass)
        {
             SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=DoAn_NguyenThaiBao;Integrated Security=True");
            string id = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID ='" + username + "' and Userpass='" + pass + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["Ma_Quyen"].ToString();
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
            return id;
        }
        public static string ID_USER = "";
        private void button1_Click(object sender, EventArgs e)
        {
            ID_USER = getID(txtTK.Text, txtMK.Text);
            if (ID_USER != "")
            {
                Menu fmain = new Menu();
                fmain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoảng và mật khẩu không đúng !");
            }


        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            FrmSignUp a = new FrmSignUp();
            a.ShowDialog();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
