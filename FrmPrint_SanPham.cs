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
    public partial class FrmPrint_SanPham : Form
    {
        public FrmPrint_SanPham()
        {
            InitializeComponent();
            DoAnTBao.Print_SanPhamDataTable b = new DoAnTBao.Print_SanPhamDataTable();
            DoAnTBaoTableAdapters.Print_SanPhamTableAdapter a = new DoAnTBaoTableAdapters.Print_SanPhamTableAdapter();
            b.Reset();
            a.Fill(b);

            RptPrint_SanPham rp = new RptPrint_SanPham();
            rp.SetDataSource((DataTable)b);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();
        }
    }
}
