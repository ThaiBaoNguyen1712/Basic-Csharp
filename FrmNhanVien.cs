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
    public partial class FrmNhanVien : Form
    {
        int opt = -1;
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        public void Load_NhanVien()
        {
            DoAnTBao.NhanVienDataTable b = new DoAnTBao.NhanVienDataTable();
            DoAnTBaoTableAdapters.NhanVienTableAdapter a = new DoAnTBaoTableAdapters.NhanVienTableAdapter();
            b.Reset();
            a.Fill(b);
            dataGridView1.DataSource = b;
            if(dataGridView1.RowCount>0)
            {
                txtHoTenNV.Text = dataGridView1[1, 0].Value.ToString();
                cbGioiTinh.Text = dataGridView1[2, 0].Value.ToString();
                txtDiaChi.Text = dataGridView1[3, 0].Value.ToString();
                dateTimePicker1.Text = dataGridView1[4, 0].Value.ToString();
                txtSoDienThoai.Text = dataGridView1[5, 0].Value.ToString();
            }
            else
            {
                dateTimePicker1.Text = DateTime.Today.ToShortDateString();
                txtSoDienThoai.Clear();
                txtHoTenNV.Clear();
                txtDiaChi.Clear();
                cbGioiTinh.SelectedIndex = 0;
            }
        }
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            Load_NhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.checkper("DEL") == true)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                    if (dataGridView1.RowCount > 0)
                    {
                        if (MessageBox.Show("Bạn có muốn xóa không?", "Warning", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DoAnTBao.NhanVienDataTable b = new DoAnTBao.NhanVienDataTable();
                            DoAnTBaoTableAdapters.NhanVienTableAdapter a = new DoAnTBaoTableAdapters.NhanVienTableAdapter();
                            b.Reset();
                            a.NhanVien_Delete(b, id);
                            Load_NhanVien();
                            btnThem.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu !");
                    }


                }
                catch
                {
                    MessageBox.Show("Dữ liệu liên quan đến bảng khác, không thể xóa!");
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền !");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if(PhanQuyen.checkper("ADD")==true&& PhanQuyen.checkper("EDIT") == true)
            {
                DoAnTBao.NhanVienDataTable b = new DoAnTBao.NhanVienDataTable();
                DoAnTBaoTableAdapters.NhanVienTableAdapter a = new DoAnTBaoTableAdapters.NhanVienTableAdapter();
                b.Reset();
                btnThem.Enabled = true;
                if (opt ==1)
                {
                    a.NhanVien_Insert(b, txtHoTenNV.Text, cbGioiTinh.Text, txtDiaChi.Text, dateTimePicker1.Value, Convert.ToInt32(txtSoDienThoai.Text));
                    Load_NhanVien();
                  
                }
                if(opt==2)
                {
                    int id = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                    a.NhanVien_Update(b, id, txtHoTenNV.Text, cbGioiTinh.Text, txtDiaChi.Text, dateTimePicker1.Value, Convert.ToInt32(txtSoDienThoai.Text));
                    Load_NhanVien();
                   
                }
            }
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn hủy các thao tác không","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                dateTimePicker1.Text = DateTime.Today.ToShortDateString();
                txtSoDienThoai.Clear();
                txtHoTenNV.Clear();
                txtDiaChi.Clear();
                cbGioiTinh.SelectedIndex = 0; 
                btnThem.Enabled = true;
                Load_NhanVien();
            }
        }

   
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            opt = 2;

            txtHoTenNV.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            cbGioiTinh.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            txtDiaChi.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            dateTimePicker1.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            txtSoDienThoai.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            opt = 1;
            dateTimePicker1.Text = DateTime.Today.ToShortDateString();
            txtSoDienThoai.Clear();
            txtHoTenNV.Clear();
            txtDiaChi.Clear();
            cbGioiTinh.SelectedIndex = 0;
            txtHoTenNV.Focus();
            btnThem.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoAnTBao.NhanVienDataTable b = new DoAnTBao.NhanVienDataTable();
            DoAnTBaoTableAdapters.NhanVienTableAdapter a = new DoAnTBaoTableAdapters.NhanVienTableAdapter();
            b.Reset();
            a.NhanVien_getbyID(b, Convert.ToInt32(txtMaNV.Text));
            Load_NhanVien();
            dataGridView1.DataSource = b;
           
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmPrint_NhanVien a = new FrmPrint_NhanVien();
            a.ShowDialog();
        }
    }
}
