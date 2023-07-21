using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_NguyenThaiBao_K17CNTT
{
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }
        public void Load_Quyen()
        {
            DoAnTBao.QuyenDataTable b = new DoAnTBao.QuyenDataTable();
            DoAnTBaoTableAdapters.QuyenTableAdapter a = new DoAnTBaoTableAdapters.QuyenTableAdapter();
            b.Reset();
            a.Fill(b);
            cbQuyen.DataSource = b;
            cbQuyen.DisplayMember = "Ten_Quyen";
            cbQuyen.ValueMember = "Ma_Quyen";
        }

        private void FrmSignUp_Load(object sender, EventArgs e)
        {
            Load_Quyen();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
            txtPass.Clear();
            txtPass2.Clear();
        }
        public bool checkPass()
        {
            if(txtPass.Text == txtPass2.Text)
            {
                return true;
            }
            return false;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.FileName = "";
            OD.Filter = "Supported Images|*.jpg;*.jpeg;*.png";
            if (OD.ShowDialog() == DialogResult.OK)
                pictureBox1.Load(OD.FileName);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (checkPass())
            {

                DoAnTBao.UsersDataTable b = new DoAnTBao.UsersDataTable();
                DoAnTBaoTableAdapters.UsersTableAdapter a = new DoAnTBaoTableAdapters.UsersTableAdapter();
                b.Reset();
                var anh = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                a.Add_Acc(b, txtID.Text, txtTen.Text, txtPass.Text, Convert.ToInt16(cbQuyen.SelectedValue.ToString()), (Byte[])anh);
                MessageBox.Show("Tạo Thành công ");
                this.Close();
            }
            else
                MessageBox.Show("Vui lòng nhập lại chính xác mật khẩu");
            
        }
    }
}
