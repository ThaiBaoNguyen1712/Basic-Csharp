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
    public partial class FrmPrint_KhachHang : Form
    {
        public FrmPrint_KhachHang()
        {
            InitializeComponent();
            DoAnTBao.Print_KhachHangDataTable b = new DoAnTBao.Print_KhachHangDataTable();
            DoAnTBaoTableAdapters.Print_KhachHangTableAdapter a = new DoAnTBaoTableAdapters.Print_KhachHangTableAdapter();
            b.Reset();
            a.Fill(b);

            RptPrint_KhachHang rp = new RptPrint_KhachHang();
            rp.SetDataSource((DataTable)b);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();
        }
    }
}
