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
    public partial class FrmKhachHang : Form
    {
        int opt = -1;
        public FrmKhachHang()
        {
            InitializeComponent();
        }
        public void setEnable()
        {
            txtSoDienThoai.Enabled = true;
            txtHoTenKH.Enabled = true;
            txtDiaChi.Enabled = true;
        }
        public void setDisable()
        {
            txtDiaChi.Enabled = false;
            txtHoTenKH.Enabled = false;
            txtSoDienThoai.Enabled = false;
        }
        public void Load_KH()
        {
            DoAnTBao.KhachHangDataTable b = new DoAnTBao.KhachHangDataTable();
            DoAnTBaoTableAdapters.KhachHangTableAdapter a = new DoAnTBaoTableAdapters.KhachHangTableAdapter();
            b.Reset();
            a.Fill(b);
            dataGridView1.DataSource = b;
            if(dataGridView1.RowCount > 0 )
            {
                txtHoTenKH.Text = dataGridView1[1, 0].Value.ToString();
                txtDiaChi.Text = dataGridView1[2, 0].Value.ToString();
                txtSoDienThoai.Text = dataGridView1[3, 0].Value.ToString();
            }
            else
            {
                txtDiaChi.Clear();
                txtHoTenKH.Clear();
                txtSoDienThoai.Clear();
                txtHoTenKH.Focus();
            }
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            Load_KH();
            setDisable();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //if (txtHoTenKH.Text != "" || txtSoDienThoai.Text != "" || txtDiaChi.Text != "")
            //{
            //    MessageBox.Show("Đang có dữ liệu cần nhập,Nếu muốn thêm dữ liệu mới hãy nhất Hủy");
            //}
            setEnable();
            opt = 1;
            txtDiaChi.Clear();
            txtHoTenKH.Clear();
            txtSoDienThoai.Clear();
            txtHoTenKH.Focus();
          

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
                            DoAnTBao.KhachHangDataTable b = new DoAnTBao.KhachHangDataTable();
                            DoAnTBaoTableAdapters.KhachHangTableAdapter a = new DoAnTBaoTableAdapters.KhachHangTableAdapter();
                            b.Reset();
                           a.KhachHang_Delete (b, id);
                            Load_KH();

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

        private void btnKhong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy tất cả thao tác không? ", "WARNING", MessageBoxButtons.YesNo
               , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtDiaChi.Clear();
                txtHoTenKH.Clear();
                txtSoDienThoai.Clear();
                txtHoTenKH.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        public bool Kiemtradulieunhap()
        {
            if (txtHoTenKH.Text == "" && txtSoDienThoai.Text == "" && txtDiaChi.Text == "")
            {
                MessageBox.Show("Yêu cầu nhập dữ liệu đầy đủ");
                return false;
            }
            return true;
          
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.checkper("ADD") == true)
            {
                if (Kiemtradulieunhap() && opt == 1)
                {
                    DoAnTBao.KhachHangDataTable b = new DoAnTBao.KhachHangDataTable();
                    DoAnTBaoTableAdapters.KhachHangTableAdapter a = new DoAnTBaoTableAdapters.KhachHangTableAdapter();
                    b.Reset();
                    a.KhachHang_Insert(b, txtHoTenKH.Text, txtDiaChi.Text, txtSoDienThoai.Text);
                    Load_KH();
                    txtDiaChi.Clear();
                    txtHoTenKH.Clear();
                    txtSoDienThoai.Clear();
                    txtHoTenKH.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }

            if (PhanQuyen.checkper("EDIT") == true)
            {
                if (opt == 2)
                {
                    if (MessageBox.Show("Bạn có muốn sửa lại không ? ", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DoAnTBao.KhachHangDataTable b = new DoAnTBao.KhachHangDataTable();
                        DoAnTBaoTableAdapters.KhachHangTableAdapter a = new DoAnTBaoTableAdapters.KhachHangTableAdapter();
                        b.Reset();
                        int MaKH = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                        a.KhachHang_Update(b, MaKH, txtHoTenKH.Text, txtDiaChi.Text, txtSoDienThoai.Text);
                        Load_KH();
                    }


                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHoTenKH.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txtDiaChi.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            txtSoDienThoai.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            opt = 2;
            setEnable();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoAnTBao.KhachHangDataTable b = new DoAnTBao.KhachHangDataTable();
            DoAnTBaoTableAdapters.KhachHangTableAdapter a = new DoAnTBaoTableAdapters.KhachHangTableAdapter();
            b.Reset();
            a.KhachHang_getbyID(b,Convert.ToInt32(txtMaKH.Text));
            dataGridView1.DataSource = b;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmPrint_KhachHang a = new FrmPrint_KhachHang();
            a.ShowDialog();

        }
    }
}
