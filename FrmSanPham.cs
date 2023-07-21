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
    public partial class FrmSanPham : Form
    {
        int opt = -1;
        public FrmSanPham()
        {
            InitializeComponent();
        }
        private void SetEnable()
        {
            txtSoLuong.Enabled = true;
            txtTenSP.Enabled = true;
            txtGhichu.Enabled = true;
            txtDongianhap.Enabled = true;
            txtDongiaban.Enabled = true;
            cbLoaiSP.Enabled = true;
            btnChonAnh.Enabled = true;
        }
        private void SetDisable()
        {
            txtSoLuong.Enabled = false;
            txtTenSP.Enabled = false;
            txtGhichu.Enabled = false;
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;
            cbLoaiSP.Enabled = false;
            btnChonAnh.Enabled = false;

        }
        public void Load_SP()
        {
            DoAnTBao.SanPhamDataTable b = new DoAnTBao.SanPhamDataTable();
            DoAnTBaoTableAdapters.SanPhamTableAdapter a = new DoAnTBaoTableAdapters.SanPhamTableAdapter();
            b.Reset();
            a.SanPham_getAll(b);
            dataGridView1.DataSource = b;
            if (dataGridView1.RowCount > 0)
            {
                txtTenSP.Text = dataGridView1[1, 0].Value.ToString();
                txtDongianhap.Text = dataGridView1[2, 0].Value.ToString();
                txtDongiaban.Text = dataGridView1[3, 0].Value.ToString();
                txtGhichu.Text = dataGridView1[4, 0].Value.ToString();
                Byte[] i = (byte[])dataGridView1[5, 0].Value;
                MemoryStream stmBLOBData = new MemoryStream(i);
                pictureBox1.Image = Image.FromStream(stmBLOBData);
                txtSoLuong.Text = dataGridView1[6, 0].Value.ToString();
                cbLoaiSP.Text = dataGridView1[7, 0].Value.ToString();
            }
            else
            {
                txtTenSP.Clear();
                txtDongianhap.Clear();
                txtDongiaban.Clear();
                txtGhichu.Clear();
                pictureBox1.Image = null;
                txtSoLuong.Clear();
                cbLoaiSP.SelectedIndex = 0;
            }
        }
        private void Load_LoaiSP()
        {
            DoAnTBao.LoaiSPDataTable b = new DoAnTBao.LoaiSPDataTable();
            DoAnTBaoTableAdapters.LoaiSPTableAdapter a = new DoAnTBaoTableAdapters.LoaiSPTableAdapter();
            b.Reset();
            a.Fill(b);
            cbLoaiSP.DisplayMember = "TenLoaiSP";
            cbLoaiSP.ValueMember = "MaLoaiSP";
            cbLoaiSP.DataSource = b;
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            Load_LoaiSP();
            Load_SP();
            SetDisable();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.FileName = "";
            OD.Filter = "Supported Images|*.jpg;*.jpeg;*.png";
            if (OD.ShowDialog() == DialogResult.OK)
                pictureBox1.Load(OD.FileName);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (PhanQuyen.checkper("EDIT") == true)
                {
                SetEnable();
                btnThem.Enabled = false;
                opt = 1;
                cbLoaiSP.SelectedIndex = 0;
                txtTenSP.Clear();
                txtDongianhap.Clear();
                txtSoLuong.Clear();
                txtDongiaban.Clear();
                txtGhichu.Clear();
                }
            else
            { MessageBox.Show("Bạn không có quyền !");}
           
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
                            DoAnTBao.SanPhamDataTable b = new DoAnTBao.SanPhamDataTable();
                            DoAnTBaoTableAdapters.SanPhamTableAdapter a = new DoAnTBaoTableAdapters.SanPhamTableAdapter();
                            b.Reset();
                            a.SanPham_Delete(b, id);
                            Load_SP();

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
                txtDongiaban.Clear();
                txtDongianhap.Clear();
                txtGhichu.Clear();
                txtSoLuong.Clear();
                txtTenSP.Clear();
                cbLoaiSP.SelectedIndex = 0;
                SetDisable();
                
            }
        }
        private bool Kiemtradulieunnhap()
        {
            if(txtTenSP.Text == "" && txtSoLuong.Text =="" &&txtGhichu.Text ==""&&txtDongianhap.Text ==""&&txtDongiaban.Text =="")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu đầy đủ !");
                return false;
            }
            return true;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {

            if (PhanQuyen.checkper("ADD") == true)
            {
                if (Kiemtradulieunnhap() && opt == 1)
                {
                    DoAnTBao.SanPhamDataTable b = new DoAnTBao.SanPhamDataTable();
                    DoAnTBaoTableAdapters.SanPhamTableAdapter a = new DoAnTBaoTableAdapters.SanPhamTableAdapter();
                    b.Reset();
                    var Anh = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                    a.SanPham_Insert(b, txtTenSP.Text, cbLoaiSP.SelectedValue.ToString(), Convert.ToDouble(txtDongianhap.Text),
                        Convert.ToDouble(txtDongiaban.Text), txtGhichu.Text, (byte[])Anh, Convert.ToInt32(txtSoLuong.Text.ToString()));
                    Load_SP();
                    txtDongiaban.Clear();
                    txtDongianhap.Clear();
                    txtGhichu.Clear();
                    txtSoLuong.Clear();
                    txtTenSP.Clear();
                    cbLoaiSP.SelectedIndex = 0;
                    SetDisable();
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
                        DoAnTBao.SanPhamDataTable b = new DoAnTBao.SanPhamDataTable();
                        DoAnTBaoTableAdapters.SanPhamTableAdapter a = new DoAnTBaoTableAdapters.SanPhamTableAdapter();
                        b.Reset();
                        var Anh = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                        int id = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                        a.SanPham_Update(b, id, txtTenSP.Text, cbLoaiSP.SelectedValue.ToString(), Convert.ToDouble(txtDongianhap.Text),
                            Convert.ToDouble(txtDongiaban.Text), txtGhichu.Text, (byte[])Anh, Convert.ToInt32(txtSoLuong.Text.ToString()));
                        Load_SP();
                        txtDongiaban.Clear();
                        txtDongianhap.Clear();
                        txtGhichu.Clear();
                        txtSoLuong.Clear();
                        txtTenSP.Clear();
                        cbLoaiSP.SelectedIndex = 0;
                    }


                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                //	Gán dữ liệu dòng đầu tiên trong dataGridView lên phần thông tin.
                txtTenSP.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                txtDongianhap.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                txtDongiaban.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();

                //Hiển ảnh 
                txtGhichu.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                Byte[] i = (byte[])dataGridView1[5, dataGridView1.CurrentRow.Index].Value;
                MemoryStream stmBLOBData = new MemoryStream(i);
                pictureBox1.Image = Image.FromStream(stmBLOBData);

                txtSoLuong.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
                cbLoaiSP.Text = dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString();
            opt = 2;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoAnTBao.SanPhamDataTable b = new DoAnTBao.SanPhamDataTable();
            DoAnTBaoTableAdapters.SanPhamTableAdapter a = new DoAnTBaoTableAdapters.SanPhamTableAdapter();
            b.Reset();
            a.SanPham_byID(b,Int32.Parse(txtMaSP.Text));
            dataGridView1.DataSource = b;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmPrint_SanPham a = new FrmPrint_SanPham();
            a.ShowDialog();
        }
    }
    }

