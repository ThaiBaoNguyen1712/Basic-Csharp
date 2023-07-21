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
    public partial class FrmPrint_NhanVien : Form
    {
        public FrmPrint_NhanVien()
        {
            InitializeComponent();
            DoAnTBao.Print_NhanVienDataTable b = new DoAnTBao.Print_NhanVienDataTable();
            DoAnTBaoTableAdapters.Print_NhanVienTableAdapter a = new DoAnTBaoTableAdapters.Print_NhanVienTableAdapter();
            b.Reset();
            a.Fill(b);

            RptPrint_NhanVien rp = new RptPrint_NhanVien();
            rp.SetDataSource((DataTable)b);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();
        }
    }
}
