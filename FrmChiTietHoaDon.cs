using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_NguyenThaiBao_K17CNTT
{
    public partial class FrmChiTietHoaDon : Form
    {
        int opt = -1;
       
        public FrmChiTietHoaDon()
        {
            InitializeComponent();
        }
        public void SetEnable()
        {
         
            cbMaHD.Enabled = true;
            cbSanPham.Enabled = true;
            txtHoTenNV.Enabled = true;
            txtHoTenKH.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtDonGia.Enabled = true;
            txtTenSP.Enabled = true;
            txtSoLuongMua.Enabled = true;
            txtGiamGia.Enabled = true;

        }
        public void SetDisable()
        {
            cbMaHD.Enabled = false;
            cbSanPham.Enabled = false;

            txtHoTenNV.Enabled = false;
            txtHoTenKH.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtDonGia.Enabled = false;
            txtTenSP.Enabled = false;
      
        }
        public void Load_MaHD()
        {
            DoAnTBao.HoaDonDataTable b = new DoAnTBao.HoaDonDataTable();
            DoAnTBaoTableAdapters.HoaDonTableAdapter a = new DoAnTBaoTableAdapters.HoaDonTableAdapter();
            b.Reset();
            a.Fill(b);
            cbMaHD.DisplayMember = "MaHD";
            cbMaHD.ValueMember = "MaHD";
            cbMaHD.DataSource = b;
        }
        public void Load_SP()
        {
            DoAnTBao.SanPhamDataTable b = new DoAnTBao.SanPhamDataTable();
            DoAnTBaoTableAdapters.SanPhamTableAdapter a = new DoAnTBaoTableAdapters.SanPhamTableAdapter();
            b.Reset();
            a.Fill(b);
            cbSanPham.DisplayMember = "TenSP";
            cbSanPham.ValueMember = "MaSP";
            cbSanPham.DataSource = b;

        }
        public void Load_CTHD()
        {
            DoAnTBao.ChiTietHoaDonDataTable b = new DoAnTBao.ChiTietHoaDonDataTable();
            DoAnTBaoTableAdapters.ChiTietHoaDonTableAdapter a = new DoAnTBaoTableAdapters.ChiTietHoaDonTableAdapter();
            b.Reset();
            a.ChiTietHoaDon_getall(b);
            dgChiTietHD.DataSource = b;
            if (dgChiTietHD.RowCount > 0)
            {
                cbMaHD.Text = dgChiTietHD[0, 0].Value.ToString();
                cbSanPham.Text = dgChiTietHD[1, 0].Value.ToString();
                txtSoLuongMua.Text = dgChiTietHD[2, 0].Value.ToString();
                txtDonGia.Text = dgChiTietHD[3, 0].Value.ToString();
                txtGiamGia.Text = dgChiTietHD[4, 0].Value.ToString();
            }
            else
            {
                cbSanPham.SelectedIndex = 0;
                cbMaHD.SelectedIndex = 0;
                txtSoLuongMua.Clear();
                txtDonGia.Clear();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (PhanQuyen.checkper("DEL") == true)
            {
                try
                {
                    if (dgChiTietHD.RowCount > 0)
                    {
                        int id = Convert.ToInt32(dgChiTietHD[0, dgChiTietHD.CurrentRow.Index].Value.ToString());
                        if (MessageBox.Show("Bạn có muốn xóa không ?", "Warning", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes) ;
                        {
                            DoAnTBao.ChiTietHoaDonDataTable b = new DoAnTBao.ChiTietHoaDonDataTable();
                            DoAnTBaoTableAdapters.ChiTietHoaDonTableAdapter a = new DoAnTBaoTableAdapters.ChiTietHoaDonTableAdapter();
                            b.Reset();
                            a.ChiTietHoaDon_Delete(b, id);
                            Load_CTHD();
                        }

                    }
                    else
                        MessageBox.Show("Không có dữ liệu !");

                }
                catch
                {
                    MessageBox.Show("Dữ liệu liên quan đến các bảng khác, Không thể xóa !");
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền!");
            } }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.checkper("EDIT") == true)
            {
                SetEnable();
                btnThem.Enabled = false;
                opt = 1;
                txtHoTenNV.Clear();
                txtHoTenKH.Clear();
                txtDiaChi.Clear();
                txtSoDienThoai.Clear();
                txtDonGia.Clear();
                txtTenSP.Clear();
                txtSoLuongMua.Clear();
                txtGiamGia.Clear();
            }
            else
            { MessageBox.Show("Bạn không có quyền !"); }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy thao tác? ", "Warning",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtHoTenNV.Clear();
                txtHoTenKH.Clear();
                txtDiaChi.Clear();
                txtSoDienThoai.Clear();
                txtDonGia.Clear();
                txtTenSP.Clear();
                txtSoLuongMua.Clear();
                txtGiamGia.Clear();
                Load_CTHD();

            }
        }
        public bool Kiemtradulieu()
        {
            if (txtSoLuongMua.Text == "" && txtDonGia.Text == "")
            {
                return false;
            }
            return true;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
                DoAnTBao.ChiTietHoaDonDataTable b = new DoAnTBao.ChiTietHoaDonDataTable();
                DoAnTBaoTableAdapters.ChiTietHoaDonTableAdapter a = new DoAnTBaoTableAdapters.ChiTietHoaDonTableAdapter();
                b.Reset();
                if (PhanQuyen.checkper("ADD") == true)
                {
                    if (Kiemtradulieu() && opt == 1)
                {
                    a.ChiTietHoaDon_Insert(b, Convert.ToInt32(cbMaHD.SelectedValue.ToString()), Convert.ToInt32(cbSanPham.SelectedValue.ToString()),
                        Convert.ToInt32(txtSoLuongMua.Text), Convert.ToInt32(txtDonGia.Text), Convert.ToInt32(txtGiamGia.Text), Convert.ToInt32(txtThanhTien.Text));
                    Load_CTHD();
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
                        int id = Convert.ToInt32(dgChiTietHD[0, dgChiTietHD.CurrentRow.Index].Value.ToString());
                        a.ChiTietHoaDon_Update(b, id, Convert.ToInt32(cbSanPham.SelectedValue.ToString()), Convert.ToInt32(txtSoLuongMua.Text),
                           Convert.ToDouble(txtDonGia.Text), Convert.ToDouble(txtGiamGia.Text), Convert.ToDouble(txtThanhTien.Text));
                        Load_CTHD();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền");
                }
            }

        private void FrmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            Load_CTHD();
            Load_MaHD();
            Load_SP();
            SetDisable();
            opt = 1;
           
        }
   
        private void dgChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            opt = 2;
            cbSanPham.Text = dgChiTietHD[1, dgChiTietHD.CurrentRow.Index].Value.ToString();
            txtSoLuongMua.Text = dgChiTietHD[2, dgChiTietHD.CurrentRow.Index].Value.ToString();
            txtDonGia.Text = dgChiTietHD[3, dgChiTietHD.CurrentRow.Index].Value.ToString();
            txtGiamGia.Text = dgChiTietHD[4, dgChiTietHD.CurrentRow.Index].Value.ToString();
            SetEnable();
        }

 

      
        public void setsanphambyid(int masp)
        {
            DoAnTBao.SanPhamDataTable b = new DoAnTBao.SanPhamDataTable();
            DoAnTBaoTableAdapters.SanPhamTableAdapter a = new DoAnTBaoTableAdapters.SanPhamTableAdapter();
            b.Reset();
            a.SanPham_byID(b, masp);
            txtDonGia.Text = b.Rows[0]["Dongiaban"].ToString();
            txtTenSP.Text = b.Rows[0]["TenSP"].ToString();
           
        }
        public void sethoadonbyID(int mahd)
        {
            DoAnTBao.HoaDon_getbyIDDataTable b = new DoAnTBao.HoaDon_getbyIDDataTable();
            DoAnTBaoTableAdapters.HoaDon_getbyIDTableAdapter a = new DoAnTBaoTableAdapters.HoaDon_getbyIDTableAdapter();
            b.Reset();
            a.Fill(b,mahd);
            txtHoTenNV.Text =  b.Rows[0]["HoTenNV"].ToString();
            txtHoTenKH.Text = b.Rows[0]["HoTenKH"].ToString();
            txtDiaChi.Text = b.Rows[0]["DiaChi"].ToString();
            txtSoDienThoai.Text = b.Rows[0]["SoDienThoai"].ToString();

        }
        private void cbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            setsanphambyid(Convert.ToInt32(cbSanPham.SelectedValue.ToString()));
          
        }

        private void cbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            sethoadonbyID(Convert.ToInt32(cbMaHD.SelectedValue.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double thanhtien, giamgia;
            thanhtien = Int32.Parse(txtSoLuongMua.Text) * double.Parse(txtDonGia.Text);
            giamgia = thanhtien * double.Parse(txtGiamGia.Text) / 100;
            txtThanhTien.Text = (thanhtien - giamgia).ToString();
            txtTongThanhTien.Text = txtThanhTien.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoAnTBao.ChiTietHoaDonDataTable b = new DoAnTBao.ChiTietHoaDonDataTable();
            DoAnTBaoTableAdapters.ChiTietHoaDonTableAdapter a = new DoAnTBaoTableAdapters.ChiTietHoaDonTableAdapter();
            b.Reset();
            a.ChiTietHoaDon_byid(b, Int32.Parse(txtMaHD.Text));
            Load_CTHD();
            dgChiTietHD.DataSource = b;
        }
    }
    }

