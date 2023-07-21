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
    public partial class btnPrint : Form
    {
        int opt = -1;

        public btnPrint()
        {
            InitializeComponent();
        }
        private void SetEnable()
        {
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtTongtien.Enabled = true;
            cbHotenkh.Enabled = true;
            cbHotennv.Enabled = true;
            cbMaSP.Enabled = true;
            dtNgayban.Enabled = true;
        }
        private void SetDisable()
        {
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtTongtien.Enabled = false;
            cbHotenkh.Enabled = false;
            cbHotennv.Enabled = false;
            cbMaSP.Enabled = false;
            dtNgayban.Enabled = false;
        }
        public void Load_NV()
        {
            DoAnTBao.NhanVienDataTable b = new DoAnTBao.NhanVienDataTable();
            DoAnTBaoTableAdapters.NhanVienTableAdapter a = new DoAnTBaoTableAdapters.NhanVienTableAdapter();
            b.Reset();
            a.Fill(b);
            cbHotennv.DisplayMember = "HoTenNV";
            cbHotennv.ValueMember = "MaNV";
            cbHotennv.DataSource = b;
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", cbHotennv.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", cbHotennv.DataSource, "SoDienThoai");

        }
        public void Load_KH()
        {
            DoAnTBao.KhachHangDataTable b = new DoAnTBao.KhachHangDataTable();
            DoAnTBaoTableAdapters.KhachHangTableAdapter a = new DoAnTBaoTableAdapters.KhachHangTableAdapter();
            b.Reset();
            a.Fill(b);
            cbHotenkh.DisplayMember = "HoTenKH";
            cbHotenkh.ValueMember = "MaKH";
            cbHotenkh.DataSource = b;
        }
        public void Load_SP()
        {
            DoAnTBao.SanPhamDataTable b = new DoAnTBao.SanPhamDataTable();
            DoAnTBaoTableAdapters.SanPhamTableAdapter a = new DoAnTBaoTableAdapters.SanPhamTableAdapter();
            b.Reset();
            a.Fill(b);
            cbMaSP.DisplayMember = "TenSP";
            cbMaSP.ValueMember = "MaSP";
            cbMaSP.DataSource = b;
        }
        private void Load_HD()
        {
            DoAnTBao.HoaDonDataTable b = new DoAnTBao.HoaDonDataTable();
            DoAnTBaoTableAdapters.HoaDonTableAdapter a = new DoAnTBaoTableAdapters.HoaDonTableAdapter();
            b.Reset();
            a.HoaDon_getall(b);
            dataGridView1.DataSource = b;
            if (dataGridView1.RowCount > 0)
            {


                cbHotennv.Text = dataGridView1[1, 0].Value.ToString();
                dtNgayban.Text = dataGridView1[2, 0].Value.ToString();
                cbHotenkh.Text = dataGridView1[3, 0].Value.ToString();
                txtTongtien.Text = dataGridView1[4, 0].Value.ToString();
            }
            else
            {

                cbHotenkh.SelectedIndex = 0;
                dtNgayban.Text = DateTime.Today.ToShortDateString();
                cbHotennv.SelectedIndex = 0;
                txtTongtien.Clear();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.checkper("EDIT") == true)
            {
                SetEnable();
                btnThem.Enabled = false;
                opt = 1;
                txtDiaChi.Clear();
                txtSDT.Clear();
                txtTongtien.Clear();
                cbHotenkh.SelectedIndex=0;
                cbHotennv.SelectedIndex = 0;
                cbMaSP.SelectedIndex = 0;
            }
            else
            { MessageBox.Show("Bạn không có quyền !"); }
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
                            DoAnTBao.HoaDonDataTable b = new DoAnTBao.HoaDonDataTable();
                            DoAnTBaoTableAdapters.HoaDonTableAdapter a = new DoAnTBaoTableAdapters.HoaDonTableAdapter();
                            b.Reset();
                            a.HoaDon_Delete(b, id);
                            Load_HD();

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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy thao tác? ", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtDiaChi.Clear();
                txtSDT.Clear();
                txtTongtien.Clear();
                cbHotenkh.SelectedIndex = 0;
                cbHotennv.SelectedIndex = 0;
                cbMaSP.SelectedIndex = 0;
                SetEnable();
                btnThem.Enabled = true;
            }
        }
        private bool Kiemtradulieunhap()
        {
            if(txtDiaChi.Text == "" && txtSDT.Text=="" && txtTongtien.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
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
                    DoAnTBao.HoaDonDataTable b = new DoAnTBao.HoaDonDataTable();
                    DoAnTBaoTableAdapters.HoaDonTableAdapter a = new DoAnTBaoTableAdapters.HoaDonTableAdapter();
                    b.Reset();
                    a.HoaDon_Insert(b, Convert.ToInt32(cbMaSP.SelectedValue.ToString())
                       , Convert.ToDateTime(dtNgayban.Text), Convert.ToInt32(cbHotenkh.SelectedValue.ToString()),
                      Convert.ToDouble(txtTongtien.Text));
                    Load_HD();
                    txtDiaChi.Clear();
                    txtSDT.Clear();
                    txtTongtien.Clear();
                    cbHotenkh.SelectedIndex = 0;
                    cbHotennv.SelectedIndex = 0;
                    cbMaSP.SelectedIndex = 0;
                    cbMaSP.Focus();
                    btnThem.Enabled = true;
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
                        DoAnTBao.HoaDonDataTable b = new DoAnTBao.HoaDonDataTable();
                        DoAnTBaoTableAdapters.HoaDonTableAdapter a = new DoAnTBaoTableAdapters.HoaDonTableAdapter();
                        b.Reset();
                      int id = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                        a.HoaDon_Update(b, id, Convert.ToInt32(cbMaSP.SelectedValue.ToString())
                          , Convert.ToDateTime(dtNgayban.Text), Convert.ToInt32(cbHotenkh.SelectedValue.ToString()),
                         Convert.ToDouble(txtTongtien.Text));
                        Load_HD();
                        cbMaSP.Focus();
                        btnThem.Enabled = true;
                    }


                }
            }
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            Load_HD();
            Load_KH();
            Load_NV();
            Load_SP();
            SetDisable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            opt = 2;
            SetEnable();
            txtMaHD.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            cbHotennv.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            dtNgayban.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            cbHotenkh.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            txtTongtien.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmChiTietHoaDon a = new FrmChiTietHoaDon();
            a.ShowDialog();
        }

        public bool checkMaHD()
        {
            if(txtMaHD.Text =="")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in !");
                return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(checkMaHD())
            {
                FrmPrint a = new FrmPrint(Convert.ToInt32(txtMaHD.Text));
                a.ShowDialog();
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            DoAnTBao.HoaDonDataTable b = new DoAnTBao.HoaDonDataTable();
            DoAnTBaoTableAdapters.HoaDonTableAdapter a = new DoAnTBaoTableAdapters.HoaDonTableAdapter();
            b.Reset();
            a.HoaDon_getbyID(b, Convert.ToInt32(txtMaHD.Text));
            Load_HD();
            dataGridView1.DataSource = b;
           
        }
    }
    }

