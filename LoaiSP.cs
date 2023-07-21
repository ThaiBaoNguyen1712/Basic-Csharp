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
    public partial class LoaiSP : Form
    {
        int opt = -1;
        public LoaiSP()
        {
           
            InitializeComponent();
           
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenLoaiSP.Enabled = true;
            txtTenLoaiSP.Focus();
            txtTenLoaiSP.Clear();
            opt = 1;
        }
        public void Load_loaiSP()
        {
            DoAnTBao.LoaiSPDataTable b = new DoAnTBao.LoaiSPDataTable();
            DoAnTBaoTableAdapters.LoaiSPTableAdapter a = new DoAnTBaoTableAdapters.LoaiSPTableAdapter();
            b.Reset();
            a.Fill(b);
            dataGridView1.DataSource = b;
            if (dataGridView1.RowCount > 0)
            {
                txtTenLoaiSP.Text = dataGridView1[1,0].Value.ToString();
            }
            else
            {
                txtTenLoaiSP.Clear();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.checkper("DEL") == true)
            {
                try
                {
                    if (dataGridView1.RowCount > 0)//L?y s? dòng c?a Lu?i
                    {
                        int id = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());

                        if (MessageBox.Show("Bạn có muốn xóa không?",
                                                         "warning",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DoAnTBao.LoaiSPDataTable b = new DoAnTBao.LoaiSPDataTable();
                            DoAnTBaoTableAdapters.LoaiSPTableAdapter a = new DoAnTBaoTableAdapters.LoaiSPTableAdapter();
                            b.Reset();
                            a.LoaiSP_Delete(b, id);
                            Load_loaiSP();

                        }
                    }
                    else
                        MessageBox.Show("Không có dữ liệu");
                }
                catch
                {
                    MessageBox.Show("Dữ liệu liên quan đến bảng khác nên không thể xóa được!");

                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void LoaiSP_Load(object sender, EventArgs e)
        {
            Load_loaiSP();
            txtTenLoaiSP.Enabled = false;
        }
  
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.checkper("ADD") == true)
            {
                if (kiemtradulieunhap()&&opt ==1)
                {
                    DoAnTBao.LoaiSPDataTable b = new DoAnTBao.LoaiSPDataTable();
                    DoAnTBaoTableAdapters.LoaiSPTableAdapter a = new DoAnTBaoTableAdapters.LoaiSPTableAdapter();
                    b.Reset();
                    a.LoaiSP_Insert(b, txtTenLoaiSP.Text);
                    Load_loaiSP();
                    txtTenLoaiSP.Clear();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
            
            if(PhanQuyen.checkper("EDIT") == true)
            {
                if(opt ==2)
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại không ? ", "Warning", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                        DoAnTBao.LoaiSPDataTable b = new DoAnTBao.LoaiSPDataTable();
                        DoAnTBaoTableAdapters.LoaiSPTableAdapter a = new DoAnTBaoTableAdapters.LoaiSPTableAdapter();
                        b.Reset();
                        int MaLoaiSP = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                        a.LoaiSP_Update(b, MaLoaiSP, txtTenLoaiSP.Text);
                        Load_loaiSP();
                        txtTenLoaiSP.Clear();
                        }
                   
                   
                }
            }

        }
        public bool kiemtradulieunhap()
        {
            if (txtTenLoaiSP.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập dữ liệu đầy đủ");
                return false;
            }

            return true;
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy thao tác? ", "Warning",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtTenLoaiSP.Clear();
            }
             
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenLoaiSP.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            opt = 2;
            txtTenLoaiSP.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoAnTBao.LoaiSPDataTable b = new DoAnTBao.LoaiSPDataTable();
            DoAnTBaoTableAdapters.LoaiSPTableAdapter a = new DoAnTBaoTableAdapters.LoaiSPTableAdapter();
            b.Reset();
            a.LoaiSP_getbyID(b, Int32.Parse(txtMaLSP.Text));
            Load_loaiSP();
            dataGridView1.DataSource = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmprintLoaiSP a = new FrmprintLoaiSP();
            a.ShowDialog();
        }
    }
}
