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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void dSLọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiSP a = new LoaiSP();
            a.ShowDialog();
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGioiThieuSV a = new FrmGioiThieuSV();
            a.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void Menu_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Xin chào User có mã quyền là: " + FrmLogin.ID_USER);

        }

        private void dSKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKhachHang a = new FrmKhachHang();
            a.ShowDialog();
        }

        private void dSNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhanVien a = new FrmNhanVien();
            a.ShowDialog();
        }

        private void dSSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSanPham a = new FrmSanPham();
            a.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPrint a = new btnPrint();
            a.ShowDialog();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChiTietHoaDon a = new FrmChiTietHoaDon();
            a.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin b = new FrmLogin();
            b.ShowDialog();
        }
    }
}
